using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment_sql_81clafra.Data;
using assignment_sql_81clafra.Models;
using assignment_sql_81clafra.Services;

namespace assignment_sql_81clafra.UI
{
    public class ConsoleUI
    {

        public static void MainMenu()
        {
            Console.WriteLine("=== Huvudmeny ===");
            Console.WriteLine("1. Hantera Monster");
            Console.WriteLine("2. Hantera Platser");
            Console.WriteLine("3. Hantera Jägare");
            Console.WriteLine("4. Hantera Observationer");
            Console.WriteLine("0. Avsluta");
            Console.Write("Val: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        MonsterManagerMenu();
                        break;
                    default:
                        break;

                }

            }
            else
            {

                return;
            }
        }


        public static void MonsterManagerMenu()
        {
            Console.WriteLine("=== HANTERA MONSTER ===");
            Console.WriteLine("1. Lägg till nytt monster");
            Console.WriteLine("2. Visa alla monster");
            Console.WriteLine("3. Sök monster (efter namn)");
            Console.WriteLine("4. Uppdatera monster");
            Console.WriteLine("5. Ta bort monster");
            Console.WriteLine("0. Tillbaka till huvudmeny");
            Console.Write("Val: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n--- Lägg till nytt monster ---");

                        // 1. Fråga användaren efter namn
                        Console.Write("Namn: ");
                        string? name = Console.ReadLine();

                        // 2. Fråga användaren efter typ av monster
                        Console.Write("Typ: ");
                        string? type = Console.ReadLine();

                        // 3. Fråga användaren efter riskgrad
                        Console.Write("Dangerlevel: ");
                        string? dangerLevel = Console.ReadLine();

                        MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0
                        facade.AddMonster(name, type, dangerLevel); // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct

                        // 5. Skriv ut ett be1kräftelsemeddelande
                        Console.WriteLine("✅ Monster tillagt!");


                        break;

                    case 2:
                        OutputAllMonsters();
                        break;

                    case 3:

                        break;

                    case 4:
                        Console.WriteLine("\n--- Uppdatera monster ---");

                        // Först visar vi alla monster så användaren ser vilka som finns
                        OutputAllMonsters();

                        // 1. Fråga vilket Id användaren vill uppdatera
                        Console.Write("\nAnge Id på monstret du vill uppdatera: ");

                        // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct
                        if (!int.TryParse(Console.ReadLine(), out int idToUpdate))
                        {
                            Console.WriteLine("Felaktigt Id!");
                            return;
                        }

                        // 2. Fråga efter nytt namn
                        Console.Write("Nytt namn: ");
                        string? newName = Console.ReadLine();

                        // 3. Fråga efter ny typ
                        Console.Write("Ny typ: ");
                        string? newType = Console.ReadLine();

                        // 3. Fråga efter ny dangerlevel
                        Console.Write("Ny dangerlevel: ");
                        string? newDangerLevel = Console.ReadLine();

                        if (newDangerLevel != "Low" && newDangerLevel != "Medium" && newDangerLevel != "High" && newDangerLevel != "Extreme")
                        {
                            Console.WriteLine("Felaktig dangerlevel!");
                            return;
                        }

                        break;

                    case 5:
                        Console.WriteLine("\n--- Ta bort monster ---");

                        // Visa alla monster först
                        OutputAllMonsters();

                        // 1. Fråga vilket Id användaren vill ta bort
                        Console.Write("\nAnge Id på monstret du vill ta bort: ");

                        if (!int.TryParse(Console.ReadLine(), out int idToDelete))
                        {
                            Console.WriteLine("Felaktigt id!");
                            return;
                        }


                        // 2. Fråga om användaren är säker (säkerhetscheck!)
                        Console.Write($"Är du säker på att du vill ta bort monstret med Id {idToDelete}? (ja/nej): ");
                        string answer = Console.ReadLine();

                        if (answer.ToLower() != "ja")
                        {
                            Console.WriteLine("Avbrutet!");
                            return;
                        }

                        Console.WriteLine("✅ Monster borttaget!");
                        break;

                    case 0:
                        break;

                    default:
                        break;

                }
            }


            {

                return;
            }

            static void OutputAllMonsters()
            {
                Console.WriteLine("\n--- Alla monster ---");

                // 1. Hämta alla monster
                MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0
                List<Monster> monsters = facade.GetAllMonsters();

                // 6. Skriv ut varje monster på ett snyggt sätt
                // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct 
                foreach (Monster monster in monsters)
                {

                    Console.WriteLine($"Id: {monster.Id}, Name: {monster.Name}, Type: {monster.Type}, Dangerlevel: {monster.DangerLevel}");
                }
            }
        }
    }
}