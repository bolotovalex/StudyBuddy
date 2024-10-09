using System.Globalization;
using System.Text.Json;

namespace Pryamolineynost;

public partial class MainForm : Form
{
    private Db _dB;
    private DataForm _dataForm;
    private GraphicsForm _graphicsForm;

    enum FileFormat
    {
        JSON,
        PDF
    }

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
        UpdateAllFields();
    }

    private void UpdateAdmPerMeter(object sender, EventArgs e)
    {
        _dB.MeterTolerance = CheckTextBoxIntValue(tolerPerMeterTextBox);
        UpdateAllFields();
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

    public string GetSrting(decimal value)
    {
        return Math.Round(value, 2).ToString(CultureInfo.InvariantCulture).ToString();
    }
    
    public void UpdateAllFields()
    {
        dateTimePicker.Value = _dB.GetDate();
        nameComboBox.Text = _dB.Name;
        descriptionComboBox.Text = _dB.Description;
        fioComboBox.Text = _dB.Fio;
        minDeviationTextBox.Text = Math.Round(_dB.GetMinDeviation(), 2).ToString(CultureInfo.InvariantCulture);
        maxDeviationTextBox.Text = Math.Round(_dB.GetMaxDeviation(), 2).ToString(CultureInfo.InvariantCulture);
        localAreaTextBox.Text = _dB.GetLocalAreaLength().ToString();
        bedLengthTextBox.Text = _dB.GetLastDataRow().GetLength().ToString();
        tolerLenghtTextBox.Text = _dB.GetFullTolerance().ToString(CultureInfo.InvariantCulture);
        tolerPerMeterTextBox.Text = _dB.GetMeterTolerance().ToString(CultureInfo.InvariantCulture);
        
        if (InTolearance(_dB.GetVerticalDeflection(), _dB.GetFullTolerance()))
        {
            verticalDeviationTextBox.Text = GetSrting(_dB.GetVerticalDeflection());
            verticalDeviationTextBox.BackColor = Color.White;
        }
        else
        {
            verticalDeviationTextBox.Text = $"Не в допуске {GetSrting(_dB.GetVerticalDeflection())}";
            verticalDeviationTextBox.BackColor = Color.LightCoral;
        }

        
        
        if (InTolearance(_dB.GetMeterDeflection(), _dB.GetMeterTolerance()))
        {
            lineDeviationTextBox.Text = GetSrting(_dB.GetMeterDeflection());
            lineDeviationTextBox.BackColor = Color.White;
        }
        else
        {
            lineDeviationTextBox.Text = $"Не в допуске {GetSrting(_dB.GetMeterDeflection())}";
            lineDeviationTextBox.BackColor = Color.LightCoral;
        }
    }

    public bool InTolearance(decimal value, int tolerance)
    {
        return value < tolerance;
    }

    private async void saveButton_Click(object sender, EventArgs e)
    {
        var filename = GetSaveFileName(FileFormat.JSON);

        if (filename != "")
        {
            using var writer = new StreamWriter(filename);
            await writer.WriteLineAsync(JsonSerializer.Serialize(_dB));
            writer.Close();
        }
    }

    private void descriptionComboBox_TextChanged(object sender, EventArgs e)
    {
        _dB.Description = descriptionComboBox.Text;
    }

    private string GetSaveFileName(FileFormat format)
    {
        var saveFileDialog = new SaveFileDialog();
        
        switch (format)
        {
            case FileFormat.PDF:
                saveFileDialog.Filter = @"PDF|*.pdf";
                saveFileDialog.Title = @"Select PDF file";
                break;
            case FileFormat.JSON:
                saveFileDialog.Filter = @"JSON|*.json";
                saveFileDialog.Title = @"Select JSON file";
                break;
        }

        saveFileDialog.ShowDialog();

        return saveFileDialog.FileName;
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

    private void savePdfButton_Click(object sender, EventArgs e)
    {
        var pdfService = new PdfService();
        var printParams = _dB.GetPrintStrings();
        var document = pdfService.CreateDocument(printParams.dbValues, printParams.dataListValues, new GraphicsForm(_dB, this).GetPlotModel());
        var fileName = GetSaveFileName(FileFormat.PDF);
        document.Save(fileName);
    }
}