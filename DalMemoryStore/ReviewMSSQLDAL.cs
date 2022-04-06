using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQLSERVER
{
    public class ReviewMSSQLDAL : IReviewContainer
    {
        public bool MaxWoordenCheck(string beschrijving)
        {
            string[] Woorden = beschrijving.Split(' ');
            return Woorden.Length <= 50;
        }
    }
}
