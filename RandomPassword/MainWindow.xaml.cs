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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandomPassword
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public object Round { get; private set; }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (LengthValue!=null)
            {
                LengthValue.Content = Math.Round(e.NewValue);
            }
        }

        private  string CreateRandomPassword(double length = 15)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            if (Numbers.IsChecked == true)
            {
                validChars += validChars + "0123456789";
            }
            if (Symbols.IsChecked == true)
            {
                validChars += validChars + "!@#$%^&*?_-";
            }
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            StringBuilder chars = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                chars.Append(validChars[random.Next(0, validChars.Length)]);
            }
            return chars.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Password.Text=CreateRandomPassword(Math.Abs(Slider1.Value));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
