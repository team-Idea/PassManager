using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace data_access_library
{
    public partial class PasswordManagerDbContext
    {
        public class CardType
        {
            public CardType()
            {
                this.Cards = new ObservableCollection<Credit_Card>();
            }
            public int Id { get; set; }
            public string Name { get; set; }
            public ObservableCollection<Credit_Card> Cards { get; set; }
        }
    }
}
