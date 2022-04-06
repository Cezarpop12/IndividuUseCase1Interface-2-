using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividuUseCase1Interface { 

    public abstract class Kleding
    {
        public int Prijs { get; }
        public string Naam { get; }
        public string FileAdress { get; }

        public Kleding(string naam, int prijs, string FileAdress)
        {
            this.Naam = naam;
            this.Prijs = prijs;
            this.FileAdress = FileAdress;
        }

        public override string ToString()
        {
            return $"Naam: {this.Naam}\nPrijs: {this.Prijs}";
        }
    }
}
