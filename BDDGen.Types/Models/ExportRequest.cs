using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDGen.Types.Models
{
    public class ExportRequest
    {
        public string ExporterName { get; set; }
        public Suite SuiteToExport { get; set; }
    }
}
