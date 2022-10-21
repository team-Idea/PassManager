namespace data_access_library
{
    public partial class PasswordManagerDbContext
    {
        public class Credit_Card : Element
        {
            public string CardHolder { get; set; }
            public string CardNumber { get; set; }
            public int CartTypeId { get; set; }
            public CardType CardType { get; set; }
            public DateTime DateExpired { get; set; }
            public string SVV { get; set; }
        }
    }
}
