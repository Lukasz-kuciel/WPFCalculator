using System.Windows;
using System.Windows.Controls;

namespace WPFCalculator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private double firstNumber = 0;
    private double secondNumber = 0;
    private string? symboloperator = null;
    private bool isNewNumber = false;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void NumberButton_OnClick(object sender, RoutedEventArgs e)
    {
        Button? button = sender as Button;
        string? digit = button?.Content.ToString();

        if (isNewNumber || Display.Content?.ToString() == "0")
        {
            Display.Content = digit;
            isNewNumber = false;
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

        if (!double.TryParse(Display.Content?.ToString(), out double currentNumber))
        {
            Display.Content = "Error";
            return;
        }

        if (symboloperator != null)
        {
            secondNumber = currentNumber;
            double result = Calculate();
            Display.Content = result.ToString();
            firstNumber = result;
        }
        else
        {
            firstNumber = currentNumber;
        }

        if (op == "=")
        {
            symboloperator = null;
        }
        else
        {
            symboloperator = op;
            isNewNumber = true;
        }
    }

    private void DotButton_OnClick(object sender, RoutedEventArgs e)
    {
        
        if (!Display.Content.ToString().Contains(","))
        {
            Display.Content += ",";
        }
    }

    private void ClearButton_OnClick(object sender, RoutedEventArgs e)
    {
            Display.Content = "0";
            firstNumber = 0;
            secondNumber = 0;
            symboloperator = null;
            isNewNumber = false;
    }

    private double Calculate()
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
                return secondNumber != 0 ? firstNumber / secondNumber : double.NaN;
        }
        return 0;
    }
}