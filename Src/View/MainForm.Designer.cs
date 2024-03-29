﻿using System.Windows.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new ToolStrip();
            CameraSellector = new ToolStripDropDownButton();
            StaticCameraButton = new ToolStripMenuItem();
            CarFollowingCameraButton = new ToolStripMenuItem();
            TPPCameraToolStripMenuItem = new ToolStripMenuItem();
            RenderingDropDownButton = new ToolStripDropDownButton();
            edgesToolStripMenuItem = new ToolStripMenuItem();
            modelColorToolStripMenuItem = new ToolStripMenuItem();
            gourandShadingToolStripMenuItem = new ToolStripMenuItem();
            phongToolStripMenuItem = new ToolStripMenuItem();
            CanvasWidget = new PictureBox();
            statusStrip1 = new StatusStrip();
            FPSCounter = new ToolStripStatusLabel();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CanvasWidget).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { CameraSellector, RenderingDropDownButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // CameraSellector
            // 
            CameraSellector.DisplayStyle = ToolStripItemDisplayStyle.Text;
            CameraSellector.DropDownItems.AddRange(new ToolStripItem[] { StaticCameraButton, CarFollowingCameraButton, TPPCameraToolStripMenuItem });
            CameraSellector.Image = (Image)resources.GetObject("CameraSellector.Image");
            CameraSellector.ImageTransparentColor = Color.Magenta;
            CameraSellector.Name = "CameraSellector";
            CameraSellector.Size = new Size(74, 24);
            CameraSellector.Text = "Camera";
            // 
            // StaticCameraButton
            // 
            StaticCameraButton.Name = "StaticCameraButton";
            StaticCameraButton.Size = new Size(182, 26);
            StaticCameraButton.Text = "Static camera";
            StaticCameraButton.Click += StaticCameraButton_Click;
            // 
            // CarFollowingCameraButton
            // 
            CarFollowingCameraButton.Name = "CarFollowingCameraButton";
            CarFollowingCameraButton.Size = new Size(182, 26);
            CarFollowingCameraButton.Text = "Car following";
            CarFollowingCameraButton.Click += CarFollowingCameraButton_Click;
            // 
            // TPPCameraToolStripMenuItem
            // 
            TPPCameraToolStripMenuItem.Name = "TPPCameraToolStripMenuItem";
            TPPCameraToolStripMenuItem.Size = new Size(182, 26);
            TPPCameraToolStripMenuItem.Text = "TPP camera";
            TPPCameraToolStripMenuItem.Click += TPPCameraToolStripMenuItem_Click;
            // 
            // RenderingDropDownButton
            // 
            RenderingDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            RenderingDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { edgesToolStripMenuItem, modelColorToolStripMenuItem, gourandShadingToolStripMenuItem, phongToolStripMenuItem });
            RenderingDropDownButton.Image = (Image)resources.GetObject("RenderingDropDownButton.Image");
            RenderingDropDownButton.ImageTransparentColor = Color.Magenta;
            RenderingDropDownButton.Name = "RenderingDropDownButton";
            RenderingDropDownButton.Size = new Size(91, 24);
            RenderingDropDownButton.Text = "Rendering";
            // 
            // edgesToolStripMenuItem
            // 
            edgesToolStripMenuItem.Name = "edgesToolStripMenuItem";
            edgesToolStripMenuItem.Size = new Size(205, 26);
            edgesToolStripMenuItem.Text = "Edges";
            edgesToolStripMenuItem.Click += edgesToolStripMenuItem_Click;
            // 
            // modelColorToolStripMenuItem
            // 
            modelColorToolStripMenuItem.Name = "modelColorToolStripMenuItem";
            modelColorToolStripMenuItem.Size = new Size(205, 26);
            modelColorToolStripMenuItem.Text = "Object color";
            modelColorToolStripMenuItem.Click += modelColorToolStripMenuItem_Click;
            // 
            // gourandShadingToolStripMenuItem
            // 
            gourandShadingToolStripMenuItem.Name = "gourandShadingToolStripMenuItem";
            gourandShadingToolStripMenuItem.Size = new Size(205, 26);
            gourandShadingToolStripMenuItem.Text = "Gourand shading";
            gourandShadingToolStripMenuItem.Click += gourandShadingToolStripMenuItem_Click;
            // 
            // phongToolStripMenuItem
            // 
            phongToolStripMenuItem.Name = "phongToolStripMenuItem";
            phongToolStripMenuItem.Size = new Size(205, 26);
            phongToolStripMenuItem.Text = "Phong shading";
            phongToolStripMenuItem.Click += phongToolStripMenuItem_Click;
            // 
            // CanvasWidget
            // 
            CanvasWidget.Dock = DockStyle.Fill;
            CanvasWidget.Location = new Point(0, 27);
            CanvasWidget.Name = "CanvasWidget";
            CanvasWidget.Size = new Size(800, 397);
            CanvasWidget.TabIndex = 1;
            CanvasWidget.TabStop = false;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { FPSCounter });
            statusStrip1.Location = new Point(0, 424);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // FPSCounter
            // 
            FPSCounter.Name = "FPSCounter";
            FPSCounter.Size = new Size(57, 20);
            FPSCounter.Text = "FPS: ---";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CanvasWidget);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Name = "MainForm";
            Text = "Form1";
            KeyDown += MainForm_KeyDown;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CanvasWidget).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private PictureBox CanvasWidget;
        private ToolStripDropDownButton CameraSellector;
        private ToolStripMenuItem StaticCameraButton;
        private ToolStripMenuItem CarFollowingCameraButton;
        private ToolStripMenuItem TPPCameraToolStripMenuItem;
        private ToolStripDropDownButton RenderingDropDownButton;
        private ToolStripMenuItem edgesToolStripMenuItem;
        private ToolStripMenuItem modelColorToolStripMenuItem;
        private ToolStripMenuItem phongToolStripMenuItem;
        private ToolStripMenuItem gourandShadingToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel FPSCounter;
    }
}