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

        public RatingDTO GetRating(int id)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Rating WHERE OutfitID = @id", this.connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new RatingDTO(
                            Convert.ToInt32(reader["ID"].ToString()),
                            Convert.ToInt32(reader["Waarde"].ToString()));
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
