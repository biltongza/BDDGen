using BDDGen.API.Services.Contracts;
using BDDGen.Types.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDGen.API.Controllers
{
    [Route("/api/[controller]")]
    public class SuiteController : Controller
    { 
        private List<ISuiteModelBinder> _binders;
        public SuiteController(ICompositionService compositionService)
        {
            _binders = compositionService.GetExports<ISuiteModelBinder>().ToList();
        }

        [HttpGet("/types")]
        public IList<string> GetSuiteModels()
        {
            return _binders.Select(r => r.ModelType.FullName).ToList();
        }
    }
}
