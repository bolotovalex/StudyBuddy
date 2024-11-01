using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;


namespace LogicLibrary
{
    public class GraphicModel
    {
        
        public int Step { get; set; } = 200;
        public DPoint[] CurvePoints { get; set; }
        public DPoint[] StraightPoints { get; set; }
        public DPoint[]? localStraightPoints { get;  set; }
        public int localStraightTolerance { get; set; }

        public PlotModel plotModel { get; }
        //public PlotView plotView { get; }

        public GraphicModel(DPoint[] curvePoints, DPoint[] straightPoint)
        {
            plotModel = new PlotModel { Title = "График отклонений от прямолинейности в вертикальной плоскости" };
            //plotView = new PlotView();
            CurvePoints = curvePoints;
            StraightPoints = straightPoint;
            RebuildModel();
            //plotView.Model = plotModel;
        }

        public void RefreshPlot()
        {
            UpdataSeries();
            plotModel.InvalidatePlot(true);
        }

        public void RebuildModel()
        {
            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom, // Ось внизу
                Title = "Длина измерения, мм", // Подпись для оси X
                MajorStep = Step, //Задаем шаг на оси y
                //MinorStep = db.Step,
                MajorGridlineStyle = LineStyle.Solid, // Основная сетка
                MinorGridlineStyle = LineStyle.Dot, // Вспомогательная сетка

            };

            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left, //Ось слева
                Title = "Показания уровня, мкм", //Подпись оси слева
                MajorGridlineStyle = LineStyle.Solid, // Основная сетка
                MinorGridlineStyle = LineStyle.Dot // Вспомогательная сетка
            };


            plotModel.Axes.Clear();
            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);


            plotModel.Legends.Clear();
            Legend legend = new Legend();
            legend.LegendPosition = LegendPosition.TopRight;
            plotModel.Legends.Add(legend);
            plotModel.IsLegendVisible = true;
        }

        public PlotModel? GetPlotModel() => plotModel;

        public void UpdataSeries()
        {
            plotModel.Series.Clear();
            var mainLine = new LineSeries { Title = "Фактический профиль проверямой поверхности, мкм" };
            var adjStraight = new LineSeries { Title = "Прилегающая прямая, мкм", LineStyle = LineStyle.Dash };
            //var points = db.GetGraphicPoints();

            for (var i = 0; i < CurvePoints.Length; i++)
            {
                mainLine.Points.Add(new DataPoint(CurvePoints[i].X, CurvePoints[i].Y));
                adjStraight.Points.Add(new DataPoint(StraightPoints[i].X, StraightPoints[i].Y));
            }
            if (localStraightPoints != null)
            {
                var localLineStraight = new LineSeries { Title = "Отклонение на локальном участке" };
                var toleranceLine1 = new LineSeries { Title = "Допуск" };
                var toleranceLine2 = new LineSeries { Title = "Допуск" };
                for (var i = 0; i <= localStraightPoints.Length; i++)
                {
                    localLineStraight.Points.Add(new DataPoint(localStraightPoints[i].X, localStraightPoints[i].Y));
                    toleranceLine1.Points.Add(new DataPoint(localStraightPoints[i].X, localStraightPoints[i].Y + localStraightTolerance));
                    toleranceLine2.Points.Add(new DataPoint(localStraightPoints[i].X, localStraightPoints[i].Y - localStraightTolerance));
                }
                plotModel.Series.Add(localLineStraight);
                plotModel.Series.Add(toleranceLine1);
                plotModel.Series.Add(toleranceLine2);
            }
            plotModel.Series.Add(mainLine);
            plotModel.Series.Add(adjStraight);
        }
    }
}
