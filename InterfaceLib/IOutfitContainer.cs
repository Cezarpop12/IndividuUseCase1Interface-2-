using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface IOutfitContainer
    {
        public void VoegOutfitToe(GebruikerDTO gebruiker, OutfitDTO outfit);
        //public void VerwijderOutfit(OutfitDTO outfit);
        public List<OutfitDTO> GetAllOutfitsVanGebr(string alias);
        public List<OutfitDTO> GetAllOutfits();
        public OutfitDTO GetOutfit(string titel);
        public bool IsOutfit(string titel);
    }
}
