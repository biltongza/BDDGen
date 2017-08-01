using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BDDGen.Types.Contracts
{
    public interface ISuiteModelBinder : IModelBinder
    {
        Type ModelType { get; }
    }
}
