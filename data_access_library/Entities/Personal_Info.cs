namespace data_access_library
{
    public partial class PasswordManagerDbContext
    {
        public class Personal_Info : Element
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FathersName { get; set; }
            public string UserName { get; set; }
            public string Company { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Country { get; set; }
        }
    }
}