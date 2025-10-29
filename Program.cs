using assignment_sql_81clafra.UI;
using assignment_sql_81clafra.Data;
using assignment_sql_81clafra.Services;

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
        catch (Exception ex)
        {
            Console.WriteLine($"Fel uppstod: {ex.Message}");
        }
    }
}