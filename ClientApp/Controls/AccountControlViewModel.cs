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
        private Login_Item _login;
        public Login_Item Login
        {
            get => _login;
            set => RaisePropertyChanged(ref _login, value);
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
                case 1: Clipboard.SetText(Login.Name); break;
                case 2: Clipboard.SetText(Login.SavedPassword); break;
                case 3: Clipboard.SetText(Login.SavedLogin); break;
            }
        }

        public void ShowContentsPanel()
        {
            AutoShowContentCallback?.Invoke(this);
        }
    }
}
