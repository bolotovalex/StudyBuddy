namespace Pryamolineynost
{
    public partial class DataForm : Form
    {
        private DataList dataList;
        public DataForm(DataList data)
        {
            this.dataList = data;
            this.dataList.AddRow(1, 1);
            this.dataList.AddRow(2, 2);

            InitializeComponent();

        }

        private void DataForm_SizeChanged(object sender, EventArgs e)
        {
            dataGrid.Size = new Size(this.ClientSize.Width - 23, this.ClientSize.Height - 75);
        }

        private void dataGrid_Load(object sender, DataGridViewCellEventArgs e)
        {


            //Console.WriteLine(e.RowIndex.ToString());
            //Console.WriteLine(e.ColumnIndex.ToString());
            //dataGrid.Rows[0].Cells[e.ColumnIndex].Value = 0.ToString();
            ////Console.WriteLine(dataGrid.Rows[e.RowIndex+1].Cells[e.ColumnIndex].Value.ToString());
        }

        private void dataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            dataGrid.Rows.Clear();
            for (var i = 0; i < dataList.RowsCount(); i++)
            {
                dataGrid.Rows.Add();
                var row = dataList.GetRow(i);
                dataGrid.Rows[i].Cells[0].Value = row.Step;
                dataGrid.Rows[i].Cells[1].Value = row.Length;
                dataGrid.Rows[i].Cells[2].Value = row.FactCheckedProfileLength;
                dataGrid.Rows[i].Cells[3].Value = row.AdjStraight;
                dataGrid.Rows[i].Cells[4].Value = row.Deviation;
                dataGrid.Rows[i].Cells[5].Value = row.DevationPerMeter;
                dataGrid.Rows[i].Cells[6].Value = row.MidValue;
                dataGrid.Rows[i].Cells[7].Value = row.FStroke;
                dataGrid.Rows[i].Cells[8].Value = row.RevStroke;
            }

        }
    }
}
