using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDGen.Types.Contracts
{
    public interface ISuiteModel
    {
        string Name { get; }
        string Creator { get; }
        IList<Type> ComponentTypes { get; }
    }
}
