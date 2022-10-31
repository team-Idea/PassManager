using ClientApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.AccountStruct
{
    public class AccountViewModel : BaseViewModel
    {
        private string _login;
        private string _password;
        
      

        public string Login { get => _login; set => RaisePropertyChanged(ref _login, value); }
        public string Password { get => _password; set => RaisePropertyChanged(ref _password, value); }
      
    }
}
