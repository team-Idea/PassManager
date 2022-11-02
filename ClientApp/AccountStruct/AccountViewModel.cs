using ClientApp.Entities;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.AccountStruct
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModelInfo 
    {
        private string _login;
        //encrypt decrypt
        private string _password;
        public string Login => _login;
        public string Password => _password;
      
    }
    [AddINotifyPropertyChangedInterface]
    public class CreditCardInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFavourite { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public int CartTypeId { get; set; }
        public DateTime DateExpired { get; set; }
        public string CVV { get; set; }

    }
    [AddINotifyPropertyChangedInterface]
    public class LoginItemInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFavourite { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string SavedLogin { get; set; }
        public string SavedPassword { get; set; }
    }
    [AddINotifyPropertyChangedInterface]
    public class PersonalInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFavourite { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
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
