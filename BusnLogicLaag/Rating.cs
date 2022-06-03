using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{
    /// <summary>
    /// Een outfit kan een rating hebben en hoort bij een bepaalde outfit
    /// Deze rating wordt in sterren gegeven (een int "Waarde")
    /// </summary>
    public class Rating
    {
        public int Waarde { get; set; }
        public int OutfitID { get; set; }
        public int ID { get; set; }

        public Rating(int id, int waarde, int outfitID)
        {
            this.ID = id;
            this.Waarde = waarde;
            this.OutfitID = outfitID;
        }

        public Rating(RatingDTO dto)
        {
            this.ID = dto.ID;
            this.Waarde = dto.Waarde;
            this.OutfitID = dto.OutfitID;
        }

        internal RatingDTO GetDTO()
        {
            RatingDTO dto = new RatingDTO(ID, Waarde, OutfitID);
            return dto;
        }
    }
}
