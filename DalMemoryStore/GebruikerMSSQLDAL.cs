using BCrypt.Net;
using InterfaceLib;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQLSERVER
{
    public class GebruikerMSSQLDAL : Database, IGebruikerContainer
    {
        /// <summary>
        /// Maak een hash bij het meegeven van een gewenst wachtwoord.
        /// </summary>
        
        public void CreateGebr(GebruikerDTO gebruiker, string wachtwoord)
        {
            OpenConnection();
            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(wachtwoord, 13);
            string query = @"INSERT INTO Gebruiker (Alias, Gebruikersnaam, Hash) VALUES(@alias, @gebruikersnaam, @hash)";   
            SqlCommand command = new SqlCommand(query, this.connection);
            command.Parameters.AddWithValue("@alias", gebruiker.Alias);
            command.Parameters.AddWithValue("@gebruikersnaam", gebruiker.Gerbuikersnaam);
            command.Parameters.AddWithValue("@hash", passwordHash); 
            command.ExecuteNonQuery();
            CloseConnection();
        }
        
        /// <summary>
        /// Zoek naar de hash die "gekoppeld" is aan de desbetreffende wachtwoord.
        /// </summary>
        
        public GebruikerDTO ZoekGebrOpGebrnaamEnWW(string gebrnaam, string wachtwoord)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand(@"SELECT * FROM Gebruiker WHERE Gebruikersnaam = @gebrnaam", this.connection);
            command.Parameters.AddWithValue("@gebrnaam", gebrnaam);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string hash = reader["Hash"].ToString();
                    bool correct = BCrypt.Net.BCrypt.EnhancedVerify(wachtwoord, hash);
                    if (correct)
                    {
                        return new GebruikerDTO(
                        reader["Gebruikersnaam"].ToString(),
                        reader["Alias"].ToString());
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            CloseConnection();
            return null;
        }

        /// <summary>
        /// Pak alles van Gebruiker tabel als Gebruiker ID hetzelfde is als de id die je krijgt bij getuserID(naam), door een naam mee te geven
        /// </summary>

        public GebruikerDTO GetGebruiker(string alias)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand(@"SELECT * FROM Gebruiker WHERE GebrID = @id", this.connection);
            command.Parameters.AddWithValue("@id", GetUserID(alias));
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    return new GebruikerDTO(
                        reader["Gebruikersnaam"].ToString(),
                        reader["Alias"].ToString());
                }
            }
            CloseConnection();
            return null;
        }
    }
}
