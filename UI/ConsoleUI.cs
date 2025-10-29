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
    // Created with guidance from Perplexity, https://www.perplexity.ai/search/what-is-a-clean-nice-way-of-co-WWwuALz6SlWtRyInK_Bz4Q#2
    {

        public static void MainMenu()
        {
            while (true)
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

                        case 2:
                            LocationManagerMenu();
                            break;
                        
                        case 3:
                            HunterManagerMenu();
                            break;

                        case 0:
                            return;

                        default:
                            break;

                    }

                }
                else
                {

                }
            }
        }

        public static void MonsterManagerMenu()
        {
            MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0

            while (true)
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
                            string? dangerLevel = InputDangerLevel();

                            facade.AddMonster(name, type, dangerLevel); // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct

                            // 4. Skriv ut ett bekräftelsemeddelande
                            Console.WriteLine("✅ Monster tillagt!");

                            break;

                        case 2:
                            OutputAllMonsters();
                            break;

                        case 3:
                            Console.WriteLine("Funktion ej aktiverad.");
                            Console.WriteLine("Betala för en VG-version för åtkomst.");
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

                            // 4. Fråga efter ny dangerlevel
                            string? newDangerLevel = InputDangerLevel();

                            facade.UpdateMonster(idToUpdate, newName, newType, newDangerLevel);

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

                            facade.DeleteMonster(idToDelete);

                            Console.WriteLine("✅ Monster borttaget!");
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Felaktigt val");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Felaktigt val");

                }
            }

            static void OutputAllMonsters()
            {
                Console.WriteLine("\n--- Alla monster ---");

                // 1. Hämta alla monster
                MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0
                List<Monster> monsters = facade.GetAllMonsters();

                // 2. Skriv ut varje monster på ett snyggt sätt
                // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct 
                foreach (Monster monster in monsters)
                {

                    Console.WriteLine($"Id: {monster.Id}, Name: {monster.Name}, Type: {monster.Type}, Dangerlevel: {monster.DangerLevel}");

                }
            }

            static string? InputDangerLevel()
            {
                // 1. Fråga användaren efter riskgrad
                string[] validDangerLevels = { "Low", "Medium", "High", "Extreme" };
                string? dangerLevel = "";
                do
                {
                    Console.Write("Dangerlevel: Low, Medium, High eller Extreme: ");
                    dangerLevel = Console.ReadLine();
                    if (!validDangerLevels.Contains(dangerLevel))
                    {
                        Console.WriteLine("Felaktigt dangerlevel");
                    }
                }
                while (!validDangerLevels.Contains(dangerLevel));
                return dangerLevel;
            }
        
    }

        public static void LocationManagerMenu()
        {
            MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0

            while (true)
            {
                Console.WriteLine("=== HANTERA PLATSER ===");
                Console.WriteLine("1. Lägg till ny plats");
                Console.WriteLine("2. Visa alla platser");
                Console.WriteLine("3. Sök plats (efter namn)");
                Console.WriteLine("4. Uppdatera platser");
                Console.WriteLine("5. Ta bort plats");
                Console.WriteLine("0. Tillbaka till huvudmeny");
                Console.Write("Val: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n--- Lägg till ny plats ---");

                            // 1. Fråga användaren efter namn
                            Console.Write("Namn: ");
                            string? name = Console.ReadLine();

                            // 2. Fråga användaren efter region
                            Console.Write("Region: ");
                            string? region = Console.ReadLine();

                            facade.AddLocation(name, region); // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct

                            // 3. Skriv ut ett bekräftelsemeddelande
                            Console.WriteLine("✅ Plats tillagd!");

                            break;

                        case 2:
                            OutputAllLocations();
                            break;

                        case 3:
                            Console.WriteLine("Funktion ej aktiverad.");
                            Console.WriteLine("Betala för en VG-version för åtkomst.");
                            break;

                        case 4:
                            Console.WriteLine("\n--- Uppdatera platser ---");

                            // Först visar vi alla monster så användaren ser vilka som finns
                            OutputAllLocations();

                            // 1. Fråga vilket Id användaren vill uppdatera
                            Console.Write("\nAnge Id på platsen du vill uppdatera: ");

                            // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct
                            if (!int.TryParse(Console.ReadLine(), out int idToUpdate))
                            {
                                Console.WriteLine("Felaktigt Id!");
                                return;
                            }

                            // 2. Fråga efter nytt namn
                            Console.Write("Nytt namn: ");
                            string? newName = Console.ReadLine();

                            // 3. Fråga efter ny region
                             Console.Write("Ny region: ");
                            string? newRegion = Console.ReadLine();

                            facade.UpdateLocation(idToUpdate, newName, newRegion);

                            break;

                        case 5:
                            Console.WriteLine("\n--- Ta bort plats ---");

                            // Visa alla platser först
                            OutputAllLocations();

                            // 1. Fråga vilket Id användaren vill ta bort
                            Console.Write("\nAnge Id på platsen du vill ta bort: ");

                            if (!int.TryParse(Console.ReadLine(), out int idToDelete))
                            {
                                Console.WriteLine("Felaktigt id!");
                                return;
                            }

                            // 2. Fråga om användaren är säker (säkerhetscheck!)
                            Console.Write($"Är du säker på att du vill ta bort platsen med Id {idToDelete}? (ja/nej): ");
                            string answer = Console.ReadLine();

                            if (answer.ToLower() != "ja")
                            {
                                Console.WriteLine("Avbrutet!");
                                return;
                            }

                            facade.DeleteLocation(idToDelete);

                            Console.WriteLine("✅ Platsen borttagen!");
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Felaktigt val");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Felaktigt val");

                }
            }

            static void OutputAllLocations()
            {
                Console.WriteLine("\n--- Alla platser ---");

                // 1. Hämta alla jägare
                MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0
                List<Location> locations = facade.GetAllLocations();

                // 2. Skriv ut varje plats på ett snyggt sätt
                // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct 
                foreach (Location location in locations)
                {

                    Console.WriteLine($"Id: {location.Id}, Namn: {location.Name}, Region: {location.Region}");

                }
            }
        }

        public static void HunterManagerMenu()
        {
            MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0

            while (true)
            {
                Console.WriteLine("=== HANTERA JÄGARE ===");
                Console.WriteLine("1. Lägg till ny jägare");
                Console.WriteLine("2. Visa alla jägare");
                Console.WriteLine("3. Sök jägare (efter namn)");
                Console.WriteLine("4. Uppdatera jägare");
                Console.WriteLine("5. Ta bort jägare");
                Console.WriteLine("0. Tillbaka till huvudmeny");
                Console.Write("Val: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n--- Lägg till ny jägare ---");

                            // 1. Fråga användaren efter namn
                            Console.Write("Namn: ");
                            string? name = Console.ReadLine();

                            // 2. Fråga användaren efter erfarenhetsnivå
                            string? experienceLevel = InputExperienceLevel();

                            facade.AddHunter(name, experienceLevel); // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct

                            // 3. Skriv ut ett bekräftelsemeddelande
                            Console.WriteLine("✅ Jägare tillagd!");

                            break;

                        case 2:
                            OutputAllHunters();
                            break;

                        case 3:
                            Console.WriteLine("Funktion ej aktiverad.");
                            Console.WriteLine("Betala för en VG-version för åtkomst.");
                            break;

                        case 4:
                            Console.WriteLine("\n--- Uppdatera jägare ---");

                            // Först visar vi alla monster så användaren ser vilka som finns
                            OutputAllHunters();

                            // 1. Fråga vilket Id användaren vill uppdatera
                            Console.Write("\nAnge Id på jägaren du vill uppdatera: ");

                            // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct
                            if (!int.TryParse(Console.ReadLine(), out int idToUpdate))
                            {
                                Console.WriteLine("Felaktigt Id!");
                                return;
                            }

                            // 2. Fråga efter nytt namn
                            Console.Write("Nytt namn: ");
                            string? newName = Console.ReadLine();

                            // 3. Fråga efter ny erfarenhetsnivå
                            string? newExperienceLevel = InputExperienceLevel();

                            facade.UpdateHunter(idToUpdate, newName, newExperienceLevel);

                            break;

                        case 5:
                            Console.WriteLine("\n--- Ta bort jägare ---");

                            // Visa alla jägare först
                            OutputAllHunters();

                            // 1. Fråga vilket Id användaren vill ta bort
                            Console.Write("\nAnge Id på jägaren du vill ta bort: ");

                            if (!int.TryParse(Console.ReadLine(), out int idToDelete))
                            {
                                Console.WriteLine("Felaktigt id!");
                                return;
                            }

                            // 2. Fråga om användaren är säker (säkerhetscheck!)
                            Console.Write($"Är du säker på att du vill ta bort jägaren med Id {idToDelete}? (ja/nej): ");
                            string answer = Console.ReadLine();

                            if (answer.ToLower() != "ja")
                            {
                                Console.WriteLine("Avbrutet!");
                                return;
                            }

                            facade.DeleteHunter(idToDelete);

                            Console.WriteLine("✅ Jägaren borttagen!");
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Felaktigt val");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Felaktigt val");

                }
            }

            static void OutputAllHunters()
            {
                Console.WriteLine("\n--- Alla jägare ---");

                // 1. Hämta alla jägare
                MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0
                List<Hunter> hunters = facade.GetAllHunters();

                // 2. Skriv ut varje jägare på ett snyggt sätt
                // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct 
                foreach (Hunter hunter in hunters)
                {

                    Console.WriteLine($"Id: {hunter.Id}, Namn: {hunter.Name}, Experiencelevel: {hunter.ExperienceLevel}");

                }
            }

            static string? InputExperienceLevel()
            {
                // 1. Fråga användaren efter erfarenhetsnivå
                string[] validExperienceLevels = { "Rookie", "Expert", "Master" };
                string? experienceLevel = "";
                do
                {
                    Console.Write("Experiencelevel: Rookie, Expert, eller Master: ");
                    experienceLevel = Console.ReadLine();
                    if (!validExperienceLevels.Contains(experienceLevel))
                    {
                        Console.WriteLine("Felaktigt experiencelevel");
                    }
                }
                while (!validExperienceLevels.Contains(experienceLevel));
                return experienceLevel;
            }

        }

        public static void ObservationManagerMenu()
        {
            MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0

            while (true)
            {
                Console.WriteLine("=== HANTERA OBSERVATIONER ===");
                Console.WriteLine("1. Lägg till ny observation");
                Console.WriteLine("2. Visa alla observationer");
                Console.WriteLine("3. Sök observation (efter datum)");
                Console.WriteLine("4. Uppdatera observation");
                Console.WriteLine("5. Ta bort observation");
                Console.WriteLine("0. Tillbaka till huvudmeny");
                Console.Write("Val: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n--- Lägg till ny observation ---");

                            Console.Write("Monster-id: ");
                            if (!int.TryParse(Console.ReadLine(), out int monsterId))
                            {
                                Console.WriteLine("Felaktigt Id!");
                                break;
                            }

                            Console.Write("Plats-id: ");
                            if (!int.TryParse(Console.ReadLine(), out int locationId))
                            {
                                Console.WriteLine("Felaktigt Id!");
                                break;
                            }

                            Console.Write("Jägar-id: ");
                            if (!int.TryParse(Console.ReadLine(), out int hunterId))
                            {
                                Console.WriteLine("Felaktigt Id!");
                                break;
                            }

                            Console.Write("Händelsebeskrivning: ");
                            string? description = Console.ReadLine();

                            Console.Write("Datum (ÅÅÅÅ-MM-DD): ");
                            string? dateSeen = Console.ReadLine();

                            facade.AddObservation(monsterId, locationId, hunterId, description,dateSeen); // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct

                            // 4. Skriv ut ett bekräftelsemeddelande
                            Console.WriteLine("✅ Observation tillagd!");

                            break;

                        case 2:
                            OutputAllMonsters();
                            break;

                        case 3:
                            Console.WriteLine("Funktion ej aktiverad.");
                            Console.WriteLine("Betala för en VG-version för åtkomst.");
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

                            // 4. Fråga efter ny dangerlevel
                            string? newDangerLevel = InputDangerLevel();

                            facade.UpdateMonster(idToUpdate, newName, newType, newDangerLevel);

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

                            facade.DeleteMonster(idToDelete);

                            Console.WriteLine("✅ Monster borttaget!");
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Felaktigt val");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Felaktigt val");

                }
            }

            static void OutputAllMonsters()
            {
                Console.WriteLine("\n--- Alla monster ---");

                // 1. Hämta alla monster
                MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0
                List<Monster> monsters = facade.GetAllMonsters();

                // 2. Skriv ut varje monster på ett snyggt sätt
                // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct 
                foreach (Monster monster in monsters)
                {

                    Console.WriteLine($"Id: {monster.Id}, Name: {monster.Name}, Type: {monster.Type}, Dangerlevel: {monster.DangerLevel}");

                }
            }
        }
    }
}