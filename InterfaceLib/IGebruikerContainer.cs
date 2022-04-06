using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface IGebruikerContainer
    {
        public void VoegOutfitToe(OutfitDTO outfit);
        public void VerwijderOutfit(OutfitDTO outfit);
        public void VoegOnderdeelToe(OnderdeelDTO onderdeel);
        public void VerwijderOnderdeel(OnderdeelDTO onderdeel);
        public List<OutfitDTO> OutfitsPerCategory(OutfitDTO.Category category);
        public List<OnderdeelDTO> OnderdeelPerCategory(OnderdeelDTO.Category category);
    }
}
