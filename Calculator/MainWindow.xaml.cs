using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _lastNumber;
        private double _result;
        private SelectedOperator _selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroButton)
            {
                selectedValue = 0;
            }
            else if (sender == oneButton)
            {
                selectedValue = 1;
            }
            else if (sender == twoButton)
            {
                selectedValue = 2;
            }
            else if (sender == threeButton)
            {
                selectedValue = 3;
            }
            else if (sender == fourButton)
            {
                selectedValue = 4;
            }
            else if (sender == fiveButton)
            {
                selectedValue = 5;
            }
            else if (sender == sixButton)
            {
                selectedValue = 6;
            }
            else if (sender == sevenButton)
            {
                selectedValue = 7;
            }
            else if (sender == eightButton)
            {
                selectedValue = 8;
            }
            else if (sender == nineButton)
            {
                selectedValue = 9;
            }

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = selectedValue;
            }
            else
            {
                resultLabel.Content += selectedValue.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out _lastNumber))
            {
                _lastNumber *= -1;
                resultLabel.Content = _lastNumber.ToString();
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out _lastNumber))
            {
                _lastNumber /= 100;
                resultLabel.Content = _lastNumber.ToString();
            }
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double newNumber))
            {
                switch (_selectedOperator)
                {
                    case SelectedOperator.Addition:
                        _result = SimpleMath.Add(_lastNumber, newNumber);
                        break;

                    case SelectedOperator.Subtraction:
                        _result = SimpleMath.Subtract(_lastNumber, newNumber);
                        break;

                    case SelectedOperator.Multiplication:
                        _result = SimpleMath.Multiply(_lastNumber, newNumber);
                        break;

                    case SelectedOperator.Division:
                        _result = SimpleMath.Divide(_lastNumber, newNumber);
                        break;
                }
                resultLabel.Content = _result.ToString();
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out _lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == multiplicationButton)
            {
                _selectedOperator = SelectedOperator.Multiplication;
            }
            else if (sender == divisionButton)
            {
                _selectedOperator = SelectedOperator.Division;
            }
            else if (sender == plusButton)
            {
                _selectedOperator = SelectedOperator.Addition;
            }
            else if (sender == minusButton)
            {
                _selectedOperator = SelectedOperator.Subtraction;
            }
        }

        public enum SelectedOperator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        public static class SimpleMath
        {
            public static double Add(double n1, double n2)
            {
                return n1 + n2;
            }

            public static double Subtract(double n1, double n2)
            {
                return n1 - n2;
            }

            public static double Multiply(double n1, double n2)
            {
                if (n2 == 0)
                {
                    MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 0;
                }

                return n1 * n2;
            }

            public static double Divide(double n1, double n2)
            {
                return n1 / n2;
            }
        }

        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains(","))
            {
                resultLabel.Content += ",";
            }
        }
    }
}