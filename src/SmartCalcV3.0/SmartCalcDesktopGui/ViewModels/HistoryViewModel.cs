using System;
using System.Collections.ObjectModel;
using CalculatorModel.Models;

namespace SmartCalcDesktopGui.ViewModels;

using SmartCalcDesktopGui.Services;

public class HistoryViewModel : ViewModelBase
{
    public HistoryViewModel(HistoryService historyService)
    {
        HistoryService = historyService;
    }

    public HistoryService HistoryService { get; set; }

    public ObservableCollection<CalculatorHistoryItem> History {
        get => HistoryService.History;
        set => HistoryService.History = value;
    }

    public void OnClearHistoryButtonCommand()
    {
        HistoryService.ClearHistory();
    }
}