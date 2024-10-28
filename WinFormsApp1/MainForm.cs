using System.Globalization;
using System.Text.Json;
using LogicLibrary;


namespace Pryamolineynost;

public partial class MainForm : Form
{
    private DB _dB;
    private DataForm _dataForm;
    private GraphicsForm _graphicsForm;

    enum FileFormat
    {
        Json,
        Pdf
    }

    public MainForm()
    {
        InitializeComponent();
        _dB = new DB() { Description = "", Name = "", Fio = "" };
        _dataForm = new DataForm(_dB, this, _graphicsForm);
        stepTextBox.Text = _dB.GetMeasurementStep().ToString();
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


    private static int CheckTextBoxIntValue(TextBox textBox)
    {
        return int.TryParse(textBox.Text, out int result) ? result : 0;
    }


    private void UpdateStep(object sender, EventArgs e)
    {
        _dB.SetMeasurementStep(CheckTextBoxIntValue(stepTextBox));
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


    private void ExitButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void FillDataFormButton_Click(object sender, EventArgs e)
    {
        _dataForm.Dispose();
        _dataForm = new DataForm(_dB, this, _graphicsForm);
        _dataForm.Show();
    }

    public static string GetSrting(decimal value)
    {
        return Math.Round(value, 2).ToString(CultureInfo.InvariantCulture).ToString();
    }

    public void UpdateAllFields()
    {
        dateTimePicker.Value = _dB.Date;
        nameComboBox.Text = _dB.Name;
        descriptionComboBox.Text = _dB.Description;
        fioComboBox.Text = _dB.Fio;
        minDeviationTextBox.Text = Math.Round(_dB.GetMinDeviation(), 2).ToString(CultureInfo.InvariantCulture);
        maxDeviationTextBox.Text = Math.Round(_dB.GetMaxDeviation(), 2).ToString(CultureInfo.InvariantCulture);
        localAreaTextBox.Text = _dB.GetLocalAreaLength().ToString();
        bedLengthTextBox.Text = _dB.GetLastDataRow().GetLength().ToString();
        tolerLenghtTextBox.Text = _dB.GetFullTolerance().ToString(CultureInfo.InvariantCulture);
        tolerPerMeterTextBox.Text = _dB.GetMeterTolerance().ToString(CultureInfo.InvariantCulture);
        stepTextBox.Text = _dB.Step.ToString();

        if (InTolearance(_dB.GetVerticalDeflection(), _dB.GetFullTolerance()))
        {
            verticalDeviationTextBox.Text = GetSrting(_dB.GetVerticalDeflection());
            verticalDeviationTextBox.BackColor = SystemColors.Control;
        }
        else
        {
            verticalDeviationTextBox.Text = $"Не в допуске {GetSrting(_dB.GetVerticalDeflection())}";
            verticalDeviationTextBox.BackColor = Color.LightCoral;
        }



        if (InTolearance(_dB.GetMeterDeflection(), _dB.GetMeterTolerance()))
        {
            lineDeviationTextBox.Text = GetSrting(_dB.GetMeterDeflection());
            lineDeviationTextBox.BackColor = SystemColors.Control;
        }
        else
        {
            lineDeviationTextBox.Text = $"Не в допуске {GetSrting(_dB.GetMeterDeflection())}";
            lineDeviationTextBox.BackColor = Color.LightCoral;
        }
    }

    public static bool InTolearance(decimal value, int tolerance)
    {
        return value <= tolerance;
    }

    private async void SaveButton_Click(object sender, EventArgs e)
    {
        var filename = GetSaveFileName(FileFormat.Json);

        if (filename != "")
        {
            using var writer = new StreamWriter(filename);
            await writer.WriteLineAsync(JsonSerializer.Serialize(_dB));
            writer.Close();
        }
    }

    private void DescriptionComboBox_TextChanged(object sender, EventArgs e)
    {
        _dB.Description = descriptionComboBox.Text;
    }

    private static string GetSaveFileName(FileFormat format)
    {
        var saveFileDialog = new SaveFileDialog();

        switch (format)
        {
            case FileFormat.Pdf:
                saveFileDialog.Filter = @"PDF|*.pdf";
                saveFileDialog.Title = @"Select PDF file";
                break;
            case FileFormat.Json:
                saveFileDialog.Filter = @"JSON|*.json";
                saveFileDialog.Title = @"Select JSON file";
                break;
        }

        saveFileDialog.ShowDialog();

        return saveFileDialog.FileName;
    }

    private async void LoadFileButton_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = @"Json|*.json",
            Title = @"Load json file"
        };
        openFileDialog.ShowDialog();
        if (openFileDialog.FileName != "")
        {
            _dataForm.Close();
            _graphicsForm.Close();
            //_dataForm.Close();
            //_graphicsForm.Close();
            var reader = new StreamReader(openFileDialog.OpenFile());
            var data = await reader.ReadToEndAsync();
            DB? newDb = JsonSerializer.Deserialize<DB>(data) ?? new DB() { Description = "", Name = "", Fio = "" };
            _dB = newDb;
            _dB.UpdateAllRows();
            UpdateAllFields();
            _dataForm.UpdateForm(null, null);
            _graphicsForm.UpdatePlot();
            reader.Close();
        }
    }

    private void GraphicButton_Click(object sender, EventArgs e)
    {
        _graphicsForm.Dispose();
        _graphicsForm = new GraphicsForm(_dB, this);
        _graphicsForm.Show();
    }

    private void SavePdfButton_Click(object sender, EventArgs e)
    {
        var fileName = GetSaveFileName(FileFormat.Pdf);
        if (fileName != "")
        {
            var document = PdfService.CreateDocument(
                _dB.GetPrintStrings().dbValues,
                _dB.GetPrintStrings().dataListValues,
                new GraphicsForm(_dB, this).GetPlotModel());
            document.Save(fileName);
        }
    }

    private void dateTimePicker_DropDown(object sender, EventArgs e)
    {
        _dB.Date = dateTimePicker.Value.Date;
    }

    private void localAreaTextBox_TextChanged(object sender, EventArgs e)
    {

    }
}