using ClientApp.viewModel;
using data_access_library;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; }
        public MainWindow(PasswordManagerDbContext.UserData user)
        {
           
            InitializeComponent();

            ViewModel = new MainViewModel(user);
            this.DataContext = ViewModel;
         
            ViewModel.ShowContentPanelCallback = this.ShowContentPanel;
            ViewModel.HideContentPanelCallback = this.HideContentPanel;
            HideContentPanel();
           

        }

        public void ScrollIntoViewThingy()
        {
            lBox.ScrollIntoView(lBox.SelectedItem);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            ViewModel.KeyDown(e.Key, true);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            ViewModel.KeyDown(e.Key, false);

        }

        public void AnimateContentPanelWidth(double oldWidth, double newWidth)
        {
            DoubleAnimation da = new DoubleAnimation(oldWidth, newWidth, TimeSpan.FromSeconds(0.2)) {
                AccelerationRatio = 0,
                DecelerationRatio = 1,
            };
            AccountPanel.BeginAnimation(WidthProperty, da);
        }

        public void ShowContentPanel()
        {
            AnimateContentPanelWidth(0, 450);
        }

        public void HideContentPanel()
        {
            AnimateContentPanelWidth(450, 0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PasswordGenerator ps = new PasswordGenerator();
            ps.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
