using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static ClientApp.CheckPasswordForDifficultyWindow;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for CheckPasswordForDifficultyWindow.xaml
    /// </summary>
    public partial class CheckPasswordForDifficultyWindow : Window
    {
        public enum PasswordStrenght
        {
            /// <summary>
            /// Very good password strenght.
            /// </summary>
            VeryGood,

            /// <summary>
            /// Good password strenght.
            /// </summary>
            Good,

            /// <summary>
            /// Medium password strenght.
            /// </summary>
            Medium,

            /// <summary>
            /// Low password strenght.
            /// </summary>
            Low,

            /// <summary>
            /// Unknown password strenght.
            /// </summary>
            Unknown
        }

        public CheckPasswordForDifficultyWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();

            }
        }



        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TextBox pBox = sender as TextBox;

            int numberOfDigits = 0, numberOfLetters = 0, numberOfSymbols = 0;

            foreach (char c in pBox.Text)
            {
                if (char.IsDigit(c))
                {
                    numberOfDigits++;
                }
                else if (char.IsLetter(c))
                {
                    numberOfLetters++;
                }
                else if (char.IsSymbol(c))
                {
                    numberOfSymbols++;
                }
            }

            if (numberOfLetters.Equals(0) && numberOfSymbols.Equals(0) && pBox.Text.Length > 0 && pBox.Text.Length < 6 ||
                numberOfDigits.Equals(0) && numberOfSymbols.Equals(0) && pBox.Text.Length > 0 && pBox.Text.Length < 6 || 
                numberOfDigits.Equals(0) && numberOfLetters.Equals(0) && pBox.Text.Length > 0 && pBox.Text.Length < 6)
            {
                indicator.Text = "weak";
            }
            else if (numberOfLetters.Equals(0) && pBox.Text.Length >= 6 && pBox.Text.Length < 12 ||
                numberOfDigits.Equals(0) && pBox.Text.Length >= 6 && pBox.Text.Length < 12 ||
                numberOfSymbols.Equals(0) && pBox.Text.Length >= 6 && pBox.Text.Length < 12)
            {
                indicator.Text = "strong";
            }
            else if(pBox.Text.Length == 0)
            {
                indicator.Text = " ";
            }
            else
            {
                indicator.Text = "very strong";
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }




    }


}
