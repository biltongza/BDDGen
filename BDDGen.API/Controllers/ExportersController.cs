using BDDGen.API.Services;
using BDDGen.Types.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDGen.API.Controllers
{
    [Route("api/[controller]")]
    public class ExportersController : Controller
    {
        [Import]
        IList<IExporter> _exporters { get; set; }
        public ExportersController(ICompositionService compositionService)
        {
            _exporters = compositionService.GetExports<IExporter>().ToList();
        }

        [HttpGet]
        public List<string> GetExporters()
        {
            return _exporters.Select(e => e.FriendlyName).ToList();
        }
    }
}
