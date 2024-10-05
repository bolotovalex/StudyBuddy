namespace Pryamolineynost
{
    public partial class DataForm : Form
    {
        private DB db;
        private MainForm mainForm;
        public DataForm(DB db, MainForm parrentForm)
        {
            this.db = db;
            this.mainForm = parrentForm;
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
            dataGrid.Rows.Add();
            UpdateForm(sender, e);
        }

        public void UpdateForm(object sender, EventArgs e)
        {
            for (var i = 0; i < db.GetDataList().Count; i++)
            {
                var row = db.GetDataRow(i);
                dataGrid.Rows[i].Cells[0].Value = i;
                dataGrid.Rows[i].Cells[1].Value = row.GetLength();
                dataGrid.Rows[i].Cells[2].Value = Math.Round(row.GetFactProfileLength(), 2);
                dataGrid.Rows[i].Cells[3].Value = Math.Round(row.GetAdjStraight(), 2);
                dataGrid.Rows[i].Cells[4].Value = Math.Round(row.GetDeviation(), 2);
                dataGrid.Rows[i].Cells[5].Value = Math.Round(row.GetDeviationPerMeter(), 2);
                dataGrid.Rows[i].Cells[6].Value = Math.Round(row.GetMidValue(), 2);
                dataGrid.Rows[i].Cells[7].Value = row.GetFStroke() == int.MinValue ? "" : row.GetFStroke();
                dataGrid.Rows[i].Cells[8].Value = row.GetRevStroke() == int.MinValue ? "" : row.GetRevStroke();
            }
        }

        public void AddRow(object sender, EventArgs e)
        {
            //dataGrid.Rows.Add();
            UpdateForm(sender, e);
        }

        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cellValue = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            int value;
            if (cellValue != null)
            {
                value = int.Parse(cellValue.ToString());
                if (e.RowIndex == db.GetDataList().Count)
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


            this.UpdateForm(sender, e);
            this.mainForm.UpdateAllFields();
        }

        private void DataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void clearDBButton_Click(object sender, EventArgs e)
        {
            this.db.CleanDB();
            this.mainForm.CleanForm();
            dataGrid.Rows.Clear();
            UpdateForm(sender, e);
            this.mainForm.UpdateAllFields();
            var a = 1;
        }
    }
}
