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
            var databaseFileName = "MonsterTracker.db";
            var sqlSchema = File.ReadAllText("monstertracker_schema.sql");

            using SQLiteConnection connection = DatabaseConnection.GetConnection();

            // Create the database file if it doesn't exist
            if (!File.Exists(databaseFileName))
                SQLiteConnection.CreateFile(databaseFileName);

            // Run the schema script
            using (var sqlCommand = connection.CreateCommand())
            {
                sqlCommand.CommandText = sqlSchema;
                sqlCommand.ExecuteNonQuery();
            }

            // Console.WriteLine("SQLite database created with schema.");
        }
    }
}