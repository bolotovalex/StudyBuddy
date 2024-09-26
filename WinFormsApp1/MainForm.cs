using Pryamolineynost;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
            DataForm dataForm = new DataForm();
            dataForm.Show();
        }
    }
}
