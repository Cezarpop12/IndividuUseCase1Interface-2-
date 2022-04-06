using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQLSERVER
{
    public class GebruikerMSSQLDAL : IGebruikerContainer
    {
        public List<OutfitDTO> Outfits { get; } = new List<OutfitDTO>();
        public List<OnderdeelDTO> Onderdelen { get; } = new List<OnderdeelDTO>();

        public void VoegOutfitToe(OutfitDTO outfit)
        {
            if (!this.Outfits.Contains(outfit))
            {
                this.Outfits.Add(outfit);
            }
        }

        public void VerwijderOutfit(OutfitDTO outfit)
        {
            if (this.Outfits.Contains(outfit))
            {
                this.Outfits.Remove(outfit);
            }
        }

        public void VoegOnderdeelToe(OnderdeelDTO onderdeel)
        {
            if (!this.Onderdelen.Contains(onderdeel))
            {
                this.Onderdelen.Add(onderdeel);
            }
        }

        public void VerwijderOnderdeel(OnderdeelDTO onderdeel)
        {
            if (this.Onderdelen.Contains(onderdeel))
            {
                this.Onderdelen.Remove(onderdeel);
            }
        }

        public List<OutfitDTO> OutfitsPerCategory(OutfitDTO.Category category)
        {
            List<OutfitDTO> outfitPerCategory = new List<OutfitDTO>();
            foreach (var outfit in this.Outfits)
            {
                if (outfit.DeCategory == category)
                {
                    outfitPerCategory.Add(outfit);
                }
            }
            return outfitPerCategory;
        }

        public List<OnderdeelDTO> OnderdeelPerCategory(OnderdeelDTO.Category category)
        {
            List<OnderdeelDTO> outfitPerCategory = new List<OnderdeelDTO>();
            foreach (var onderdeel in this.Onderdelen)
            {
                if (onderdeel.DeCategory == category)
                {
                    outfitPerCategory.Add(onderdeel);
                }
            }
            return outfitPerCategory;
        }
    }
}
