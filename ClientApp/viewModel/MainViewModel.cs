using ClientApp.Controls;
using ClientApp.Entities;
using data_access_library;
using data_access_library.Repositories;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using Nest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static data_access_library.PasswordManagerDbContext;



namespace ClientApp.viewModel
{
    public class MainViewModel : BaseViewModel
    {
        PasswordManagerDbContext context;
        //Private fields
        
        private int selectedIndex;
        private bool contentPanelShowing;
        private AccountControlViewModel _selectedAccount;
        private UserData _currentUser;
        private string searchedName;
        public ObservableCollection<AccountControlViewModel> AccountsList { get; set; }
     

        public int SelectedIndex
        {
            get => selectedIndex;
            set { RaisePropertyChanged(ref selectedIndex, value); }
        }
        public string SearchedName
        {
            get => searchedName;
            set { RaisePropertyChanged(ref searchedName, value); }
        }
        public UserData CurrentUser
        {
            get => _currentUser;
            set => RaisePropertyChanged(ref _currentUser, value);
        }

        public bool ContentPanelShowing
        {
            get => contentPanelShowing;
            set => RaisePropertyChanged(ref contentPanelShowing, value);
        }

        public AccountControlViewModel SelectedAccount
        {
            get => _selectedAccount;
            set => RaisePropertyChanged(ref _selectedAccount, value);
        }

        public ICommand ShowAddAccountWindowCommand { get; set; }
        public ICommand ShowEditAccountWindowCommand { get; set; }
        public ICommand DeleteAccountCommand { get; set; }
        public ICommand SaveAccountCommand { get; set; }
        public ICommand LoadAccountCommand { get; set; }
        public ICommand SearchAccountCommand { get; set; }
        public ICommand MoveAccountPositionCommand { get; set; }
        public ICommand AutoShowContentPanelCommand { get; set; }
        public ICommand CopyDetailsCommand { get; set; }


        //Some helpers
        public bool[] KeysDown = new bool[200];
        public bool AccountsArePresent => AccountsList.Count > 0;
        public bool AccountIsSelected { get => SelectedIndex > -1; }

        public LoginAddWindow LoginAddWindow { get; set; }


        public Action ShowContentPanelCallback { get; set; }
        public Action HideContentPanelCallback { get; set; }
        public Action ScrollIntoView { get; set; }

        public MainViewModel(UserData user)
        {
            AccountsList = new ObservableCollection<AccountControlViewModel>();
            LoginAddWindow = new LoginAddWindow();
            SetupCommandBindings();
            CurrentUser = user;
            LoginAddWindow.AddLoginCallback = this.AddLogin;

            context = new PasswordManagerDbContext();
            ShowLogins();
        }
        public void ShowLogins()
        {
            foreach (var item in context.Logins.Where(l => l.UserId == CurrentUser.Id))
            {
                AccountsList.Add(new AccountControlViewModel() { Login = item });
            }
        }
        private void SetupCommandBindings()
        {
            ShowAddAccountWindowCommand = new Command(ShowAddLoginWindow);
            ShowEditAccountWindowCommand = new Command(ShowEditLoginWindow);
            DeleteAccountCommand = new Command(DeleteSelectedLogin);
            MoveAccountPositionCommand = new CommandParam<object>(MoveAccPos);
            AutoShowContentPanelCommand = new Command(AutoSetContentPanelVisibility);
            CopyDetailsCommand = new CommandParam<int>(CopyDetailsToClipboard);
            SearchAccountCommand = new Command(SearchAccount);
           
        }


        #region key
        //helper. converts the "index" of a Key to an int. e.g, A = 1, c = 3.
        private int KeyInt(Key key) => (int)key;
        public void KeyDown(Key key, bool keyIsDown)
        {
            KeysDown[KeyInt(key)] = keyIsDown;
            ProcessKeyInputs();
        }

        public void ProcessKeyInputs()
        {
            if (KeysDown[KeyInt(Key.LeftCtrl)])
            {
                //CTRL Pressed
                if (KeysDown[KeyInt(Key.A)]) ShowAddLoginWindow();
                if (KeysDown[KeyInt(Key.E)]) ShowEditLoginWindow();
                if (KeysDown[KeyInt(Key.K)]) AutoSetContentPanelVisibility();
                if (KeysDown[KeyInt(Key.Delete)]) DeleteSelectedLogin();
            }
            else
            {
                //CTRL Released
                if (KeysDown[KeyInt(Key.Left)]) AutoSetContentPanelVisibility();
            }
        }

        #endregion
        #region Adding,Search, Editing and Deleting Accounts 

       
        public void AddLogin() 
        {
            AddLogin(LoginAddWindow.LoginModel); 
        }

        public void SearchAccount()
        {
            AccountsList.Clear();
            if (SearchedName == "")
            {
                ShowLogins();
            }
            else
            {
                foreach (var item in context.Logins.Where(l => l.Name == SearchedName))
            {
                AccountsList.Add(new AccountControlViewModel() { Login = item });
            }
            }
        }



        public void AddLogin(Login_Item accountContent)
        {
            //e
            AccountControlViewModel account = CreateLogintItem(accountContent);

            AddLogin(account);
            LoginAddWindow.ResetAccountContext();

        }

        public void AddLogin(AccountControlViewModel account)
        {
            AccountsList.Add(account);
            context.Logins.Add(new Login_Item() {
                Name = account.Login.Name,
                SavedLogin = account.Login.SavedLogin,
                SavedPassword = account.Login.SavedPassword,
                IsFavourite = account.Login.IsFavourite,
                UserId = CurrentUser.Id
            });
            context.SaveChanges();
        }

        public AccountControlViewModel CreateLogintItem(Login_Item accountDetails)
        {
            AccountControlViewModel account = new AccountControlViewModel();
            account.Login = accountDetails;
            SetupLoginItemCallbacks(account);
            return account;
        }

        public void SetupLoginItemCallbacks(AccountControlViewModel item)
        {
            item.AutoShowContentCallback = ShowLoginContent;
        }

        public void DeleteSelectedLogin()
        {
            if (AccountIsSelected && AccountsArePresent)
            {
                var itemremove = context.Logins.SingleOrDefault(l => l.Id == SelectedAccount.Login.Id);
                if (itemremove != null)
                {
                    context.Logins.Remove(itemremove);
                    context.SaveChanges();

                }
                AccountsList.RemoveAt(SelectedIndex);

            }
        }

        public void ShowAddLoginWindow()
        {
            
            LoginAddWindow.Show();
            LoginAddWindow.Focus();
        }

        public void ShowEditLoginWindow()
        {
            ShowLoginContent(SelectedAccount);
        }

        public void ShowLoginContent(AccountControlViewModel account)
        {
            if (account?.Login != null)
            {
               
                if (!ContentPanelShowing) ShowContentPanel();
                SelectedAccount = account;
                  
            }
        }
        #endregion
        public void ClearLoginsList()
        {
            SelectedIndex = 0;
            AccountsList.Clear();
        }

        public void MoveAccPos(object upordown)
        {
            switch (int.Parse(upordown.ToString()))
            {
                //UP
                case 0:
                    if (SelectedIndex > 0)
                    {
                        AccountsList.Move(SelectedIndex, SelectedIndex - 1);
                    }
                    break;
                //Down
                case 1:
                    if (SelectedIndex + 1 < AccountsList.Count())
                    {
                        AccountsList.Move(SelectedIndex, SelectedIndex + 1);
                    }
                    break;
            }
            ScrollIntoView();
        }

        public void CloseAllWindows()
        {
            LoginAddWindow.Close();
        }

        public void AutoSetContentPanelVisibility()
        {
            if (ContentPanelShowing)
                HideContentPanel();
            else
                ShowContentPanel();
        }

        public void ShowContentPanel()
        {
            if (!ContentPanelShowing)
            {
                ShowContentPanelCallback?.Invoke();
                ContentPanelShowing = true;
            }
        }

        public void HideContentPanel()
        {
            if (ContentPanelShowing)
            {
                var item = context.Logins.SingleOrDefault(l => l.Id == SelectedAccount.Login.Id);
                if (item != null)
                {
                    item.Id = SelectedAccount.Login.Id;
                    item.Name = SelectedAccount.Login.Name;
                    item.SavedLogin = SelectedAccount.Login.SavedLogin;
                    item.SavedPassword = SelectedAccount.Login.SavedPassword;
                    item.IsFavourite = SelectedAccount.Login.IsFavourite;
                    context.SaveChanges();
                }
                HideContentPanelCallback?.Invoke();
                ContentPanelShowing = false;
            }
        }

        public void CopyDetailsToClipboard(int detailsIndex)
        {
            switch (detailsIndex)
            {
                case 0: Clipboard.SetText(SelectedAccount.Login.Name); break;
                case 1: Clipboard.SetText(SelectedAccount.Login.SavedLogin); break;
                case 2: Clipboard.SetText(SelectedAccount.Login.SavedPassword); break; 
            }
        }
       
    }
}
