using BDDGen.Types.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BDDSuiteModel
{
    public class BDDSuiteModelBinder : ISuiteModelBinder
    {
        public Type ModelType { get { return typeof(BDDSuite); } }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            throw new NotImplementedException();
        }
    }
}
