namespace CalculatorModel.Models;

public class CalculatorHistoryItem
{
    public CalculatorHistoryItem(string expression, string result)
    {
        Expression = expression;
        Result = result;
    }
    public string Expression { get; set; }
    public string Result { get; set; }
}