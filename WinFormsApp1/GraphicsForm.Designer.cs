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
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            button1 = new Button();
            SuspendLayout();
            // 
            // plotView1
            // 
            plotView1.BackColor = SystemColors.Window;
            plotView1.Dock = DockStyle.Fill;
            plotView1.Location = new Point(0, 0);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(784, 561);
            plotView1.TabIndex = 0;
            plotView1.Text = "plotView1";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // button1
            // 
            button1.Location = new Point(746, 526);
            button1.Name = "button1";
            button1.Size = new Size(26, 23);
            button1.TabIndex = 1;
            button1.Text = "R";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // GraphicsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(button1);
            Controls.Add(plotView1);
            Name = "GraphicsForm";
            Text = "GraphicsForm";
            Resize += GraphicsForm_Resize;
            ResumeLayout(false);
        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotView1;
        private Button button1;
    }
}