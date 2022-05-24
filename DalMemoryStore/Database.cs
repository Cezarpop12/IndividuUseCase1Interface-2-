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
        private string data = File.ReadAllText(@"C:\Users\mrcha\OneDrive - Office 365 Fontys\Documents\IndividuUseCase1Interface (2)\DalMemoryStore\Ww.json");
        private Rootobject? root;
        public SqlConnection connection;

        public void OpenConnection()
        {
            root = JsonSerializer.Deserialize<Rootobject>(data);
            if (root != null)
            {
                connection = new SqlConnection(root.DatabaseConfig.ConnectionString);
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        /// <summary>
        /// Er wordt gecheckt of een titel al bestaat voor een outfit
        /// </summary>
        /// <param name="titel">De titel die wordt meegegeven</param>
        /// <returns>Een true of false (outfit gevonden of niet)</returns>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public bool BestaandeTitleNaamOut(string titel)
        {
            try
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
        /// Er wordt gecheckt of een titel al bestaat voor een onderdeel
        /// </summary>
        /// <param name="titel">De titel die wordt meegegeven</param>
        /// <returns>Een true of false (onderdeel gevonden of niet)</returns>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public bool BestaandeTitleNaamOnder(string titel)
        {
            try
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
        /// Er wordt een ID opgehaald uit de gebruiker tabel
        /// </summary>
        /// <param name="alias">De alias die wordt meegegeven</param>
        /// <returns>Een gebrID of een waarde van 0</returns>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public int GetUserID(string alias)
        {
            try
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
        /// Er wordt een ID opgehaald uit de Outfit tabel
        /// </summary>
        /// <param name="titel">De titel die wordt meegegeven</param>
        /// <returns>Een ID of een waarde van 0</returns>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public int GetOutfitID(string titel)
        {
            try
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
        /// Er wordt een ID opgehaald uit de Onderdeel tabel
        /// </summary>
        /// <param name="titel">De titel die wordt meegegeven</param>
        /// <returns>Een ID of een waarde van 0</returns>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public int GetOnderdeelID(string titel)
        {
            try
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
        /// Er wordt een ID opgehaald uit de Review tabel
        /// </summary>
        /// <param name="titel">De titel die wordt meegegeven</param>
        /// <returns>Een ID of een waarde van 0</returns>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public int GetReviewID(string titel)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT ID FROM Review WHERE Titel = @titel", this.connection);
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

