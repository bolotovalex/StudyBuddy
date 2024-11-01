using LogicLibrary;
namespace Pryamolineynost;

public partial class DataForm : Form
{
    private DB db;
    private MainForm mainForm;
    private readonly GraphicsForm _graphicsForm;

    public DataForm(DB db, MainForm parrentForm, GraphicsForm graphicsForm)
    {
        this.db = db;
        mainForm = parrentForm;
        this._graphicsForm = graphicsForm;
        InitializeComponent();
    }

    public void ReloadDataForm(DB db, MainForm parrentForm)
    {
        this.db = db;
        mainForm = parrentForm;
        dataGrid.Rows.Clear();
        UpdateForm(null, null);
    }


    private void DataForm_SizeChanged(object sender, EventArgs e)
    {
        dataGrid.Size = new Size(ClientSize.Width - 6, ClientSize.Height - 36);
        closeButton.Location = new Point(ClientSize.Width - 79, ClientSize.Height - 28);
    }

    public void DataForm_Load(object sender, EventArgs e)
    {
        dataGrid.Rows.Clear();
        if (dataGrid.Columns.Count == 0) 
            InitializeComponent();
        
        dataGrid.Rows.Add();
        UpdateForm(sender, e);
    }

    public void UpdateForm(object? sender, EventArgs? e)
    {
        if (dataGrid.Rows.Count < db.DataList.Count)
        {
            if (dataGrid.Columns.Count == 0)
                InitializeComponent();
            for (var i = dataGrid.Rows.Count; i <= db.DataList.Count; i++)
                dataGrid.Rows.Add();
        }


        for (var i = 0; i < db.DataList.Count; i++)
        {
            var row = db.DataList[i];
            for (var cellNumber = 0; cellNumber < dataGrid.ColumnCount - 2; cellNumber++)
            {
                dataGrid.Rows[i].Cells[cellNumber].Style.BackColor = Color.WhiteSmoke;
            }
            dataGrid.Rows[i].Cells[0].Value = i;
            dataGrid.Rows[i].Cells[1].Value = row.GetPosition();
            dataGrid.Rows[i].Cells[2].Value = Math.Round(row.GetFactProfile(), 2);
            dataGrid.Rows[i].Cells[3].Value = Math.Round(row.GetAdjStraight(), 2);
            dataGrid.Rows[i].Cells[4].Value = Math.Round(row.GetDeviation(), 2);
            dataGrid.Rows[i].Cells[5].Value = Math.Round(row.GetDevationPerMeter(), 2);
            dataGrid.Rows[i].Cells[6].Value = Math.Round(row.GetMidValue(), 2);
            dataGrid.Rows[i].Cells[7].Value = row.FStroke == int.MinValue ? "" : row.FStroke;
            dataGrid.Rows[i].Cells[8].Value = row.RevStroke == int.MinValue ? "" : row.RevStroke;

            if (Math.Round(row.GetDevationPerMeter(), 2) > this.db.MeterTolerance)
                dataGrid.Rows[i].Cells[5].Style.BackColor = Color.LightCoral;
            else
                dataGrid.Rows[i].Cells[5].Style.BackColor = SystemColors.Control;
        }

        if (db.RevStrokeEnbled)
        {
            dataGrid.Columns[6].Visible = true;
            dataGrid.Columns[8].Visible = true;
            revStrokeCheckBox.Checked = true;
        }
        else
        {
            dataGrid.Columns[6].Visible = false;
            dataGrid.Columns[8].Visible = false;
            revStrokeCheckBox.Checked = false;
        }
    }

    private void DataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        object? cellValue = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? "";
        int value;
        
        if (cellValue != "")
        {
            int.TryParse(cellValue.ToString(), out value);
            if (e.RowIndex == db.DataList.Count)
                switch (e.ColumnIndex)
                {
                    case 7:
                        db.AddRow(value, int.MinValue);
                        break;
                    case 8:
                        db.AddRow(int.MinValue, value);
                        break;
                }
            else
                switch (e.ColumnIndex)
                {
                    case 7:
                        db.UpdateFStrokeRow(e.RowIndex, value);
                        break;
                    case 8:
                        db.UpdateRevStrokeRow(e.RowIndex, value);
                        break;
                }
        }
        else
        {
            switch (e.ColumnIndex)
            {
                case 7:
                    if (this.db.DataList[e.RowIndex].RevStroke == int.MinValue)
                    {
                        this.db.DataList.RemoveAt(e.RowIndex);
                        dataGrid.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        db.UpdateFStrokeRow(e.RowIndex, int.MinValue);
                        dataGrid.Rows.RemoveAt(e.RowIndex);
                    }
                    break;
                case 8:
                    if (this.db.DataList[e.RowIndex].FStroke == int.MinValue)
                    {
                        this.db.DataList.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        db.UpdateRevStrokeRow(e.RowIndex, int.MinValue);
                    }
                    break;
            }
            this.db.UpdateAllRows();
            
            

        }

        UpdateForm(sender, e);
        mainForm.UpdateAllFields();
        mainForm.UpdateGraphic();
        if (_graphicsForm != null)
        {
            _graphicsForm.UpdateDeviationList();
        }
        
        //_graphicsForm.UpdatePlot();
    }


    private void CloseButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void ClearDBButton_Click(object sender, EventArgs e)
    {
        while (dataGrid.RowCount > 2) dataGrid.Rows.RemoveAt(1);
        db.CleanDb();
        mainForm.UpdateAllFields();
        UpdateForm(sender, e);
        _graphicsForm.UpdatePlot();
    }

    private void revStrokeCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (revStrokeCheckBox.Checked)
        {
            db.RevStrokeEnbled = true;
            dataGrid.Columns[6].Visible = true;
            dataGrid.Columns[8].Visible = true;
        }
        else
        {
            db.RevStrokeEnbled = false;
            dataGrid.Columns[6].Visible = false;
            dataGrid.Columns[8].Visible = false;
        }

        db.UpdateAllRows();
        UpdateForm(sender, e);
        mainForm.UpdateAllFields() ;
    }
}