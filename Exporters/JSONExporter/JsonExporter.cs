using System;
using Newtonsoft.Json;
using BDDGen.Types.Interfaces;
using BDDGen.Types.Models;
using System.IO;
using System.Composition;

namespace JSONExporter
{
    [Export(typeof(IExporter))]
    public class JsonExporter : IExporter
    {
        public string FriendlyName { get { return "JSON"; } }

        public string ContentType { get { return "application/json"; } }

        public Stream Export(Suite suite)
        {
            MemoryStream ms = new MemoryStream();
            StreamWriter writer = new StreamWriter(ms);
            new JsonSerializer().Serialize(writer, suite);
            writer.Flush();
            ms.Flush();
            return ms;
        }
    }
}
