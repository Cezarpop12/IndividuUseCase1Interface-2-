using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividuUseCase1Interface
{
    internal class Review
    {
        public DateTime DatumTijd { get;}
        public Gebruiker Gebruiker { get; }
        public string StukTekst { get; }

        public Review(string stuktekst, Gebruiker gebruiker)
        {
            this.StukTekst = stuktekst;
            this.Gebruiker = gebruiker;
            this.DatumTijd = DateTime.Now;
        }

        public Review(ReviewDTO dto)
        {
            this.StukTekst = dto.StukTekst;
            this.Gebruiker = dto.Gebruiker;
            //weer namespace error
            this.DatumTijd = DateTime.Now;
        }

        public override string ToString()
        {
            return $"({this.DatumTijd})  {this.Gebruiker.Alias}:  {this.StukTekst}";
        }
    }
}
