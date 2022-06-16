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

        public PermanentExceptions(string errorMessage, string? perError = null) : base(errorMessage)
        {
            this.errorMessage = errorMessage;
            PermanentErrorMessage = perError;
        }

        public string GetFullError()
        {
            return $"{errorMessage} {PermanentErrorMessage}";
        }
    }
}
