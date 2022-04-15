using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{
    public class Gebruiker
    {
        public string Gerbuikersnaam { get; set; }
        public string Alias { get; set; }
        public List<Outfit> Outfits { get; set; } = new List<Outfit>();
        public List<Onderdeel> Onderdelen { get; set; } = new List<Onderdeel>();

        public Gebruiker(string gerbuikersnaam, string alias)
        {
            Gerbuikersnaam = gerbuikersnaam;
            Alias = alias;
        }

        /// <summary>
        /// Van een dto maak je een domein.
        /// </summary>

        public Gebruiker(GebruikerDTO dto)
        {
            this.Gerbuikersnaam = dto.Gerbuikersnaam;
            this.Alias = dto.Alias;
        }
        
        public GebruikerDTO GetDTO()
        {
            GebruikerDTO dto = new GebruikerDTO(Gerbuikersnaam, Alias);
            return dto;
        }

        public override string ToString()
        {
            return $"{Alias}";
        }
    }
}
