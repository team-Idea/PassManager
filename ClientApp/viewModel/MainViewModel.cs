using ClientApp.Controls;
using ClientApp.Entities;
using data_access_library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static data_access_library.PasswordManagerDbContext;
using data_access_library.Repositories;
using System.Xml.Linq;
using PropertyChanged;
using ClientApp.AccountStruct;

namespace ClientApp.viewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        //Private fields
        private int selectedIndex;
        private bool enableSaveLoad;
        private bool contentPanelShowing;
        private AccountControlViewModel _selectedAccount;
        PasswordManagerDbContext context;
        IRepository<User> userRep;
        IRepository<Login_Item> loginRep;
        IRepository<Credit_Card> creditcardRep;
        IRepository<Personal_Info> personalinfoRep;
        private ObservableCollection<CreditCardInfo> creditCards;
        private ObservableCollection<LoginItemInfo> loginItemInfos;
        private ObservableCollection<PersonalInfo> personalInfos;
        public ObservableCollection<AccountControlViewModel> AccountsList { get; set; }

        public IEnumerable<CreditCardInfo> CreditCardInfos => creditCards;
        public IEnumerable<LoginItemInfo> LoginItemInfos => loginItemInfos;
        public IEnumerable<PersonalInfo> PersonalInfos => personalInfos;
        public int SelectedIndex { get; set; }

        public bool EnableSaveAndLoad { get; set; }

        public bool ContentPanelShowing { get; set; }
        public User CurrentUser  { get; set; }
        public AccountControlViewModel SelectedAccount { get; set; }
        // add personal_info,credit_card, login
        public ICommand ShowAddAccountWindowCommand { get; set; }
        public ICommand ShowEditAccountWindowCommand { get; set; }
        public ICommand DeleteAccountCommand { get; set; }
        public ICommand SaveAccountCommand { get; set; }
        public ICommand LoadAccountCommand { get; set; }
        public ICommand SearchAccountCommand { get; set; }
        public ICommand MoveAccountPositionCommand { get; set; }
        public ICommand ShowHelpWindowCommand { get; set; }
        public ICommand AutoShowContentPanelCommand { get; set; }
        public ICommand CopyDetailsCommand { get; set; }


        //Some helpers
        public bool[] KeysDown = new bool[200];
        public bool AccountsArePresent => AccountsList.Count > 0;
        public bool AccountIsSelected { get => SelectedIndex > -1; }

        public NewAccountWindow NewAccountWndow { get; set; }


        public Action ShowContentPanelCallback { get; set; }
        public Action HideContentPanelCallback { get; set; }
        public Action ScrollIntoView { get; set; }

        public MainViewModel()
        {
            creditCards = new ObservableCollection<CreditCardInfo>();
            loginItemInfos = new ObservableCollection<LoginItemInfo>();
            personalInfos = new ObservableCollection<PersonalInfo>();
            NewAccountWndow = new NewAccountWindow();
          
            SetupCommandBindings();
            context = new PasswordManagerDbContext();
            userRep = new Repository<User>(context);
            loginRep = new Repository<Login_Item>(context);
            creditcardRep = new Repository<Credit_Card>(context);
            personalinfoRep = new Repository<Personal_Info>(context);

            NewAccountWndow.AddAccountCallback = this.AddAccount;
        }

        private void SetupCommandBindings()
        {
            ShowAddAccountWindowCommand = new Command(ShowAddAccountWindow);
            ShowEditAccountWindowCommand = new Command(ShowEditAccountWindow);
            DeleteAccountCommand = new Command(DeleteSelectedAccount);
            MoveAccountPositionCommand = new CommandParam<object>(MoveAccPos);
            AutoShowContentPanelCommand = new Command(AutoSetContentPanelVisibility);
            CopyDetailsCommand = new CommandParam<int>(CopyDetailsToClipboard);

           
        }

       

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
                if (KeysDown[KeyInt(Key.A)]) ShowAddAccountWindow();
                if (KeysDown[KeyInt(Key.E)]) ShowEditAccountWindow();
                if (KeysDown[KeyInt(Key.K)]) AutoSetContentPanelVisibility();
                if (KeysDown[KeyInt(Key.Delete)]) DeleteSelectedAccount();
            }
            else
            {
                //CTRL Released
                if (KeysDown[KeyInt(Key.Left)]) AutoSetContentPanelVisibility();
            }
        }


        #region Adding, Editing and Deleting Accounts
        // fix Add methods to windows (AccountControlViewModel has method addAccount, needs to bind it with all collections)
        public void AddLogAccount() { AddAccount(); }
        public void AddCardAccount() { AddAccount(); }
        public void AddInfoAccount() { AddAccount(); }
        public void AddAccount(LoginItemInfo accountContent)
        {
            //e
            AccountControlViewModel account = CreateLoginItem(accountContent);

            AddAccount(account);
            loginRep.Insert(new Login_Item {
                Id = accountContent.Id,
                Name = accountContent.Name,
                IsFavourite = accountContent.IsFavourite,
                CategoryId = accountContent.CategoryId,
                UserId = accountContent.UserId,
                SavedLogin = accountContent.SavedLogin,
                SavedPassword = accountContent.SavedPassword
            });
            NewAccountWndow.ResetAccountContext();
        }

        public void AddAccount(AccountControlViewModel account)
        {
            AccountsList.Add(account);
        }

        public AccountControlViewModel CreateLoginItem(LoginItemInfo accountDetails)
        {
            AccountControlViewModel account = new AccountControlViewModel();
            account.LogAccount = accountDetails;
            SetupAccountItemCallbacks(account);
            return account;
        }

        public void SetupAccountItemCallbacks(AccountControlViewModel item)
        {
            item.AutoShowContentCallback = ShowAccountContent;
        }

        public void DeleteSelectedAccount()
        {
            if (AccountIsSelected && AccountsArePresent) AccountsList.RemoveAt(SelectedIndex);
        }

        public void ShowAddAccountWindow()
        {
            NewAccountWndow.Show();
            NewAccountWndow.Focus();
        }

        public void ShowEditAccountWindow()
        {
            ShowAccountContent(SelectedAccount);
        }

        public void ShowAccountContent(AccountControlViewModel account)
        {
            if (account?.LogAccount != null)
            {
                if (!ContentPanelShowing) ShowContentPanel();
                SelectedAccount = account;
            }
        }


        #endregion


        public void ClearAccountsList()
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
            NewAccountWndow.Close();
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
                HideContentPanelCallback?.Invoke();
                ContentPanelShowing = false;
            }
        }

        public void CopyDetailsToClipboard(int detailsIndex)
        {
            switch (detailsIndex)
            {
                case 0: Clipboard.SetText(SelectedAccount.LogAccount.SavedLogin); break;
                case 1: Clipboard.SetText(SelectedAccount.LogAccount.SavedPassword); break; 
            }
        }
        
        
    }
}
