using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_sql_81clafra.Data
{
    // Hanterar endast Monster-relaterade databasoperationer
    public class MonsterRepository
    {
        // Implementera CRUD-metoder här
        // Create, GetAll, GetById, Update, Delete

        static void CreatePerson()
        {
            Console.WriteLine("\n--- Lägg till ny person ---");

            // 1. Fråga användaren efter namn
            Console.Write("Namn: ");
            string? name = Console.ReadLine();

            // 2. Fråga användaren efter ålder
            Console.Write("Ålder: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
                Console.WriteLine("Felaktig ålder!");

            // 3. Skapa SQL-frågan med PARAMETRAR (inte string concatenation!)
            // Tipset: INSERT INTO Personer (Namn, Ålder) VALUES (@namn, @ålder)
            using SQLiteConnection connection = new SQLiteConnection(sqlConnectionString);

            // 4. Öppna connection, skapa command, lägg till parametrar, kör ExecuteNonQuery()
            connection.Open();

            string sqlCommandText = "INSERT INTO Personer (Namn, Ålder) VALUES (@name, @age)";

            using var sqlCommand = new SQLiteCommand(sqlCommandText, connection);
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@age", age);

            sqlCommand.ExecuteNonQuery();

            // 5. Skriv ut ett be1kräftelsemeddelande

            Console.WriteLine("✅ Person tillagd!");
        }
    }
}