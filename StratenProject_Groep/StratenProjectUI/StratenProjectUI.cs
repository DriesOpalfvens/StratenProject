using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratenProjectUI {
    public class StratenProjectUI
    {

       


            public static void ImportCsvToSqlite(string csvFilePath, string tableName, SqliteConnection conn)
        {
            // Hier CSV lezen en tabel maken + data invoegen
            // Voorbeeld: gebruik CsvHelper of eenvoudige string.Split
            var lines = File.ReadAllLines(csvFilePath);
            var headers = lines[0].Split(';');

            // Maak tabel
            string createTableSql = $"CREATE TABLE {tableName} ({string.Join(", ", headers.Select(h => $"{h} TEXT"))})";
            var cmd = new SqliteCommand(createTableSql, conn);
            cmd.ExecuteNonQuery();

            // Voeg data toe
            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(';');
                string insertSql = $"INSERT INTO {tableName} VALUES ({string.Join(", ", values.Select(v => $"'{v.Replace("'", "''")}'"))})";
                var insertCmd = new SqliteCommand(insertSql, conn);
                insertCmd.ExecuteNonQuery();
            }
        }
    } 
    
}
