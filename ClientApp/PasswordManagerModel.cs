using data_access_library;
using data_access_library.Repositories;
using static data_access_library.PasswordManagerDbContext;

namespace ClientApp
{
    internal class PasswordManagerModel
    {
        public PasswordManagerDbContext context;
        //IRepository<User> userRep;
        //IRepository<Login_Item> loginRep;
        //IRepository<Credit_Card> creditcardRep;
        //IRepository<Personal_Info> personalinfoRep;
        public PasswordManagerModel()
        {
            //context = new PasswordManagerDbContext();
            //userRep = new Repository<User>(context);
            //loginRep = new Repository<Login_Item>(context);
            //creditcardRep = new Repository<Credit_Card>(context);
            //personalinfoRep = new Repository<Personal_Info>(context);
        }
    }
}
