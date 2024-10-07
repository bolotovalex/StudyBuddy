using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Pryamolineynost;

public partial class MainForm : Form
{
    private Db dB;
    private DataForm dataForm;

    public MainForm()
    {
        InitializeComponent();
        dB = new Db();
        dataForm = new DataForm(dB, this);
        stepTextPanel.Text = dB.GetMeasurementStep().ToString();
    }


    private void UpdateFio(object sender, EventArgs e)
    {
        dB.Fio = fioComboBox.Text;
    }

    private void UpdateProjectName(object sender, EventArgs e)
    {
        dB.Name = nameComboBox.Text;
    }


    private int CheckTextBoxIntValue(TextBox textBox)
    {
        int result;
        if (int.TryParse(textBox.Text, out result))
        {
        }
        else
        {
            textBox.Text = "0";
        }

        return result;
    }


    private void UpdateStep(object sender, EventArgs e)
    {
        dB.SetMeasurementStep(CheckTextBoxIntValue(stepTextPanel));

        dB.UpdateStepsPerMeter(dB.GetMeasurementStep());
        dB.UpdateAllRows();

        UpdateAllFields();
        dataForm.DataForm_Load(sender, e);
    }

    private void UpdateFullTolerance(object sender, EventArgs e)
    {
        dB.FullTolerance = CheckTextBoxIntValue(tolerLenghtTextBox);
    }

    private void UpdateAdmPerMeter(object sender, EventArgs e)
    {
        dB.MeterTolerance = CheckTextBoxIntValue(tolerPerMeterTextBox);
    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        var date = (DateTime)dateTimePicker1.Value;
    }

    private void exitButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void fillDataFormButton_Click(object sender, EventArgs e)
    {
        dataForm = new DataForm(dB, this);
        dataForm.Show();
    }

    public void UpdateAllFields()
    {
        minDeviationTextBox.Text = Math.Round(dB.GetMinDeviation(), 2).ToString();
        maxDeviationTextBox.Text = Math.Round(dB.GetMaxDeviation(), 2).ToString();
        lineDeviationTextBox.Text = Math.Round(dB.GetMeterDeflection(), 2).ToString();
        localAreaTextBox.Text = dB.GetLocalAreaLength().ToString();
        verticalDeviationTextBox.Text = Math.Round(dB.GetVerticalDeflection(), 2).ToString();
        bedLengthTextBox.Text = dB.GetLastDataRow().GetLength().ToString();
    }

    private async void saveButton_Click(object sender, EventArgs e)
    {
        var saveFileDialog1 = new SaveFileDialog();
        saveFileDialog1.Filter = "Json|*.json";
        saveFileDialog1.Title = "Save json file";
        saveFileDialog1.ShowDialog();

        if (saveFileDialog1.FileName != "")
            using (var writer = new StreamWriter(saveFileDialog1.OpenFile()))
            {
                await writer.WriteLineAsync(JsonSerializer.Serialize<Db>(dB));
                writer.Close();
            }
    }

    private void descriptionComboBox_TextChanged(object sender, EventArgs e)
    {
        dB.Description = descriptionComboBox.Text;
    }

    private async void loadFileButton_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Json|*.json";
        openFileDialog.Title = "Load json file";
        openFileDialog.ShowDialog();
        var reader = new StreamReader(openFileDialog.OpenFile());
        var data = await reader.ReadToEndAsync();
        var newDB = JsonSerializer.Deserialize<Db>(data);
        dB = newDB;
        dB.UpdateAllRows();
        UpdateAllFields();
    }
}