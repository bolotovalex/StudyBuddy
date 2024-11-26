namespace Pryamolineynost
{
    partial class DataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGrid = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            length = new DataGridViewTextBoxColumn();
            factProfile = new DataGridViewTextBoxColumn();
            straight = new DataGridViewTextBoxColumn();
            deviation = new DataGridViewTextBoxColumn();
            deviationPerMeter = new DataGridViewTextBoxColumn();
            advValue = new DataGridViewTextBoxColumn();
            fStroke = new DataGridViewTextBoxColumn();
            rStroke = new DataGridViewTextBoxColumn();
            closeButton = new Button();
            clearDBButton = new Button();
            revStrokeCheckBox = new CheckBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // dataGrid
            // 
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Columns.AddRange(new DataGridViewColumn[] { id, length, factProfile, straight, deviation, deviationPerMeter, advValue, fStroke, rStroke });
            dataGrid.Location = new Point(3, 2);
            dataGrid.Name = "dataGrid";
            dataGrid.Size = new Size(915, 580);
            dataGrid.TabIndex = 3;
            dataGrid.CellEndEdit += DataGrid_CellEndEdit;
            dataGrid.DataContextChanged += DataForm_SizeChanged;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            id.HeaderText = "№ изм(точка)";
            id.Name = "id";
            id.ReadOnly = true;
            id.Resizable = DataGridViewTriState.False;
            // 
            // length
            // 
            length.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            length.HeaderText = "Длина измерения, мм";
            length.Name = "length";
            length.ReadOnly = true;
            // 
            // factProfile
            // 
            factProfile.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            factProfile.HeaderText = "Фактический профиль проверяемой поверхности, мкм";
            factProfile.Name = "factProfile";
            factProfile.ReadOnly = true;
            // 
            // straight
            // 
            straight.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            straight.HeaderText = "Прилегающая прямая, мкм";
            straight.Name = "straight";
            straight.ReadOnly = true;
            // 
            // deviation
            // 
            deviation.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            deviation.HeaderText = "Отклонение, мкм";
            deviation.Name = "deviation";
            deviation.ReadOnly = true;
            // 
            // deviationPerMeter
            // 
            deviationPerMeter.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            deviationPerMeter.HeaderText = "Отклонение на метре, мкм";
            deviationPerMeter.Name = "deviationPerMeter";
            deviationPerMeter.ReadOnly = true;
            // 
            // advValue
            // 
            advValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            advValue.HeaderText = "Среднее значение, мкм";
            advValue.Name = "advValue";
            advValue.ReadOnly = true;
            advValue.Visible = false;
            // 
            // fStroke
            // 
            fStroke.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fStroke.HeaderText = "Прямой ход, мкм";
            fStroke.Name = "fStroke";
            // 
            // rStroke
            // 
            rStroke.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            rStroke.HeaderText = "Обратный ход, мкм";
            rStroke.Name = "rStroke";
            rStroke.Visible = false;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(843, 588);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 4;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // clearDBButton
            // 
            clearDBButton.Location = new Point(3, 588);
            clearDBButton.Name = "clearDBButton";
            clearDBButton.Size = new Size(75, 23);
            clearDBButton.TabIndex = 5;
            clearDBButton.Text = "Очистить";
            clearDBButton.UseVisualStyleBackColor = true;
            clearDBButton.Click += ClearDBButton_Click;
            // 
            // revStrokeCheckBox
            // 
            revStrokeCheckBox.AutoSize = true;
            revStrokeCheckBox.Location = new Point(733, 591);
            revStrokeCheckBox.Name = "revStrokeCheckBox";
            revStrokeCheckBox.Size = new Size(105, 19);
            revStrokeCheckBox.TabIndex = 6;
            revStrokeCheckBox.Text = "Обратный ход";
            revStrokeCheckBox.UseVisualStyleBackColor = true;
            revStrokeCheckBox.CheckedChanged += revStrokeCheckBox_CheckedChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Микрометр", "Градус/Минута/Секунды" });
            comboBox1.Location = new Point(534, 588);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(180, 23);
            comboBox1.TabIndex = 7;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(410, 592);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 8;
            label1.Text = "Единицы измерения:";
            // 
            // DataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 616);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(revStrokeCheckBox);
            Controls.Add(clearDBButton);
            Controls.Add(closeButton);
            Controls.Add(dataGrid);
            MinimumSize = new Size(640, 480);
            Name = "DataForm";
            Text = "Измерения";
            Load += DataForm_Load;
            Resize += DataForm_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGrid;
        private Button closeButton;
        private Button clearDBButton;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn length;
        private DataGridViewTextBoxColumn factProfile;
        private DataGridViewTextBoxColumn straight;
        private DataGridViewTextBoxColumn deviation;
        private DataGridViewTextBoxColumn deviationPerMeter;
        private DataGridViewTextBoxColumn advValue;
        private DataGridViewTextBoxColumn fStroke;
        private DataGridViewTextBoxColumn rStroke;
        private CheckBox revStrokeCheckBox;
        private ComboBox comboBox1;
        private Label label1;
    }
}