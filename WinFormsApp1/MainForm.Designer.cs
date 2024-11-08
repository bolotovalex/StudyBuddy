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
            //this.Close();
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
            datePanel = new Panel();
            dateLabel = new Label();
            dateTimePicker = new DateTimePicker();
            namePanel = new Panel();
            nameLabel = new Label();
            nameComboBox = new ComboBox();
            descriptionPanel = new Panel();
            descriptionComboBox = new ComboBox();
            descriptionLabel = new Label();
            fioPanel = new Panel();
            fioComboBox = new ComboBox();
            fioLabel = new Label();
            maxDeviationPanel = new Panel();
            maxDeviationTextBox = new TextBox();
            maxDeviationLabel = new Label();
            minDeviationPanel = new Panel();
            minDeviationTextBox = new TextBox();
            minDeviationLabel = new Label();
            verticalDeviationPanel = new Panel();
            verticalDeviationTextBox = new TextBox();
            verticalDeviationLabel = new Label();
            lineDeviationPanel = new Panel();
            lineDeviationTextBox = new TextBox();
            lineDeviationLabel = new Label();
            bedPanelLength = new Panel();
            bedLengthTextBox = new TextBox();
            bedLengthLabel = new Label();
            localAreaPanel = new Panel();
            localAreaTextBox = new TextBox();
            localAreaLabel = new Label();
            tolerPerMeterPanel = new Panel();
            tolerPerMeterTextBox = new TextBox();
            tolerPerMeterLabel = new Label();
            tolerLenghtPanel = new Panel();
            tolerLenghtTextBox = new TextBox();
            tolerLengthLabel = new Label();
            stepPanel = new Panel();
            stepTextBox = new TextBox();
            stepLabel = new Label();
            fillDataFormButton = new Button();
            graphicButton = new Button();
            saveButton = new Button();
            loadFileButton = new Button();
            savePdfButton = new Button();
            exitButton = new Button();
            datePanel.SuspendLayout();
            namePanel.SuspendLayout();
            descriptionPanel.SuspendLayout();
            fioPanel.SuspendLayout();
            maxDeviationPanel.SuspendLayout();
            minDeviationPanel.SuspendLayout();
            verticalDeviationPanel.SuspendLayout();
            lineDeviationPanel.SuspendLayout();
            bedPanelLength.SuspendLayout();
            localAreaPanel.SuspendLayout();
            tolerPerMeterPanel.SuspendLayout();
            tolerLenghtPanel.SuspendLayout();
            stepPanel.SuspendLayout();
            SuspendLayout();
            // 
            // datePanel
            // 
            datePanel.BorderStyle = BorderStyle.FixedSingle;
            datePanel.Controls.Add(dateLabel);
            datePanel.Controls.Add(dateTimePicker);
            datePanel.Location = new Point(8, 12);
            datePanel.Name = "datePanel";
            datePanel.Size = new Size(527, 31);
            datePanel.TabIndex = 0;
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
            dateTimePicker.CustomFormat = "dd MMMM yyyy";
            dateTimePicker.Location = new Point(400, 3);
            dateTimePicker.MinDate = new DateTime(2024, 9, 1, 0, 0, 0, 0);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.RightToLeft = RightToLeft.No;
            dateTimePicker.Size = new Size(122, 23);
            dateTimePicker.TabIndex = 1;
            dateTimePicker.CloseUp += dateTimePicker_DropDown;
            // 
            // namePanel
            // 
            namePanel.BorderStyle = BorderStyle.FixedSingle;
            namePanel.Controls.Add(nameLabel);
            namePanel.Controls.Add(nameComboBox);
            namePanel.Location = new Point(8, 49);
            namePanel.Name = "namePanel";
            namePanel.Size = new Size(527, 31);
            namePanel.TabIndex = 2;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(10, 7);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(90, 15);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "Наименование";
            // 
            // nameComboBox
            // 
            nameComboBox.FlatStyle = FlatStyle.System;
            nameComboBox.FormattingEnabled = true;
            nameComboBox.Location = new Point(108, 3);
            nameComboBox.Name = "nameComboBox";
            nameComboBox.RightToLeft = RightToLeft.Yes;
            nameComboBox.Size = new Size(414, 23);
            nameComboBox.TabIndex = 4;
            nameComboBox.TextChanged += UpdateProjectName;
            // 
            // descriptionPanel
            // 
            descriptionPanel.BorderStyle = BorderStyle.FixedSingle;
            descriptionPanel.Controls.Add(descriptionComboBox);
            descriptionPanel.Controls.Add(descriptionLabel);
            descriptionPanel.Location = new Point(8, 86);
            descriptionPanel.Name = "descriptionPanel";
            descriptionPanel.Size = new Size(527, 31);
            descriptionPanel.TabIndex = 5;
            // 
            // descriptionComboBox
            // 
            descriptionComboBox.FlatStyle = FlatStyle.System;
            descriptionComboBox.FormattingEnabled = true;
            descriptionComboBox.Location = new Point(108, 3);
            descriptionComboBox.Name = "descriptionComboBox";
            descriptionComboBox.RightToLeft = RightToLeft.Yes;
            descriptionComboBox.Size = new Size(414, 23);
            descriptionComboBox.TabIndex = 7;
            descriptionComboBox.TextChanged += DescriptionComboBox_TextChanged;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(8, 7);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(81, 15);
            descriptionLabel.TabIndex = 6;
            descriptionLabel.Text = "Обозначение";
            // 
            // fioPanel
            // 
            fioPanel.BorderStyle = BorderStyle.FixedSingle;
            fioPanel.Controls.Add(fioComboBox);
            fioPanel.Controls.Add(fioLabel);
            fioPanel.Location = new Point(8, 123);
            fioPanel.Name = "fioPanel";
            fioPanel.Size = new Size(527, 31);
            fioPanel.TabIndex = 8;
            // 
            // fioComboBox
            // 
            fioComboBox.FormattingEnabled = true;
            fioComboBox.Location = new Point(140, 3);
            fioComboBox.Name = "fioComboBox";
            fioComboBox.RightToLeft = RightToLeft.Yes;
            fioComboBox.Size = new Size(382, 23);
            fioComboBox.TabIndex = 10;
            fioComboBox.TextUpdate += UpdateFio;
            // 
            // fioLabel
            // 
            fioLabel.AutoSize = true;
            fioLabel.Location = new Point(10, 7);
            fioLabel.Name = "fioLabel";
            fioLabel.Size = new Size(124, 15);
            fioLabel.TabIndex = 9;
            fioLabel.Text = "Измерение произвел";
            // 
            // maxDeviationPanel
            // 
            maxDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
            maxDeviationPanel.Controls.Add(maxDeviationTextBox);
            maxDeviationPanel.Controls.Add(maxDeviationLabel);
            maxDeviationPanel.Location = new Point(8, 160);
            maxDeviationPanel.Name = "maxDeviationPanel";
            maxDeviationPanel.Size = new Size(527, 31);
            maxDeviationPanel.TabIndex = 11;
            // 
            // maxDeviationTextBox
            // 
            maxDeviationTextBox.BackColor = SystemColors.Control;
            maxDeviationTextBox.Location = new Point(390, 3);
            maxDeviationTextBox.Name = "maxDeviationTextBox";
            maxDeviationTextBox.ReadOnly = true;
            maxDeviationTextBox.Size = new Size(132, 23);
            maxDeviationTextBox.TabIndex = 13;
            maxDeviationTextBox.TabStop = false;
            maxDeviationTextBox.Text = "0";
            maxDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // maxDeviationLabel
            // 
            maxDeviationLabel.AutoSize = true;
            maxDeviationLabel.Location = new Point(10, 7);
            maxDeviationLabel.Name = "maxDeviationLabel";
            maxDeviationLabel.Size = new Size(177, 15);
            maxDeviationLabel.TabIndex = 12;
            maxDeviationLabel.Text = "Наибольшее отклонение, мкм";
            // 
            // minDeviationPanel
            // 
            minDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
            minDeviationPanel.Controls.Add(minDeviationTextBox);
            minDeviationPanel.Controls.Add(minDeviationLabel);
            minDeviationPanel.Location = new Point(8, 197);
            minDeviationPanel.Name = "minDeviationPanel";
            minDeviationPanel.Size = new Size(527, 31);
            minDeviationPanel.TabIndex = 14;
            // 
            // minDeviationTextBox
            // 
            minDeviationTextBox.BackColor = SystemColors.Control;
            minDeviationTextBox.Location = new Point(390, 3);
            minDeviationTextBox.Name = "minDeviationTextBox";
            minDeviationTextBox.ReadOnly = true;
            minDeviationTextBox.Size = new Size(132, 23);
            minDeviationTextBox.TabIndex = 16;
            minDeviationTextBox.TabStop = false;
            minDeviationTextBox.Text = "0";
            minDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // minDeviationLabel
            // 
            minDeviationLabel.AutoSize = true;
            minDeviationLabel.Location = new Point(10, 7);
            minDeviationLabel.Name = "minDeviationLabel";
            minDeviationLabel.Size = new Size(178, 15);
            minDeviationLabel.TabIndex = 15;
            minDeviationLabel.Text = "Наименьшее отклонение, мкм";
            // 
            // verticalDeviationPanel
            // 
            verticalDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
            verticalDeviationPanel.Controls.Add(verticalDeviationTextBox);
            verticalDeviationPanel.Controls.Add(verticalDeviationLabel);
            verticalDeviationPanel.Location = new Point(8, 234);
            verticalDeviationPanel.Name = "verticalDeviationPanel";
            verticalDeviationPanel.Size = new Size(527, 31);
            verticalDeviationPanel.TabIndex = 17;
            // 
            // verticalDeviationTextBox
            // 
            verticalDeviationTextBox.BackColor = SystemColors.Control;
            verticalDeviationTextBox.Location = new Point(390, 3);
            verticalDeviationTextBox.Name = "verticalDeviationTextBox";
            verticalDeviationTextBox.ReadOnly = true;
            verticalDeviationTextBox.Size = new Size(132, 23);
            verticalDeviationTextBox.TabIndex = 19;
            verticalDeviationTextBox.TabStop = false;
            verticalDeviationTextBox.Text = "0";
            verticalDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // verticalDeviationLabel
            // 
            verticalDeviationLabel.AutoSize = true;
            verticalDeviationLabel.Location = new Point(10, 7);
            verticalDeviationLabel.Name = "verticalDeviationLabel";
            verticalDeviationLabel.Size = new Size(374, 15);
            verticalDeviationLabel.TabIndex = 18;
            verticalDeviationLabel.Text = "Отклонение от прямолинейности в вертикальной плоскости, мкм";
            // 
            // lineDeviationPanel
            // 
            lineDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
            lineDeviationPanel.Controls.Add(lineDeviationTextBox);
            lineDeviationPanel.Controls.Add(lineDeviationLabel);
            lineDeviationPanel.Location = new Point(8, 271);
            lineDeviationPanel.Name = "lineDeviationPanel";
            lineDeviationPanel.Size = new Size(527, 31);
            lineDeviationPanel.TabIndex = 20;
            // 
            // lineDeviationTextBox
            // 
            lineDeviationTextBox.BackColor = SystemColors.Control;
            lineDeviationTextBox.Location = new Point(390, 3);
            lineDeviationTextBox.Name = "lineDeviationTextBox";
            lineDeviationTextBox.ReadOnly = true;
            lineDeviationTextBox.Size = new Size(132, 23);
            lineDeviationTextBox.TabIndex = 22;
            lineDeviationTextBox.TabStop = false;
            lineDeviationTextBox.Text = "0";
            lineDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // lineDeviationLabel
            // 
            lineDeviationLabel.AutoSize = true;
            lineDeviationLabel.Location = new Point(10, 7);
            lineDeviationLabel.Name = "lineDeviationLabel";
            lineDeviationLabel.Size = new Size(350, 15);
            lineDeviationLabel.TabIndex = 21;
            lineDeviationLabel.Text = "Отклонение от прямолинейности на локальном участке, мкм";
            // 
            // bedPanelLength
            // 
            bedPanelLength.BorderStyle = BorderStyle.FixedSingle;
            bedPanelLength.Controls.Add(bedLengthTextBox);
            bedPanelLength.Controls.Add(bedLengthLabel);
            bedPanelLength.Location = new Point(8, 308);
            bedPanelLength.Name = "bedPanelLength";
            bedPanelLength.Size = new Size(527, 31);
            bedPanelLength.TabIndex = 23;
            // 
            // bedLengthTextBox
            // 
            bedLengthTextBox.Location = new Point(390, 3);
            bedLengthTextBox.Name = "bedLengthTextBox";
            bedLengthTextBox.ReadOnly = true;
            bedLengthTextBox.Size = new Size(132, 23);
            bedLengthTextBox.TabIndex = 25;
            bedLengthTextBox.TabStop = false;
            bedLengthTextBox.Text = "0";
            bedLengthTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // bedLengthLabel
            // 
            bedLengthLabel.AutoSize = true;
            bedLengthLabel.Location = new Point(8, 7);
            bedLengthLabel.Name = "bedLengthLabel";
            bedLengthLabel.Size = new Size(116, 15);
            bedLengthLabel.TabIndex = 24;
            bedLengthLabel.Text = "Длина станины, мм";
            // 
            // localAreaPanel
            // 
            localAreaPanel.BorderStyle = BorderStyle.FixedSingle;
            localAreaPanel.Controls.Add(localAreaTextBox);
            localAreaPanel.Controls.Add(localAreaLabel);
            localAreaPanel.Location = new Point(8, 345);
            localAreaPanel.Name = "localAreaPanel";
            localAreaPanel.Size = new Size(527, 31);
            localAreaPanel.TabIndex = 26;
            // 
            // localAreaTextBox
            // 
            localAreaTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            localAreaTextBox.Location = new Point(390, 3);
            localAreaTextBox.Name = "localAreaTextBox";
            localAreaTextBox.Size = new Size(132, 23);
            localAreaTextBox.TabIndex = 28;
            localAreaTextBox.Text = "0";
            localAreaTextBox.TextAlign = HorizontalAlignment.Right;
            localAreaTextBox.TextChanged += localAreaTextBox_TextChanged;
            // 
            // localAreaLabel
            // 
            localAreaLabel.AutoSize = true;
            localAreaLabel.Location = new Point(10, 7);
            localAreaLabel.Name = "localAreaLabel";
            localAreaLabel.Size = new Size(140, 15);
            localAreaLabel.TabIndex = 27;
            localAreaLabel.Text = "Локальный участок, мм";
            // 
            // tolerPerMeterPanel
            // 
            tolerPerMeterPanel.BorderStyle = BorderStyle.FixedSingle;
            tolerPerMeterPanel.Controls.Add(tolerPerMeterTextBox);
            tolerPerMeterPanel.Controls.Add(tolerPerMeterLabel);
            tolerPerMeterPanel.Location = new Point(8, 382);
            tolerPerMeterPanel.Name = "tolerPerMeterPanel";
            tolerPerMeterPanel.Size = new Size(527, 31);
            tolerPerMeterPanel.TabIndex = 29;
            // 
            // tolerPerMeterTextBox
            // 
            tolerPerMeterTextBox.Location = new Point(390, 3);
            tolerPerMeterTextBox.Name = "tolerPerMeterTextBox";
            tolerPerMeterTextBox.Size = new Size(132, 23);
            tolerPerMeterTextBox.TabIndex = 31;
            tolerPerMeterTextBox.Text = "0";
            tolerPerMeterTextBox.TextAlign = HorizontalAlignment.Right;
            tolerPerMeterTextBox.TextChanged += UpdateAdmPerMeter;
            // 
            // tolerPerMeterLabel
            // 
            tolerPerMeterLabel.AutoSize = true;
            tolerPerMeterLabel.Location = new Point(10, 7);
            tolerPerMeterLabel.Name = "tolerPerMeterLabel";
            tolerPerMeterLabel.Size = new Size(203, 15);
            tolerPerMeterLabel.TabIndex = 30;
            tolerPerMeterLabel.Text = "Допуск на локальном участке, мкм";
            // 
            // tolerLenghtPanel
            // 
            tolerLenghtPanel.BorderStyle = BorderStyle.FixedSingle;
            tolerLenghtPanel.Controls.Add(tolerLenghtTextBox);
            tolerLenghtPanel.Controls.Add(tolerLengthLabel);
            tolerLenghtPanel.Location = new Point(8, 419);
            tolerLenghtPanel.Name = "tolerLenghtPanel";
            tolerLenghtPanel.Size = new Size(527, 31);
            tolerLenghtPanel.TabIndex = 32;
            // 
            // tolerLenghtTextBox
            // 
            tolerLenghtTextBox.Location = new Point(390, 3);
            tolerLenghtTextBox.Name = "tolerLenghtTextBox";
            tolerLenghtTextBox.Size = new Size(132, 23);
            tolerLenghtTextBox.TabIndex = 34;
            tolerLenghtTextBox.Text = "0";
            tolerLenghtTextBox.TextAlign = HorizontalAlignment.Right;
            tolerLenghtTextBox.TextChanged += UpdateFullTolerance;
            // 
            // tolerLengthLabel
            // 
            tolerLengthLabel.AutoSize = true;
            tolerLengthLabel.Location = new Point(10, 7);
            tolerLengthLabel.Name = "tolerLengthLabel";
            tolerLengthLabel.Size = new Size(154, 15);
            tolerLengthLabel.TabIndex = 33;
            tolerLengthLabel.Text = "Допуск на всю длину, мкм";
            // 
            // stepPanel
            // 
            stepPanel.BorderStyle = BorderStyle.FixedSingle;
            stepPanel.Controls.Add(stepTextBox);
            stepPanel.Controls.Add(stepLabel);
            stepPanel.Location = new Point(8, 456);
            stepPanel.Name = "stepPanel";
            stepPanel.Size = new Size(527, 31);
            stepPanel.TabIndex = 35;
            // 
            // stepTextBox
            // 
            stepTextBox.Location = new Point(390, 3);
            stepTextBox.Name = "stepTextBox";
            stepTextBox.Size = new Size(132, 23);
            stepTextBox.TabIndex = 37;
            stepTextBox.Text = "0";
            stepTextBox.TextAlign = HorizontalAlignment.Right;
            stepTextBox.TextChanged += UpdateStep;
            // 
            // stepLabel
            // 
            stepLabel.AutoSize = true;
            stepLabel.Location = new Point(10, 7);
            stepLabel.Name = "stepLabel";
            stepLabel.Size = new Size(331, 15);
            stepLabel.TabIndex = 36;
            stepLabel.Text = "Шаг измерения (расстояние между опорами мостика), мм";
            // 
            // fillDataFormButton
            // 
            fillDataFormButton.Location = new Point(8, 495);
            fillDataFormButton.Name = "fillDataFormButton";
            fillDataFormButton.Size = new Size(155, 31);
            fillDataFormButton.TabIndex = 38;
            fillDataFormButton.Text = "Заполнить данные";
            fillDataFormButton.UseVisualStyleBackColor = true;
            fillDataFormButton.Click += FillDataFormButton_Click;
            // 
            // graphicButton
            // 
            graphicButton.Location = new Point(8, 531);
            graphicButton.Name = "graphicButton";
            graphicButton.Size = new Size(155, 31);
            graphicButton.TabIndex = 39;
            graphicButton.Text = "График";
            graphicButton.UseVisualStyleBackColor = true;
            graphicButton.Click += GraphicButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(195, 496);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(155, 31);
            saveButton.TabIndex = 40;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // loadFileButton
            // 
            loadFileButton.Location = new Point(195, 531);
            loadFileButton.Name = "loadFileButton";
            loadFileButton.Size = new Size(155, 31);
            loadFileButton.TabIndex = 41;
            loadFileButton.Text = "Загрузить";
            loadFileButton.UseVisualStyleBackColor = true;
            loadFileButton.Click += LoadFileButton_Click;
            // 
            // savePdfButton
            // 
            savePdfButton.Location = new Point(380, 496);
            savePdfButton.Name = "savePdfButton";
            savePdfButton.Size = new Size(155, 31);
            savePdfButton.TabIndex = 42;
            savePdfButton.Text = "Выгрузить PDF";
            savePdfButton.UseVisualStyleBackColor = true;
            savePdfButton.Click += SavePdfButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(380, 531);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(155, 31);
            exitButton.TabIndex = 43;
            exitButton.Text = "Выход";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += ExitButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(541, 566);
            Controls.Add(bedPanelLength);
            Controls.Add(localAreaPanel);
            Controls.Add(descriptionPanel);
            Controls.Add(loadFileButton);
            Controls.Add(saveButton);
            Controls.Add(exitButton);
            Controls.Add(savePdfButton);
            Controls.Add(graphicButton);
            Controls.Add(fillDataFormButton);
            Controls.Add(stepPanel);
            Controls.Add(tolerPerMeterPanel);
            Controls.Add(tolerLenghtPanel);
            Controls.Add(lineDeviationPanel);
            Controls.Add(verticalDeviationPanel);
            Controls.Add(minDeviationPanel);
            Controls.Add(maxDeviationPanel);
            Controls.Add(fioPanel);
            Controls.Add(namePanel);
            Controls.Add(datePanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = $"Прямолинейность. WinForms(v.{Version})";
            datePanel.ResumeLayout(false);
            datePanel.PerformLayout();
            namePanel.ResumeLayout(false);
            namePanel.PerformLayout();
            descriptionPanel.ResumeLayout(false);
            descriptionPanel.PerformLayout();
            fioPanel.ResumeLayout(false);
            fioPanel.PerformLayout();
            maxDeviationPanel.ResumeLayout(false);
            maxDeviationPanel.PerformLayout();
            minDeviationPanel.ResumeLayout(false);
            minDeviationPanel.PerformLayout();
            verticalDeviationPanel.ResumeLayout(false);
            verticalDeviationPanel.PerformLayout();
            lineDeviationPanel.ResumeLayout(false);
            lineDeviationPanel.PerformLayout();
            bedPanelLength.ResumeLayout(false);
            bedPanelLength.PerformLayout();
            localAreaPanel.ResumeLayout(false);
            localAreaPanel.PerformLayout();
            tolerPerMeterPanel.ResumeLayout(false);
            tolerPerMeterPanel.PerformLayout();
            tolerLenghtPanel.ResumeLayout(false);
            tolerLenghtPanel.PerformLayout();
            stepPanel.ResumeLayout(false);
            stepPanel.PerformLayout();
            ResumeLayout(false);
        }


        #endregion

        private DateTimePicker dateTimePicker;
        private ComboBox fioComboBox;
        private ComboBox nameComboBox;
        private Label dateLabel;
        private Label nameLabel;
        private Label fioLabel;
        private Label maxDeviationLabel;
        private Label minDeviationLabel;
        private Label verticalDeviationLabel;
        private Label lineDeviationLabel;
        private Label tolerLengthLabel;
        private Label tolerPerMeterLabel;
        private Label stepLabel;
        private Panel datePanel;
        private Panel namePanel;
        private Panel fioPanel;
        private Panel maxDeviationPanel;
        private Panel minDeviationPanel;
        private Panel verticalDeviationPanel;
        private Panel lineDeviationPanel;
        private Panel tolerLenghtPanel;
        private Panel tolerPerMeterPanel;
        private Panel stepPanel;
        private Button graphicButton;
        private Button savePdfButton;
        private Button exitButton;
        private TextBox maxDeviationTextBox;
        private TextBox minDeviationTextBox;
        private TextBox verticalDeviationTextBox;
        private TextBox tolerLenghtTextBox;
        private TextBox tolerPerMeterTextBox;
        private TextBox stepTextBox;
        private Button loadFileButton;
        private Button saveButton;
        private DateTime dateTime;
        private Button fillDataFormButton;
        private Panel descriptionPanel;
        private ComboBox descriptionComboBox;
        private Label descriptionLabel;
        private Panel localAreaPanel;
        private Panel bedPanelLength;
        private Label localAreaLabel;
        private Label bedLengthLabel;
        private TextBox localAreaTextBox;
        private TextBox bedLengthTextBox;
        internal TextBox lineDeviationTextBox;
    }
}
