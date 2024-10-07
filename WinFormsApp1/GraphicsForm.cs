using OxyPlot;
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
            plotView1.Size = new Size(this.Width - 16, this.Height - 40);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            plotView1.Refresh();
            UpdatePlot();
        }

        public void UpdatePlot()
        {
            plotView1.Dock = DockStyle.Fill;
            var plotModel = new PlotModel { Title = "График отклонений от прямолинейности в вертикальной плоскости" };
            var line1 = new LineSeries { Title = "График1" };
            var line2 = new LineSeries { Title = "График2" };
            var points = db.GetGraphicPoints();

            for (var i = 0; i < db.DataList.Count; i++) 
            {
                line1.Points.Add(new DataPoint(points.positions[i], points.graph1[i]));
                line2.Points.Add(new DataPoint(points.positions[i], points.graph2[i]));
            }

            plotModel.Series.Add(line1);
            plotModel.Series.Add(line2);
            plotView1.Model = plotModel;
            this.Controls.Add(plotView1);
        }
    }
}
