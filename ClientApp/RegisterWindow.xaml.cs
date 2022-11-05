using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using data_access_library;
using Microsoft.Data.SqlClient;
using static data_access_library.PasswordManagerDbContext;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;
        PasswordManagerDbContext Db;

        public object PasswordConfrim { get; private set; }

        public RegisterWindow()
        {
            InitializeComponent();

          
            Db= new PasswordManagerDbContext();


        }
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginWindow log=new LoginWindow();  
            log.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Db.Users.FirstOrDefault(u => u.Login == Username.Text) == null)
            {
                if (Password_d.Password == PasswordConfrim_d.Password)
                {

                    LoginItem user = new LoginItem { Login=Username.Text,Password=Password_d.Password };                   
                    // string hash = Hash(Password_d.Password);
                    // MessageBox.Show(hash);
                    MainWindow main = new MainWindow();
                    Db.Users.Add(user);
                    Db.SaveChanges();
                    main.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Erorr Try again!");
                    PasswordConfrim_d.Password = " ";
                    Password_d.Password = " ";
                }
            }
            else
            {
                Username.Text = "User is already taken";
            }
        }
        public static string Hash(string password, int iteration)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            var pb = new Rfc2898DeriveBytes(password, salt, iteration);
            var hash = pb.GetBytes(HashSize);

            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            var base64 = Convert.ToBase64String(hashBytes);

            return String.Format("$MYHASH$V1{0}${1}", iteration, base64);
        }
        public string Hash(string password)
        {
            return Hash(password, 1000);
        }



    }

}

