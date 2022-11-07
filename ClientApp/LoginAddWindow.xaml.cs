using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ClientApp.viewModel;
using data_access_library;
using static data_access_library.PasswordManagerDbContext;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for LoginAddWindow.xaml
    /// </summary>
    public partial class LoginAddWindow : Window
    {
        public Login_Item LoginModel = new Login_Item();

        public Action AddLoginCallback { get; set;}

        public MainViewModel ViewModel { get; set; }
        public LoginAddWindow()
        {
            InitializeComponent();

            DataContext = LoginModel;
        }
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();

            }
        }


        public void ResetAccountContext()
        {
            LoginModel = new Login_Item();
            this.DataContext = LoginModel;
        }

        private void AddLoginCallbackFunc() { AddLoginCallback?.Invoke(); }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape: this.Close(); break;
                case Key.Enter: AddLoginCallbackFunc(); this.Close(); break;
            }
        }

        private void PasteTextToBox(object sender, RoutedEventArgs e)
        {
            switch (int.Parse(((Button)e.Source).Uid))
            {
                case 1: a.Text = Clipboard.GetText(); break;
                case 2: b.Text = Clipboard.GetText(); break;
                case 3: c.Text = Clipboard.GetText(); break;
            }
        }

        private void ClearTextClick(object sender, RoutedEventArgs e)
        {
            switch (int.Parse(((Button)e.Source).Uid))
            {
                case 1: a.Text = ""; break;
                case 2: b.Text = ""; break;
                case 3: c.Text = ""; break;
            }
        }

        private void AddAccountClick(object sender, RoutedEventArgs e)
        {
            if (a.Text == "" || b.Text == "" || c.Text == "") { MessageBox.Show("lines are empty"); }
            else if (a.Text == a.Text || b.Text == b.Text||c.Text==c.Text) { AddLoginCallbackFunc(); this.Hide(); }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
