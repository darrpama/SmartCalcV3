using System.Collections.ObjectModel;
using CalculatorModel.Models;
using ReactiveUI;
using Microsoft.Data.Sqlite;
using System.IO;


namespace SmartCalcDesktopGui.Services;

public class HistoryService : ReactiveObject
{

   private const string DatabaseFileName = "history.db";
   private const string TableName = "History";
   public HistoryService()
   {
      InitializeDatabase();
      LoadHistoryFromDatabase();
   }
   
   private ObservableCollection<CalculatorHistoryItem> _history;

   public ObservableCollection<CalculatorHistoryItem> History
   {
      get => _history;
      set => this.RaiseAndSetIfChanged(ref _history, value);
   }

   public void AddToHistory(string expression, string result)
   {
      var historyItem = new CalculatorHistoryItem(expression, result);
      History.Add(historyItem);
      SaveToDatabase(historyItem);
   }
   
   public void ClearHistory()
   {
      History.Clear();
      ClearDatabase();
   }

   private void InitializeDatabase()
   {
      if (!File.Exists(DatabaseFileName))
      {
         using (var connection = new SqliteConnection($"Data Source={DatabaseFileName};"))
         {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $@"
                CREATE TABLE IF NOT EXISTS `{TableName}` (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Expression TEXT NOT NULL,
                    Result TEXT NOT NULL,
                    Date TEXT NOT NULL
                )";
            command.ExecuteNonQuery();
         }
      }
   }

   private void LoadHistoryFromDatabase()
   {
      History = new ObservableCollection<CalculatorHistoryItem>();
      using (var connection = new SqliteConnection($"Data Source={DatabaseFileName};"))
      {
         connection.Open();
         var command = connection.CreateCommand();
         command.CommandText = $"SELECT Expression, Result, Date FROM {TableName}";

         using (var reader = command.ExecuteReader())
         {
            while (reader.Read())
            {
               var expression = reader.GetString(0);
               var result = reader.GetString(1);
               var date = reader.GetDateTime(2);
               History.Add(new CalculatorHistoryItem(expression, result) { Date = date });
            }
         }
      }
   }

   private void SaveToDatabase(CalculatorHistoryItem historyItem)
   {
      using (var connection = new SqliteConnection($"Data Source={DatabaseFileName};"))
      {
         connection.Open();
         var command = connection.CreateCommand();
         command.CommandText = $"INSERT INTO {TableName} (Expression, Result, Date) VALUES (@expression, @result, @date)";
         command.Parameters.AddWithValue("@expression", historyItem.Expression);
         command.Parameters.AddWithValue("@result", historyItem.Result);
         command.Parameters.AddWithValue("@date", historyItem.Date.ToString("o")); // Use ISO 8601 format
         command.ExecuteNonQuery();
      }
   }

   private void ClearDatabase()
   {
      using (var connection = new SqliteConnection($"Data Source={DatabaseFileName};"))
      {
         connection.Open();
         var command = connection.CreateCommand();
         command.CommandText = $"DELETE FROM {TableName}";
         command.ExecuteNonQuery();
      }
   }
}