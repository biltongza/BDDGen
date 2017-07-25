using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDGen.Types.Models
{
    public class Story
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Scenario> Scenarios { get; set; }

    }
}
