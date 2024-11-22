using System;
using System.IO;
using System.Net;
using System.Text.Json;
using SmartCalcDesktopGui.Models;

namespace SmartCalcDesktopGui.Services;

public class HelpService
{
    public HelpModel GetHelp()
    {
        if (App.Settings is null)
        {
            throw new Exception("App setting is not initialized");
        }

        if (!File.Exists(App.Settings.CombinedInstructionFilePath()))
        {
            throw new Exception("Help file does not exist");
        }

        var json = File.ReadAllText(App.Settings.CombinedInstructionFilePath());
        return JsonSerializer.Deserialize<HelpModel>(json);
    }
}