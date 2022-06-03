using InterfaceLib;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQLSERVER
{
    public class RatingMSSQLDAL : Database, IRatingContainer
    {
        /// <summary>
        /// Rating toevoegen door een outfitID mee te geven en een waarde
        /// </summary>
        /// <param name="id">De OutfitID die wordt meegegeven</param>
        /// <param name="waarde">De waarde die wordt meegegeven</param>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public void AddRating(int id, int waarde)
        {
            try
            {
                OpenConnection();
                string query = @"INSERT INTO Rating VALUES(@outfitID, @waarde)";
                SqlCommand command = new SqlCommand(query, this.connection);
                command.Parameters.AddWithValue("@outfitID", id);
                command.Parameters.AddWithValue("@waarde", waarde);
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
        /// De gemiddelde rating die wordt opgehaald van een bepaalde outfit
        /// </summary>
        /// <param name="id">De OutfitID die wordt meegegeven</param>
        /// <returns>Return een gemiddelde rating of 0</returns>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public int GemRatingBijOutfit(int id)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT AVG(Waarde) AS GemRating FROM Rating WHERE OutfitID = @id", this.connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return Convert.ToInt32(reader["GemRating"]);
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
