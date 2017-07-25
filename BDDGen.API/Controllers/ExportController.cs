using BDDGen.Types.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Composition;
using System.Composition.Hosting;
using BDDGen.Types.Interfaces;
using BDDGen.API.Services;
using BDDGen.API.Exceptions;
using Microsoft.Net.Http.Headers;

namespace BDDGen.API.Controllers
{
    [Route("api/[controller]")]
    public class ExportController : Controller
    {
        [Import]
        IList<IExporter> _exporters { get; set; }
        public ExportController(ICompositionService compositionService)
        {
            _exporters = compositionService.GetExports<IExporter>().ToList();
        }

        [HttpPost]
        public FileStreamResult Export([FromBody] ExportRequest request)
        {
            var exporter = _exporters.Where(r => r.FriendlyName.Equals(request.ExporterName)).FirstOrDefault();
            if (exporter == null)
            {
                throw new ExporterNotFoundException(request.ExporterName);
            }
            using (var stream = exporter.Export(request.SuiteToExport))
            {
                var invalids = System.IO.Path.GetInvalidFileNameChars();
                var newName = String.Join("_", request.SuiteToExport.Name.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
                var result = new FileStreamResult(stream, new MediaTypeHeaderValue("application/octet-stream"));
                result.FileDownloadName = newName + DateTime.Now.ToString("yyyyMMddHHmmss");
                return result;
            }
            
        }        
    }
}
