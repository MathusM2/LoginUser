using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginUserWPF.Data
{
    public static class DatabaseInitializer
    {
        private const string DbFilePath = "users.db";
        public static void Initialize() 
        {
            //If users.db does not exist, then it is created
            if(!File.Exists(DbFilePath))
            {
                SQLiteConnection.CreateFile(DbFilePath);
                Debug.WriteLine("Banco de dados criado!");

                using (var connection  = new SQLiteConnection($"DataSource={DbFilePath};Version=3;"))
                {
                    connection.Open();
                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        PasswordHash TEXT NOT NULL
                        );
                    ";

                    using (var command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            else
            {
                Debug.WriteLine("Banco de dados já existe");
            }
        }
    }
}
