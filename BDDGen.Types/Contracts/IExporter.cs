using BDDGen.Types.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDGen.Types.Contracts
{
    public interface IExporter
    {
        string FriendlyName { get; }
        string ContentType { get; }
        string Creator { get; }
        Stream Export(Suite suite);
    }
}
