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
            System.Windows.Forms.ToolStripLabel DropDownLabel;
            System.Windows.Forms.ToolStripSeparator ToolbarSeperator1;
            System.Windows.Forms.ToolStripSeparator ToolbarSeperator2;
            System.Windows.Forms.ToolStripContainer ToolbarContainer;
            System.Windows.Forms.ToolStrip Toolbar;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppLogWindow));
            this.CurrentLog = new System.Windows.Forms.RichTextBox();
            this.LogDropDown = new System.Windows.Forms.ToolStripComboBox();
            this.SaveCurrentLog = new System.Windows.Forms.ToolStripButton();
            this.ClearCurrentLog = new System.Windows.Forms.ToolStripButton();
            this.ClearAllLogs = new System.Windows.Forms.ToolStripButton();
            this.Seperator03 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowWindowOnTop = new System.Windows.Forms.ToolStripButton();
            DropDownLabel = new System.Windows.Forms.ToolStripLabel();
            ToolbarSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            ToolbarSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            ToolbarContainer = new System.Windows.Forms.ToolStripContainer();
            Toolbar = new System.Windows.Forms.ToolStrip();
            ToolbarContainer.ContentPanel.SuspendLayout();
            ToolbarContainer.TopToolStripPanel.SuspendLayout();
            ToolbarContainer.SuspendLayout();
            Toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // DropDownLabel
            // 
            DropDownLabel.Name = "DropDownLabel";
            DropDownLabel.Size = new System.Drawing.Size(93, 22);
            DropDownLabel.Text = "Message Types: ";
            // 
            // ToolbarSeperator1
            // 
            ToolbarSeperator1.Name = "ToolbarSeperator1";
            ToolbarSeperator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolbarSeperator2
            // 
            ToolbarSeperator2.Name = "ToolbarSeperator2";
            ToolbarSeperator2.Size = new System.Drawing.Size(6, 25);
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
            ToolbarContainer.Text = "toolStripContainer1";
            // 
            // ToolbarContainer.TopToolStripPanel
            // 
            ToolbarContainer.TopToolStripPanel.Controls.Add(Toolbar);
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
            Toolbar.Dock = System.Windows.Forms.DockStyle.None;
            Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            DropDownLabel,
            this.LogDropDown,
            ToolbarSeperator1,
            this.SaveCurrentLog,
            this.ClearCurrentLog,
            ToolbarSeperator2,
            this.ClearAllLogs,
            this.Seperator03,
            this.ShowWindowOnTop});
            Toolbar.Location = new System.Drawing.Point(0, 0);
            Toolbar.Name = "Toolbar";
            Toolbar.Size = new System.Drawing.Size(624, 25);
            Toolbar.Stretch = true;
            Toolbar.TabIndex = 0;
            // 
            // LogDropDown
            // 
            this.LogDropDown.Name = "LogDropDown";
            this.LogDropDown.Size = new System.Drawing.Size(121, 25);
            this.LogDropDown.SelectedIndexChanged += new System.EventHandler(this.LogDropDown_SelectedChanged);
            // 
            // SaveCurrentLog
            // 
            this.SaveCurrentLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveCurrentLog.Image = ((System.Drawing.Image)(resources.GetObject("SaveCurrentLog.Image")));
            this.SaveCurrentLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveCurrentLog.Name = "SaveCurrentLog";
            this.SaveCurrentLog.Size = new System.Drawing.Size(23, 22);
            this.SaveCurrentLog.Text = "Save Current Log";
            this.SaveCurrentLog.Click += new System.EventHandler(this.SaveCurrentLog_Click);
            // 
            // ClearCurrentLog
            // 
            this.ClearCurrentLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearCurrentLog.Image = ((System.Drawing.Image)(resources.GetObject("ClearCurrentLog.Image")));
            this.ClearCurrentLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearCurrentLog.Name = "ClearCurrentLog";
            this.ClearCurrentLog.Size = new System.Drawing.Size(23, 22);
            this.ClearCurrentLog.Text = "Clear Current Log";
            this.ClearCurrentLog.Click += new System.EventHandler(this.ClearCurrentLog_Click);
            // 
            // ClearAllLogs
            // 
            this.ClearAllLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearAllLogs.Image = ((System.Drawing.Image)(resources.GetObject("ClearAllLogs.Image")));
            this.ClearAllLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearAllLogs.Name = "ClearAllLogs";
            this.ClearAllLogs.Size = new System.Drawing.Size(23, 22);
            this.ClearAllLogs.Text = "Clear All Logs";
            this.ClearAllLogs.Click += new System.EventHandler(this.ClearAllLogs_Click);
            // 
            // Seperator03
            // 
            this.Seperator03.Name = "Seperator03";
            this.Seperator03.Size = new System.Drawing.Size(6, 25);
            // 
            // ShowWindowOnTop
            // 
            this.ShowWindowOnTop.CheckOnClick = true;
            this.ShowWindowOnTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ShowWindowOnTop.Image = ((System.Drawing.Image)(resources.GetObject("ShowWindowOnTop.Image")));
            this.ShowWindowOnTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShowWindowOnTop.Name = "ShowWindowOnTop";
            this.ShowWindowOnTop.Size = new System.Drawing.Size(23, 22);
            this.ShowWindowOnTop.Text = "Show Always on Top";
            this.ShowWindowOnTop.Click += new System.EventHandler(this.ShowWindowOnTop_Click);
            // 
            // AppLogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(ToolbarContainer);
            this.Icon = global::HoneyCube.Editor.Properties.Resources.HoneyCube;
            this.Name = "AppLogWindow";
            this.Text = "Application Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppLogWindow_Closing);
            ToolbarContainer.ContentPanel.ResumeLayout(false);
            ToolbarContainer.TopToolStripPanel.ResumeLayout(false);
            ToolbarContainer.TopToolStripPanel.PerformLayout();
            ToolbarContainer.ResumeLayout(false);
            ToolbarContainer.PerformLayout();
            Toolbar.ResumeLayout(false);
            Toolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripComboBox LogDropDown;
        private System.Windows.Forms.ToolStripButton SaveCurrentLog;
        private System.Windows.Forms.ToolStripButton ClearCurrentLog;
        private System.Windows.Forms.ToolStripButton ShowWindowOnTop;
        private System.Windows.Forms.RichTextBox CurrentLog;
        private System.Windows.Forms.ToolStripButton ClearAllLogs;
        private System.Windows.Forms.ToolStripSeparator Seperator03;

    }
}