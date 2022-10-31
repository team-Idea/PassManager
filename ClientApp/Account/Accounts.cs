
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static data_access_library.PasswordManagerDbContext;

namespace ClientApp.Account
{
    public static class Accounts
    {
       
        
        public static string PasswrdName = "pssWrd.txt";
       
        public static string LogingName = "Log.txt";

        public static List<User> AccountFailure
        {
            get
            {
                return new List<User>()
                {
                    new User()
                    {
                        Login = "Failed to load accounts from the",
                        Password = "main account directory."
                    }
                };
            }
        }

        public static class AccountFileCreator
        {
            public static void CreateAccountsDirectoryAndFiles()
            {
                VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog
                {
                    RootFolder = Environment.SpecialFolder.MyDocuments
                };

                if (fbd.ShowDialog() == true)
                {
                    File.Create(Path.Combine(fbd.SelectedPath, LogingName));
                   
                    File.Create(Path.Combine(fbd.SelectedPath, PasswrdName));
                  
                }
            }
        }

        
    }
}
