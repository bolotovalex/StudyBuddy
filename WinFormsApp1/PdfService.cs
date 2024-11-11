using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using OxyPlot;
using OxyPlot.WindowsForms;
using PdfSharp.Pdf;

namespace Pryamolineynost
{
    public class PdfService
    {
        public const int GraphicWidth = 575;
       
        public static PdfDocument CreateDocument(string[][] dbValues, string[][] dataListValues, PlotModel plotModel)
        {
            var document = new Document();
            var png = GetPNG(plotModel);
            BuildDocument(document, dbValues, dataListValues, png);
            var pdfRender = new PdfDocumentRenderer
            {
                Document = document
            };
            pdfRender.RenderDocument();
            return pdfRender.PdfDocument;
        }

        private static MemoryStream GetPNG(PlotModel plotModel)
        {
            var stream = new MemoryStream();
            var pngExporter = new PngExporter { Width = 1280, Height = 1024 };
            pngExporter.Export(plotModel, stream);
            return stream;
        }

        private static void AddDbValues(Document document, string[][] dbValues)
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
                        row.Shading.Color = new MigraDoc.DocumentObjectModel.Color(14, 14, 14, 1);
                    row.BottomPadding = 5;
                    row.TopPadding = 5;

                }
                row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            }
        }

        private static void AddDataListValues(Document document, string[][] dataListValues)
        {
            var table = document.LastSection.AddTable();
            table.Borders.Width = 0.1;
            var columnMultipler =  (int)(20.0 / (2.25 * (dataListValues[0].Length-1)));
            double cellsWidth = 18.0 / ((columnMultipler) * (dataListValues[0].Length - 1));

            // Заполняем шапку колонками
            for (var j = 0; j < columnMultipler; j++)
            {
                for (var i = 0; i < dataListValues[0].Length; i++)
                {
                    if (i == 0)
                    {
                        table.AddColumn($"1cm");
                    }
                    else
                    {
                        table.AddColumn($"{cellsWidth}cm");
                    }
                }
            }

            //Считаем количество строк с учет, объединения
            var rowsCount = dataListValues.Length % columnMultipler == 0 ? dataListValues.Length / columnMultipler : dataListValues.Length / columnMultipler + 1;

            //Заполнени шапки подписями
            var row0 = table.AddRow();
            for (var j = 0; j < dataListValues[0].Length; j++)
            {
                for (var c = 0; c < columnMultipler; c++)
                {
                    row0.Cells[c * dataListValues[0].Length + j].AddParagraph(dataListValues[0][j]);
                    row0.Shading.Color = new MigraDoc.DocumentObjectModel.Color(14, 14, 14, 1);
                }
                row0.BottomPadding = 5;
                row0.TopPadding = 5;
            }
            row0.BottomPadding = 5;
            row0.TopPadding = 5;

            //Обход всех ячеек
            for (var i = 1; i < rowsCount; i++)
            {
                var row = table.AddRow();
                
                for (var j = 0; j < dataListValues[0].Length; j++)
                {
                    for (var c = 0; c < columnMultipler; c++)
                    {
                        var koef = dataListValues.Length % columnMultipler == 0 ? dataListValues.Length / columnMultipler : dataListValues.Length / columnMultipler + 1;
                        var rowIndex = i + koef * c;

                        if (rowIndex < dataListValues.Length)
                        {
                            var cellIndex = c * dataListValues[0].Length + j;
                            row.Cells[cellIndex].AddParagraph(dataListValues[rowIndex][j]);
                        }
                        else
                        {
                            continue;
                        }

                        if (i % 2 == 0)
                            row.Shading.Color = new MigraDoc.DocumentObjectModel.Color(14, 14, 14, 1);
                        row.BottomPadding = 5;
                        row.TopPadding = 5;
                    }
                }
            }
        }

        private static void AddPNG(Section section, MemoryStream png)
        {
            var imageArray = png.ToArray();
            var image = section.AddImage("base64:" + Convert.ToBase64String(imageArray.ToArray()));
            image.Width = Unit.FromPoint(GraphicWidth);
        }

        private static void BuildDocument(Document document, string[][] dbValues, string[][] dataListValues, MemoryStream png)
        {

            Section section = document.AddSection();
            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Portrait;
            section.PageSetup.BottomMargin = 30;
            section.PageSetup.TopMargin = 30;
            section.PageSetup.LeftMargin = 20;
            section.PageSetup.RightMargin = 10;
            

            AddDbValues(document, dbValues);
            AddPNG(section, png);
            document.AddSection();
            AddDataListValues(document, dataListValues);


        }
    }
}
