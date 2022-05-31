using InterfaceLib;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQLSERVER
{
    public class ReviewMSSQLDAL : Database, IReviewContainer
    {
        /// <summary>
        /// Review wordt toegevoeg aan outfit met de meegegeven alias en titel
        /// </summary>
        /// <param name="review">Review die wordt meegegeven</param>
        /// <param name="gebruiker">gebruiker die wordt meegegeven</param>
        /// <param name="titel">Titel die wordt meegegeven</param>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public void VoegReviewToeOutfit(int gebrID, int outfitID, ReviewDTO review)
        {
            try
            {
                OpenConnection();
                {
                    OpenConnection();
                    string query = "INSERT INTO Review (GebrID, OutfitID, StukTekst, Datum, Titel) VALUES (@gebrID, @outfitID , @stuktekst, @datumtijd, @titel)";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    command.Parameters.AddWithValue("@gebrID", gebrID);
                    command.Parameters.AddWithValue("@outfitID", outfitID);
                    command.Parameters.AddWithValue("@stuktekst", review.StukTekst);
                    command.Parameters.AddWithValue("@datumtijd", review.DatumTijd);
                    command.Parameters.AddWithValue("@titel", review.Titel);
                    command.ExecuteNonQuery();
                    CloseConnection();
                }
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
        /// Alle reviews van een bepaalde gebr worden opgehaald
        /// </summary>
        /// <param name="gebruiker">Gebruiker die wordt meegegeven</param>
        /// <returns>Return een lijst van reviews</returns>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public List<ReviewDTO> GetAllReviewsVanGebr(int gebrID)
        {
            try
            {
                List<ReviewDTO> Reviews = new List<ReviewDTO>();
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Review WHERE GebrID = @id", this.connection);
                command.Parameters.AddWithValue("@id", gebrID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Reviews.Add(new ReviewDTO(
                            Convert.ToInt32(reader["ID"].ToString()),
                            reader["StukTekst"].ToString(),
                            reader["Titel"].ToString(),
                            Convert.ToDateTime(reader["Datum"])));
                    }
                }
                CloseConnection();
                return Reviews;
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
        /// Een review wordt verwijderd
        /// </summary>
        /// <param name="review">Review die wordt meegegeven</param>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public void DeleteReview(ReviewDTO review)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(@"DELETE FROM Review WHERE ID = @id", this.connection);
                command.Parameters.AddWithValue("@id", review.ID);
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
        /// Een review wordt geupdatet
        /// </summary>
        /// <param name="review">Review die wordt meegegeven</param>
        /// <exception cref="TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public void UpdateReview(ReviewDTO review)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(@"UPDATE Review SET StukTekst = @stuktekst, Titel = @titel WHERE ID = @id", this.connection);
                command.Parameters.AddWithValue("@titel", review.Titel);
                command.Parameters.AddWithValue("@stuktekst", review.StukTekst);
                command.Parameters.AddWithValue("@id", review.ID);
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

        public ReviewDTO GetReview(int id)
        {
            try
            {
                ReviewDTO review = null;
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Review WHERE ID = @id", this.connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        review = new ReviewDTO(
                        Convert.ToInt32(reader["ID"].ToString()),
                        reader["Titel"].ToString(),
                        reader["StukTekst"].ToString(),
                        Convert.ToDateTime(reader["Datum"].ToString()));
                    }
                }
                CloseConnection();
                return review;
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
