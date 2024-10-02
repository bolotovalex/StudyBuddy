namespace Pryamolineynost
{
    public partial class MainForm : Form
    {
        private DB dB;
        private DataForm dataForm;
        public MainForm()
        {
            InitializeComponent();
            //this.dataList = new DataList();
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


        private int UpdateIntTextBox(TextBox textBox)
        {
            int result;
            if (int.TryParse(textBox.Text, out result))
                textBox.BackColor = Color.White;
            else
                textBox.BackColor = Color.Red;
            return result;
        }

        private void updateStep(object sender, EventArgs e)
        {
            this.dB.SetMeasurementStep(UpdateIntTextBox(measurementStepTextPanel));
            this.dB.UpdateAllRows();
            this.UpdateAllFields();
            this.dataForm.DataForm_Load(sender, e);

        }

        private void updateAdmLength(object sender, EventArgs e)
        {

            this.admLenght = UpdateIntTextBox(admLenghtTextBox);
        }

        private void updateAdmPerMeter(object sender, EventArgs e)
        {
            this.admPerMeter = UpdateIntTextBox(admPerMeterTextBox);
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

        public void UpdateAllFields()
        {
            this.minDeviationTextBox.Text = this.dB.GetMinDeviation().ToString();
            this.maxDeviationTextBox.Text = this.dB.GetMaxDeviation().ToString();
            this.localAreaTextBox.Text = (1000 / this.dB.GetMeasurementStep() * this.dB.GetMeasurementStep()).ToString();



            this.verticalDeviationTextBox.Text = (this.dB.GetMaxDeviation() + (this.dB.GetMinDeviation() * (-1))).ToString();

            this.bedLengthTextBox.Text = this.dB.GetLastDataRow().GetLength().ToString();
        }
    }
}
