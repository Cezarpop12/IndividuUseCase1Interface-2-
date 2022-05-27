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
        /// Er wordt een outfit toegevoegd met de meegegeven GebrID
        /// </summary>
        /// <param name="GebrID">De gebruikersID die meegegeven wordt</param>
        /// <param name="outfit">De outfit die meegegeven wordt</param>
        /// <exception cref="TemporaryExceptions">TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
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
        /// Alle outfits worden opgehaald met een bepaalde GebrID
        /// </summary>
        /// <param name="GebrID">De gebruikersID die meegegeven wordt</param>
        /// <returns>Return een lijst van outfits</returns>
        /// <exception cref="TemporaryExceptions">TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public List<OutfitDTO> GetAllOutfitsVanGebr(int GebrID)
        {
            try
            {
                List<OutfitDTO> Outfits; 
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Outfit WHERE GebrID = @id", this.connection);
                command.Parameters.AddWithValue("@id", GebrID);
                SqlDataReader reader = command.ExecuteReader();
                Outfits = LeesOutfits(reader);
                CloseConnection();
                return Outfits;
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
        /// Reader leest of er een outfit is in de db
        /// </summary>
        /// <param name="reader">de reader</param>
        /// <returns>Return een lijst van outfits</returns>
        private List<OutfitDTO> LeesOutfits(SqlDataReader reader)
        {
            List<OutfitDTO> Outfits = new List<OutfitDTO>();
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
            return Outfits;
        }

        /// <summary>
        /// Alle outfits worden opgehaald 
        /// </summary>
        /// <returns>Return een lijst van outfits</returns>
        /// <exception cref="TemporaryExceptions">TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
        public List<OutfitDTO> GetAllOutfits()
        {
            try
            {
                List<OutfitDTO> Outfits;
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Outfit", this.connection);
                SqlDataReader reader = command.ExecuteReader();
                Outfits = LeesOutfits(reader);
                CloseConnection();
                return Outfits;
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
        /// De laatste 4 geplaatste outfits worden opgehaald
        /// </summary>
        /// <returns>Return een lijst van outfits</returns>
        /// <exception cref="TemporaryExceptions">TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de
        public List<OutfitDTO> GetLast4Outfits()
        {
            try
            {
                List<OutfitDTO> Outfits;
                OpenConnection();
                SqlCommand command = new SqlCommand(@"SELECT TOP 4 * FROM Outfit ORDER BY ID DESC", this.connection);
                SqlDataReader reader = command.ExecuteReader();
                Outfits = LeesOutfits(reader);
                CloseConnection();
                return Outfits;
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
        /// Outfit wordt verwijderd met een bepaalde ID
        /// </summary>
        /// <param name="outfit">De outfit die meegegeven wordt</param>
        /// <exception cref="TemporaryExceptions">TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
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
        /// Outfit wordt geupdatet met een bepaalde GebrID
        /// </summary>
        /// <param name="outfit">De outfit die meegegeven wordt</param>
        /// <exception cref="TemporaryExceptions">TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
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
        /// Checken of er een outfit bestaat met de opgegeven Titel
        /// </summary>
        /// <param name="titel">De titel die meegegeven wordt</param>
        /// <returns>Een true of false (Wel een outfit of niet)</returns>
        /// <exception cref="TemporaryExceptions">TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
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
        /// Outfit wordt opgehaald met een bepaalde titel
        /// </summary>
        /// <param name="titel">De titel die meegegeven wordt</param>
        /// <returns>Return een outfit</returns>
        /// <exception cref="TemporaryExceptions">TemporaryExceptions">Bij verbindingsproblemen met de database</exception>
        /// <exception cref="PermanentExceptions">PermanentExceptions">Bij fouten in het programma(dus bijv querys verkeerd opgesteld door de programeur)</exception>
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
