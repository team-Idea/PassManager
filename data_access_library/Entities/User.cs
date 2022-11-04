using System.Collections.Generic;

namespace data_access_library
{
    public partial class PasswordManagerDbContext
    {
        public class User
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public ICollection<Login_Item> Logins { get; set; }
        }
    }
}
