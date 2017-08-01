using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDDGen.Types.Models;

namespace BDDGen.Types.Contracts
{
    public interface IScenarioComponent
    {
        ScenarioComponentType ComponentType { get;}
        string Name { get;}
        string Value { get;}
    
    }
}
