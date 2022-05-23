using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQLSERVER
{
    public class TemporaryExceptions : Exception
    {
        public readonly Exception Ex;
        public string errorMessage { get; set; }
        public string? TemporaryErrorMessage { get; set; }
        //optionele error message als 2e in de constructor

        public TemporaryExceptions(Exception ex) 
        {
            this.Ex = ex;
        }

        public string GetFullError()
        {
            return $"{Ex.Message} {TemporaryErrorMessage}";
        }
        //To be continued..
    }
}
