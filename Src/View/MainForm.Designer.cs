using System.Windows.Forms;

namespace _3D_graphics
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
            toolStrip1 = new ToolStrip();
            CanvasWidget = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CanvasWidget).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // CanvasWidget
            // 
            CanvasWidget.Dock = DockStyle.Fill;
            CanvasWidget.Location = new Point(0, 25);
            CanvasWidget.Name = "CanvasWidget";
            CanvasWidget.Size = new Size(800, 425);
            CanvasWidget.TabIndex = 1;
            CanvasWidget.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CanvasWidget);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            Text = "Form1";
            KeyDown += MainForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)CanvasWidget).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private PictureBox CanvasWidget;
    }
}