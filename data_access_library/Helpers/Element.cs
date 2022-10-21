namespace data_access_library
{
    public partial class PasswordManagerDbContext
    {
        public class Element
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsFavourite { get; set; }
            public int CategoryId { get; set; }
            public Category Category { get; set; }
            public int UserId { get; set; }
            public User User { get; set; }
        }
    }
}
