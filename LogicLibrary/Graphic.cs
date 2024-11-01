using LogicLibrary;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.Drawing;

namespace LogicLibrary
{
    public class Graphic
    {
        
        public int Step { get; set; } = 200;
        public required Point[] CurvePoints { get; set; }
        public required Point[] StraightPoints { get; set; }
        public Point[]? localStraightPoints { get;  set; }
        public int localStraightTolerance { get; set; }

        public PlotModel _plotModel { get; }
        public PlotView? _plotView { get; }

        public Graphic(string title, Point[] curvePoints, Point[] straightPoint)
        {
            _plotModel = new PlotModel { Title = "График отклонений от прямолинейности в вертикальной плоскости" };
            CurvePoints = curvePoints;
            StraightPoints = straightPoint;
            BuildModel();
            _plotView.Model = _plotModel;
        }

        public void RefreshPlot()
        {
            _plotModel?.InvalidatePlot(true);
        }

        public PlotView? GetPlotView() => _plotView;
        public PlotModel? GetPlotModel() => _plotModel;

        public void BuildModel()
        {
            //plotView1.Dock = DockStyle.Left;
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


            _plotModel?.Axes.Add(xAxis);
            _plotModel?.Axes.Add(yAxis);

            var mainLine = new LineSeries { Title = "Фактический профиль проверямой поверхности, мкм" };
            var adjStraight = new LineSeries { Title = "Прилегающая прямая, мкм", LineStyle = LineStyle.Dash };
            //var points = db.GetGraphicPoints();

            for (var i = 0; i < CurvePoints.Length; i++)
            {
                mainLine.Points.Add(new DataPoint(CurvePoints[i].X, CurvePoints[i].Y));
                adjStraight.Points.Add(new DataPoint(StraightPoints[i].X, StraightPoints[i].Y));
            }

            Legend legend = new Legend();
            legend.LegendPosition = LegendPosition.TopRight;
            _plotModel.Legends.Add(legend);
            _plotModel.IsLegendVisible = true;
            _plotModel.Series.Add(mainLine);
            _plotModel.Series.Add(adjStraight);

            if (localStraightPoints != null) 
            {
                var localLineStraight = new LineSeries { Title = "Отклонение на локальном участке" };
                var toleranceLine1 = new LineSeries { Title = "Допуск" };
                var toleranceLine2 = new LineSeries { Title = "Допуск" };
                for (var i = 0; i<= localStraightPoints.Length; i++)
                {
                    localLineStraight.Points.Add(new DataPoint(localStraightPoints[i].X, localStraightPoints[i].Y));
                    toleranceLine1.Points.Add(new DataPoint(localStraightPoints[i].X, localStraightPoints[i].Y + localStraightTolerance));
                    toleranceLine2.Points.Add(new DataPoint(localStraightPoints[i].X, localStraightPoints[i].Y - localStraightTolerance));
                }
                _plotModel.Series.Add(localLineStraight);
                _plotModel.Series.Add(toleranceLine1);
                _plotModel.Series.Add(toleranceLine2);
            }
        }
    }
}
