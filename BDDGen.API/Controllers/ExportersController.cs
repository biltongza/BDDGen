using BDDGen.API.Services;
using BDDGen.API.Services.Contracts;
using BDDGen.Types.Interfaces;
using BDDGen.Types.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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
        public List<ExporterDetail> GetExporters()
        {
            return _exporters.Select(e => 
            {
                var typeInfo = e.GetType().GetTypeInfo();
                return new ExporterDetail
                {
                    FriendlyName = e.FriendlyName,
                    FullyQualifiedName = typeInfo.FullName,
                    Version = typeInfo.Assembly.GetName().Version.ToString(),
                    Creator = e.Creator
                };
            }).ToList();
        }
    }
}
