using ClientApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static data_access_library.PasswordManagerDbContext;

namespace ClientApp.AccountStruct
{
    public class AccountViewModel : BaseViewModel
    {
        private string _name;
        private string _savedLogin;
        private string _savedPassword;



        public string Name { get => _name; set => RaisePropertyChanged(ref _name, value); }
        public string  SavedLogin {get => _savedLogin; set => RaisePropertyChanged(ref _savedLogin, value);}
        public string  SavedPassword{ get => _savedPassword; set => RaisePropertyChanged(ref _savedPassword, value); }
     

    }
}
