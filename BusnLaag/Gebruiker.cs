using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividuUseCase1Interface
{
    internal class Gebruiker
    {
        public string Wachtwoord { get; }
        public string Gerbuikersnaam { get; }
        public string Alias { get; }
        public List<Outfit> Outfits { get; } = new List<Outfit>();
        public List<Onderdeel> Onderdelen { get; } = new List<Onderdeel>();

        public Gebruiker(string gerbuikersnaam, string wachtwoord, string alias)
        {
            this.Gerbuikersnaam = gerbuikersnaam;
            this.Wachtwoord = wachtwoord;
            this.Alias = alias;
        }

        public void VoegOutfitToe(Outfit outfit)
        {
            if (!this.Outfits.Contains(outfit))
            {
                this.Outfits.Add(outfit);
            }
        }

        public void VerwijderOutfit(Outfit outfit)
        {
            if (this.Outfits.Contains(outfit))
            {
                this.Outfits.Remove(outfit);
            }
        }

        public void VoegOnderdeelToe(Onderdeel onderdeel)
        {
            if (!this.Onderdelen.Contains(onderdeel))
            {
                this.Onderdelen.Add(onderdeel);
            }
        }

        public void VerwijderOnderdeel(Onderdeel onderdeel)
        {
            if (this.Onderdelen.Contains(onderdeel))
            {
                this.Onderdelen.Remove(onderdeel);
            }
        }

        public List<Outfit> OutfitsPerCategory(Outfit.Category category)
        {
            List<Outfit> outfitPerCategory = new List<Outfit>();
            foreach(var outfit in this.Outfits)
            {
                if(outfit.DeCategory == category)
                {
                    outfitPerCategory.Add(outfit);
                }
            }
            return outfitPerCategory;
        }

        public List<Onderdeel> OnderdeelPerCategory(Onderdeel.Category category)
        {
            List<Onderdeel> outfitPerCategory = new List<Onderdeel>();
            foreach (var onderdeel in this.Onderdelen)
            {
                if (onderdeel.DeCategory == category)
                {
                    outfitPerCategory.Add(onderdeel);
                }
            }
            return outfitPerCategory;
        }

        public override string ToString()
        {
            return $"{this.Alias}";
        }
    }
}
