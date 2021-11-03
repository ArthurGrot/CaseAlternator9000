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

namespace CaseAlternator9000
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Input.TextChanged += Input_TextChanged;
            Input.GotFocus += Input_GotFocus;
            ClipboardButton.Click += Clipboard_Click;
        }

        private void Clipboard_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Output.Text);
        }

        private void Input_GotFocus(object sender, RoutedEventArgs e)
        {
            Input.Text = string.Empty;
            Input.GotFocus -= Input_GotFocus;
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int index = 0;

            foreach (char inputChar in Input.Text)
            {
                if (index % 2 == 0)
                {
                    stringBuilder.Append(char.ToUpper(inputChar));
                }
                else
                {
                    stringBuilder.Append(char.ToLower(inputChar));
                }

                if (char.IsLetter(inputChar))
                {
                    index++;
                }

            }

            Output.Text = stringBuilder.ToString();
        }
    }
}
