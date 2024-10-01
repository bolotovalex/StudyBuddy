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
            dataGrid.CellEndEdit += dataGrid_CellEndEdit;
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
            // 
            // DataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 616);
            Controls.Add(dataGrid);
            Name = "DataForm";
            Text = "DataForm";
            Load += DataForm_Load;
            Resize += DataForm_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGrid;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn length;
        private DataGridViewTextBoxColumn factProfile;
        private DataGridViewTextBoxColumn straight;
        private DataGridViewTextBoxColumn deviation;
        private DataGridViewTextBoxColumn deviationPerMeter;
        private DataGridViewTextBoxColumn advValue;
        private DataGridViewTextBoxColumn fStroke;
        private DataGridViewTextBoxColumn rStroke;
    }
}