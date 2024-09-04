﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Reflection.Emit;


namespace SQL
{
    internal class DBWork
    {
        static public string MakeDB(string _dbname = "test02")
        {
            string result = "Что то пошло не так!";
            string path = $"Data Source={_dbname};";
            string init_db = "CREATE TABLE IF NOT EXISTS " +
                "Category " +
                "(id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "Name VARCHAR);";
            string init_data = "INSERT INTO " +
                "Category " +
                "(Name) " +
                "VALUES " +
                "('SportWatch');";
            string show_all_data = "SELECT * FROM Category;";
            SQLiteConnection conn = new SQLiteConnection(path);
            SQLiteCommand cmd01 = conn.CreateCommand();
            SQLiteCommand cmd02 = conn.CreateCommand();
            SQLiteCommand cmd03 = conn.CreateCommand();
            cmd01.CommandText = init_db;
            cmd02.CommandText = init_data;
            cmd03.CommandText = show_all_data;
            conn.Open();
            cmd01.ExecuteNonQuery();
            cmd02.ExecuteNonQuery();
            var reader = cmd03.ExecuteReader();
            if(reader.HasRows)
            {
                result = string.Empty;
                //reader.FieldCount - колличество полей
                while(reader.Read())
                {
                    result += reader.GetValue(0).ToString();
                    result += " | ";
                    result += reader.GetValue(1).ToString();
                    result += "\n";
                }
            }
            conn.Close();
            return result;
        }
    }
}
