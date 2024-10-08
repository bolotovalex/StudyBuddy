﻿namespace Pryamolineynost;

public partial class DataForm : Form
{
    private Db db;
    private MainForm mainForm;

    public DataForm(Db db, MainForm parrentForm)
    {
        this.db = db;
        mainForm = parrentForm;
        InitializeComponent();
    }

    public void ReloadDataForm(Db db, MainForm parrentForm)
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
        dataGrid.Rows.Add();
        UpdateForm(sender, e);
    }

    public void UpdateForm(object sender, EventArgs e)
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

    private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        var cellValue = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        int value;
        if (cellValue != null)
        {
            value = int.Parse(cellValue.ToString());
            if (e.RowIndex == db.GetDataList().Count)
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
                    db.UpdateFStrokeRow(e.RowIndex, int.MinValue);
                    break;
                case 8:
                    db.UpdateRevStrokeRow(e.RowIndex, int.MinValue);
                    break;
            }
        }


        UpdateForm(sender, e);
        mainForm.UpdateAllFields();
    }


    private void closeButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void clearDBButton_Click(object sender, EventArgs e)
    {
        while (dataGrid.RowCount > 2) dataGrid.Rows.RemoveAt(1);
        db.CleanDb();
        mainForm.UpdateAllFields();
        UpdateForm(sender, e);
    }
}