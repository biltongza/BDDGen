using BDDGen.Types.Contracts;
using BDDGen.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDSuiteModel
{
    public class Then : IScenarioComponent
    {
        public Then(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public ScenarioComponentType ComponentType { get { return ScenarioComponentType.Actor; } }

        public string Name { get; }

        public string Value { get; }
    }
}
