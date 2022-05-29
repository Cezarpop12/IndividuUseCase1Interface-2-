using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public class RatingDTO
    {
        public int Waarde { get; set; }
        public int ID { get; set; }

        public RatingDTO(int id, int waarde)
        {
            this.ID = id;
            this.Waarde = waarde;
        }
    }
}
