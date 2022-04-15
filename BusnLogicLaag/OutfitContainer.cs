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

        public void VoegOutfitToe(Gebruiker gebruiker, Outfit outfit)
        {
            GebruikerDTO gebrdto = gebruiker.GetDTO();            
            OutfitDTO outfitdto = outfit.GetDTO();
            Container.VoegOutfitToe(gebrdto, outfitdto);
        }
        
        public List<Outfit> GetAllOutfitsVanGebr(string alias)
        {
            List<OutfitDTO> outfitdtos = Container.GetAllOutfitsVanGebr(alias);
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



        /// <summary>
        /// Voor later.
        /// </summary>
        /// <returns></returns>
        
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



       /// <summary>
       /// Voor later.
       /// </summary>

        public Outfit GetOutfit(string titel)
        {
            OutfitDTO outfitdto = Container.GetOutfit(titel);
            Outfit outfit = new Outfit(outfitdto);
            return outfit;
        }

        //public void VerwijderOutfit(Outfit outfit)
        //{
        //    OutfitDTO dto = outfit.GetDTO();
        //    Container.VerwijderOutfit(dto);
        //}
    }
}
