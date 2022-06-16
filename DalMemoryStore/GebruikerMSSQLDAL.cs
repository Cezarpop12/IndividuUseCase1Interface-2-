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
        /// <param name="gebruiker">Gebrnaam die ingevuld is</param>
        /// <param name="wachtwoord">ww wordt gehasht en opgeslagen in db</param>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public void CreateGebr(GebruikerDTO gebruiker, string wachtwoord)
        {
            try
            {
                OpenConnection();
                string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(wachtwoord, 13);
                string query = @"INSERT INTO Gebruiker VALUES(@alias, @gebruikersnaam, @hash)";
                SqlCommand command = new SqlCommand(query, this.connection);
                command.Parameters.AddWithValue("@alias", gebruiker.Alias);
                command.Parameters.AddWithValue("@gebruikersnaam", gebruiker.Gerbuikersnaam);
                command.Parameters.AddWithValue("@hash", passwordHash);
                command.ExecuteNonQuery();
                CloseConnection();
            }
            catch (InvalidOperationException ex)
            {
                throw new TemporaryExceptions(ex);
            }
            catch (IOException ex)
            {
                throw new TemporaryExceptions(ex);
            }
            catch (Exception ex)
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
        public GebruikerDTO? ZoekGebrOpGebrnaamEnWW(string gebrnaam, string wachtwoord)
        {
            try
            {
                OpenConnection();
                GebruikerDTO dto = null;
                SqlCommand command = new SqlCommand(@"SELECT * FROM Gebruiker WHERE Gebruikersnaam = @gebrnaam", this.connection);
                command.Parameters.AddWithValue("@gebrnaam", gebrnaam);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bool correct = BCrypt.Net.BCrypt.EnhancedVerify(wachtwoord, reader["Hash"].ToString());
                        if (correct)
                        {
                            dto = new GebruikerDTO(
                            Convert.ToInt32(reader["GebrID"].ToString()),
                            reader["Gebruikersnaam"].ToString(),
                            reader["Alias"].ToString());
                        }
                    }
                    CloseConnection();
                }
                return dto;
            }
            catch (InvalidOperationException ex)
            {
                throw new TemporaryExceptions(ex);
            }
            catch (IOException ex)
            {
                throw new TemporaryExceptions(ex);
            }
            catch (Exception ex)
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
                        Convert.ToInt32(reader["GebrID"].ToString()),
                        reader["Gebruikersnaam"].ToString(),
                        reader["Alias"].ToString());
                    }
                }
                CloseConnection();
                return null;
            }
            catch (InvalidOperationException ex)
            {
                throw new TemporaryExceptions(ex);
            }
            catch (IOException ex)
            {
                throw new TemporaryExceptions(ex);
            }
            catch (Exception ex)
            {
                throw new PermanentExceptions("Iets gaat hier fout!");
            }
        }
    }
}
