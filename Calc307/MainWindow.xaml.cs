using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc307
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Data _data = new Data();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                if (b.Content.ToString() == ",")
                {
                    if (InOutput.Text.Contains(',')) return;
                    if (_data.IsNew)
                    {
                        InOutput.Text = "0";
                        _data.IsNew = false;
                    }
                }

                if (_data.IsNew) { InOutput.Text = b.Content.ToString(); _data.IsNew = false; }
                else InOutput.Text += b.Content;
            }
            
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InOutput.Text = "0";
            _data.Number = 0;
            _data.IsNew = true;
            _data.Operation = null;
        }

        private void Action_Click(object sender, RoutedEventArgs e)
        {
            double value = 0;
            if (!Double.TryParse(InOutput.Text, out value)) return;
            _data.Number = value;

            if (sender is Button b)
            {
                _data.Operation = b.Content switch
                {
                    "+" => Operation.Plus,
                    "-" => Operation.Minus,
                    "×" => Operation.Times,
                    "÷" => Operation.Div,
                    _ => null
                };
                _data.IsNew = true;
                
            }
                
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            double secondValue;
            if (!Double.TryParse(InOutput.Text, out secondValue)) return;

            double result = _data.Operation switch {
                Operation.Plus => _data.Number + secondValue,
                Operation.Minus => _data.Number - secondValue,
                Operation.Times => _data.Number * secondValue,
                Operation.Div => _data.Number / secondValue,
                _ => secondValue
            };

            InOutput.Text = result.ToString();
            if (!_data.IsNew) _data.Number = secondValue;
            _data.IsNew = true;
        }

    }
}