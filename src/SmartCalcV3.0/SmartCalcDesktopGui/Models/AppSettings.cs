using System;
using System.IO;

namespace SmartCalcDesktopGui.Models;

public class AppSettings
{
    public string HelpFilePath { get; init; }
    public string CombinedInstructionFilePath() => Path.Combine(BaseDirectory, HelpFilePath);
    private string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;
    
    public AppSettings(string helpFilePath)
    {
        HelpFilePath = helpFilePath;
    }
}