using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{
    /// <summary>
    /// Een gebruiker heeft een gebruikersnaam en alias die beiden uniek zijn.
    /// </summary>
    public class Gebruiker
    {
        public int ID { get; set; }
        public string Gerbuikersnaam { get; set; }
        public string Alias { get; set; }

        public Gebruiker(int id, string gerbuikersnaam, string alias)
        {
            this.Gerbuikersnaam = gerbuikersnaam;
            this.Alias = alias;
            this.ID = id;
        }

        public Gebruiker(GebruikerDTO dto)
        {
            this.ID = dto.ID;
            this.Gerbuikersnaam = dto.Gerbuikersnaam;
            this.Alias = dto.Alias;
        }
        
        public GebruikerDTO GetDTO()
        {
            GebruikerDTO dto = new GebruikerDTO(ID, Gerbuikersnaam, Alias);
            return dto;
        }

        public override string ToString()
        {
            return $"{Alias}";
        }
    }
}
