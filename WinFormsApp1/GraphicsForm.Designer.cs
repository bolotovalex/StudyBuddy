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
            // 
            // GraphicsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 441);
            Controls.Add(plotView1);
            MinimumSize = new Size(600, 480);
            Name = "GraphicsForm";
            Text = "График";
            Resize += GraphicsForm_Resize;
            ResumeLayout(false);

            plotView1 = new OxyPlot.WindowsForms.PlotView();
            SuspendLayout();
            // 
            // plotView1
            // 
            plotView1.BackColor = SystemColors.Window;
            plotView1.Dock = DockStyle.Top;
            plotView1.Location = new Point(0, 0);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.HSplit;
            plotView1.Size = new Size(this.Width-16, this.Height-_botomGraphIndention);
            plotView1.TabIndex = 0;
            plotView1.Text = "plotView1";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            
        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotView1;
    }
}