using System;
using ReactiveUI;

namespace CalculatorModel.Models;

public class CalculatorHistoryItem : ReactiveObject
{
    public CalculatorHistoryItem(string expression, string result)
    {
        Expression = expression;
        Result = result;
        Date = DateTime.Now;
    }
    private string _expression = string.Empty;
    private string _result = string.Empty;
    private DateTime _date;
    
    public string Expression
    {
        get { return $"Expression: {_expression}"; }
        set { this.RaiseAndSetIfChanged(ref _expression, value); }
    }

    public string Result
    {
        get { return $"Result: {_result}"; }
        set { this.RaiseAndSetIfChanged(ref _result, value); }
    }
    
    public DateTime Date
    {
        get { return _date; }
        set { this.RaiseAndSetIfChanged(ref _date, value); }
    }
}