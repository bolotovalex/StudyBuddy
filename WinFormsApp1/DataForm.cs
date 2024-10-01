namespace Pryamolineynost
{
    public partial class DataForm : Form
    {
        private DB db;
        public DataForm(DB db)
        {
            this.db = db;
            InitializeComponent();

        }

        private void DataForm_SizeChanged(object sender, EventArgs e)
        {
            dataGrid.Size = new Size(this.ClientSize.Width - 23, this.ClientSize.Height - 75);
        }



        //private void DataForm_Load(object sender, EventArgs e)
        //{
        //    dataGrid.Rows.Clear();
        //    for (var i = 0; i < dataList.RowsCount(); i++)
        //    {
        //        dataGrid.Rows.Add();
        //        var row = dataList.GetRow(i);
        //        dataGrid.Rows[i].Cells[0].Value = row.Step;
        //        dataGrid.Rows[i].Cells[1].Value = row.Length;
        //        dataGrid.Rows[i].Cells[2].Value = row.FactCheckedProfileLength;
        //        dataGrid.Rows[i].Cells[3].Value = row.AdjStraight;
        //        dataGrid.Rows[i].Cells[4].Value = row.Deviation;
        //        dataGrid.Rows[i].Cells[5].Value = row.DevationPerMeter;
        //        dataGrid.Rows[i].Cells[6].Value = row.MidValue;
        //        dataGrid.Rows[i].Cells[7].Value = row.FStroke;
        //        dataGrid.Rows[i].Cells[8].Value = row.RevStroke;
        //    }
        //}

        //public void DataForm_ReLoad()
        //{
        //    dataGrid.Rows.Clear();
        //    for (var i = 0; i < dataList.RowsCount(); i++)
        //    {
        //        dataGrid.Rows.Add();
        //        var row = dataList.GetRow(i);
        //        dataGrid.Rows[i].Cells[0].Value = row.Step;
        //        dataGrid.Rows[i].Cells[1].Value = row.Length;
        //        dataGrid.Rows[i].Cells[2].Value = row.FactCheckedProfileLength;
        //        dataGrid.Rows[i].Cells[3].Value = row.AdjStraight;
        //        dataGrid.Rows[i].Cells[4].Value = row.Deviation;
        //        dataGrid.Rows[i].Cells[5].Value = row.DevationPerMeter;
        //        dataGrid.Rows[i].Cells[6].Value = row.MidValue;
        //        dataGrid.Rows[i].Cells[7].Value = row.FStroke;
        //        dataGrid.Rows[i].Cells[8].Value = row.RevStroke;
        //    }
        //}

        private float UpdateIntTextBox(int row, int col)
        {
            int result;

            var value = dataGrid.Rows[row].Cells[col].Value.ToString();

            if (int.TryParse(value, out result))
                dataGrid.Rows[row].Cells[col].Style.BackColor = Color.White;
            else
                dataGrid.Rows[row].Cells[col].Style.BackColor = Color.Red;
            return result;
        }


        private void dataGrid_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var value1 = UpdateIntTextBox(e.RowIndex, 7);
                var value2 = UpdateIntTextBox(e.RowIndex, 8);
                Console.WriteLine(value1);
                Console.WriteLine(value2);
                //dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
            }



            //dataList.UpdateRow(e.RowIndex, value1, value2);
            //Console.WriteLine($"row: {e.RowIndex}, col: {e.ColumnIndex}");
        }
    }
}
