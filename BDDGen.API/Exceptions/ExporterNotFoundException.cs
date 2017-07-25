using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDGen.API.Exceptions
{
    public class ExporterNotFoundException : Exception
    {
        public ExporterNotFoundException() : base()
        {

        }
        public ExporterNotFoundException(string message) : base(message)
        {

        }
    }
}
