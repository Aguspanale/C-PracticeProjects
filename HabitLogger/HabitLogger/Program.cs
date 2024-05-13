// CREATE READ UPDATE DELETE

using Microsoft.Data.Sqlite;

namespace HabitLogger
{ 
    public class HabitLogger
    {
        public static void Main()
        {
            HabitLogger logger = new HabitLogger();
            logger.connect();           
        }
        internal void connect()
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source = Habits.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand() ;
                command.CommandText =
                @"
                    CREATE TABLE IF NOT EXISTS habits(
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Habit TEXT NOT NULL                    
                )";
                command.ExecuteNonQuery();


                command = connection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO habits (Name)
                    VALUES('A Habit!')
                ";
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT *
                    FROM habits
                ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(1);

                        Console.WriteLine($"{name}!");
                    }
                }
                connection.Close();
            }
        }       

    }
}