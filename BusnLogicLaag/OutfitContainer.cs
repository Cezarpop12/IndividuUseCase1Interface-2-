using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{
    public class OutfitContainer
    {
        private readonly IOutfitContainer Container;

        public OutfitContainer(IOutfitContainer container)
        {
            this.Container = container;
        }

        public void VoegOutfitToe(int GebrID, Outfit outfit)
        {
            OutfitDTO outfitdto = outfit.GetDTO();
            Container.VoegOutfitToe(GebrID, outfitdto);
        }

        public List<Outfit> GetAllOutfitsVanGebr(int GebrID)
        {
            List<OutfitDTO> outfitdtos = Container.GetAllOutfitsVanGebr(GebrID);
            List<Outfit> outfits = new List<Outfit>();
            foreach (OutfitDTO outfitdto in outfitdtos)
            {
                outfits.Add(new Outfit(outfitdto));
            }
            return outfits;
        }
        
        public bool IsOutfit(string titel)
        {
            return Container.IsOutfit(titel);
        }

        public void DeleteOutfit(Outfit outfit)
        {
            OutfitDTO dto = outfit.GetDTO();
            Container.DeleteOutfit(dto);
        }

        public void UpdateOutfit(Outfit outfit)
        {
            OutfitDTO outfitdto = outfit.GetDTO();
            Container.UpdateOutfit(outfitdto);
        }

        public List<Outfit> GetAllOutfits()
        {
            List<OutfitDTO> outfitdtos = Container.GetAllOutfits();
            List<Outfit> outfits = new List<Outfit>();
            foreach (OutfitDTO outfitdto in outfitdtos)
            {
                outfits.Add(new Outfit(outfitdto));
            }
            return outfits; 
        }

        public Outfit GetOutfit(string titel)
        {
            OutfitDTO outfitdto = Container.GetOutfit(titel);
            Outfit outfit = new Outfit(outfitdto);
            return outfit;
        }
    }
}
