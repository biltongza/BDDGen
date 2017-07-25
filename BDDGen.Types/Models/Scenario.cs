using BDDGen.Types.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDGen.Types.Models
{
    public class Scenario
    {
        public string Name { get; set; }
        public IList<IScenarioComponent> Components { get; set; }
    }
}
