using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividuUseCase1Interface
{
    public class Gebruiker
    {
        public string Wachtwoord { get; }
        public string Gerbuikersnaam { get; }
        public string Alias { get; }
        public List<OutfitDTO> Outfits { get; } = new List<OutfitDTO>();
        public List<OnderdeelDTO> Onderdelen { get; } = new List<OnderdeelDTO>();
        //Hier geen DTO's toch?

        public Gebruiker(string gerbuikersnaam, string wachtwoord, string alias)
        {
            this.Gerbuikersnaam = gerbuikersnaam;
            this.Wachtwoord = wachtwoord;
            this.Alias = alias;
        }

        public Gebruiker(GebruikerDTO dto)
        {
            this.Gerbuikersnaam = dto.Gerbuikersnaam;
            this.Wachtwoord = dto.Wachtwoord;
            this.Alias = dto.Alias;
        }

        public override string ToString()
        {
            return $"{this.Alias}";
        }
    }
}
