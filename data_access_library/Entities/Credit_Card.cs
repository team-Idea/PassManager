using System;

namespace data_access_library
{
    public partial class PasswordManagerDbContext
    {
        public class Credit_Card : Element
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsFavourite { get; set; }
            public int CategoryId { get; set; }
            public Category Category { get; set; }
            public int UserId { get; set; }
            public User User { get; set; }
            public string CardHolder { get; set; }
            public string CardNumber { get; set; }
            public int CartTypeId { get; set; }
            public CardType CardType { get; set; }
            public DateTime DateExpired { get; set; }
            public string CVV { get; set; }
        }
    }
}
