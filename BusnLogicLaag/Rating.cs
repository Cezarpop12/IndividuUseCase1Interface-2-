using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{
    /// <summary>
    /// Een outfit kan een rating hebben 
    /// Deze rating wordt in sterren gegeven (een int waarde)
    /// </summary>
    public class Rating
    {
        public int Waarde { get; set; }
        public int ID { get; set; }

        public Rating(int id, int waarde)
        {
            this.ID = id;
            this.Waarde = waarde;
        }

        public Rating(RatingDTO dto)
        {
            this.ID = dto.ID;
            this.Waarde = dto.Waarde;
        }

        internal RatingDTO GetDTO()
        {
            RatingDTO dto = new RatingDTO(ID, Waarde);
            return dto;
        }
    }
}
