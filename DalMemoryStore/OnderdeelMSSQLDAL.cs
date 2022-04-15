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
        ///Voeg de waardes in OutfitTabel, specificeer welk gebruikerID de outfit toevoegd dmv de alias
        /// </summary>

        public void VoegOnderdeelToe(GebruikerDTO gebruiker, OnderdeelDTO onderdeel)
        {
            OpenConnection();
            if (!BestaandeTitleNaamOnder(onderdeel.Titel))
            {
                OpenConnection();
                string query = @"INSERT INTO Onderdeel VALUES((SELECT GebrID FROM Gebruiker WHERE Alias = @alias), @titel, @prijs, @category, @path)";
                SqlCommand command = new SqlCommand(query, this.connection);
                command.Parameters.AddWithValue("@alias", gebruiker.Alias);
                command.Parameters.AddWithValue("@titel", onderdeel.Titel);
                command.Parameters.AddWithValue("@prijs", onderdeel.Prijs);
                command.Parameters.AddWithValue("@category", onderdeel.DeCategory.ToString());
                command.Parameters.AddWithValue("@path", onderdeel.FileAdress);
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }
        
        public List<OnderdeelDTO> GetAllOnderdelenVanGebr(string alias)
        {
            List<OnderdeelDTO> Onderdelen = new List<OnderdeelDTO>();
            OpenConnection();
            SqlCommand command = new SqlCommand(@"SELECT * FROM Onderdeel WHERE GebrID = @id", this.connection);
            command.Parameters.AddWithValue("@id", GetUserID(alias));
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Onderdelen.Add(new OnderdeelDTO(
                    reader["Titel"].ToString(),
                    Convert.ToInt32(reader["Prijs"]),
                    reader["FileAdress"].ToString(),
                    (OnderdeelDTO.OnderdeelCategory)Enum.Parse(typeof(OnderdeelDTO.OnderdeelCategory), reader["Categorie"].ToString())));
                }
            }
            CloseConnection();
            return Onderdelen;
        }

        public List<OnderdeelDTO> GetAllOnderdelen()
        {
            List<OnderdeelDTO> Onderdelen = new List<OnderdeelDTO>();
            OpenConnection();
            SqlCommand command = new SqlCommand(@"SELECT * FROM Onderdeel", this.connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Onderdelen.Add(new OnderdeelDTO(
                    reader["Titel"].ToString(),
                    Convert.ToInt32(reader["Prijs"]),
                    reader["FileAdress"].ToString(),
                    (OnderdeelDTO.OnderdeelCategory)Enum.Parse(typeof(OnderdeelDTO.OnderdeelCategory), reader["Categorie"].ToString())));
                }
            }
            CloseConnection();
            return Onderdelen;
        }
        
        public bool IsOnderdeel(string titel)
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

        /// <summary>
        /// GetOnderdeel ga ik later gebruiken voor filteren bijv, zoeken op naam etc.
        /// </summary>

        public OnderdeelDTO GetOnderdeel(string titel)
        {
            OnderdeelDTO onderdeel = null;
            //Recap
            OpenConnection();
            SqlCommand command = new SqlCommand(@"SELECT * FROM Onderdeel WHERE Titel = @titel", this.connection);
            command.Parameters.AddWithValue("@titel", titel);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    onderdeel = new OnderdeelDTO(
                    reader["Titel"].ToString(),
                    Convert.ToInt32(reader["Prijs"]),
                    reader["FileAdress"].ToString(),
                    (OnderdeelDTO.OnderdeelCategory)Enum.Parse(typeof(OnderdeelDTO.OnderdeelCategory), reader["Categorie"].ToString()));
                }
            }
            CloseConnection();
            return onderdeel;
        }
    }

}
