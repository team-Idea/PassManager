namespace ClientApp
{
    public partial class PasswordManagerDbContext
    {
        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string SavedLogin { get; set; }
            public string SavedPass { get; set; }
            public bool IsFavourite { get; set; }
            public int CategoryId { get; set; }
            public Category Category { get; set; }
            public int UserId { get; set; }
            public User User { get; set; }
        }
    }
}
