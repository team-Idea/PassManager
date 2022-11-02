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
using static data_access_library.PasswordManagerDbContext;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private const int SaltSize = 16;
        private const int HashSize = 20; 

        PasswordManagerDbContext context;
        public LoginWindow()
        {
            InitializeComponent();

            context = new PasswordManagerDbContext();
        }
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow reg=new RegisterWindow();
            reg.Show();
            this.Close();   
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (context.Users.FirstOrDefault(u => u.Login == Username.Text) != null)
            {
                User user = context.Users.Where(u => u.Login == Username.Text).FirstOrDefault();
                if (Verify(Password.Password, user.Password))
                {
                    MainWindow min = new MainWindow();
                    min.Show();
                    this.Close();
                } 
            else
            {
                MessageBox.Show("Incorrect password!");
            }

            }
            else
            {
                MessageBox.Show("User mot found");
            }
        }
        public static bool IsHashSupported(string  hashString)
        {
            return hashString.Contains("$MYHAHS$V1$");
        }

        public static bool Verify(string passwordd, string hashPass)
        {
            /*
            if(!IsHashSupported(hashPass))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }
            
            var split = hashPass.Replace("$MYHAHS$V1$", "").Split('$');
            var iteration = int.Parse(split[0]);
            var base64 = split[1];

            var hashBytes=Convert.FromBase64String(base64);
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes,0,salt,0,SaltSize);

            var pb=new Rfc2898DeriveBytes(passwordd,salt,iteration);
            byte[] hash = pb.GetBytes(HashSize);

            for (var i=0;i<HashSize;i++)
            {
                if(hashBytes[i+HashSize]!= hash[1])
                {
                    return false;
                }
            }
            */
            return true;
            
        }

    }
}
