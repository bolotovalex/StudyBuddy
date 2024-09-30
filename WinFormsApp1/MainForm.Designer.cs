using System.Data;
using System.Data.Common;
using Pryamolineynost;

namespace Pryamolineynost
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dateLabel = new Label();
            dateTimePicker = new DateTimePicker();
            comboBox1 = new ComboBox();
            nameComboBox = new ComboBox();
            nameLabel = new Label();
            label3 = new Label();
            maxDeviationLabel = new Label();
            minDeviationLabel = new Label();
            verticalDeviationLabel = new Label();
            lineDeviationLabel = new Label();
            admLengthLabel = new Label();
            label9 = new Label();
            label10 = new Label();
            datePanel = new Panel();
            namePanel = new Panel();
            dateTimePicker1 = new DateTimePicker();
            panel1 = new Panel();
            dateTimePicker2 = new DateTimePicker();
            maxDeviationPanel = new Panel();
            maxDeviationTextBox = new TextBox();
            dateTimePicker3 = new DateTimePicker();
            minDeviationPanel = new Panel();
            minDeviationTextBox = new TextBox();
            dateTimePicker4 = new DateTimePicker();
            verticalDeviationPanel = new Panel();
            verticalDeviationTextBox = new TextBox();
            dateTimePicker5 = new DateTimePicker();
            lineDeviationPanel = new Panel();
            lineDeviationTextBox = new TextBox();
            dateTimePicker6 = new DateTimePicker();
            admLenghtPanel = new Panel();
            admLenghtTextBox = new TextBox();
            dateTimePicker7 = new DateTimePicker();
            admPerMeterPanel = new Panel();
            admPerMeterTextBox = new TextBox();
            dateTimePicker8 = new DateTimePicker();
            measurementStepPanel = new Panel();
            measurementStepTextPanel = new TextBox();
            dateTimePicker9 = new DateTimePicker();
            graphicButton = new Button();
            button1 = new Button();
            exitButton = new Button();
            loadFileButton = new Button();
            saveButton = new Button();
            fillDataFormButton = new Button();
            datePanel.SuspendLayout();
            namePanel.SuspendLayout();
            panel1.SuspendLayout();
            maxDeviationPanel.SuspendLayout();
            minDeviationPanel.SuspendLayout();
            verticalDeviationPanel.SuspendLayout();
            lineDeviationPanel.SuspendLayout();
            admLenghtPanel.SuspendLayout();
            admPerMeterPanel.SuspendLayout();
            measurementStepPanel.SuspendLayout();
            SuspendLayout();
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(10, 7);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(32, 15);
            dateLabel.TabIndex = 3;
            dateLabel.Text = "Дата";
            
            // 
            // dateTimePicker
            // 
            dateTimePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker.Checked = false;
            dateTimePicker.Enabled = false;
            dateTimePicker.Location = new Point(364, 3);
            dateTimePicker.MinDate = new DateTime(2024, 9, 26, 0, 0, 0, 0);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(126, 23);
            dateTimePicker.TabIndex = 0;
            dateTimePicker.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(206, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.RightToLeft = RightToLeft.Yes;
            comboBox1.Size = new Size(284, 23);
            comboBox1.TabIndex = 1;
            comboBox1.TextUpdate += updateFIO;
            // 
            // nameComboBox
            // 
            nameComboBox.FlatStyle = FlatStyle.System;
            nameComboBox.FormattingEnabled = true;
            nameComboBox.Location = new Point(206, 3);
            nameComboBox.Name = "nameComboBox";
            nameComboBox.RightToLeft = RightToLeft.Yes;
            nameComboBox.Size = new Size(284, 23);
            nameComboBox.TabIndex = 2;
            nameComboBox.TextChanged += updateMeasure;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(10, 7);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(169, 15);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "Наименование/Обозначение";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 7);
            label3.Name = "label3";
            label3.Size = new Size(124, 15);
            label3.TabIndex = 5;
            label3.Text = "Измерение произвел";
            // 
            // maxDeviationLabel
            // 
            maxDeviationLabel.AutoSize = true;
            maxDeviationLabel.Location = new Point(10, 7);
            maxDeviationLabel.Name = "maxDeviationLabel";
            maxDeviationLabel.Size = new Size(177, 15);
            maxDeviationLabel.TabIndex = 6;
            maxDeviationLabel.Text = "Наибольшее отклонение, мкм";
            // 
            // minDeviationLabel
            // 
            minDeviationLabel.AutoSize = true;
            minDeviationLabel.Location = new Point(10, 7);
            minDeviationLabel.Name = "minDeviationLabel";
            minDeviationLabel.Size = new Size(178, 15);
            minDeviationLabel.TabIndex = 7;
            minDeviationLabel.Text = "Наименьшее отклонение, мкм";
            // 
            // verticalDeviationLabel
            // 
            verticalDeviationLabel.AutoSize = true;
            verticalDeviationLabel.Location = new Point(10, 7);
            verticalDeviationLabel.Name = "verticalDeviationLabel";
            verticalDeviationLabel.Size = new Size(374, 15);
            verticalDeviationLabel.TabIndex = 8;
            verticalDeviationLabel.Text = "Отклонение от прямолинейности в вертикальной плоскости, мкм";
            // 
            // lineDeviationLabel
            // 
            lineDeviationLabel.AutoSize = true;
            lineDeviationLabel.Location = new Point(10, 7);
            lineDeviationLabel.Name = "lineDeviationLabel";
            lineDeviationLabel.Size = new Size(279, 15);
            lineDeviationLabel.TabIndex = 9;
            lineDeviationLabel.Text = "Отклонение от прямолинейности на 1 метр, мкм";
            // 
            // admLengthLabel
            // 
            admLengthLabel.AutoSize = true;
            admLengthLabel.Location = new Point(10, 7);
            admLengthLabel.Name = "admLengthLabel";
            admLengthLabel.Size = new Size(154, 15);
            admLengthLabel.TabIndex = 10;
            admLengthLabel.Text = "Допуск на всю длину, мкм";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(10, 7);
            label9.Name = "label9";
            label9.Size = new Size(132, 15);
            label9.TabIndex = 11;
            label9.Text = "Допуск на 1 метр, мкм";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(10, 7);
            label10.Name = "label10";
            label10.Size = new Size(331, 15);
            label10.TabIndex = 12;
            label10.Text = "Шаг измерения (расстояние между опорами мостика), мм";
            // 
            // datePanel
            // 
            datePanel.BorderStyle = BorderStyle.FixedSingle;
            datePanel.Controls.Add(dateLabel);
            datePanel.Controls.Add(dateTimePicker);
            datePanel.Location = new Point(8, 12);
            datePanel.Name = "datePanel";
            datePanel.Size = new Size(495, 31);
            datePanel.TabIndex = 15;
            // 
            // namePanel
            // 
            namePanel.BorderStyle = BorderStyle.FixedSingle;
            namePanel.Controls.Add(nameLabel);
            namePanel.Controls.Add(dateTimePicker1);
            namePanel.Controls.Add(nameComboBox);
            namePanel.Location = new Point(8, 49);
            namePanel.Name = "namePanel";
            namePanel.Size = new Size(495, 31);
            namePanel.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker1.Location = new Point(697, 3);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(251, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(dateTimePicker2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(8, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(495, 31);
            panel1.TabIndex = 17;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker2.Location = new Point(697, 3);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(251, 23);
            dateTimePicker2.TabIndex = 0;
            // 
            // maxDeviationPanel
            // 
            maxDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
            maxDeviationPanel.Controls.Add(maxDeviationTextBox);
            maxDeviationPanel.Controls.Add(dateTimePicker3);
            maxDeviationPanel.Controls.Add(maxDeviationLabel);
            maxDeviationPanel.Location = new Point(8, 123);
            maxDeviationPanel.Name = "maxDeviationPanel";
            maxDeviationPanel.Size = new Size(495, 31);
            maxDeviationPanel.TabIndex = 18;
            // 
            // maxDeviationTextBox
            // 
            maxDeviationTextBox.BackColor = SystemColors.Control;
            maxDeviationTextBox.Location = new Point(390, 3);
            maxDeviationTextBox.Name = "maxDeviationTextBox";
            maxDeviationTextBox.ReadOnly = true;
            maxDeviationTextBox.Size = new Size(100, 23);
            maxDeviationTextBox.TabIndex = 7;
            maxDeviationTextBox.Text = "0";
            maxDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker3.Location = new Point(697, 3);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(251, 23);
            dateTimePicker3.TabIndex = 0;
            // 
            // minDeviationPanel
            // 
            minDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
            minDeviationPanel.Controls.Add(minDeviationTextBox);
            minDeviationPanel.Controls.Add(dateTimePicker4);
            minDeviationPanel.Controls.Add(minDeviationLabel);
            minDeviationPanel.Location = new Point(8, 160);
            minDeviationPanel.Name = "minDeviationPanel";
            minDeviationPanel.Size = new Size(495, 31);
            minDeviationPanel.TabIndex = 19;
            // 
            // minDeviationTextBox
            // 
            minDeviationTextBox.BackColor = SystemColors.Control;
            minDeviationTextBox.Location = new Point(390, 3);
            minDeviationTextBox.Name = "minDeviationTextBox";
            minDeviationTextBox.ReadOnly = true;
            minDeviationTextBox.Size = new Size(100, 23);
            minDeviationTextBox.TabIndex = 8;
            minDeviationTextBox.Text = "0";
            minDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // dateTimePicker4
            // 
            dateTimePicker4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker4.Location = new Point(697, 3);
            dateTimePicker4.Name = "dateTimePicker4";
            dateTimePicker4.Size = new Size(251, 23);
            dateTimePicker4.TabIndex = 0;
            // 
            // verticalDeviationPanel
            // 
            verticalDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
            verticalDeviationPanel.Controls.Add(verticalDeviationTextBox);
            verticalDeviationPanel.Controls.Add(dateTimePicker5);
            verticalDeviationPanel.Controls.Add(verticalDeviationLabel);
            verticalDeviationPanel.Location = new Point(8, 197);
            verticalDeviationPanel.Name = "verticalDeviationPanel";
            verticalDeviationPanel.Size = new Size(495, 31);
            verticalDeviationPanel.TabIndex = 20;
            // 
            // verticalDeviationTextBox
            // 
            verticalDeviationTextBox.BackColor = SystemColors.Control;
            verticalDeviationTextBox.Location = new Point(390, 3);
            verticalDeviationTextBox.Name = "verticalDeviationTextBox";
            verticalDeviationTextBox.ReadOnly = true;
            verticalDeviationTextBox.Size = new Size(100, 23);
            verticalDeviationTextBox.TabIndex = 9;
            verticalDeviationTextBox.Text = "0";
            verticalDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // dateTimePicker5
            // 
            dateTimePicker5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker5.Location = new Point(1155, 3);
            dateTimePicker5.Name = "dateTimePicker5";
            dateTimePicker5.Size = new Size(251, 23);
            dateTimePicker5.TabIndex = 0;
            // 
            // lineDeviationPanel
            // 
            lineDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
            lineDeviationPanel.Controls.Add(lineDeviationTextBox);
            lineDeviationPanel.Controls.Add(dateTimePicker6);
            lineDeviationPanel.Controls.Add(lineDeviationLabel);
            lineDeviationPanel.Location = new Point(8, 234);
            lineDeviationPanel.Name = "lineDeviationPanel";
            lineDeviationPanel.Size = new Size(495, 31);
            lineDeviationPanel.TabIndex = 21;
            // 
            // lineDeviationTextBox
            // 
            lineDeviationTextBox.BackColor = SystemColors.Control;
            lineDeviationTextBox.Location = new Point(390, 3);
            lineDeviationTextBox.Name = "lineDeviationTextBox";
            lineDeviationTextBox.ReadOnly = true;
            lineDeviationTextBox.Size = new Size(100, 23);
            lineDeviationTextBox.TabIndex = 10;
            lineDeviationTextBox.Text = "0";
            lineDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // dateTimePicker6
            // 
            dateTimePicker6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker6.Location = new Point(1155, 3);
            dateTimePicker6.Name = "dateTimePicker6";
            dateTimePicker6.Size = new Size(251, 23);
            dateTimePicker6.TabIndex = 0;
            // 
            // admLenghtPanel
            // 
            admLenghtPanel.BorderStyle = BorderStyle.FixedSingle;
            admLenghtPanel.Controls.Add(admLenghtTextBox);
            admLenghtPanel.Controls.Add(dateTimePicker7);
            admLenghtPanel.Controls.Add(admLengthLabel);
            admLenghtPanel.Location = new Point(8, 271);
            admLenghtPanel.Name = "admLenghtPanel";
            admLenghtPanel.Size = new Size(495, 31);
            admLenghtPanel.TabIndex = 22;
            // 
            // admLenghtTextBox
            // 
            admLenghtTextBox.Location = new Point(390, 3);
            admLenghtTextBox.Name = "admLenghtTextBox";
            admLenghtTextBox.Size = new Size(100, 23);
            admLenghtTextBox.TabIndex = 11;
            admLenghtTextBox.Text = "0";
            admLenghtTextBox.TextAlign = HorizontalAlignment.Right;
            admLenghtTextBox.TextChanged += updateAdmLength;
            // 
            // dateTimePicker7
            // 
            dateTimePicker7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker7.Location = new Point(1155, 3);
            dateTimePicker7.Name = "dateTimePicker7";
            dateTimePicker7.Size = new Size(251, 23);
            dateTimePicker7.TabIndex = 0;
            // 
            // admPerMeterPanel
            // 
            admPerMeterPanel.BorderStyle = BorderStyle.FixedSingle;
            admPerMeterPanel.Controls.Add(admPerMeterTextBox);
            admPerMeterPanel.Controls.Add(dateTimePicker8);
            admPerMeterPanel.Controls.Add(label9);
            admPerMeterPanel.Location = new Point(8, 308);
            admPerMeterPanel.Name = "admPerMeterPanel";
            admPerMeterPanel.Size = new Size(495, 31);
            admPerMeterPanel.TabIndex = 23;
            // 
            // admPerMeterTextBox
            // 
            admPerMeterTextBox.Location = new Point(390, 3);
            admPerMeterTextBox.Name = "admPerMeterTextBox";
            admPerMeterTextBox.Size = new Size(100, 23);
            admPerMeterTextBox.TabIndex = 12;
            admPerMeterTextBox.Text = "0";
            admPerMeterTextBox.TextAlign = HorizontalAlignment.Right;
            admPerMeterTextBox.TextChanged += updateAdmPerMeter;
            // 
            // dateTimePicker8
            // 
            dateTimePicker8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker8.Location = new Point(1155, 3);
            dateTimePicker8.Name = "dateTimePicker8";
            dateTimePicker8.Size = new Size(251, 23);
            dateTimePicker8.TabIndex = 0;
            // 
            // measurementStepPanel
            // 
            measurementStepPanel.BorderStyle = BorderStyle.FixedSingle;
            measurementStepPanel.Controls.Add(measurementStepTextPanel);
            measurementStepPanel.Controls.Add(dateTimePicker9);
            measurementStepPanel.Controls.Add(label10);
            measurementStepPanel.Location = new Point(8, 345);
            measurementStepPanel.Name = "measurementStepPanel";
            measurementStepPanel.Size = new Size(495, 31);
            measurementStepPanel.TabIndex = 24;
            // 
            // measurementStepTextPanel
            // 
            measurementStepTextPanel.Location = new Point(390, 3);
            measurementStepTextPanel.Name = "measurementStepTextPanel";
            measurementStepTextPanel.Size = new Size(100, 23);
            measurementStepTextPanel.TabIndex = 13;
            measurementStepTextPanel.Text = "0";
            measurementStepTextPanel.TextAlign = HorizontalAlignment.Right;
            measurementStepTextPanel.TextChanged += updateStep;
            // 
            // dateTimePicker9
            // 
            dateTimePicker9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker9.Location = new Point(1155, 3);
            dateTimePicker9.Name = "dateTimePicker9";
            dateTimePicker9.Size = new Size(251, 23);
            dateTimePicker9.TabIndex = 0;
            // 
            // graphicButton
            // 
            graphicButton.Location = new Point(178, 382);
            graphicButton.Name = "graphicButton";
            graphicButton.Size = new Size(155, 31);
            graphicButton.TabIndex = 26;
            graphicButton.Text = "График";
            graphicButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(8, 419);
            button1.Name = "button1";
            button1.Size = new Size(155, 31);
            button1.TabIndex = 27;
            button1.Text = "Выгрузить PDF";
            button1.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(348, 419);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(155, 31);
            exitButton.TabIndex = 28;
            exitButton.Text = "Выход";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // loadFileButton
            // 
            loadFileButton.Location = new Point(348, 382);
            loadFileButton.Name = "loadFileButton";
            loadFileButton.Size = new Size(155, 31);
            loadFileButton.TabIndex = 29;
            loadFileButton.Text = "Загрузить";
            loadFileButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(178, 419);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(155, 31);
            saveButton.TabIndex = 30;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // fillDataFormButton
            // 
            fillDataFormButton.Location = new Point(8, 382);
            fillDataFormButton.Name = "fillDataFormButton";
            fillDataFormButton.Size = new Size(155, 31);
            fillDataFormButton.TabIndex = 25;
            fillDataFormButton.Text = "Заполнить данные";
            fillDataFormButton.UseVisualStyleBackColor = true;
            fillDataFormButton.Click += fillDataFormButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 455);
            Controls.Add(saveButton);
            Controls.Add(loadFileButton);
            Controls.Add(exitButton);
            Controls.Add(button1);
            Controls.Add(graphicButton);
            Controls.Add(fillDataFormButton);
            Controls.Add(measurementStepPanel);
            Controls.Add(admPerMeterPanel);
            Controls.Add(admLenghtPanel);
            Controls.Add(lineDeviationPanel);
            Controls.Add(verticalDeviationPanel);
            Controls.Add(minDeviationPanel);
            Controls.Add(maxDeviationPanel);
            Controls.Add(panel1);
            Controls.Add(namePanel);
            Controls.Add(datePanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Прямолинейность";
            datePanel.ResumeLayout(false);
            datePanel.PerformLayout();
            namePanel.ResumeLayout(false);
            namePanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            maxDeviationPanel.ResumeLayout(false);
            maxDeviationPanel.PerformLayout();
            minDeviationPanel.ResumeLayout(false);
            minDeviationPanel.PerformLayout();
            verticalDeviationPanel.ResumeLayout(false);
            verticalDeviationPanel.PerformLayout();
            lineDeviationPanel.ResumeLayout(false);
            lineDeviationPanel.PerformLayout();
            admLenghtPanel.ResumeLayout(false);
            admLenghtPanel.PerformLayout();
            admPerMeterPanel.ResumeLayout(false);
            admPerMeterPanel.PerformLayout();
            measurementStepPanel.ResumeLayout(false);
            measurementStepPanel.PerformLayout();
            ResumeLayout(false);
        }


        #endregion

        private DateTimePicker dateTimePicker;
        private ComboBox comboBox1;
        private ComboBox nameComboBox;
        private Label dateLabel;
        private Label nameLabel;
        private Label label3;
        private Label maxDeviationLabel;
        private Label minDeviationLabel;
        private Label verticalDeviationLabel;
        private Label lineDeviationLabel;
        private Label admLengthLabel;
        private Label label9;
        private Label label10;
        private Panel datePanel;
        private Panel namePanel;
        private DateTimePicker dateTimePicker1;
        private Panel panel1;
        private DateTimePicker dateTimePicker2;
        private Panel maxDeviationPanel;
        private DateTimePicker dateTimePicker3;
        private Panel minDeviationPanel;
        private DateTimePicker dateTimePicker4;
        private Panel verticalDeviationPanel;
        private DateTimePicker dateTimePicker5;
        private Panel lineDeviationPanel;
        private DateTimePicker dateTimePicker6;
        private Panel admLenghtPanel;
        private DateTimePicker dateTimePicker7;
        private Panel admPerMeterPanel;
        private DateTimePicker dateTimePicker8;
        private Panel measurementStepPanel;
        private DateTimePicker dateTimePicker9;
        private Button graphicButton;
        private Button button1;
        private Button exitButton;
        private TextBox maxDeviationTextBox;
        private TextBox minDeviationTextBox;
        private TextBox verticalDeviationTextBox;
        private TextBox lineDeviationTextBox;
        private TextBox admLenghtTextBox;
        private TextBox admPerMeterTextBox;
        private TextBox measurementStepTextPanel;
        private Button loadFileButton;
        private Button saveButton;
        private int step;
        private int admPerMeter;
        private int admLenght;
        private DateTime dateTime;
        private string measurementName;
        private string fio;
        private Button fillDataFormButton;
    }
}
