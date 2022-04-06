using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public class ReviewDTO
    {
        public DateTime DatumTijd { get; }
        public GebruikerDTO Gebruiker { get; }
        public string StukTekst { get; }

        public ReviewDTO(string stuktekst, GebruikerDTO gebruiker)
        {
            this.StukTekst = stuktekst;
            this.Gebruiker = gebruiker;
            this.DatumTijd = DateTime.Now;
        }
    }
}
