using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public abstract class KledingDTO
    {
        public int Prijs { get; set; }
        public string Titel { get; set; }
        public string FileAdress { get; set; }
        
        public KledingDTO(string titel, int prijs, string FileAdress)
        {
            this.Titel = titel;
            this.Prijs = prijs;
            this.FileAdress = FileAdress;
        }

    }
}
