using InterfaceLib;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQLSERVER
{
    public class OutfitMSSQLDAL : Database, IOutfitContainer
    {

        /// <summary>
        /// Voeg de waardes in OutfitTabel, specificeer welk gebruikerID de outfit toevoegd dmv de alias
        /// </summary>

        public void VoegOutfitToe(int GebrID, OutfitDTO outfit)
        {
            try
            {
                OpenConnection();
                if (!BestaandeTitleNaamOut(outfit.Titel))
                {
                    OpenConnection();
                    string query = @"INSERT INTO Outfit VALUES(@id, @titel, @prijs, @category, @path)";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    command.Parameters.AddWithValue("@id", GebrID);
                    command.Parameters.AddWithValue("@titel", outfit.Titel);
                    command.Parameters.AddWithValue("@prijs", outfit.Prijs);
                    command.Parameters.AddWithValue("@category", outfit.DeCategory.ToString());
                    command.Parameters.AddWithValue("@path", outfit.FileAdress);
                    command.ExecuteNonQuery();
                }
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

        public List<OutfitDTO> GetAllOutfitsVanGebr(int GebrID)
        {
            try
            {
                List<OutfitDTO> Outfits = new List<OutfitDTO>();
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Outfit WHERE GebrID = @id", this.connection);
                command.Parameters.AddWithValue("@id", GebrID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Outfits.Add(new OutfitDTO(
                        Convert.ToInt32(reader["ID"].ToString()),
                        reader["Titel"].ToString(),
                        Convert.ToInt32(reader["Prijs"]),
                        (OutfitDTO.OutfitCategory)Enum.Parse(typeof(OutfitDTO.OutfitCategory), reader["Categorie"].ToString()),
                        reader["FileAdress"].ToString()));
                    }
                }
                CloseConnection();
                return Outfits;
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
        
        public List<OutfitDTO> GetAllOutfits()
        {
            try
            {
                List<OutfitDTO> Outfits = new List<OutfitDTO>();
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Outfit", this.connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Outfits.Add(new OutfitDTO(
                        Convert.ToInt32(reader["ID"].ToString()),
                        reader["Titel"].ToString(),
                        Convert.ToInt32(reader["Prijs"]),
                        (OutfitDTO.OutfitCategory)Enum.Parse(typeof(OutfitDTO.OutfitCategory), reader["Categorie"].ToString()),
                        reader["FileAdress"].ToString()));
                    }
                }
                CloseConnection();
                return Outfits;
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

        public void DeleteOutfit(OutfitDTO outfit) //fixen
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(@"DELETE FROM Outfit WHERE ID = @id", this.connection);
                command.Parameters.AddWithValue("@id", outfit.ID);
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
        
        public void UpdateOutfit(OutfitDTO outfit) //fixen
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(@"UPDATE Outfit SET Prijs = @prijs, Categorie = @categorie WHERE ID = @id", this.connection);
                command.Parameters.AddWithValue("@titel", outfit.ID);
                command.Parameters.AddWithValue("@prijs", outfit.Prijs);
                command.Parameters.AddWithValue("@categorie", outfit.DeCategory);
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

        public bool IsOutfit(string titel)
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
        /// GetOutfit ga ik later gebruiken voor filteren bijv, zoeken op naam etc.
        /// </summary>

        public OutfitDTO GetOutfit(string titel)
        {
            try
            {
                OutfitDTO outfit = null;
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Outfit WHERE Titel = @titel", this.connection);
                command.Parameters.AddWithValue("@titel", titel);
                //Je zoekt outfit op titel omdat deze uniek is
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        outfit = new OutfitDTO(
                        Convert.ToInt32(reader["ID"].ToString()),
                        reader["Titel"].ToString(),
                        Convert.ToInt32(reader["Prijs"]),
                        (OutfitDTO.OutfitCategory)Enum.Parse(typeof(OutfitDTO.OutfitCategory), reader["Categorie"].ToString()),
                        reader["FileAdress"].ToString());
                    }
                }
                CloseConnection();
                return outfit;
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
