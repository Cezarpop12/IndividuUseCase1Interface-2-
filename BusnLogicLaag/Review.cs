using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{
    public class Review
    {
        public DateTime DatumTijd { get; }
        public Gebruiker Gebruiker { get; }
        public string StukTekst { get; }

        public Review(string stuktekst, Gebruiker gebruiker, DateTime datumtijd)
        {
            StukTekst = stuktekst;
            Gebruiker = gebruiker;
            DatumTijd = datumtijd;
        }

        public Review(ReviewDTO dto)
        {
            StukTekst = dto.StukTekst;
            Gebruiker = new Gebruiker(dto.Gebruiker);
            DatumTijd = DateTime.Now;
        }

        internal ReviewDTO GetDTO()
        {
            ReviewDTO dto = new ReviewDTO(StukTekst, Gebruiker.GetDTO(), DatumTijd);
            return dto;
        }

        public override string ToString()
        {
            return $"({DatumTijd})  {Gebruiker.Alias}:  {StukTekst}";
        }
    }
}
