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

namespace WPFCalculator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private double firstNumber = 0;
    private double secondNumber = 0;
    private string? symboloperator = null;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void NumberButton_OnClick(object sender, RoutedEventArgs e)
    {
        Button? button = sender as Button;
        string? digit = button?.Content.ToString();
        //Display.Content = Display.Content == "0" ? digit : Display.Content + digit;
        
        if (Display.Content?.ToString() == "0")
        {
            Display.Content = digit;
        }
        else
        {
            Display.Content += digit;
        }

    }

    private void OperatorButton_OnClick(object sender, RoutedEventArgs e)
    {
        Button? button = sender as Button;
        string? op = button?.Content.ToString();

        if (op == "=")
        {
            secondNumber = double.Parse(Display.Content.ToString());
            var result = Calcualte();
            Display.Content = result.ToString();
            symboloperator = null;
        }
        else
        {
            firstNumber = double.Parse(Display.Content.ToString());
            symboloperator = op;
            Display.Content = "0";
        }
    }

    private void DotButton_OnClick(object sender, RoutedEventArgs e)
    {
        
    }

    private void ClearButton_OnClick(object sender, RoutedEventArgs e)
    {
        Display.Content = "0";
    }

    private double Calcualte()
    {
        switch (symboloperator)
        {
            case "-":
                return firstNumber - secondNumber;
            case "+":
                return firstNumber + secondNumber;
            case "*":   
                return firstNumber * secondNumber;
            case ":":
                return firstNumber / secondNumber;
        }
        return 0;
    }
}