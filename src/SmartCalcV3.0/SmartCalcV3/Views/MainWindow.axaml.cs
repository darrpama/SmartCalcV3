using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using LiveChartsCore.SkiaSharpView;

namespace SmartCalcV3.Views;

public partial class MainWindow : Window
{
    public MainWindow()
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

    private void NumericUpDown_OnSpinned(object? sender, SpinEventArgs e)
    {
    }
}