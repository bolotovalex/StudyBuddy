using Pryamolineynost;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        DataList dataList = new DataList();
        public MainForm()
        {
            InitializeComponent();
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
            this.step = UpdateIntTextBox(measurementStepTextPanel);
        }

        private void updateAdmLength(object sender, EventArgs e)
        {
            this.admLenght = UpdateIntTextBox(admLenghtTextBox);
        }

        private void updateAdmPerMeter(object sender, EventArgs e)
        {
            this.admPerMeter = UpdateIntTextBox(admPerMeterTextBox);
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            DataForm dataForm = new DataForm(this.step, this.admLenght, this.admPerMeter, dataList);
            dataForm.Show();
        }
    }
}
