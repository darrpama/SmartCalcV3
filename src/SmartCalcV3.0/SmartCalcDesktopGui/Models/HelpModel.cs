using System.Collections.Generic;

namespace SmartCalcDesktopGui.Models;

public class HelpModel
{
    public List<string>? OperationsText { get; set; }
    public List<string>? FunctionsText { get; set; }
    public List<string>? OperationsExamples { get; set; }
    public List<string>? FunctionsExamples { get; set; }
}