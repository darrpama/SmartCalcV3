using System;
using System.IO;
using System.Text.Json;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SmartCalcDesktopGui.Models;
using SmartCalcDesktopGui.ViewModels;
using SmartCalcDesktopGui.Views;

namespace SmartCalcDesktopGui;

public partial class App : Application
{
    public static AppSettings Settings { get; private set; }
    public override void Initialize()
    {
        var directory = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = Path.Combine(directory, "appsettings.json");

        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            Settings = JsonSerializer.Deserialize<AppSettings>(json);
        }
        else
        {
            Console.WriteLine("Settings file not found");
        }
        
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}