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
        /// Gebruiker wordt toegevoeg met de meegegeven ww
        /// </summary>
        /// <param name="gebruiker">Gebrgegevens die ingevuld zijn</param>
        /// <param name="wachtwoord">ww wordt gehasht en opgeslagen in db</param>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public void CreateGebr(GebruikerDTO gebruiker, string wachtwoord)
        {
            try
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
            catch (SqlException ex)
            {
                throw new TemporaryExceptions("Fout met de verbinding");
            }
            catch (Exception ex) //Toegang tot de exceptie class
            {
                throw new PermanentExceptions("Iets gaat hier fout!");
            }
        }

        /// <summary>
        /// Er wordt een gebruiker gezocht op wachtwoord en gebrNaam
        /// </summary>
        /// <param name="gebrnaam">Gebrnaam die meegegeven is</param>
        /// <param name="wachtwoord">Wachtwoord die meegegeven is</param>
        /// <returns>Return een gebruiker</returns>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public GebruikerDTO ZoekGebrOpGebrnaamEnWW(string gebrnaam, string wachtwoord)
        {
            try
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
                            Convert.ToInt32(reader["ID"].ToString()),
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
            catch (SqlException ex)
            {
                throw new TemporaryExceptions("Fout met de verbinding");
            }
            catch (Exception ex) //Toegang tot de exceptie class
            {
                throw new PermanentExceptions("Iets gaat hier fout!");
            }
        }

        /// <summary>
        /// Er wordt een gebruiker gezocht op gebrNaam en Alias
        /// </summary>
        /// <param name="gebrnaam">Gebrnaam die meegegeven is</param>
        /// <param name="alias">Alias die meegegeven is</param>
        /// <returns>Return een gebruiker</returns>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public GebruikerDTO ZoekGebrOpGebrnaamOfAlias(string gebrnaam, string alias)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Gebruiker WHERE Gebruikersnaam = @gebrnaam OR Alias = @alias", this.connection);
                command.Parameters.AddWithValue("@gebrnaam", gebrnaam);
                command.Parameters.AddWithValue("@alias", alias);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new GebruikerDTO(
                            Convert.ToInt32(reader["ID"].ToString()),
                            reader["Gebruikersnaam"].ToString(),
                            reader["Alias"].ToString());
                    }
                }
                CloseConnection();
                return null;
            }
            catch (SqlException ex)
            {
                throw new TemporaryExceptions("Fout met de verbinding");
            }
            catch (Exception ex) 
            {
                throw new PermanentExceptions("Iets gaat hier fout!");
            }
        }

        /// <summary>
        /// Gebruiker opgehaald door alias mee te geven
        /// </summary>
        /// <param name="alias">De alias die wordt meegegeven</param>
        /// <returns>Return een gebruiker</returns>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public GebruikerDTO GetGebruiker(string alias)
        {
            try
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
                            Convert.ToInt32(reader["ID"].ToString()),
                            reader["Gebruikersnaam"].ToString(),
                            reader["Alias"].ToString());
                    }
                }
                CloseConnection();
                return null;
            }
            catch (SqlException ex)
            {
                throw new TemporaryExceptions("Fout met de verbinding");
            }
            catch (Exception ex) //Toegang tot de exceptie class
            {
                throw new PermanentExceptions("Iets gaat hier fout!");
            }
        }
    }
}
