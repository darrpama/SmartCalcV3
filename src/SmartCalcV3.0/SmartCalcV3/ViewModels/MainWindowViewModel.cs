using System.Text;
using ReactiveUI;
using SmartCalcV3.Models;

namespace SmartCalcV3.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static CalcCore _calc = new CalcCore();
    
    private string _expression = "";
    private string _answer = "";

    public string Expression
    {
        get => _expression;
        set => this.RaiseAndSetIfChanged(ref _expression, value);
    }
    
    public string Answer
    {
        get => _answer;
        set => this.RaiseAndSetIfChanged(ref _answer, value);
    }

    public void OnEqualButtonClickCommand()
    {
        Answer = _calc.Calculate(Expression);
    }
}