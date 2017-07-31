using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Composition;
using System.Composition.Hosting;
using Microsoft.Extensions.Options;
using BDDGen.API.Services.Contracts;

namespace BDDGen.API.Services
{
    public class CompositionService : ICompositionService
    {
        ExporterOptions options;
        ContainerConfiguration config;
        public CompositionService(IOptions<ExporterOptions> optionsAccessor)
        {
            options = optionsAccessor.Value;
            config = new ContainerConfiguration().WithAssembliesInPath(options.ExporterLocation);
        }
        public IEnumerable<T> GetExports<T>(string contractName)
        {
            using (var container = config.CreateContainer())
            {
                return container.GetExports<T>(contractName);
            }
        }

        public IEnumerable<T> GetExports<T>()
        {
            return GetExports<T>(null);
        }
    }
}
