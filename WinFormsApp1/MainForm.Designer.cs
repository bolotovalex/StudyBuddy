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
            dateTimePicker1 = new DateTimePicker();
            fioPanel = new Panel();
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
            tolerLenghtPanel = new Panel();
            tolerLenghtTextBox = new TextBox();
            dateTimePicker7 = new DateTimePicker();
            tolerPerMeterPanel = new Panel();
            tolerPerMeterTextBox = new TextBox();
            dateTimePicker8 = new DateTimePicker();
            stepPanel = new Panel();
            stepTextPanel = new TextBox();
            dateTimePicker9 = new DateTimePicker();
            graphicButton = new Button();
            button1 = new Button();
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
            dateTimePicker.Checked = false;
            dateTimePicker.Enabled = false;
            dateTimePicker.Location = new Point(354, 3);
            dateTimePicker.MinDate = new DateTime(2024, 9, 26, 0, 0, 0, 0);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(126, 23);
            dateTimePicker.TabIndex = 0;
            dateTimePicker.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // fioComboBox
            // 
            fioComboBox.FormattingEnabled = true;
            fioComboBox.Location = new Point(140, 3);
            fioComboBox.Name = "fioComboBox";
            fioComboBox.RightToLeft = RightToLeft.Yes;
            fioComboBox.Size = new Size(340, 23);
            fioComboBox.TabIndex = 1;
            fioComboBox.TextUpdate += UpdateFio;
            // 
            // nameComboBox
            // 
            nameComboBox.FlatStyle = FlatStyle.System;
            nameComboBox.FormattingEnabled = true;
            nameComboBox.Location = new Point(106, 3);
            nameComboBox.Name = "nameComboBox";
            nameComboBox.RightToLeft = RightToLeft.Yes;
            nameComboBox.Size = new Size(374, 23);
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
            datePanel.Size = new Size(485, 31);
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
            namePanel.Size = new Size(485, 31);
            namePanel.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker1.Location = new Point(687, 3);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(251, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // fioPanel
            // 
            fioPanel.BorderStyle = BorderStyle.FixedSingle;
            fioPanel.Controls.Add(dateTimePicker2);
            fioPanel.Controls.Add(fioComboBox);
            fioPanel.Controls.Add(fioLabel);
            fioPanel.Location = new Point(8, 123);
            fioPanel.Name = "fioPanel";
            fioPanel.Size = new Size(485, 31);
            fioPanel.TabIndex = 17;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker2.Location = new Point(687, 3);
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
            maxDeviationPanel.Location = new Point(8, 160);
            maxDeviationPanel.Name = "maxDeviationPanel";
            maxDeviationPanel.Size = new Size(485, 31);
            maxDeviationPanel.TabIndex = 18;
            // 
            // maxDeviationTextBox
            // 
            maxDeviationTextBox.BackColor = SystemColors.Control;
            maxDeviationTextBox.Location = new Point(390, 3);
            maxDeviationTextBox.Name = "maxDeviationTextBox";
            maxDeviationTextBox.ReadOnly = true;
            maxDeviationTextBox.Size = new Size(90, 23);
            maxDeviationTextBox.TabIndex = 7;
            maxDeviationTextBox.Text = "0";
            maxDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker3.Location = new Point(687, 3);
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
            minDeviationPanel.Location = new Point(8, 197);
            minDeviationPanel.Name = "minDeviationPanel";
            minDeviationPanel.Size = new Size(485, 31);
            minDeviationPanel.TabIndex = 19;
            // 
            // minDeviationTextBox
            // 
            minDeviationTextBox.BackColor = SystemColors.Control;
            minDeviationTextBox.Location = new Point(390, 3);
            minDeviationTextBox.Name = "minDeviationTextBox";
            minDeviationTextBox.ReadOnly = true;
            minDeviationTextBox.Size = new Size(90, 23);
            minDeviationTextBox.TabIndex = 8;
            minDeviationTextBox.Text = "0";
            minDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // dateTimePicker4
            // 
            dateTimePicker4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker4.Location = new Point(687, 3);
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
            verticalDeviationPanel.Location = new Point(8, 234);
            verticalDeviationPanel.Name = "verticalDeviationPanel";
            verticalDeviationPanel.Size = new Size(485, 31);
            verticalDeviationPanel.TabIndex = 20;
            // 
            // verticalDeviationTextBox
            // 
            verticalDeviationTextBox.BackColor = SystemColors.Control;
            verticalDeviationTextBox.Location = new Point(390, 3);
            verticalDeviationTextBox.Name = "verticalDeviationTextBox";
            verticalDeviationTextBox.ReadOnly = true;
            verticalDeviationTextBox.Size = new Size(90, 23);
            verticalDeviationTextBox.TabIndex = 9;
            verticalDeviationTextBox.Text = "0";
            verticalDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // dateTimePicker5
            // 
            dateTimePicker5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker5.Location = new Point(1145, 3);
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
            lineDeviationPanel.Location = new Point(8, 271);
            lineDeviationPanel.Name = "lineDeviationPanel";
            lineDeviationPanel.Size = new Size(485, 31);
            lineDeviationPanel.TabIndex = 21;
            // 
            // lineDeviationTextBox
            // 
            lineDeviationTextBox.BackColor = SystemColors.Control;
            lineDeviationTextBox.Location = new Point(390, 3);
            lineDeviationTextBox.Name = "lineDeviationTextBox";
            lineDeviationTextBox.ReadOnly = true;
            lineDeviationTextBox.Size = new Size(90, 23);
            lineDeviationTextBox.TabIndex = 10;
            lineDeviationTextBox.Text = "0";
            lineDeviationTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // dateTimePicker6
            // 
            dateTimePicker6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker6.Location = new Point(1145, 3);
            dateTimePicker6.Name = "dateTimePicker6";
            dateTimePicker6.Size = new Size(251, 23);
            dateTimePicker6.TabIndex = 0;
            // 
            // tolerLenghtPanel
            // 
            tolerLenghtPanel.BorderStyle = BorderStyle.FixedSingle;
            tolerLenghtPanel.Controls.Add(tolerLenghtTextBox);
            tolerLenghtPanel.Controls.Add(dateTimePicker7);
            tolerLenghtPanel.Controls.Add(tolerLengthLabel);
            tolerLenghtPanel.Location = new Point(8, 382);
            tolerLenghtPanel.Name = "tolerLenghtPanel";
            tolerLenghtPanel.Size = new Size(485, 31);
            tolerLenghtPanel.TabIndex = 22;
            // 
            // tolerLenghtTextBox
            // 
            tolerLenghtTextBox.Location = new Point(390, 3);
            tolerLenghtTextBox.Name = "tolerLenghtTextBox";
            tolerLenghtTextBox.Size = new Size(90, 23);
            tolerLenghtTextBox.TabIndex = 11;
            tolerLenghtTextBox.Text = "0";
            tolerLenghtTextBox.TextAlign = HorizontalAlignment.Right;
            tolerLenghtTextBox.TextChanged += UpdateFullTolerance;
            // 
            // dateTimePicker7
            // 
            dateTimePicker7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker7.Location = new Point(1145, 3);
            dateTimePicker7.Name = "dateTimePicker7";
            dateTimePicker7.Size = new Size(251, 23);
            dateTimePicker7.TabIndex = 0;
            // 
            // tolerPerMeterPanel
            // 
            tolerPerMeterPanel.BorderStyle = BorderStyle.FixedSingle;
            tolerPerMeterPanel.Controls.Add(tolerPerMeterTextBox);
            tolerPerMeterPanel.Controls.Add(dateTimePicker8);
            tolerPerMeterPanel.Controls.Add(tolerPerMeterLabel);
            tolerPerMeterPanel.Location = new Point(8, 419);
            tolerPerMeterPanel.Name = "tolerPerMeterPanel";
            tolerPerMeterPanel.Size = new Size(485, 31);
            tolerPerMeterPanel.TabIndex = 23;
            // 
            // tolerPerMeterTextBox
            // 
            tolerPerMeterTextBox.Location = new Point(390, 3);
            tolerPerMeterTextBox.Name = "tolerPerMeterTextBox";
            tolerPerMeterTextBox.Size = new Size(90, 23);
            tolerPerMeterTextBox.TabIndex = 12;
            tolerPerMeterTextBox.Text = "0";
            tolerPerMeterTextBox.TextAlign = HorizontalAlignment.Right;
            tolerPerMeterTextBox.TextChanged += UpdateAdmPerMeter;
            // 
            // dateTimePicker8
            // 
            dateTimePicker8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker8.Location = new Point(1145, 3);
            dateTimePicker8.Name = "dateTimePicker8";
            dateTimePicker8.Size = new Size(251, 23);
            dateTimePicker8.TabIndex = 0;
            // 
            // stepPanel
            // 
            stepPanel.BorderStyle = BorderStyle.FixedSingle;
            stepPanel.Controls.Add(stepTextPanel);
            stepPanel.Controls.Add(dateTimePicker9);
            stepPanel.Controls.Add(stepLabel);
            stepPanel.Location = new Point(8, 456);
            stepPanel.Name = "stepPanel";
            stepPanel.Size = new Size(485, 31);
            stepPanel.TabIndex = 24;
            // 
            // stepTextPanel
            // 
            stepTextPanel.Location = new Point(390, 3);
            stepTextPanel.Name = "stepTextPanel";
            stepTextPanel.Size = new Size(90, 23);
            stepTextPanel.TabIndex = 13;
            stepTextPanel.Text = "0";
            stepTextPanel.TextAlign = HorizontalAlignment.Right;
            stepTextPanel.TextChanged += UpdateStep;
            // 
            // dateTimePicker9
            // 
            dateTimePicker9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker9.Location = new Point(1145, 3);
            dateTimePicker9.Name = "dateTimePicker9";
            dateTimePicker9.Size = new Size(251, 23);
            dateTimePicker9.TabIndex = 0;
            // 
            // graphicButton
            // 
            graphicButton.Location = new Point(8, 531);
            graphicButton.Name = "graphicButton";
            graphicButton.Size = new Size(155, 31);
            graphicButton.TabIndex = 26;
            graphicButton.Text = "График";
            graphicButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(339, 496);
            button1.Name = "button1";
            button1.Size = new Size(155, 31);
            button1.TabIndex = 27;
            button1.Text = "Выгрузить PDF";
            button1.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(339, 531);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(155, 31);
            exitButton.TabIndex = 28;
            exitButton.Text = "Выход";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // loadFileButton
            // 
            loadFileButton.Location = new Point(173, 531);
            loadFileButton.Name = "loadFileButton";
            loadFileButton.Size = new Size(155, 31);
            loadFileButton.TabIndex = 29;
            loadFileButton.Text = "Загрузить";
            loadFileButton.UseVisualStyleBackColor = true;
            loadFileButton.Click += loadFileButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(173, 496);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(155, 31);
            saveButton.TabIndex = 30;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // fillDataFormButton
            // 
            fillDataFormButton.Location = new Point(8, 495);
            fillDataFormButton.Name = "fillDataFormButton";
            fillDataFormButton.Size = new Size(155, 31);
            fillDataFormButton.TabIndex = 25;
            fillDataFormButton.Text = "Заполнить данные";
            fillDataFormButton.UseVisualStyleBackColor = true;
            fillDataFormButton.Click += fillDataFormButton_Click;
            // 
            // descriptionPanel
            // 
            descriptionPanel.BorderStyle = BorderStyle.FixedSingle;
            descriptionPanel.Controls.Add(descriptionComboBox);
            descriptionPanel.Controls.Add(descriptionLabel);
            descriptionPanel.Location = new Point(8, 86);
            descriptionPanel.Name = "descriptionPanel";
            descriptionPanel.Size = new Size(485, 31);
            descriptionPanel.TabIndex = 32;
            // 
            // descriptionComboBox
            // 
            descriptionComboBox.FlatStyle = FlatStyle.System;
            descriptionComboBox.FormattingEnabled = true;
            descriptionComboBox.Location = new Point(106, 3);
            descriptionComboBox.Name = "descriptionComboBox";
            descriptionComboBox.RightToLeft = RightToLeft.Yes;
            descriptionComboBox.Size = new Size(374, 23);
            descriptionComboBox.TabIndex = 6;
            descriptionComboBox.TextChanged += descriptionComboBox_TextChanged;
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
            localAreaPanel.Location = new Point(8, 308);
            localAreaPanel.Name = "localAreaPanel";
            localAreaPanel.Size = new Size(485, 31);
            localAreaPanel.TabIndex = 33;
            // 
            // localAreaTextBox
            // 
            localAreaTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            localAreaTextBox.Location = new Point(390, 3);
            localAreaTextBox.Name = "localAreaTextBox";
            localAreaTextBox.ReadOnly = true;
            localAreaTextBox.Size = new Size(90, 23);
            localAreaTextBox.TabIndex = 1;
            localAreaTextBox.Text = "0";
            localAreaTextBox.TextAlign = HorizontalAlignment.Right;
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
            bedPanelLength.Location = new Point(8, 345);
            bedPanelLength.Name = "bedPanelLength";
            bedPanelLength.Size = new Size(485, 31);
            bedPanelLength.TabIndex = 34;
            // 
            // bedLengthTextBox
            // 
            bedLengthTextBox.Location = new Point(390, 3);
            bedLengthTextBox.Name = "bedLengthTextBox";
            bedLengthTextBox.ReadOnly = true;
            bedLengthTextBox.Size = new Size(90, 23);
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
            ClientSize = new Size(501, 566);
            Controls.Add(bedPanelLength);
            Controls.Add(localAreaPanel);
            Controls.Add(descriptionPanel);
            Controls.Add(loadFileButton);
            Controls.Add(saveButton);
            Controls.Add(exitButton);
            Controls.Add(button1);
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
        private DateTimePicker dateTimePicker1;
        private Panel fioPanel;
        private DateTimePicker dateTimePicker2;
        private Panel maxDeviationPanel;
        private DateTimePicker dateTimePicker3;
        private Panel minDeviationPanel;
        private DateTimePicker dateTimePicker4;
        private Panel verticalDeviationPanel;
        private DateTimePicker dateTimePicker5;
        private Panel lineDeviationPanel;
        private DateTimePicker dateTimePicker6;
        private Panel tolerLenghtPanel;
        private DateTimePicker dateTimePicker7;
        private Panel tolerPerMeterPanel;
        private DateTimePicker dateTimePicker8;
        private Panel stepPanel;
        private DateTimePicker dateTimePicker9;
        private Button graphicButton;
        private Button button1;
        private Button exitButton;
        private TextBox maxDeviationTextBox;
        private TextBox minDeviationTextBox;
        private TextBox verticalDeviationTextBox;
        private TextBox lineDeviationTextBox;
        private TextBox tolerLenghtTextBox;
        private TextBox tolerPerMeterTextBox;
        private TextBox stepTextPanel;
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
    }
}
