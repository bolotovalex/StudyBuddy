using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;

namespace Pryamolineynost
{
    public class PdfService
    {
        public PdfDocument CreateDocument(string[][] printParams)
        {
            var document = new Document();
            BuildDocument(document, printParams);
            var pdfRender = new PdfDocumentRenderer();
            pdfRender.Document = document;
            pdfRender.RenderDocument();
            return pdfRender.PdfDocument;
        }

        private void BuildDocument(Document document, string[][] printParams)
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
                        row.Shading.Color = new MigraDoc.DocumentObjectModel.Color(50, 50, 50, 1);
                    }
                    row.BottomPadding = 5;
                    row.TopPadding = 5;
                    
                }
                row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            }
        }
    }
}
