using ClientApp.AccountStruct;
using ClientApp.Entities;
using PropertyChanged;
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
    [AddINotifyPropertyChangedInterface]
    public class AccountControlViewModel 
    {

        public LoginItemInfo LogAccount { get; set; }
        public CreditCardInfo CreditCard { get; set; }
        public PersonalInfo Personal { get; set; }

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
                case 1: Clipboard.SetText(LogAccount.SavedLogin); break;
                case 2: Clipboard.SetText(LogAccount.SavedPassword); break;
            }
        }

        public void ShowContentsPanel()
        {
            AutoShowContentCallback?.Invoke(this);
        }
    }
}
