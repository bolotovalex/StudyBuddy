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
            dataGrid.Size = new Size(this.ClientSize.Width - 6, this.ClientSize.Height - 36);
            closeButton.Location = new Point(ClientSize.Width - 79, this.ClientSize.Height - 28);
        }

        public void DataForm_Load(object sender, EventArgs e)
        {
            dataGrid.Rows.Clear();
            for (var i = 0; i < db.GetDataList().Count; i++)
            {
                {
                    dataGrid.Rows.Add();
                    var row = db.GetDataRow(i);
                    dataGrid.Rows[i].Cells[0].Value = i;
                    dataGrid.Rows[i].Cells[1].Value = row.GetLength();
                    dataGrid.Rows[i].Cells[2].Value = row.GetFactProfileLength();
                    dataGrid.Rows[i].Cells[3].Value = row.GetAdjStraight();
                    dataGrid.Rows[i].Cells[4].Value = row.GetDeviation();
                    dataGrid.Rows[i].Cells[5].Value = row.GetDeviationPerMeter();
                    dataGrid.Rows[i].Cells[6].Value = row.GetMidValue();
                    dataGrid.Rows[i].Cells[7].Value = row.GetFStroke() == int.MinValue ? "" : row.GetFStroke();
                    dataGrid.Rows[i].Cells[8].Value = row.GetRevStroke() == int.MinValue ? "" : row.GetRevStroke();
                }
            }
        }

        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cellValue = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            int value;
            if (cellValue != null)
            {
                value = int.Parse(cellValue.ToString());
                if (e.RowIndex == db.GetLength())
                {
                    switch (e.ColumnIndex)
                    {
                        case (7):
                            this.db.AddRow(value, int.MinValue);
                            break;
                        case (8):
                            this.db.AddRow(int.MinValue, value);
                            break;
                    }
                }
                else
                {
                    switch (e.ColumnIndex)
                    {
                        case (7):
                            this.db.UpdateFStrokeRow(e.RowIndex, value);
                            break;
                        case (8):
                            this.db.UpdateRevStrokeRow(e.RowIndex, value);
                            break;
                    }
                }
            }
            else
            {
                switch (e.ColumnIndex)
                {
                    case (7):
                        this.db.UpdateFStrokeRow(e.RowIndex, int.MinValue);
                        break;
                    case (8):
                        this.db.UpdateRevStrokeRow(e.RowIndex, int.MinValue);
                        break;
                }
            }


            this.DataForm_Load(sender, e);
            Console.WriteLine(dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }

        private void DataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
