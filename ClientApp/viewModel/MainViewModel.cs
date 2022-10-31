using ClientApp.Controls;
using ClientApp.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static data_access_library.PasswordManagerDbContext;

namespace ClientApp.viewModel
{
    public class MainViewModel : BaseViewModel
    {
        //Private fields
        private int selectedIndex;
        private bool enableSaveLoad;
        private bool contentPanelShowing;
        private AccountControlViewModel _selectedAccount;

        public ObservableCollection<AccountControlViewModel> AccountsList { get; set; }


        public int SelectedIndex
        {
            get => selectedIndex;
            set { RaisePropertyChanged(ref selectedIndex, value); }
        }

        public bool EnableSaveAndLoad
        {
            get => enableSaveLoad;
            set => RaisePropertyChanged(ref enableSaveLoad, value);
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
            AccountsList = new ObservableCollection<AccountControlViewModel>();
            NewAccountWndow = new NewAccountWindow();
          
            SetupCommandBindings();

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

        public void AddAccount() { AddAccount(NewAccountWndow.AccountModel); }
        public void AddAccount(User accountContent)
        {
            //e
            AccountControlViewModel account = CreateAccountItem(accountContent);

            AddAccount(account);
            NewAccountWndow.ResetAccountContext();
        }

        public void AddAccount(AccountControlViewModel account)
        {
            AccountsList.Add(account);
        }

        public AccountControlViewModel CreateAccountItem(User accountDetails)
        {
            AccountControlViewModel account = new AccountControlViewModel();
            account.Account = accountDetails;
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
            if (account?.Account != null)
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
                case 0: Clipboard.SetText(SelectedAccount.Account.Login); break;
                case 1: Clipboard.SetText(SelectedAccount.Account.Password); break; 
            }
        }
    }
}
