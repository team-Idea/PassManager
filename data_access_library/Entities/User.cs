using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace data_access_library
{
    public partial class PasswordManagerDbContext
    {
        public class User
        {
            public User()
            {
                this.Logins = new ObservableCollection<Login_Item>();
                this.Infos = new ObservableCollection<Personal_Info>();
                this.Cards = new ObservableCollection<Credit_Card>();
            }
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public ObservableCollection<Login_Item> Logins { get; set; }
            public ObservableCollection<Personal_Info> Infos { get; set; }
            public ObservableCollection<Credit_Card> Cards { get; set; }
        }
    }
}
