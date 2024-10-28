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
            dateLabel = new Label();
            dateTimePicker = new DateTimePicker();
            fioComboBox = new ComboBox();
            nameComboBox = new ComboBox();
            nameLabel = new Label();
            fioLabel = new Label();
            maxDeviationLabel = new Label();
            minDeviationLabel = new Label();
            verticalDeviationLabel = new Label();
            lineDeviationLabel = new Label();
            tolerLengthLabel = new Label();
            tolerPerMeterLabel = new Label();
            stepLabel = new Label();
            datePanel = new Panel();
            namePanel = new Panel();
            fioPanel = new Panel();
            maxDeviationPanel = new Panel();
            maxDeviationTextBox = new TextBox();
            minDeviationPanel = new Panel();
            minDeviationTextBox = new TextBox();
            verticalDeviationPanel = new Panel();
            verticalDeviationTextBox = new TextBox();
            lineDeviationPanel = new Panel();
            lineDeviationTextBox = new TextBox();
            tolerLenghtPanel = new Panel();
            tolerLenghtTextBox = new TextBox();
            tolerPerMeterPanel = new Panel();
            tolerPerMeterTextBox = new TextBox();
            stepPanel = new Panel();
            stepTextBox = new TextBox();
            graphicButton = new Button();
            savePdfButton = new Button();
            exitButton = new Button();
            loadFileButton = new Button();
            saveButton = new Button();
            fillDataFormButton = new Button();
            descriptionPanel = new Panel();
            descriptionComboBox = new ComboBox();
            descriptionLabel = new Label();
            localAreaPanel = new Panel();
            localAreaTextBox = new TextBox();
            localAreaLabel = new Label();
            bedPanelLength = new Panel();
            bedLengthTextBox = new TextBox();
            bedLengthLabel = new Label();
            datePanel.SuspendLayout();
            namePanel.SuspendLayout();
            fioPanel.SuspendLayout();
            maxDeviationPanel.SuspendLayout();
            minDeviationPanel.SuspendLayout();
            verticalDeviationPanel.SuspendLayout();
            lineDeviationPanel.SuspendLayout();
            tolerLenghtPanel.SuspendLayout();
            tolerPerMeterPanel.SuspendLayout();
            stepPanel.SuspendLayout();
            descriptionPanel.SuspendLayout();
            localAreaPanel.SuspendLayout();
            bedPanelLength.SuspendLayout();
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
            dateTimePicker.CustomFormat = "dd MMMM yyyy";
            dateTimePicker.Location = new Point(400, 3);
            dateTimePicker.MinDate = new DateTime(2024, 9, 1, 0, 0, 0, 0);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.RightToLeft = RightToLeft.No;
            dateTimePicker.Size = new Size(122, 23);
            dateTimePicker.TabIndex = 0;
            dateTimePicker.CloseUp += dateTimePicker_DropDown;
            // 
            // fioComboBox
            // 
            fioComboBox.FormattingEnabled = true;
            fioComboBox.Location = new Point(140, 3);
            fioComboBox.Name = "fioComboBox";
            fioComboBox.RightToLeft = RightToLeft.Yes;
            fioComboBox.Size = new Size(382, 23);
            fioComboBox.TabIndex = 1;
            fioComboBox.TextUpdate += UpdateFio;
            // 
            // nameComboBox
            // 
            nameComboBox.FlatStyle = FlatStyle.System;
            nameComboBox.FormattingEnabled = true;
            nameComboBox.Location = new Point(108, 3);
            nameComboBox.Name = "nameComboBox";
            nameComboBox.RightToLeft = RightToLeft.Yes;
            nameComboBox.Size = new Size(414, 23);
            nameComboBox.TabIndex = 2;
            nameComboBox.TextChanged += UpdateProjectName;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(10, 7);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(90, 15);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "Наименование";
            // 
            // fioLabel
            // 
            fioLabel.AutoSize = true;
            fioLabel.Location = new Point(10, 7);
            fioLabel.Name = "fioLabel";
            fioLabel.Size = new Size(124, 15);
            fioLabel.TabIndex = 5;
            fioLabel.Text = "Измерение произвел";
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
            // tolerLengthLabel
            // 
            tolerLengthLabel.AutoSize = true;
            tolerLengthLabel.Location = new Point(10, 7);
            tolerLengthLabel.Name = "tolerLengthLabel";
            tolerLengthLabel.Size = new Size(154, 15);
            tolerLengthLabel.TabIndex = 10;
            tolerLengthLabel.Text = "Допуск на всю длину, мкм";
            // 
            // tolerPerMeterLabel
            // 
            tolerPerMeterLabel.AutoSize = true;
            tolerPerMeterLabel.Location = new Point(10, 7);
            tolerPerMeterLabel.Name = "tolerPerMeterLabel";
            tolerPerMeterLabel.Size = new Size(132, 15);
            tolerPerMeterLabel.TabIndex = 11;
            tolerPerMeterLabel.Text = "Допуск на 1 метр, мкм";
            // 
            // stepLabel
            // 
            stepLabel.AutoSize = true;
            stepLabel.Location = new Point(10, 7);
            stepLabel.Name = "stepLabel";
            stepLabel.Size = new Size(331, 15);
            stepLabel.TabIndex = 12;
            stepLabel.Text = "Шаг измерения (расстояние между опорами мостика), мм";
            // 
            // datePanel
            // 
            datePanel.BorderStyle = BorderStyle.FixedSingle;
            datePanel.Controls.Add(dateLabel);
            datePanel.Controls.Add(dateTimePicker);
            datePanel.Location = new Point(8, 12);
            datePanel.Name = "datePanel";
            datePanel.Size = new Size(527, 31);
            datePanel.TabIndex = 15;
            // 
            // namePanel
            // 
            namePanel.BorderStyle = BorderStyle.FixedSingle;
            namePanel.Controls.Add(nameLabel);
            namePanel.Controls.Add(nameComboBox);
            namePanel.Location = new Point(8, 49);
            namePanel.Name = "namePanel";
            namePanel.Size = new Size(527, 31);
            namePanel.TabIndex = 16;
            // 
            // fioPanel
            // 
            fioPanel.BorderStyle = BorderStyle.FixedSingle;
            fioPanel.Controls.Add(fioComboBox);
            fioPanel.Controls.Add(fioLabel);
            fioPanel.Location = new Point(8, 123);
            fioPanel.Name = "fioPanel";
            fioPanel.Size = new Size(527, 31);
            fioPanel.TabIndex = 17;
            // 
            // maxDeviationPanel
            // 
            maxDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
            maxDeviationPanel.Controls.Add(maxDeviationTextBox);
            maxDeviationPanel.Controls.Add(maxDeviationLabel);
            maxDeviationPanel.Location = new Point(8, 160);
            maxDeviationPanel.Name = "maxDeviationPanel";
            maxDeviationPanel.Size = new Size(527, 31);
            maxDeviationPanel.TabIndex = 18;
            // 
            // maxDeviationTextBox
            // 
            maxDeviationTextBox.BackColor = SystemColors.Control;
            maxDeviationTextBox.Location = new Point(390, 3);
            maxDeviationTextBox.Name = "maxDeviationTextBox";
            maxDeviationTextBox.ReadOnly = true;
            maxDeviationTextBox.Size = new Size(132, 23);
            maxDeviationTextBox.TabIndex = 7;
            maxDeviationTextBox.Text = "0";
            maxDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // minDeviationPanel
            // 
            minDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
            minDeviationPanel.Controls.Add(minDeviationTextBox);
            minDeviationPanel.Controls.Add(minDeviationLabel);
            minDeviationPanel.Location = new Point(8, 197);
            minDeviationPanel.Name = "minDeviationPanel";
            minDeviationPanel.Size = new Size(527, 31);
            minDeviationPanel.TabIndex = 19;
            // 
            // minDeviationTextBox
            // 
            minDeviationTextBox.BackColor = SystemColors.Control;
            minDeviationTextBox.Location = new Point(390, 3);
            minDeviationTextBox.Name = "minDeviationTextBox";
            minDeviationTextBox.ReadOnly = true;
            minDeviationTextBox.Size = new Size(132, 23);
            minDeviationTextBox.TabIndex = 8;
            minDeviationTextBox.Text = "0";
            minDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // verticalDeviationPanel
            // 
            verticalDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
            verticalDeviationPanel.Controls.Add(verticalDeviationTextBox);
            verticalDeviationPanel.Controls.Add(verticalDeviationLabel);
            verticalDeviationPanel.Location = new Point(8, 234);
            verticalDeviationPanel.Name = "verticalDeviationPanel";
            verticalDeviationPanel.Size = new Size(527, 31);
            verticalDeviationPanel.TabIndex = 20;
            // 
            // verticalDeviationTextBox
            // 
            verticalDeviationTextBox.BackColor = SystemColors.Control;
            verticalDeviationTextBox.Location = new Point(390, 3);
            verticalDeviationTextBox.Name = "verticalDeviationTextBox";
            verticalDeviationTextBox.ReadOnly = true;
            verticalDeviationTextBox.Size = new Size(132, 23);
            verticalDeviationTextBox.TabIndex = 9;
            verticalDeviationTextBox.Text = "0";
            verticalDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // lineDeviationPanel
            // 
            lineDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
            lineDeviationPanel.Controls.Add(lineDeviationTextBox);
            lineDeviationPanel.Controls.Add(lineDeviationLabel);
            lineDeviationPanel.Location = new Point(8, 271);
            lineDeviationPanel.Name = "lineDeviationPanel";
            lineDeviationPanel.Size = new Size(527, 31);
            lineDeviationPanel.TabIndex = 21;
            // 
            // lineDeviationTextBox
            // 
            lineDeviationTextBox.BackColor = Color.FromArgb(224, 224, 224);
            lineDeviationTextBox.Location = new Point(390, 3);
            lineDeviationTextBox.Name = "lineDeviationTextBox";
            lineDeviationTextBox.ReadOnly = true;
            lineDeviationTextBox.Size = new Size(132, 23);
            lineDeviationTextBox.TabIndex = 10;
            lineDeviationTextBox.Text = "0";
            lineDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // tolerLenghtPanel
            // 
            tolerLenghtPanel.BorderStyle = BorderStyle.FixedSingle;
            tolerLenghtPanel.Controls.Add(tolerLenghtTextBox);
            tolerLenghtPanel.Controls.Add(tolerLengthLabel);
            tolerLenghtPanel.Location = new Point(8, 382);
            tolerLenghtPanel.Name = "tolerLenghtPanel";
            tolerLenghtPanel.Size = new Size(527, 31);
            tolerLenghtPanel.TabIndex = 22;
            // 
            // tolerLenghtTextBox
            // 
            tolerLenghtTextBox.Location = new Point(390, 3);
            tolerLenghtTextBox.Name = "tolerLenghtTextBox";
            tolerLenghtTextBox.Size = new Size(132, 23);
            tolerLenghtTextBox.TabIndex = 11;
            tolerLenghtTextBox.Text = "0";
            tolerLenghtTextBox.TextAlign = HorizontalAlignment.Right;
            tolerLenghtTextBox.TextChanged += UpdateFullTolerance;
            // 
            // tolerPerMeterPanel
            // 
            tolerPerMeterPanel.BorderStyle = BorderStyle.FixedSingle;
            tolerPerMeterPanel.Controls.Add(tolerPerMeterTextBox);
            tolerPerMeterPanel.Controls.Add(tolerPerMeterLabel);
            tolerPerMeterPanel.Location = new Point(8, 419);
            tolerPerMeterPanel.Name = "tolerPerMeterPanel";
            tolerPerMeterPanel.Size = new Size(527, 31);
            tolerPerMeterPanel.TabIndex = 23;
            // 
            // tolerPerMeterTextBox
            // 
            tolerPerMeterTextBox.Location = new Point(390, 3);
            tolerPerMeterTextBox.Name = "tolerPerMeterTextBox";
            tolerPerMeterTextBox.Size = new Size(132, 23);
            tolerPerMeterTextBox.TabIndex = 12;
            tolerPerMeterTextBox.Text = "0";
            tolerPerMeterTextBox.TextAlign = HorizontalAlignment.Right;
            tolerPerMeterTextBox.TextChanged += UpdateAdmPerMeter;
            // 
            // stepPanel
            // 
            stepPanel.BorderStyle = BorderStyle.FixedSingle;
            stepPanel.Controls.Add(stepTextBox);
            stepPanel.Controls.Add(stepLabel);
            stepPanel.Location = new Point(8, 456);
            stepPanel.Name = "stepPanel";
            stepPanel.Size = new Size(527, 31);
            stepPanel.TabIndex = 24;
            // 
            // stepTextBox
            // 
            stepTextBox.Location = new Point(390, 3);
            stepTextBox.Name = "stepTextBox";
            stepTextBox.Size = new Size(132, 23);
            stepTextBox.TabIndex = 13;
            stepTextBox.Text = "0";
            stepTextBox.TextAlign = HorizontalAlignment.Right;
            stepTextBox.TextChanged += UpdateStep;
            // 
            // graphicButton
            // 
            graphicButton.Location = new Point(8, 531);
            graphicButton.Name = "graphicButton";
            graphicButton.Size = new Size(155, 31);
            graphicButton.TabIndex = 26;
            graphicButton.Text = "График";
            graphicButton.UseVisualStyleBackColor = true;
            graphicButton.Click += GraphicButton_Click;
            // 
            // savePdfButton
            // 
            savePdfButton.Location = new Point(380, 496);
            savePdfButton.Name = "savePdfButton";
            savePdfButton.Size = new Size(155, 31);
            savePdfButton.TabIndex = 27;
            savePdfButton.Text = "Выгрузить PDF";
            savePdfButton.UseVisualStyleBackColor = true;
            savePdfButton.Click += SavePdfButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(380, 531);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(155, 31);
            exitButton.TabIndex = 28;
            exitButton.Text = "Выход";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += ExitButton_Click;
            // 
            // loadFileButton
            // 
            loadFileButton.Location = new Point(195, 531);
            loadFileButton.Name = "loadFileButton";
            loadFileButton.Size = new Size(155, 31);
            loadFileButton.TabIndex = 29;
            loadFileButton.Text = "Загрузить";
            loadFileButton.UseVisualStyleBackColor = true;
            loadFileButton.Click += LoadFileButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(195, 496);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(155, 31);
            saveButton.TabIndex = 30;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // fillDataFormButton
            // 
            fillDataFormButton.Location = new Point(8, 495);
            fillDataFormButton.Name = "fillDataFormButton";
            fillDataFormButton.Size = new Size(155, 31);
            fillDataFormButton.TabIndex = 25;
            fillDataFormButton.Text = "Заполнить данные";
            fillDataFormButton.UseVisualStyleBackColor = true;
            fillDataFormButton.Click += FillDataFormButton_Click;
            // 
            // descriptionPanel
            // 
            descriptionPanel.BorderStyle = BorderStyle.FixedSingle;
            descriptionPanel.Controls.Add(descriptionComboBox);
            descriptionPanel.Controls.Add(descriptionLabel);
            descriptionPanel.Location = new Point(8, 86);
            descriptionPanel.Name = "descriptionPanel";
            descriptionPanel.Size = new Size(527, 31);
            descriptionPanel.TabIndex = 32;
            // 
            // descriptionComboBox
            // 
            descriptionComboBox.FlatStyle = FlatStyle.System;
            descriptionComboBox.FormattingEnabled = true;
            descriptionComboBox.Location = new Point(108, 3);
            descriptionComboBox.Name = "descriptionComboBox";
            descriptionComboBox.RightToLeft = RightToLeft.Yes;
            descriptionComboBox.Size = new Size(414, 23);
            descriptionComboBox.TabIndex = 6;
            descriptionComboBox.TextChanged += DescriptionComboBox_TextChanged;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(8, 7);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(81, 15);
            descriptionLabel.TabIndex = 5;
            descriptionLabel.Text = "Обозначение";
            // 
            // localAreaPanel
            // 
            localAreaPanel.BorderStyle = BorderStyle.FixedSingle;
            localAreaPanel.Controls.Add(localAreaTextBox);
            localAreaPanel.Controls.Add(localAreaLabel);
            localAreaPanel.Location = new Point(8, 345);
            localAreaPanel.Name = "localAreaPanel";
            localAreaPanel.Size = new Size(527, 31);
            localAreaPanel.TabIndex = 33;
            // 
            // localAreaTextBox
            // 
            localAreaTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            localAreaTextBox.Location = new Point(390, 3);
            localAreaTextBox.Name = "localAreaTextBox";
            localAreaTextBox.Size = new Size(132, 23);
            localAreaTextBox.TabIndex = 1;
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
            localAreaLabel.TabIndex = 0;
            localAreaLabel.Text = "Локальный участок, мм";
            // 
            // bedPanelLength
            // 
            bedPanelLength.BorderStyle = BorderStyle.FixedSingle;
            bedPanelLength.Controls.Add(bedLengthTextBox);
            bedPanelLength.Controls.Add(bedLengthLabel);
            bedPanelLength.Location = new Point(8, 308);
            bedPanelLength.Name = "bedPanelLength";
            bedPanelLength.Size = new Size(527, 31);
            bedPanelLength.TabIndex = 34;
            // 
            // bedLengthTextBox
            // 
            bedLengthTextBox.Location = new Point(390, 3);
            bedLengthTextBox.Name = "bedLengthTextBox";
            bedLengthTextBox.ReadOnly = true;
            bedLengthTextBox.Size = new Size(132, 23);
            bedLengthTextBox.TabIndex = 2;
            bedLengthTextBox.Text = "0";
            bedLengthTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // bedLengthLabel
            // 
            bedLengthLabel.AutoSize = true;
            bedLengthLabel.Location = new Point(8, 7);
            bedLengthLabel.Name = "bedLengthLabel";
            bedLengthLabel.Size = new Size(116, 15);
            bedLengthLabel.TabIndex = 0;
            bedLengthLabel.Text = "Длина станины, мм";
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
            Text = "Прямолинейность";
            datePanel.ResumeLayout(false);
            datePanel.PerformLayout();
            namePanel.ResumeLayout(false);
            namePanel.PerformLayout();
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
            tolerLenghtPanel.ResumeLayout(false);
            tolerLenghtPanel.PerformLayout();
            tolerPerMeterPanel.ResumeLayout(false);
            tolerPerMeterPanel.PerformLayout();
            stepPanel.ResumeLayout(false);
            stepPanel.PerformLayout();
            descriptionPanel.ResumeLayout(false);
            descriptionPanel.PerformLayout();
            localAreaPanel.ResumeLayout(false);
            localAreaPanel.PerformLayout();
            bedPanelLength.ResumeLayout(false);
            bedPanelLength.PerformLayout();
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
