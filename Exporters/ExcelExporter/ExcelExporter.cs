using BDDGen.Types.Interfaces;
using System;
using System.IO;
using System.Composition;
using BDDGen.Types.Models;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ExcelExporter
{
    [Export(typeof(IExporter))]
    public class ExcelExporter : IExporter
    {
        public string ContentType { get { return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; } }
        public string FriendlyName { get { return "Excel"; } }
        public Stream Export(Suite suite)
        {
            throw new NotImplementedException();
        }
    }
}
