using BDDGen.Types.Interfaces;
using System;
using System.IO;
using System.Composition;
using BDDGen.Types.Models;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using System.Linq;

namespace ExcelExporter
{
    [Export(typeof(IExporter))]
    public class ExcelExporter : IExporter
    {
        public string ContentType { get { return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; } }
        public string FriendlyName { get { return "Excel"; } }

        public string Creator { get { return "Logan Dam"; } }

        public Stream Export(Suite suite)
        {
            MemoryStream ms = new MemoryStream();

            var spreadsheet = CreateBlankSpreadsheet(ms);

            SheetData data = spreadsheet.WorkbookPart.WorksheetParts.First().Worksheet.GetFirstChild<SheetData>();


            var headerRow = CreateHeader(suite);
            data.AppendChild(headerRow);
            data.AppendChild(new Row());

            foreach (var story in suite.Stories)
            {
                var storyHeader = new Row();
                storyHeader.Append(
                    ConstructCell("Story: ", CellValues.String),
                    ConstructCell(story.Name, CellValues.String)
                );
                data.AppendChild(storyHeader);
                var storyDescription = new Row();
                storyDescription.Append(ConstructCell(story.Description, CellValues.String));
                data.AppendChild(storyDescription);
                data.AppendChild(new Row());

                foreach (var scenario in story.Scenarios)
                {
                    var scenarioRow = new Row();
                    scenarioRow.Append(ConstructCell(scenario.Name, CellValues.String));
                    data.AppendChild(scenarioRow);

                    string lastVerb = null;
                    foreach (var component in scenario.Components)
                    {
                        var componentRow = new Row();
                        string verb = null;
                        string verbToUse = null;
                        if (!component.Name.Equals(lastVerb))
                        {
                            verb = component.Name;
                            verbToUse = verb;
                        }
                        else
                        {
                            verbToUse = "AND";
                        }
                        componentRow.Append(
                            ConstructCell(verbToUse, CellValues.String),
                            ConstructCell(component.Value, CellValues.String));
                        data.AppendChild(componentRow);
                    }
                    spreadsheet.Save();

                }
                data.AppendChild(new Row());
            }

            spreadsheet.Save();

            return ms;
        }

        private static Row CreateHeader(Suite suite)
        {
            Row headerRow = new Row();

            headerRow.Append(
                ConstructCell(suite.Name, CellValues.String),
                ConstructCell(suite.Description, CellValues.String)
            );
            return headerRow;

        }

        private static Cell ConstructCell(string value, CellValues dataType)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType)
            };
        }

        private SpreadsheetDocument CreateBlankSpreadsheet(Stream stream)
        {
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);
            // Add a WorkbookPart to the document.
            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();

            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            // Add Sheets to the Workbook.
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            // Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "mySheet" };
            sheets.Append(sheet);

            workbookpart.Workbook.Save();

            return spreadsheetDocument;
        }
    }
}
