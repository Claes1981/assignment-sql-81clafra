using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.Data.Sqlite;

namespace assignment_sql_81clafra.Data
{
    public class DatabaseCreation
    {
        // Written with help from Perplexity, https://www.perplexity.ai/search/i-have-this-sqlite-schema-file-60Ef84DKTFyjOfb7WaOXpg#0
        public void CreateDatabase()
        {
            var dbPath = "MonsterTracker.db";
            var schema = File.ReadAllText("monstertracker_schema.sql");

            using SQLiteConnection connection = DatabaseConnection.GetConnection();

            // Create the database file if it doesn't exist
            if (!File.Exists(dbPath))
                SQLiteConnection.CreateFile(dbPath);

            // Enable foreign keys as mentioned in schema comments
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "PRAGMA foreign_keys = ON;";
                cmd.ExecuteNonQuery();
            }

            // Run the schema script
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = schema;
                cmd.ExecuteNonQuery();
            }


            // Console.WriteLine("SQLite database created with schema.");
        }
    }
}