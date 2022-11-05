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
using static data_access_library.PasswordManagerDbContext;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for NewAccountWindow.xaml
    /// </summary>
    public partial class NewAccountWindow : Window
    {
        public User AccountModel = new User();
        public Action AddAccountCallback { get; set; }
        public NewAccountWindow()
        {
            InitializeComponent();
            DataContext = AccountModel;
        }

        public void ResetAccountContext()
        {
            AccountModel = new User();
            this.DataContext = AccountModel;
        }

        private void AddAccountCallbackFunc() { AddAccountCallback?.Invoke(); }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape: this.Hide(); break;
                case Key.Enter: AddAccountCallbackFunc(); this.Hide(); break;
            }
        }

        private void PasteTextToBox(object sender, RoutedEventArgs e)
        {
            switch (int.Parse(((Button)e.Source).Uid))
            {
                case 1: a.Text = Clipboard.GetText(); break;
                case 2: b.Text = Clipboard.GetText(); break;
            }
        }

        private void ClearTextClick(object sender, RoutedEventArgs e)
        {
            switch (int.Parse(((Button)e.Source).Uid))
            {
                case 1: a.Text = ""; break;
                case 2: b.Text = ""; break;
            }
        }

        private void AddAccountClick(object sender, RoutedEventArgs e)
        {
            if (a.Text == "" || b.Text == "") { MessageBox.Show("lines are empty"); }
            else if (a.Text == a.Text || b.Text == b.Text) { AddAccountCallbackFunc(); this.Hide(); }

        }
    }
}