using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment_sql_81clafra.Data;
using assignment_sql_81clafra.Models;
using assignment_sql_81clafra.Services;
using System.Data.SQLite;

namespace assignment_sql_81clafra.UI
{
    public class ConsoleUI
    // Created with guidance from Perplexity, https://www.perplexity.ai/search/what-is-a-clean-nice-way-of-co-WWwuALz6SlWtRyInK_Bz4Q#2
    {

        public static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== HUVUDMENY ===");
                Console.WriteLine("1. Hantera monster.");
                Console.WriteLine("2. Hantera platser.");
                Console.WriteLine("3. Hantera jägare.");
                Console.WriteLine("4. Hantera observationer.");
                Console.WriteLine("0. Avsluta programmet.");
                Console.Write("val: ");

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

                        case 4:
                            ObservationManagerMenu();
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
                Console.WriteLine("\n=== HANTERA MONSTER ===");
                Console.WriteLine("1. Lägg till nytt monster.");
                Console.WriteLine("2. Visa alla monster.");
                Console.WriteLine("3. Sök monster (efter namn).");
                Console.WriteLine("4. Uppdatera monster.");
                Console.WriteLine("5. Ta bort monster.");
                Console.WriteLine("0. Återgå till huvudmeny.");
                Console.Write("val: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n--- Lägg till nytt monster. ---");

                            // 1. Fråga användaren efter namn
                            Console.Write("namn: ");
                            string? name = Console.ReadLine();

                            // 2. Fråga användaren efter typ av monster
                            Console.Write("typ: ");
                            string? type = Console.ReadLine();

                            // 3. Fråga användaren efter riskgrad
                            string? dangerLevel = InputDangerLevel();

                            facade.AddMonster(name, type, dangerLevel); // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct

                            // 4. Skriv ut ett bekräftelsemeddelande
                            Console.WriteLine("✅ Monstret har lagts till!");

                            break;

                        case 2:
                            OutputAllMonsters();
                            break;

                        case 3:
                            Console.WriteLine("Funktion är ej aktiverad.");
                            Console.WriteLine("Betala för en VG-version för åtkomst.");
                            break;

                        case 4:
                            Console.WriteLine("\n--- Uppdatera monster. ---");

                            // Först visar vi alla monster så användaren ser vilka som finns
                            OutputAllMonsters();

                            // 1. Fråga vilket Id användaren vill uppdatera
                            Console.Write("\nAnge id på monstret du vill uppdatera: ");

                            // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct
                            if (!int.TryParse(Console.ReadLine(), out int idToUpdate))
                            {
                                Console.WriteLine("Felaktigt id har angivits!");
                                return;
                            }

                            // 2. Fråga efter nytt namn
                            Console.Write("nytt namn: ");
                            string? newName = Console.ReadLine();

                            // 3. Fråga efter ny typ
                            Console.Write("ny typ: ");
                            string? newType = Console.ReadLine();

                            // 4. Fråga efter ny dangerlevel
                            string? newDangerLevel = InputDangerLevel();

                            facade.UpdateMonster(idToUpdate, newName, newType, newDangerLevel);

                            break;

                        case 5:
                            Console.WriteLine("\n--- Ta bort monster. ---");

                            // Visa alla monster först
                            OutputAllMonsters();

                            // 1. Fråga vilket Id användaren vill ta bort
                            Console.Write("\nAnge id på monstret du vill ta bort: ");

                            if (!int.TryParse(Console.ReadLine(), out int idToDelete))
                            {
                                Console.WriteLine("Felaktigt id har angivits!");
                                return;
                            }

                            // 2. Fråga om användaren är säker (säkerhetscheck!)
                            Console.Write($"Är du säker på att du vill ta bort monstret med id {idToDelete}? (ja/nej): ");
                            string answer = Console.ReadLine();

                            if (answer.ToLower() != "ja")
                            {
                                Console.WriteLine("avbrutet");
                                return;
                            }

                            try
                            {
                                facade.DeleteMonster(idToDelete);

                                Console.WriteLine("✅ Monstret är borttaget!");
                            }

                            // Written with help from Perplexity, https://www.perplexity.ai/search/when-i-run-this-code-and-try-t-M23pxGhiQb2Mqfr3ThnIWA#0
                            catch (SQLiteException ex)
                            {
                                if (ex.Message.Contains("FOREIGN KEY constraint failed"))
                                    Console.WriteLine("Kan inte radera eftersom monstret har registrerade observationer!");
                                else
                                    Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                            }

                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Felaktigt val har angivits.");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Felaktigt val har angivits.");

                }
            }

            static void OutputAllMonsters()
            {
                Console.WriteLine("\n--- alla monster ---");

                // 1. Hämta alla monster
                MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0
                List<Monster> monsters = facade.GetAllMonsters();

                // 2. Skriv ut varje monster på ett snyggt sätt
                // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct 
                foreach (Monster monster in monsters)
                {

                    Console.WriteLine($"id: {monster.Id}, namn: {monster.Name}, typ: {monster.Type}, dangerlevel: {monster.DangerLevel}");

                }
            }

            static string? InputDangerLevel()
            {
                // 1. Fråga användaren efter riskgrad
                string[] validDangerLevels = { "Low", "Medium", "High", "Extreme" };
                string? dangerLevel = "";
                do
                {
                    Console.Write("dangerlevel: Low, Medium, High eller Extreme: ");
                    dangerLevel = Console.ReadLine();
                    if (!validDangerLevels.Contains(dangerLevel))
                    {
                        Console.WriteLine("Felaktigt dangerlevel har angivits.");
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
                Console.WriteLine("\n=== HANTERA PLATSER ===");
                Console.WriteLine("1. Lägg till ny plats.");
                Console.WriteLine("2. Visa alla platser.");
                Console.WriteLine("3. Sök plats (efter namn).");
                Console.WriteLine("4. Uppdatera platser.");
                Console.WriteLine("5. Ta bort plats.");
                Console.WriteLine("0. Återgå till huvudmeny.");
                Console.Write("val: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n--- Lägg till ny plats. ---");

                            // 1. Fråga användaren efter namn
                            Console.Write("namn: ");
                            string? name = Console.ReadLine();

                            // 2. Fråga användaren efter region
                            Console.Write("region: ");
                            string? region = Console.ReadLine();

                            facade.AddLocation(name, region); // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct

                            // 3. Skriv ut ett bekräftelsemeddelande
                            Console.WriteLine("✅ Platen har lagts till!");

                            break;

                        case 2:
                            OutputAllLocations();
                            break;

                        case 3:
                            Console.WriteLine("Funktion är ej aktiverad.");
                            Console.WriteLine("Betala för en VG-version för åtkomst.");
                            break;

                        case 4:
                            Console.WriteLine("\n--- Uppdatera platser. ---");

                            // Först visar vi alla monster så användaren ser vilka som finns
                            OutputAllLocations();

                            // 1. Fråga vilket Id användaren vill uppdatera
                            Console.Write("\nAnge id på platsen du vill uppdatera: ");

                            // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct
                            if (!int.TryParse(Console.ReadLine(), out int idToUpdate))
                            {
                                Console.WriteLine("Felaktigt id har angivits!");
                                return;
                            }

                            // 2. Fråga efter nytt namn
                            Console.Write("nytt namn: ");
                            string? newName = Console.ReadLine();

                            // 3. Fråga efter ny region
                            Console.Write("ny region: ");
                            string? newRegion = Console.ReadLine();

                            facade.UpdateLocation(idToUpdate, newName, newRegion);

                            break;

                        case 5:
                            Console.WriteLine("\n--- Ta bort plats. ---");

                            // Visa alla platser först
                            OutputAllLocations();

                            // 1. Fråga vilket Id användaren vill ta bort
                            Console.Write("\nAnge id på platsen du vill ta bort: ");

                            if (!int.TryParse(Console.ReadLine(), out int idToDelete))
                            {
                                Console.WriteLine("Felaktigt id har angivits!");
                                return;
                            }

                            // 2. Fråga om användaren är säker (säkerhetscheck!)
                            Console.Write($"Är du säker på att du vill ta bort platsen med id {idToDelete}? (ja/nej): ");
                            string answer = Console.ReadLine();

                            if (answer.ToLower() != "ja")
                            {
                                Console.WriteLine("avbrutet");
                                return;
                            }

                            try
                            {


                                facade.DeleteLocation(idToDelete);

                                Console.WriteLine("✅ Platsen är borttagen!");
                            }
                            // Written with help from Perplexity, https://www.perplexity.ai/search/when-i-run-this-code-and-try-t-M23pxGhiQb2Mqfr3ThnIWA#0
                            catch (SQLiteException ex)
                            {
                                if (ex.Message.Contains("FOREIGN KEY constraint failed"))
                                    Console.WriteLine("Kan inte radera eftersom platsen har registrerade observationer!");
                                else
                                    Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                            }
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Felaktigt val har angivits.");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Felaktigt val har angivits.");

                }
            }

            static void OutputAllLocations()
            {
                Console.WriteLine("\n--- alla platser ---");

                // 1. Hämta alla jägare
                MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0
                List<Location> locations = facade.GetAllLocations();

                // 2. Skriv ut varje plats på ett snyggt sätt
                // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct 
                foreach (Location location in locations)
                {

                    Console.WriteLine($"id: {location.Id}, namn: {location.Name}, region: {location.Region}");

                }
            }
        }

        public static void HunterManagerMenu()
        {
            MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0

            while (true)
            {
                Console.WriteLine("\n=== HANTERA JÄGARE ===");
                Console.WriteLine("1. Lägg till ny jägare.");
                Console.WriteLine("2. Visa alla jägare.");
                Console.WriteLine("3. Sök jägare (efter namn).");
                Console.WriteLine("4. Uppdatera jägare.");
                Console.WriteLine("5. Ta bort jägare.");
                Console.WriteLine("0. Återgå till huvudmeny.");
                Console.Write("val: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n--- Lägg till ny jägare ---");

                            // 1. Fråga användaren efter namn
                            Console.Write("namn: ");
                            string? name = Console.ReadLine();

                            // 2. Fråga användaren efter erfarenhetsnivå
                            string? experienceLevel = InputExperienceLevel();

                            facade.AddHunter(name, experienceLevel); // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct

                            // 3. Skriv ut ett bekräftelsemeddelande
                            Console.WriteLine("✅ Jägaren har lagts till!");

                            break;

                        case 2:
                            OutputAllHunters();
                            break;

                        case 3:
                            Console.WriteLine("Funktion är ej aktiverad.");
                            Console.WriteLine("Betala för en VG-version för åtkomst.");
                            break;

                        case 4:
                            Console.WriteLine("\n--- Uppdatera jägare. ---");

                            // Först visar vi alla monster så användaren ser vilka som finns
                            OutputAllHunters();

                            // 1. Fråga vilket Id användaren vill uppdatera
                            Console.Write("\nAnge id på jägaren du vill uppdatera: ");

                            // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct
                            if (!int.TryParse(Console.ReadLine(), out int idToUpdate))
                            {
                                Console.WriteLine("Felaktigt id har angivits!");
                                return;
                            }

                            // 2. Fråga efter nytt namn
                            Console.Write("nytt namn: ");
                            string? newName = Console.ReadLine();

                            // 3. Fråga efter ny erfarenhetsnivå
                            string? newExperienceLevel = InputExperienceLevel();

                            facade.UpdateHunter(idToUpdate, newName, newExperienceLevel);

                            break;

                        case 5:
                            Console.WriteLine("\n--- Ta bort jägare. ---");

                            // Visa alla jägare först
                            OutputAllHunters();

                            // 1. Fråga vilket Id användaren vill ta bort
                            Console.Write("\nAnge id på jägaren du vill ta bort: ");

                            if (!int.TryParse(Console.ReadLine(), out int idToDelete))
                            {
                                Console.WriteLine("Felaktigt id har angivits!");
                                return;
                            }

                            // 2. Fråga om användaren är säker (säkerhetscheck!)
                            Console.Write($"Är du säker på att du vill ta bort jägaren med Id {idToDelete}? (ja/nej): ");
                            string answer = Console.ReadLine();

                            if (answer.ToLower() != "ja")
                            {
                                Console.WriteLine("avbrutet");
                                return;
                            }

                            try
                            {

                                facade.DeleteHunter(idToDelete);

                                Console.WriteLine("✅ Jägaren är borttagen!");
                            }

                            // Written with help from Perplexity, https://www.perplexity.ai/search/when-i-run-this-code-and-try-t-M23pxGhiQb2Mqfr3ThnIWA#0
                            catch (SQLiteException ex)
                            {
                                if (ex.Message.Contains("FOREIGN KEY constraint failed"))
                                    Console.WriteLine("Kan inte radera eftersom jägaren har registrerade observationer!");
                                else
                                    Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                            }
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Felaktigt val har angivits.");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Felaktigt val har angivits.");

                }
            }

            static void OutputAllHunters()
            {
                Console.WriteLine("\n--- alla jägare ---");

                // 1. Hämta alla jägare
                MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0
                List<Hunter> hunters = facade.GetAllHunters();

                // 2. Skriv ut varje jägare på ett snyggt sätt
                // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct 
                foreach (Hunter hunter in hunters)
                {

                    Console.WriteLine($"id: {hunter.Id}, namn: {hunter.Name}, erfarenhetsnivå: {hunter.ExperienceLevel}");

                }
            }

            static string? InputExperienceLevel()
            {
                // 1. Fråga användaren efter erfarenhetsnivå
                string[] validExperienceLevels = { "Rookie", "Expert", "Master" };
                string? experienceLevel = "";
                do
                {
                    Console.Write("erfarenhetsnivå: Rookie, Expert, eller Master: ");
                    experienceLevel = Console.ReadLine();
                    if (!validExperienceLevels.Contains(experienceLevel))
                    {
                        Console.WriteLine("Felaktig erfarenhetsnivå har angivits.");
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
                Console.WriteLine("\n=== HANTERA OBSERVATIONER ===");
                Console.WriteLine("1. Lägg till ny observation.");
                Console.WriteLine("2. Visa alla observationer.");
                Console.WriteLine("3. Sök observation (efter datum).");
                Console.WriteLine("4. Uppdatera observation.");
                Console.WriteLine("5. Ta bort observation.");
                Console.WriteLine("0. Återgå till huvudmeny.");
                Console.Write("val: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n--- Lägg till ny observation ---");

                            Console.Write("monster-id: ");
                            if (!int.TryParse(Console.ReadLine(), out int monsterId))
                            {
                                Console.WriteLine("Felaktigt monster-id har angivits!");
                                break;
                            }

                            Console.Write("plats-id: ");
                            if (!int.TryParse(Console.ReadLine(), out int locationId))
                            {
                                Console.WriteLine("Felaktigt plats-id har angivits!");
                                break;
                            }

                            Console.Write("jägar-id: ");
                            if (!int.TryParse(Console.ReadLine(), out int hunterId))
                            {
                                Console.WriteLine("Felaktigt jägar-id har angivits!");
                                break;
                            }

                            Console.Write("händelsebeskrivning: ");
                            string? description = Console.ReadLine();

                            Console.Write("datum (ÅÅÅÅ-MM-DD): ");
                            string? dateSeen = Console.ReadLine();

                            facade.AddObservation(monsterId, locationId, hunterId, description, dateSeen); // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct

                            // 4. Skriv ut ett bekräftelsemeddelande
                            Console.WriteLine("✅ Observationen har lagts till!");

                            break;

                        case 2:
                            OutputAllObservations();
                            break;

                        case 3:
                            Console.WriteLine("Funktion är ej aktiverad.");
                            Console.WriteLine("Betala för en VG-version för åtkomst.");
                            break;

                        case 4:
                            Console.WriteLine("\n--- Uppdatera observation. ---");

                            // Först visar vi alla monster så användaren ser vilka som finns
                            OutputAllObservations();

                            // 1. Fråga vilket Id användaren vill uppdatera
                            Console.Write("\nAnge id på observationen du vill uppdatera: ");

                            // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct
                            if (!int.TryParse(Console.ReadLine(), out int idToUpdate))
                            {
                                Console.WriteLine("Felaktigt id har angivits!");
                                return;
                            }

                            Console.Write("\nnytt monster-id: ");

                            // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct
                            if (!int.TryParse(Console.ReadLine(), out int newMonsterId))
                            {
                                Console.WriteLine("Felaktigt monster-id har angivits!");
                                return;
                            }

                            Console.Write("\nnytt plats-id: ");

                            // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct
                            if (!int.TryParse(Console.ReadLine(), out int newLocationId))
                            {
                                Console.WriteLine("Felaktigt plats-id har angivits!");
                                return;
                            }

                            Console.Write("\nnytt jägar-id: ");

                            // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct
                            if (!int.TryParse(Console.ReadLine(), out int newHunterId))
                            {
                                Console.WriteLine("Felaktigt jägar-id har angivits!");
                                return;
                            }

                            // 2. Fråga efter ny beskrivning
                            Console.Write("ny händelsebeskrivning: ");
                            string? newDescription = Console.ReadLine();

                            // 3. Fråga efter nytt datum
                            Console.Write("nytt datum: ");
                            string? newDateSeen = Console.ReadLine();

                            facade.UpdateObservation(idToUpdate, newMonsterId, newLocationId, newHunterId, newDescription, newDateSeen);

                            break;

                        case 5:
                            Console.WriteLine("\n--- Ta bort observation. ---");

                            // Visa alla observationer först
                            OutputAllObservations();

                            // 1. Fråga vilket Id användaren vill ta bort
                            Console.Write("\nAnge id på observationen du vill ta bort: ");

                            if (!int.TryParse(Console.ReadLine(), out int idToDelete))
                            {
                                Console.WriteLine("Felaktigt id har angivits!");
                                return;
                            }

                            // 2. Fråga om användaren är säker (säkerhetscheck!)
                            Console.Write($"Är du säker på att du vill ta bort observationen med id {idToDelete}? (ja/nej): ");
                            string answer = Console.ReadLine();

                            if (answer.ToLower() != "ja")
                            {
                                Console.WriteLine("avbrutet");
                                return;
                            }

                            facade.DeleteObservation(idToDelete);

                            Console.WriteLine("✅ Observation är borttagen!");
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Felaktigt val har angivits.");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Felaktigt val har angivits.");

                }
            }

            static void OutputAllObservations()
            {
                Console.WriteLine("\n--- alla observationer ---");

                // 1. Hämta alla observationer
                MonsterTrackerFacade facade = new MonsterTrackerFacade(); // With help from Perplexity, https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#0
                List<Observation> observations = facade.GetAllObservations();

                // 2. Skriv ut varje observation på ett snyggt sätt
                // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct 
                foreach (Observation observation in observations)
                {

                    Console.WriteLine($"id: {observation.Id}, monster-id: {observation.MonsterId}, plats-id: {observation.LocationId}, jägar-id: {observation.HunterId}, händelsebeskrivning: {observation.Description}, datum: {observation.DateSeen}");

                }
            }
        }
    }
}