using System.Globalization;
using System.Text.Json;
using static Pryamolineynost.PdfService;

//using OxyPlot.Series;
//using OxyPlot.WindowsForms;
//using OxyPlot;
//using PdfSharp.Drawing;
//using PdfSharp.Pdf;

namespace Pryamolineynost;

public partial class MainForm : Form
{
    private Db _dB;
    private DataForm _dataForm;
    private GraphicsForm _graphicsForm;

    public MainForm()
    {
        InitializeComponent();
        _dB = new Db();
        _dataForm = new DataForm(_dB, this, _graphicsForm);
        stepTextPanel.Text = _dB.GetMeasurementStep().ToString();
        _graphicsForm = new GraphicsForm(_dB, this);
    }


    private void UpdateFio(object sender, EventArgs e)
    {
        _dB.Fio = fioComboBox.Text;
    }

    private void UpdateProjectName(object sender, EventArgs e)
    {
        _dB.Name = nameComboBox.Text;
    }


    private int CheckTextBoxIntValue(TextBox textBox)
    {
        int result;
        return int.TryParse(textBox.Text, out result) ? result : 0;
    }


    private void UpdateStep(object sender, EventArgs e)
    {
        _dB.SetMeasurementStep(CheckTextBoxIntValue(stepTextPanel));
        _dB.UpdateStepsPerMeter(_dB.GetMeasurementStep());
        _dB.UpdateAllRows();
        _dataForm.DataForm_Load(sender, e);
        UpdateAllFields();
    }

    private void UpdateFullTolerance(object sender, EventArgs e)
    {
        _dB.FullTolerance = CheckTextBoxIntValue(tolerLenghtTextBox);
    }

    private void UpdateAdmPerMeter(object sender, EventArgs e)
    {
        _dB.MeterTolerance = CheckTextBoxIntValue(tolerPerMeterTextBox);
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
        _dataForm = new DataForm(_dB, this, _graphicsForm);
        _dataForm.Show();
    }

    public void UpdateAllFields()
    {
        dateTimePicker.Value = _dB.GetDate();
        nameComboBox.Text = _dB.Name;
        descriptionComboBox.Text = _dB.Description;
        fioComboBox.Text = _dB.Fio;
        minDeviationTextBox.Text = Math.Round(_dB.GetMinDeviation(), 2).ToString(CultureInfo.InvariantCulture);
        maxDeviationTextBox.Text = Math.Round(_dB.GetMaxDeviation(), 2).ToString(CultureInfo.InvariantCulture);
        lineDeviationTextBox.Text = Math.Round(_dB.GetMeterDeflection(), 2).ToString(CultureInfo.InvariantCulture);
        localAreaTextBox.Text = _dB.GetLocalAreaLength().ToString();
        verticalDeviationTextBox.Text = Math.Round(_dB.GetVerticalDeflection(), 2).ToString(CultureInfo.InvariantCulture);
        bedLengthTextBox.Text = _dB.GetLastDataRow().GetLength().ToString();
    }

    private async void saveButton_Click(object sender, EventArgs e)
    {
        var saveFileDialog1 = new SaveFileDialog();
        saveFileDialog1.Filter = @"Json|*.json";
        saveFileDialog1.Title = @"Save json file";
        saveFileDialog1.ShowDialog();

        if (saveFileDialog1.FileName != "")
        {
            using var writer = new StreamWriter(saveFileDialog1.OpenFile());
            await writer.WriteLineAsync(JsonSerializer.Serialize(_dB));
            writer.Close();
        }
    }

    private void descriptionComboBox_TextChanged(object sender, EventArgs e)
    {
        _dB.Description = descriptionComboBox.Text;
    }

    private async void loadFileButton_Click(object sender, EventArgs e)
    {
        _dataForm.Close();
        _graphicsForm.Close();
        var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = @"Json|*.json";
        openFileDialog.Title = @"Load json file";
        openFileDialog.ShowDialog();
        var reader = new StreamReader(openFileDialog.OpenFile());
        var data = await reader.ReadToEndAsync();
        var newDb = JsonSerializer.Deserialize<Db>(data); //TODO Нужно сделать проверку на правлиьность файла и данных в нем
        _dB = newDb;
        _dB.UpdateAllRows();
        UpdateAllFields();
        _dataForm.UpdateForm(null, null);
        _graphicsForm.UpdatePlot();
        reader.Close();
    }

    private void graphicButton_Click(object sender, EventArgs e)
    {
        _graphicsForm = new GraphicsForm(_dB, this);
        _graphicsForm.Show();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var pdfService = new PdfService();
        var document = pdfService.CreateDocument(_dB.GetPrintStrings());
        document.Save("1234.pdf");
    }
}