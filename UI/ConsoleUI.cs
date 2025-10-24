using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                switch(choice)
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
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {

                return;
            }
        }
    }
}