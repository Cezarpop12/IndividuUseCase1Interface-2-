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
        public OutfitDTO GetOutfit(string titel);
        public void DeleteOutfit(OutfitDTO outfit);
        public void UpdateOutfit(OutfitDTO outfit);
        public bool IsOutfit(string titel);
    }
}
