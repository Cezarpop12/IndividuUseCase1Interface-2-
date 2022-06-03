using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface IRatingContainer
    {
        public void AddRating(int id, int waarde);
        public int GemRatingBijOutfit(int id);
    }
}
