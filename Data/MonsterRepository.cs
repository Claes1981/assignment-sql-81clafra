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

        static void CreateMonster()
        {
            Console.WriteLine("\n--- Lägg till nytt monster ---");

            // 1. Fråga användaren efter namn
            Console.Write("Namn: ");
            string? name = Console.ReadLine();

            // 2. Fråga användaren efter typ av monster
            Console.Write("Typ: ");
            string? type = Console.ReadLine();

            // 3. Fråga användaren efter riskgrad
            Console.Write("Typ: ");
            string? dangerLevel = Console.ReadLine();

            // 3. Skapa SQL-frågan med PARAMETRAR (inte string concatenation!)
            // Tipset: INSERT INTO Personer (Namn, Ålder) VALUES (@namn, @ålder)
            using SQLiteConnection connection = new SQLiteConnection(sqlConnectionString);

            // 4. Öppna connection, skapa command, lägg till parametrar, kör ExecuteNonQuery()
            connection.Open();

            // TODO: Does Id need to be inserted?
            string sqlCommandText = "INSERT INTO Monster (Name, Type, DangerLevel) VALUES (@name, @type, @dangerlevel)";

            using var sqlCommand = new SQLiteCommand(sqlCommandText, connection);
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@type", type);
            sqlCommand.Parameters.AddWithValue("@dangerlevel", dangerLevel);

            sqlCommand.ExecuteNonQuery();

            // 5. Skriv ut ett be1kräftelsemeddelande

            Console.WriteLine("✅ Monster tillagt!");
        }
    }
}