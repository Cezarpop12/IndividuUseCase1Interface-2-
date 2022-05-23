using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicLaag
{
    /// <summary>
    /// Base classe van een kledingstuk en outfit. Deze hebben beiden een prijs, titel en fileadress
    /// </summary>
    public abstract class Kleding
    {
        public int Prijs { get; set; }
        public string Titel { get; set; }
        public string FileAdress { get; set; }

        public Kleding(string titel, int prijs, string fileAdress)
        {
            this.Titel = titel;
            this.Prijs = prijs;
            this.FileAdress = fileAdress;
        }

        public override string ToString()
        {
            return $"Naam: {Titel}\nPrijs: {Prijs}";
        }
    }
}
