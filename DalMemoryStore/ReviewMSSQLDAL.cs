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
        
        public void VoegReviewToeOnderdeel(ReviewDTO review, GebruikerDTO gebruiker, string titel)
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

        public List<ReviewDTO> GetAllReviewsVanGebr(string alias)
        {
            List<ReviewDTO> Reviews = new List<ReviewDTO>();
            OpenConnection();
            SqlCommand command = new SqlCommand(@"SELECT * FROM Review WHERE GebrID = @id", this.connection);
            command.Parameters.AddWithValue("@id", GetUserID(alias));
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Reviews.Add(new ReviewDTO(
                        reader["StukTekst"].ToString(),
                        GetGebruiker(alias),
                        Convert.ToDateTime(reader["Datum"])));
                }
            }
            CloseConnection();
            return Reviews;
        }
        
        /// <summary>
        /// Een methode om alle reviews te tonen en een om van een specifieke gebr te tonen.
        /// </summary>
        /// <returns></returns>

        public List<ReviewDTO> GetAllReviews()
        {
            List<ReviewDTO> Reviews = new List<ReviewDTO>();
            OpenConnection();
            SqlCommand command = new SqlCommand(@"SELECT * FROM Review", this.connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Reviews.Add(new ReviewDTO(
                        reader["StukTekst"].ToString(),
                        GetGebruiker("Alias"),
                        Convert.ToDateTime(reader["Datum"])));
                }
            }
            CloseConnection();
            return Reviews;
        }

        /// <summary>
        /// Pak alles van Gebruiker tabel (retourneer gebruiker) als Gebruiker ID hetzelfde is als de id die je krijgt bij getuserID(naam) .
        /// </summary>

        public GebruikerDTO GetGebruiker(string naam)
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
                        reader["Gebruikersnaam"].ToString(),
                        reader["Alias"].ToString());
                }
            }
            CloseConnection();
            return null;
        }
    }
}
