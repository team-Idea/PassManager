namespace data_access_library
{
    public partial class PasswordManagerDbContext
    {
        public class CardType
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<Credit_Card> Cards { get; set; }
        }
    }
}
