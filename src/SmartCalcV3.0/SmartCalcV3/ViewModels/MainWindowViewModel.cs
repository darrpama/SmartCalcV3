using System.Text;
using SmartCalcV3.Models;

namespace SmartCalcV3.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => CalcCore.CalculateExpression(new StringBuilder("1+1"));
}