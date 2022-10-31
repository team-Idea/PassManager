using ClientApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static data_access_library.PasswordManagerDbContext;

namespace ClientApp.Controls
{
    public class AccountControlViewModel : BaseViewModel
    {
        private User _account;
        public User Account
        {
            get => _account;
            set => RaisePropertyChanged(ref _account, value);
        }

        public ICommand SetClipboardCommand { get; }

        public Action<AccountControlViewModel> AutoShowContentCallback { get; set; }

        public AccountControlViewModel()
        {
            SetClipboardCommand = new CommandParam<int>(SetClipboard);
        }

        public void SetClipboard(int accountInfoUid)
        {
            switch (accountInfoUid)
            {
                case 1: Clipboard.SetText(Account.Login); break;
                case 2: Clipboard.SetText(Account.Password); break;
            }
        }

        public void ShowContentsPanel()
        {
            AutoShowContentCallback?.Invoke(this);
        }
    }
}
