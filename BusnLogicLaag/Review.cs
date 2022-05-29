using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{
    /// <summary>
    /// Een review heeft een ID en een vaste datum en tijd wanneer het is geplaatst
    /// Een review hoort bij een bepaalde gebruiker en moet een titel hebben
    /// </summary>
    public class Review
    {
        public int ID { get; set; }
        public string Titel { get; set; }
        public DateTime DatumTijd { get; }
        public string StukTekst { get; set; }

        public Review(int id, string titel, string stuktekst, Gebruiker gebruiker, DateTime datumtijd)
        {
            Titel = titel;
            StukTekst = stuktekst;
            DatumTijd = datumtijd;
            this.ID = id;
        }

        public Review(ReviewDTO dto)
        {
            Titel = dto.Titel;
            StukTekst = dto.StukTekst;
            DatumTijd = DateTime.Now;
            ID = dto.ID;
        }

        internal ReviewDTO GetDTO()
        {
            ReviewDTO dto = new ReviewDTO(ID, Titel, StukTekst, DatumTijd);
            return dto;
        }

        public override string ToString()
        {
            return $"({DatumTijd}) :  {StukTekst}";
        }
    }
}
