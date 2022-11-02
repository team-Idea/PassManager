using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }
        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (context.Users.FirstOrDefault(u => u.Login == Username.Text) == null)
            {
                if (Password.Password == PasswordConfrim.Password)
                {
                    string hash = Hash(Password.Password);
                    MessageBox.Show(hash);
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Erorr Try again!");
                    PasswordConfrim.Password = " ";
                    Password.Password = " ";
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
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSoze]);

            var pb = new Rfc2898DeriveBytes(password, salt, iteration);
            var hash = pb.GetBytes(HashSize);

            var hashBytes = new byte[SaltSoze + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSoze);
            Array.Copy(hash, 0, hashBytes, SaltSoze, HashSize);

            var base64 = Convert.ToBase64String(hashBytes);

            return String.Format("$MYHASH$V1{0}${1}", iteration, base64);
        }
        public string Hash(string password)
        {
            return Hash(password, 1000);
        }
        */


    }

}
