using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CalculatorModel.Models;

namespace SmartCalcDesktopGui.Services;

public class HistoryService
{
   public ObservableCollection<CalculatorHistoryItem> History { get; set; } = [];

   public void AddToHistory(string expression, string result)
   {
      History.Add(new CalculatorHistoryItem(expression, result));
   }
   
   public void ClearHistory()
   {
      History.Clear();
   }

}