using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using OxyPlot;
using OxyPlot.WindowsForms;

namespace Pryamolineynost
{
    public class PdfService
    {
        public const int GraphicWidth = 575;
        //public const int GraphicHeight = 370;
        public PdfDocument CreateDocument(string[][] dbValues, string[][] dataListValues, PlotModel plotModel)
        {
            var document = new Document();
            var png = GetPNG(plotModel);
            BuildDocument(document, dbValues, dataListValues, png);
            var pdfRender = new PdfDocumentRenderer();
            pdfRender.Document = document;
            pdfRender.RenderDocument();
            return pdfRender.PdfDocument;
        }

        private MemoryStream GetPNG(PlotModel plotModel)
        {
            var stream = new MemoryStream();
            var pngExporter = new PngExporter { Width = 1280, Height = 1024 };
            pngExporter.Export(plotModel, stream);
            return stream;
        }
        
        private void AddDbValues(Document document, string[][] dbValues)
        {
            var table = document.LastSection.AddTable();
            table.AddColumn("11cm");
            table.AddColumn("9cm");

            for (var i = 0; i < dbValues.Length; i++)
            {
                var row = table.AddRow();

                for (var j = 0; j < dbValues[0].Length; j++)
                {
                    row.Cells[j].AddParagraph(dbValues[i][j]);
                    if (i % 2 == 0)
                    {
                        row.Shading.Color = new MigraDoc.DocumentObjectModel.Color(14, 14, 14, 1);
                    }
                    row.BottomPadding = 5;
                    row.TopPadding = 5;

                }
                row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            }
        }

        private void AddDataListValues(Document document, string[][] dataListValues) 
        {
            var table = document.LastSection.AddTable();
            table.Borders.Width = 0.1;
            double cellsWidth = 20.0 / dataListValues[0].Length;
            for (var i = 0;i < dataListValues[0].Length; i++)
            {
                table.AddColumn($"{cellsWidth}cm");
            }
                

            for (var i = 0; i < dataListValues.Length; i++)
            {
                var row = table.AddRow();

                for (var j = 0; j < dataListValues[0].Length; j++)
                {
                    row.Cells[j].AddParagraph(dataListValues[i][j]);
                    if (i % 2 == 0)
                    {
                        row.Shading.Color = new MigraDoc.DocumentObjectModel.Color(14, 14, 14, 1);
                    }
                    row.BottomPadding = 5;
                    row.TopPadding = 5;
                }
            }
        }

        private void AddPNG(Section section, MemoryStream png)
        {
            var imageArray = png.ToArray();
            var image = section.AddImage("base64:" + Convert.ToBase64String(imageArray.ToArray()));
            image.Width = Unit.FromPoint(GraphicWidth);
        }

        private void BuildDocument(Document document, string[][] dbValues, string[][] dataListValues, MemoryStream png)
        {
            
            Section section = document.AddSection();
            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Portrait;
            section.PageSetup.BottomMargin = 10;
            section.PageSetup.TopMargin = 20;
            section.PageSetup.LeftMargin = 20;
            section.PageSetup.RightMargin = 10;
            
            AddDbValues(document, dbValues);
            AddPNG(section, png);
            AddDataListValues(document, dataListValues);


        }
    }
}
