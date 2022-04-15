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

        public void VoegOutfitToe(GebruikerDTO gebruiker, OutfitDTO outfit)
        {
            OpenConnection();
            if (!BestaandeTitleNaamOut(outfit.Titel))
            {
                OpenConnection();
                string query = @"INSERT INTO Outfit VALUES((SELECT GebrID FROM Gebruiker WHERE Alias = @alias), @titel, @prijs, @category, @path)";
                SqlCommand command = new SqlCommand(query, this.connection);
                command.Parameters.AddWithValue("@alias", gebruiker.Alias);
                command.Parameters.AddWithValue("@titel", outfit.Titel);
                command.Parameters.AddWithValue("@prijs", outfit.Prijs);
                command.Parameters.AddWithValue("@category", outfit.DeCategory.ToString());
                command.Parameters.AddWithValue("@path", outfit.FileAdress);
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public List<OutfitDTO> GetAllOutfitsVanGebr(string alias)
        {
            List<OutfitDTO> Outfits = new List<OutfitDTO>();
            OpenConnection();
            SqlCommand command = new SqlCommand(@"SELECT * FROM Outfit WHERE GebrID = @id", this.connection);
            command.Parameters.AddWithValue("@id", GetUserID(alias));
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Outfits.Add(new OutfitDTO(
                    reader["Titel"].ToString(),
                    Convert.ToInt32(reader["Prijs"]),
                    reader["FileAdress"].ToString(),
                    (OutfitDTO.OutfitCategory)Enum.Parse(typeof(OutfitDTO.OutfitCategory), reader["Categorie"].ToString())));
                }
            }
            CloseConnection();
            return Outfits;
        }
        
        public List<OutfitDTO> GetAllOutfits()
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
                    reader["Titel"].ToString(),
                    Convert.ToInt32(reader["Prijs"]),
                    reader["FileAdress"].ToString(),
                    (OutfitDTO.OutfitCategory)Enum.Parse(typeof(OutfitDTO.OutfitCategory), reader["Categorie"].ToString())));
                }
            }
            CloseConnection();
            return Outfits;
        }
        
        public bool IsOutfit(string titel)
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

        /// <summary>
        /// GetOutfit ga ik later gebruiken voor filteren bijv, zoeken op naam etc.
        /// </summary>

        public OutfitDTO GetOutfit(string titel)
        {
            OutfitDTO outfit = null;
            //Recap
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
                    reader["Titel"].ToString(),
                    Convert.ToInt32(reader["Prijs"]),
                    reader["FileAdress"].ToString(),
                    (OutfitDTO.OutfitCategory)Enum.Parse(typeof(OutfitDTO.OutfitCategory), reader["Categorie"].ToString()));
                }
            }
            CloseConnection();
            return outfit;
        }        
    }
}
