using ReactiveUI;

namespace SmartCalcDesktopGui.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _calculatorContentViewModel;
    
    public MainWindowViewModel()
    {
        Calculator = new CalculatorViewModel();
        _calculatorContentViewModel = Calculator;
    }
    public ViewModelBase CalculatorContentViewModel
    {
        get => _calculatorContentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _calculatorContentViewModel, value);
    }
    
    public CalculatorViewModel Calculator { get; }

}