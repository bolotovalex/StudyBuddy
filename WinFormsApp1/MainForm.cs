using System;
using System.IO;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
namespace Pryamolineynost
{
    public partial class MainForm : Form
    {
        private DB dB;
        private DataForm dataForm;
        public MainForm()
        {
            InitializeComponent();
            this.dB = new DB();
            this.dataForm = new DataForm(dB, this);
            this.measurementStepTextPanel.Text = this.dB.GetMeasurementStep().ToString();
        }


        private void updateFIO(object sender, EventArgs e)
        {
            this.fio = comboBox1.Text;
        }

        private void updateMeasure(object sender, EventArgs e)
        {
            this.measurementName = nameComboBox.Text;
        }


        private int CheckTextBoxIntValue(TextBox textBox)
        {
            int result;
            if (int.TryParse(textBox.Text, out result)) { }
            //textBox.BackColor = Color.White;
            else
            {
                //var tr = new Thread(textbox => BlinkTextBox(textBox));
                //tr.Start(textBox);
                textBox.Text = "0";
            }
            return result;
        }

        //private void BlinkTextBox(TextBox textbox)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        textbox.BackColor = Color.Red;
        //        Thread.Sleep(300);
        //        textbox.BackColor = Color.White;
        //    }

        //}

        private void updateStep(object sender, EventArgs e)
        {

            this.dB.SetMeasurementStep(CheckTextBoxIntValue(measurementStepTextPanel));

            this.dB.UpdateStepsPerMeter(this.dB.GetMeasurementStep());
            this.dB.UpdateAllRows();

            this.UpdateAllFields();
            this.dataForm.DataForm_Load(sender, e);
        }

        private void updateAdmLength(object sender, EventArgs e)
        {

            this.admLenght = CheckTextBoxIntValue(admLenghtTextBox);
        }

        private void updateAdmPerMeter(object sender, EventArgs e)
        {
            this.admPerMeter = CheckTextBoxIntValue(admPerMeterTextBox);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var date = (DateTime)dateTimePicker1.Value;
            Console.WriteLine(date);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fillDataFormButton_Click(object sender, EventArgs e)
        {
            if (this.dataForm == null)
            {
                this.dataForm = new DataForm(dB, this);
            }
            this.dataForm.Show();
        }

        public void CleanForm()
        {
            this.dataForm.Dispose();
        }

        public void UpdateAllFields()
        {
            this.minDeviationTextBox.Text = Math.Round(this.dB.GetMinDeviation(), 2).ToString();
            this.maxDeviationTextBox.Text = Math.Round(this.dB.GetMaxDeviation(), 2).ToString();
            this.lineDeviationTextBox.Text = Math.Round(this.dB.GetMeterDeflection(), 2).ToString();
            this.localAreaTextBox.Text = this.dB.GetLocalAreaLength().ToString();
            this.verticalDeviationTextBox.Text = Math.Round(this.dB.GetVerticalDeflection(), 2).ToString();
            this.bedLengthTextBox.Text = this.dB.GetLastDataRow().GetLength().ToString();
        }

        async private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Json|*.json";
            saveFileDialog1.Title = "Save json file";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile()))
                {
                    await writer.WriteLineAsync(JsonSerializer.Serialize(this.dB));
                    writer.Close();
                }
                


            }
                
            
        }
    }
}
