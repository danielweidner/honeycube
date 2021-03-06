﻿namespace HoneyCube.Editor.Views
{
    partial class SceneView
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
            if (_graphicsDeviceService != null)
            {
                _graphicsDeviceService.Release(disposing);
                _graphicsDeviceService = null;
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary> 
        /// Required method for Designer support. Initializes the control and
        /// all its components.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SceneViewer
            // 
            this.BackColorChanged += new System.EventHandler(this.SceneViewer_BackColorChanged);
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ResumeLayout(false);

        }

        #endregion
    }
}
