using ReactiveUI;
using SmartCalcDesktopGui.Services;

namespace SmartCalcDesktopGui.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _calculatorContentViewModel;
    private ViewModelBase _historyContentViewModel;
    private HistoryService _historyService = new HistoryService();
    
    public MainWindowViewModel()
    {
        Calculator = new CalculatorViewModel(_historyService);
        History = new HistoryViewModel(_historyService);
        _calculatorContentViewModel = Calculator;
        _historyContentViewModel = History;
    }
    public ViewModelBase CalculatorContentViewModel
    {
        get => _calculatorContentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _calculatorContentViewModel, value);
    }
    public ViewModelBase HistoryContentViewModel
    {
        get => _historyContentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _historyContentViewModel, value);
    }
    
    public CalculatorViewModel Calculator { get; }
    public HistoryViewModel History { get; }

}