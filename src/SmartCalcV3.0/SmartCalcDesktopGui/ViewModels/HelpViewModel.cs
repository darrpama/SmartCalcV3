using System;
using System.Collections.Generic;
using SmartCalcDesktopGui.Models;
using SmartCalcDesktopGui.Services;

namespace SmartCalcDesktopGui.ViewModels;

public class HelpViewModel : ViewModelBase
{
    private readonly HelpModel _helpModel;
    public HelpViewModel()
    {
        var helpService = new HelpService();
        _helpModel = helpService.GetHelp();
        if (_helpModel == null)
        {
            throw new Exception("Help is empty after initialization");
        }
    }
    public string InstructionsOperationText =>
        _helpModel?.OperationsText == null
            ? string.Empty
            : string.Join(Environment.NewLine, _helpModel.OperationsText);

    public string InstructionsFunctionsText =>
        _helpModel?.FunctionsText == null
            ? string.Empty
            : string.Join(Environment.NewLine, _helpModel.FunctionsText);

    public string InstructionsOperationExamples =>
        _helpModel?.OperationsExamples == null
            ? string.Empty
            : string.Join(Environment.NewLine, _helpModel.OperationsExamples);

    public string InstructionsFunctionsExamples =>
        _helpModel?.FunctionsExamples == null
            ? string.Empty
            : string.Join(Environment.NewLine, _helpModel.FunctionsExamples);
}