using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pryamolineynost
{
    public partial class GraphicsForm : Form
    {
        Db db;
        MainForm mainForm;
        public GraphicsForm(Db db, MainForm mainForm)
        {
            this.db = db;
            this.mainForm = mainForm;
            InitializeComponent();
            UpdatePlot();
        }

        private void GraphicsForm_Resize(object sender, EventArgs e)
        {
            plotView1.Size = new Size(this.Width - 16, this.Height - 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            plotView1.Refresh();
            UpdatePlot();
        }

        public void UpdatePlot()
        {
            //plotView1.Dock = DockStyle.Fill;
            var plotModel = new PlotModel { Title = "График отклонений от прямолинейности в вертикальной плоскости" };

            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom, // Ось внизу
                Title = "Длина измерения, мм", // Подпись для оси X
                MajorGridlineStyle = LineStyle.Solid, // Основная сетка
                MinorGridlineStyle = LineStyle.Dot // Вспомогательная сетка
            };

            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left, //Ось слева
                Title = "Показания электронного уровня, мкм", //Подпись оси слева
                MajorGridlineStyle = LineStyle.Solid, // Основная сетка
                MinorGridlineStyle = LineStyle.Dot // Вспомогательная сетка
            };

            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);

            var line1 = new LineSeries { Title = "Фактический профиль проверямой поверхности, мкм" };
            var line2 = new LineSeries { Title = "Прилегающая прямая, мкм", LineStyle = LineStyle.Dash };
            var points = db.GetGraphicPoints();

            for (var i = 0; i < db.DataList.Count; i++)
            {
                line1.Points.Add(new DataPoint(points.positions[i], points.graph1[i]));
                line2.Points.Add(new DataPoint(points.positions[i], points.graph2[i]));
            }

            Legend legend = new Legend();
            legend.LegendPosition = LegendPosition.TopRight;

            plotModel.Series.Add(line1);
            plotModel.Series.Add(line2);
            plotModel.Legends.Add(legend);
            plotModel.IsLegendVisible = true;
            plotView1.Model = plotModel;
            this.Controls.Add(plotView1);
        }

    }
}
