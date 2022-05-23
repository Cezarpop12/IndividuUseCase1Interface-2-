using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQLSERVER
{
    public class PermanentExceptions : Exception
    {
        public string errorMessage { get; set; }
        public string? PermanentErrorMessage { get; set; }
        //optionele error message als 2e in de constructor

        public PermanentExceptions(string errormessage, string? permanentErrorMessage = null) : base(errormessage)
        {
            this.errorMessage = errormessage;
            this.PermanentErrorMessage = permanentErrorMessage;
        }

        public string GetFullError()
        {
            return $"{errorMessage} {PermanentErrorMessage}";
        }
        //To be continued..
    }
}
