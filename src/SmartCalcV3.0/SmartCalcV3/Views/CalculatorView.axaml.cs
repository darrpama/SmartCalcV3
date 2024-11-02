using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SmartCalcV3.Views;

public partial class CalculatorView : UserControl
{
    public CalculatorView()
    {
        InitializeComponent();
    }
    private void Calculator_Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Button clickedButton = (Button)e.Source;
        var text = clickedButton.Content.ToString();
        switch (text)
        {
            case "AC":
                ExpressionTextBox.Text = "";
                break;
            case "Del":
            {
                if (ExpressionTextBox.Text is { Length: > 0 })
                    ExpressionTextBox.Text = ExpressionTextBox.Text.Remove(ExpressionTextBox.Text.Length - 1);
                break;
            }
            default:
                ExpressionTextBox.Text += text;
                break;
        }
    }
}