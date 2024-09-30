namespace Pryamolineynost
{
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
            dataGrid.Rows[0].Cells[0].Value = "a";
        }

        private void DataGridLoad()
        {
            
        }
        
        private void DataForm_SizeChanged(object sender, EventArgs e)
        {
            dataGrid.Size = new Size(this.ClientSize.Width - 23, this.ClientSize.Height - 75);
        }

        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine(e.RowIndex.ToString());
            //Console.WriteLine(e.ColumnIndex.ToString());
            //dataGrid.Rows[0].Cells[e.ColumnIndex].Value = 0.ToString();
            ////Console.WriteLine(dataGrid.Rows[e.RowIndex+1].Cells[e.ColumnIndex].Value.ToString());
        }
    }
}
