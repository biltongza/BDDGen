using BDDGen.Types.Contracts;
using System;
using System.Collections.Generic;

namespace BDDSuiteModel
{
    public class BDDSuite : ISuiteModel
    {
        public string Name { get { return "BDD"; } }
        public string Creator { get { return "Logan Dam"; } }

        public IList<Type> ComponentTypes { get { return new List<Type> { typeof(Given), typeof(When), typeof(Then) }; } }
    }
}
