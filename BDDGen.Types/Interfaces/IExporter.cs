using BDDGen.Types.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDGen.Types.Interfaces
{
    public interface IExporter
    {
        string FriendlyName { get; }
        string ContentType { get; }
        Stream Export(Suite suite);
    }
}
