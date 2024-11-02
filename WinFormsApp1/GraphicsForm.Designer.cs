namespace Pryamolineynost
{
    partial class GraphicsForm
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
            //this.Hide();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            plotView1.Model = null;

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            listBox1 = new ListBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // plotView1
            // 
            plotView1.BackColor = SystemColors.Window;
            plotView1.Dock = DockStyle.Left;
            plotView1.Location = new Point(0, 0);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.HSplit;
            plotView1.Size = new Size(_initFormWidth - _rightGraphIndexnt, _initFormHeight);
            plotView1.TabIndex = 0;
            plotView1.Text = "plotView1";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Bottom;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 167);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, _initFormHeight - 25);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.MaximumSize = new Size(300, 50);
            label1.Name = "label1";
            label1.Size = new Size(284, 30);
            label1.TabIndex = 1;
            label1.Text = "Отклонения";
            label1.Visible = true;
            // 
            // GraphicsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(_initFormWidth, _initFormHeight);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(plotView1);
            Name = "GraphicsForm";
            Text = "График";
            Resize += GraphicsForm_Resize;
            ResumeLayout(false);
            MinimumSize = new Size(_initFormWidth, _initFormHeight);
        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotView1;
        private ListBox listBox1;
        private Label label1;
    }
}