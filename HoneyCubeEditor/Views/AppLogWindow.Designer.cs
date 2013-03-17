namespace HoneyCube.Editor.Views
{
    partial class AppLogWindow
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
            System.Windows.Forms.ToolStripContainer ToolbarContainer;
            System.Windows.Forms.ToolStripLabel DropDownLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppLogWindow));
            System.Windows.Forms.ToolStripMenuItem ClearCurrentLog;
            System.Windows.Forms.ToolStripMenuItem ClearAllLogs;
            this.CurrentLog = new System.Windows.Forms.RichTextBox();
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.LogDropDown = new System.Windows.Forms.ToolStripComboBox();
            this.Seperator01 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveCurrentLog = new System.Windows.Forms.ToolStripButton();
            this.ClearLogs = new System.Windows.Forms.ToolStripSplitButton();
            this.Seperator02 = new System.Windows.Forms.ToolStripSeparator();
            ToolbarContainer = new System.Windows.Forms.ToolStripContainer();
            DropDownLabel = new System.Windows.Forms.ToolStripLabel();
            ClearCurrentLog = new System.Windows.Forms.ToolStripMenuItem();
            ClearAllLogs = new System.Windows.Forms.ToolStripMenuItem();
            ToolbarContainer.ContentPanel.SuspendLayout();
            ToolbarContainer.TopToolStripPanel.SuspendLayout();
            ToolbarContainer.SuspendLayout();
            this.Toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolbarContainer
            // 
            // 
            // ToolbarContainer.ContentPanel
            // 
            ToolbarContainer.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            ToolbarContainer.ContentPanel.Controls.Add(this.CurrentLog);
            ToolbarContainer.ContentPanel.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            ToolbarContainer.ContentPanel.Size = new System.Drawing.Size(624, 417);
            ToolbarContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            ToolbarContainer.LeftToolStripPanelVisible = false;
            ToolbarContainer.Location = new System.Drawing.Point(0, 0);
            ToolbarContainer.Name = "ToolbarContainer";
            ToolbarContainer.RightToolStripPanelVisible = false;
            ToolbarContainer.Size = new System.Drawing.Size(624, 442);
            ToolbarContainer.TabIndex = 0;
            // 
            // ToolbarContainer.TopToolStripPanel
            // 
            ToolbarContainer.TopToolStripPanel.Controls.Add(this.Toolbar);
            // 
            // CurrentLog
            // 
            this.CurrentLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CurrentLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentLog.Location = new System.Drawing.Point(6, 3);
            this.CurrentLog.Name = "CurrentLog";
            this.CurrentLog.ReadOnly = true;
            this.CurrentLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.CurrentLog.ShortcutsEnabled = false;
            this.CurrentLog.Size = new System.Drawing.Size(614, 407);
            this.CurrentLog.TabIndex = 0;
            this.CurrentLog.Text = "";
            // 
            // Toolbar
            // 
            this.Toolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            DropDownLabel,
            this.LogDropDown,
            this.Seperator01,
            this.SaveCurrentLog,
            this.ClearLogs,
            this.Seperator02});
            this.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(624, 25);
            this.Toolbar.Stretch = true;
            this.Toolbar.TabIndex = 0;
            // 
            // DropDownLabel
            // 
            DropDownLabel.Name = "DropDownLabel";
            DropDownLabel.Size = new System.Drawing.Size(90, 22);
            DropDownLabel.Text = "Message Types:";
            // 
            // LogDropDown
            // 
            this.LogDropDown.Name = "LogDropDown";
            this.LogDropDown.Size = new System.Drawing.Size(121, 25);
            this.LogDropDown.SelectedIndexChanged += new System.EventHandler(this.LogDropDown_SelectedChanged);
            // 
            // Seperator01
            // 
            this.Seperator01.Name = "Seperator01";
            this.Seperator01.Size = new System.Drawing.Size(6, 25);
            // 
            // SaveCurrentLog
            // 
            this.SaveCurrentLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveCurrentLog.Image = ((System.Drawing.Image)(resources.GetObject("SaveCurrentLog.Image")));
            this.SaveCurrentLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveCurrentLog.Name = "SaveCurrentLog";
            this.SaveCurrentLog.Size = new System.Drawing.Size(23, 22);
            this.SaveCurrentLog.Text = "Save Current Log ...";
            this.SaveCurrentLog.Click += new System.EventHandler(this.SaveCurrentLog_Click);
            // 
            // ClearLogs
            // 
            this.ClearLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearLogs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ClearCurrentLog,
            ClearAllLogs});
            this.ClearLogs.Image = ((System.Drawing.Image)(resources.GetObject("ClearLogs.Image")));
            this.ClearLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearLogs.Name = "ClearLogs";
            this.ClearLogs.Size = new System.Drawing.Size(32, 22);
            this.ClearLogs.Text = "Clear Current Log";
            this.ClearLogs.ButtonClick += new System.EventHandler(this.ClearCurrentLog_Click);
            // 
            // ClearCurrentLog
            // 
            ClearCurrentLog.Name = "ClearCurrentLog";
            ClearCurrentLog.Size = new System.Drawing.Size(167, 22);
            ClearCurrentLog.Text = "Clear Current Log";
            ClearCurrentLog.Click += new System.EventHandler(this.ClearCurrentLog_Click);
            // 
            // ClearAllLogs
            // 
            ClearAllLogs.Name = "ClearAllLogs";
            ClearAllLogs.Size = new System.Drawing.Size(167, 22);
            ClearAllLogs.Text = "Clear All Logs";
            ClearAllLogs.Click += new System.EventHandler(this.ClearAllLogs_Click);
            // 
            // Seperator02
            // 
            this.Seperator02.Name = "Seperator02";
            this.Seperator02.Size = new System.Drawing.Size(6, 25);
            // 
            // AppLogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(ToolbarContainer);
            this.Name = "AppLogWindow";
            this.Text = "Application Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppLogWindow_Closing);
            ToolbarContainer.ContentPanel.ResumeLayout(false);
            ToolbarContainer.TopToolStripPanel.ResumeLayout(false);
            ToolbarContainer.TopToolStripPanel.PerformLayout();
            ToolbarContainer.ResumeLayout(false);
            ToolbarContainer.PerformLayout();
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox CurrentLog;
        private System.Windows.Forms.ToolStrip Toolbar;
        private System.Windows.Forms.ToolStripComboBox LogDropDown;
        private System.Windows.Forms.ToolStripButton SaveCurrentLog;
        private System.Windows.Forms.ToolStripSeparator Seperator01;
        private System.Windows.Forms.ToolStripSeparator Seperator02;
        private System.Windows.Forms.ToolStripSplitButton ClearLogs;

    }
}