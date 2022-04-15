using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace DALMSSQLSERVER
{
    public class Database : DatabaseConfig
    {

        /// <summary>
        /// Hier komen alle algemene methodes in.
        /// </summary>

        private string data = File.ReadAllText(@"C:\Users\ISSD\OneDrive - Office 365 Fontys\Documents\IndividuUseCase1Interface (2)\DalMemoryStore\Ww.json");
        private Rootobject? root;
        public SqlConnection connection;

        public void OpenConnection()
        {
            root = JsonSerializer.Deserialize<Rootobject>(data);
            if(root != null)
            {
                connection = new SqlConnection(root.DatabaseConfig.ConnectionString);
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public bool BestaandeTitleNaamOut(string titel)
        {
            bool check = false;
            OpenConnection();
            string query = @"SELECT * FROM Outfit WHERE Titel = @titel";
            SqlCommand command = new SqlCommand(query, this.connection);
            command.Parameters.AddWithValue("@titel", titel);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                check = true;
            }
            CloseConnection();
            return check;
        }

        public bool BestaandeTitleNaamOnder(string titel)
        {
            bool check = false;
            OpenConnection();
            string query = @"SELECT * FROM Onderdeel WHERE Titel = @titel";
            SqlCommand command = new SqlCommand(query, this.connection);
            command.Parameters.AddWithValue("@titel", titel);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                check = true;
            }
            CloseConnection();
            return check;
        }

        public int GetUserID(string alias)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand(@"SELECT GebrID FROM Gebruiker WHERE Alias = @alias", this.connection);
            command.Parameters.AddWithValue("@alias", alias);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    return Convert.ToInt32(reader["GebrID"]);
                }
            }
            CloseConnection();
            return 0;
        }

        public int GetOutfitID(string titel)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand(@"SELECT ID FROM Outfit WHERE Titel = @titel", this.connection);
            command.Parameters.AddWithValue("@Titel", titel);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    return Convert.ToInt32(reader["ID"]);
                }
            }
            CloseConnection();
            return 0;
        }

        public int GetOnderdeelID(string titel)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand(@"SELECT ID FROM Onderdeel WHERE Titel = @titel", this.connection);
            command.Parameters.AddWithValue("@Titel", titel);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    return Convert.ToInt32(reader["ID"]);
                }
            }
            CloseConnection();
            return 0;
        }
    }
}

