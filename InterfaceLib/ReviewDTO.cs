using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public class ReviewDTO
    {
        public int ID { get; set; }
        public int OutfitID { get; set; }

        public string Titel { get; set; }
        public DateTime DatumTijd { get; }
        public string StukTekst { get; set; }

        public ReviewDTO(int id, int outfitID, string titel, string stuktekst, DateTime datumtijd)
        {
            this.Titel = titel;
            this.StukTekst = stuktekst;
            this.DatumTijd = datumtijd;
            this.ID = id;
            this.OutfitID = outfitID;
        }
    }
}
