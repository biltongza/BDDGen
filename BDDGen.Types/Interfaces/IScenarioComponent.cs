using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDDGen.Types.Models;

namespace BDDGen.Types.Interfaces
{
    public interface IScenarioComponent
    {
        ScenarioComponentType ComponentType { get; set; }
        string Name { get; set; }
        string Value { get; set; }
    
    }
}
