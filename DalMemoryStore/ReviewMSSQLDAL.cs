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
        public void VoegReviewToeOutfit(ReviewDTO review, GebruikerDTO gebruiker, string titel)
        {
            try
            {
                OpenConnection();
                if (GetOutfitID(titel) > 0)
                {
                    OpenConnection();
                    string query = "INSERT INTO Review (GebrID, OutfitID, StukTekst, Datum) VALUES((SELECT GebrID FROM Gebruiker WHERE Alias = @alias),(SELECT ID FROM Outfit WHERE ID = @id), @stuktekst, @datumtijd)";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    command.Parameters.AddWithValue("@alias", gebruiker.Alias);
                    command.Parameters.AddWithValue("@id", GetOutfitID(titel));
                    command.Parameters.AddWithValue("@stuktekst", review.StukTekst);
                    command.Parameters.AddWithValue("@datumtijd", review.DatumTijd);
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

        public void VoegReviewToeOnderdeel(ReviewDTO review, GebruikerDTO gebruiker, string titel)
        {
            try
            {
                OpenConnection();
                if (GetOnderdeelID(titel) > 0)
                {
                    OpenConnection();
                    string query = "INSERT INTO Review (GebrID, KledingstukID, StukTekst, Datum) VALUES((SELECT GebrID FROM Gebruiker WHERE Alias = @alias),(SELECT ID FROM Onderdeel WHERE ID = @id), @stuktekst, @datumtijd)";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    command.Parameters.AddWithValue("@alias", gebruiker.Alias);
                    command.Parameters.AddWithValue("@id", GetOnderdeelID(titel));
                    command.Parameters.AddWithValue("@stuktekst", review.StukTekst);
                    command.Parameters.AddWithValue("@datumtijd", review.DatumTijd);
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

        public List<ReviewDTO> GetAllReviewsVanGebr(GebruikerDTO gebruiker)
        {
            try
            {
                List<ReviewDTO> Reviews = new List<ReviewDTO>();
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Review WHERE GebrID = @id", this.connection);
                command.Parameters.AddWithValue("@id", gebruiker.ID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Reviews.Add(new ReviewDTO(
                            Convert.ToInt32(reader["Id"].ToString()),
                            reader["StukTekst"].ToString(),
                            reader["Titel"].ToString(),
                            GetGebruiker(gebruiker.Alias), //misschien "Alias" tussen quotes en zonder gebruiker.
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

        public void UpdateReview(ReviewDTO review)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(@"UPDATE Review SET StukTekst = @stuktekst WHERE ID = @id", this.connection);
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

        /// <summary>
        /// Pak alles van Gebruiker tabel (retourneer gebruiker) als Gebruiker ID hetzelfde is als de id die je krijgt bij getuserID(naam) .
        /// </summary>

        public GebruikerDTO GetGebruiker(string naam)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Gebruiker WHERE GebrID = @id", this.connection);
                command.Parameters.AddWithValue("@id", GetUserID(naam));
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
