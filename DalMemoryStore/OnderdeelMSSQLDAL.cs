using InterfaceLib;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQLSERVER
{
    public class OnderdeelMSSQLDAL : Database, IOnderdeelContainer
    {
        /// <summary>
        /// Er wordt een onderdeel toegevoegd met de meegegeven GebrID
        /// </summary>
        /// <param name="GebrID">De gebruikersID die meegegeven wordt</param>
        /// <param name="onderdeel">De onderdeel die meegegeven wordt</param>
        /// <exception cref="TemporaryExceptions">TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public void VoegOnderdeelToe(int GebrID, OnderdeelDTO onderdeel)
        {
            try
            {
                OpenConnection();
                string query = @"INSERT INTO Onderdeel VALUES(@id, @titel, @prijs, @category, @path)";
                SqlCommand command = new SqlCommand(query, this.connection);
                command.Parameters.AddWithValue("@id", GebrID);
                command.Parameters.AddWithValue("@titel", onderdeel.Titel);
                command.Parameters.AddWithValue("@prijs", onderdeel.Prijs);
                command.Parameters.AddWithValue("@category", onderdeel.DeCategory.ToString());
                command.Parameters.AddWithValue("@path", onderdeel.FileAdress);
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
        /// Alle onderdelen worden opgehaald met een bepaalde GebrID
        /// </summary>
        /// <param name="GebrID">De gebruikersID die meegegeven wordt</param>
        /// <returns>Return een lijst van onderdelen</returns>
        /// <exception cref="TemporaryExceptions">TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public List<OnderdeelDTO> GetAllOnderdelenVanGebr(int GebrID)
        {
            try
            {
                List<OnderdeelDTO> Onderdelen;
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Onderdeel WHERE GebrID = @id", this.connection);
                command.Parameters.AddWithValue("@id", GebrID);
                SqlDataReader reader = command.ExecuteReader();
                Onderdelen = LeesOnderdelen(reader);
                CloseConnection();
                return Onderdelen;
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
        /// Alle onderdelen worden opgehaald 
        /// </summary>
        /// <returns>Return een lijst van onderdelen</returns>
        /// <exception cref="TemporaryExceptions">TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public List<OnderdeelDTO> GetAllOnderdelen()
        {
            try
            {
                List<OnderdeelDTO> Onderdelen;
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Onderdeel", this.connection);
                SqlDataReader reader = command.ExecuteReader();
                Onderdelen = LeesOnderdelen(reader);
                CloseConnection();
                return Onderdelen;
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
        /// Laatste 4 geplaatste onderdelen worden opgehaald
        /// </summary>
        /// <returns>Return een lijst van onderdelen</returns>
        /// <exception cref="TemporaryExceptions">TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public List<OnderdeelDTO> GetLast4Onderdelen()
        {
            try
            {
                List<OnderdeelDTO> Onderdelen;
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT TOP 4 * FROM Onderdeel ORDER BY ID DESC", this.connection);
                SqlDataReader reader = command.ExecuteReader();
                Onderdelen = LeesOnderdelen(reader);
                CloseConnection();
                return Onderdelen;
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
        /// Reader leest of er een onderdeel is in de db
        /// </summary>
        /// <param name="reader">de reader</param>
        /// <returns>Return een lijst van onderdelen</returns>
        private List<OnderdeelDTO> LeesOnderdelen(SqlDataReader reader)
        {
            List<OnderdeelDTO> Onderdelen = new List<OnderdeelDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Onderdelen.Add(new OnderdeelDTO(
                    Convert.ToInt32(reader["ID"].ToString()),
                    reader["Titel"].ToString(),
                    Convert.ToInt32(reader["Prijs"]),
                    (OnderdeelDTO.OnderdeelCategory)Enum.Parse(typeof(OnderdeelDTO.OnderdeelCategory),
                    reader["Categorie"].ToString()),
                    reader["FileAdress"].ToString()));
                }
            }
            return Onderdelen;
        }
    }
}
