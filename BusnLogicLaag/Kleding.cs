using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{

    public abstract class Kleding
    {
        public int Prijs { get; set; }
        public string Titel { get; set; }
        public string FileAdress { get; set; }

        public Kleding(string titel, int prijs, string FileAdress)
        {
            this.Titel = titel;
            this.Prijs = prijs;
            this.FileAdress = FileAdress;
        }

        public override string ToString()
        {
            return $"Naam: {Titel}\nPrijs: {Prijs}";
        }
    }
}
