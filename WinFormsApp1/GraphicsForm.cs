using LogicLibrary;
using OxyPlot;
using OxyPlot.WindowsForms;

namespace Pryamolineynost
{
    public partial class GraphicsForm : Form
    {
        DB DB;
        MainForm mainForm;
        GraphicModel graphic;
        public int _rightGraphIndexnt = 150;
        public int _botomGraphIndention = 37;
        public int _initFormWidth = 1000;
        public int _initFormHeight = 600;
        
        public GraphicsForm(DB db, MainForm mainForm, GraphicModel graphic)
        {
            this.DB = db;
            this.mainForm = mainForm;
            this.graphic = graphic;
            InitializeComponent();
            plotView1.Model = graphic.GetPlotModel();
            this.Controls.Add(plotView1);
            graphic.RefreshPlot();
        }

        private void GraphicsForm_Resize(object sender, EventArgs e)
        {
            plotView1.Size = new Size(this.Width - _rightGraphIndexnt, this.Height - _botomGraphIndention);
            listBox1.Size = new Size(120, this.Height - label1.Size.Height-25);
        }

        public void UpdatePlot()
        {
            graphic.RefreshPlot();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"{listBox1.SelectedIndex} {listBox1.SelectedItem}");
        }
    }
}
