namespace data_access_library
{
    public partial class PasswordManagerDbContext
    {
        public class Login_Item : Element
        {
            public string SavedLogin { get; set; }
            public string SavedPassword { get; set; }
        }
    }
}
