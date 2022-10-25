namespace data_access_library
{
    public partial class PasswordManagerDbContext
    {
        public class Personal_Info : Element
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsFavourite { get; set; }
            public int CategoryId { get; set; }
            public Category Category { get; set; }
            public int UserId { get; set; }
            public User User { get; set; }
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