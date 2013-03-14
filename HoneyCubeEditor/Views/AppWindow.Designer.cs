namespace HoneyCube.Editor.Views
{
    partial class AppWindow
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
            this.ToolbarContainer = new System.Windows.Forms.ToolStripContainer();
            this.WorkspaceSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SidebarSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ToolbarContainer.ContentPanel.SuspendLayout();
            this.ToolbarContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkspaceSplitContainer)).BeginInit();
            this.WorkspaceSplitContainer.Panel2.SuspendLayout();
            this.WorkspaceSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SidebarSplitContainer)).BeginInit();
            this.SidebarSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolbarContainer
            // 
            // 
            // ToolbarContainer.ContentPanel
            // 
            this.ToolbarContainer.ContentPanel.Controls.Add(this.WorkspaceSplitContainer);
            this.ToolbarContainer.ContentPanel.Size = new System.Drawing.Size(1264, 737);
            this.ToolbarContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolbarContainer.LeftToolStripPanelVisible = false;
            this.ToolbarContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolbarContainer.Name = "ToolbarContainer";
            this.ToolbarContainer.RightToolStripPanelVisible = false;
            this.ToolbarContainer.Size = new System.Drawing.Size(1264, 762);
            this.ToolbarContainer.TabIndex = 2;
            // 
            // WorkspaceSplitContainer
            // 
            this.WorkspaceSplitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.WorkspaceSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkspaceSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.WorkspaceSplitContainer.Name = "WorkspaceSplitContainer";
            // 
            // WorkspaceSplitContainer.Panel2
            // 
            this.WorkspaceSplitContainer.Panel2.Controls.Add(this.SidebarSplitContainer);
            this.WorkspaceSplitContainer.Size = new System.Drawing.Size(1264, 737);
            this.WorkspaceSplitContainer.SplitterDistance = 700;
            this.WorkspaceSplitContainer.SplitterIncrement = 10;
            this.WorkspaceSplitContainer.SplitterWidth = 6;
            this.WorkspaceSplitContainer.TabIndex = 0;
            // 
            // SidebarSplitContainer
            // 
            this.SidebarSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SidebarSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SidebarSplitContainer.Name = "SidebarSplitContainer";
            // 
            // SidebarSplitContainer.Panel1
            // 
            this.SidebarSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            // 
            // SidebarSplitContainer.Panel2
            // 
            this.SidebarSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SidebarSplitContainer.Size = new System.Drawing.Size(558, 737);
            this.SidebarSplitContainer.SplitterDistance = 279;
            this.SidebarSplitContainer.SplitterIncrement = 10;
            this.SidebarSplitContainer.SplitterWidth = 6;
            this.SidebarSplitContainer.TabIndex = 0;
            // 
            // AppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 762);
            this.Controls.Add(this.ToolbarContainer);
            this.Icon = global::HoneyCube.Editor.Properties.Resources.HoneyCube;
            this.KeyPreview = true;
            this.Name = "AppWindow";
            this.Text = "Honey Cube Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppWindow_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AppWindow_KeyUp);
            this.ToolbarContainer.ContentPanel.ResumeLayout(false);
            this.ToolbarContainer.ResumeLayout(false);
            this.ToolbarContainer.PerformLayout();
            this.WorkspaceSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WorkspaceSplitContainer)).EndInit();
            this.WorkspaceSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SidebarSplitContainer)).EndInit();
            this.SidebarSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer WorkspaceSplitContainer;
        private System.Windows.Forms.SplitContainer SidebarSplitContainer;
        private System.Windows.Forms.ToolStripContainer ToolbarContainer;
    }
}

