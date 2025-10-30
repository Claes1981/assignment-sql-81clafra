using assignment_sql_81clafra.UI;
using assignment_sql_81clafra.Data;
using assignment_sql_81clafra.Services;
using System.Data.SQLite;

internal class Program
{
    private static void Main(string[] args)
    {
        MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0

        try
        {
            facade.CreateDatabase();

            ConsoleUI.MainMenu();
        }

        // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct
        catch (SQLiteException ex)
        {
            if (ex.Message.Contains("no such table"))
            {
                Console.WriteLine("Kan inte hitta databasfilen. Se till att databasen finns i katalogen programmet körs i.");
            }
            else
            {
                Console.WriteLine($"Ett fel uppstod: {ex.Message}");
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Fel uppstod: {ex.Message}");
        }
    }
}