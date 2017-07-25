using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDGen.API.Services
{
    public interface ICompositionService
    {
        IEnumerable<T> GetExports<T>();
        IEnumerable<T> GetExports<T>(string contractName);
    }
}
