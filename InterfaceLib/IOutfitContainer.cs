using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface IOutfitContainer
    {
        public void VoegOutfitToe(int GebrID, OutfitDTO outfit);
        public List<OutfitDTO> GetAllOutfitsVanGebr(int GebrID);
        public List<OutfitDTO> GetAllOutfits();
        public List<OutfitDTO> GetLast4Outfits();
        public OutfitDTO GetOutfit(int id);
        public void DeleteOutfit(OutfitDTO outfit);
        public void UpdateOutfit(OutfitDTO outfit);
    }
}
