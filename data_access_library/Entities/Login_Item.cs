namespace data_access_library
{
    public partial class PasswordManagerDbContext
    {
        public class Login_Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsFavourite { get; set; }
            public int UserId { get; set; }
            public UserData User { get; set; }
            public string SavedLogin { get; set; }
            public string SavedPassword { get; set; }
        }
    }
}
