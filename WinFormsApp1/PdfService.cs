using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;
using OxyPlot;
using OxyPlot.WindowsForms;
using PdfSharp.Drawing;

namespace Pryamolineynost
{
    public class PdfService
    {
        public const int GraphicWidth = 570;
        public const int GraphicHeight = 428;
        public PdfDocument CreateDocument(string[][] printParams, PlotModel plotModel)
        {
            var document = new Document();
            var png = GetPNG(plotModel);
            BuildDocument(document, printParams, png);
            var pdfRender = new PdfDocumentRenderer();
            pdfRender.Document = document;
            pdfRender.RenderDocument();
            return pdfRender.PdfDocument;
        }

        private MemoryStream GetPNG(PlotModel plotModel)
        {
            var stream = new MemoryStream();
            var pngExporter = new PngExporter { Width = GraphicWidth, Height = GraphicHeight };
            pngExporter.Export(plotModel, stream);
            return stream;
        }
        
        private void BuildDocument(Document document, string[][] printParams, MemoryStream png)
        {
            
            Section section = document.AddSection();
            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Portrait;
            section.PageSetup.BottomMargin = 10;
            section.PageSetup.TopMargin = 20;
            section.PageSetup.LeftMargin = 20;
            section.PageSetup.RightMargin = 10;


            var table = document.LastSection.AddTable();
            table.AddColumn("11cm");
            table.AddColumn("9cm");

            for (var i = 0; i < printParams.Length; i++)
            {
                var row = table.AddRow();

                for (var j = 0; j < printParams[0].Length; j++)
                {
                    row.Cells[j].AddParagraph(printParams[i][j]);
                    if ( i % 2 == 0 )
                    {
                        row.Shading.Color = new MigraDoc.DocumentObjectModel.Color(14, 14, 14, 1);
                    }
                    row.BottomPadding = 5;
                    row.TopPadding = 5;
                    
                }
                row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            }

            var imageArray = png.ToArray();
            var image = section.AddImage("base64:" + Convert.ToBase64String(imageArray.ToArray()));
            image.Width = Unit.FromPoint(GraphicWidth);
            image.Height = Unit.FromPoint(GraphicHeight);
        }
    }
}
