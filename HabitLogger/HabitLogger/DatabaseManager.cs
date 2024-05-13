using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger
{
    public class DatabaseManager
    {
        SqliteConnection connection;
        string tableName;
        public DatabaseManager(string databaseName) 
        {
            tableName = databaseName;
            connection = new SqliteConnection($"Data Source = {tableName}.db");
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText =
            $@"
                    CREATE TABLE IF NOT EXISTS {tableName}(
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Habit TEXT NOT NULL                    
                )";
            command.ExecuteNonQuery();
        }

        ~DatabaseManager()
        {
            connection.Close();
        }

        public void addToDatabase(string Habit)
        {
            SqliteCommand command = connection.CreateCommand();
            command.CommandText =
            $@"
                    INSERT INTO {tableName} (Habit)
                    VALUES('{Habit}')
                ";
            command.ExecuteNonQuery();
        }
        public int count(string Habit)
        {
            SqliteCommand command = connection.CreateCommand();
            command.CommandText =
            $@"
                    SELECT COUNT(Habit)
                    FROM {tableName}
                    WHERE Habit = '{Habit}'
                ";
            int countResult = Convert.ToInt32(command.ExecuteScalar());

            return countResult;
        }
        public void deleteAll()
        {
            SqliteCommand command = connection.CreateCommand();
            command.CommandText =
            $@"
                    DELETE FROM {tableName}
                ";
            command.ExecuteNonQuery();
        }
    }
}
