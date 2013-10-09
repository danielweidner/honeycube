namespace HoneyCube.Editor.Views
{
    partial class AppToolbar
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
            System.Windows.Forms.ToolStripSeparator ToolbarSeparator1;
            System.Windows.Forms.ToolStripSeparator ToolbarSeparator2;
            System.Windows.Forms.ToolStripSeparator ToolbarSeparator3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppToolbar));
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.ToolbarNewProject = new System.Windows.Forms.ToolStripButton();
            this.ToolbarOpenProject = new System.Windows.Forms.ToolStripButton();
            this.ToolbarSave = new System.Windows.Forms.ToolStripButton();
            this.ToolbarUndo = new System.Windows.Forms.ToolStripButton();
            this.ToolbarRedo = new System.Windows.Forms.ToolStripButton();
            this.ToolbarCopy = new System.Windows.Forms.ToolStripButton();
            this.ToolbarPaste = new System.Windows.Forms.ToolStripButton();
            this.ToolbarCut = new System.Windows.Forms.ToolStripButton();
            this.ToolbarLog = new System.Windows.Forms.ToolStripButton();
            ToolbarSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ToolbarSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ToolbarSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolbarSeparator1
            // 
            ToolbarSeparator1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            ToolbarSeparator1.Name = "ToolbarSeparator1";
            ToolbarSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolbarSeparator2
            // 
            ToolbarSeparator2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            ToolbarSeparator2.Name = "ToolbarSeparator2";
            ToolbarSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolbarSeparator3
            // 
            ToolbarSeparator3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            ToolbarSeparator3.Name = "ToolbarSeparator3";
            ToolbarSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolbarNewProject,
            this.ToolbarOpenProject,
            this.ToolbarSave,
            ToolbarSeparator1,
            this.ToolbarUndo,
            this.ToolbarRedo,
            ToolbarSeparator2,
            this.ToolbarCopy,
            this.ToolbarPaste,
            this.ToolbarCut,
            ToolbarSeparator3,
            this.ToolbarLog});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.MinimumSize = new System.Drawing.Size(800, 25);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(800, 25);
            this.ToolStrip.Stretch = true;
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip_ItemClicked);
            // 
            // ToolbarNewProject
            // 
            this.ToolbarNewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarNewProject.Image = ((System.Drawing.Image)(resources.GetObject("ToolbarNewProject.Image")));
            this.ToolbarNewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarNewProject.Name = "ToolbarNewProject";
            this.ToolbarNewProject.Size = new System.Drawing.Size(23, 22);
            this.ToolbarNewProject.Text = "New Project...";
            this.ToolbarNewProject.ToolTipText = "New Project...";
            // 
            // ToolbarOpenProject
            // 
            this.ToolbarOpenProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarOpenProject.Image = ((System.Drawing.Image)(resources.GetObject("ToolbarOpenProject.Image")));
            this.ToolbarOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarOpenProject.Name = "ToolbarOpenProject";
            this.ToolbarOpenProject.Size = new System.Drawing.Size(23, 22);
            this.ToolbarOpenProject.Text = "Open Project...";
            this.ToolbarOpenProject.ToolTipText = "Open Project...";
            // 
            // ToolbarSave
            // 
            this.ToolbarSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarSave.Image = ((System.Drawing.Image)(resources.GetObject("ToolbarSave.Image")));
            this.ToolbarSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarSave.Name = "ToolbarSave";
            this.ToolbarSave.Size = new System.Drawing.Size(23, 22);
            this.ToolbarSave.Text = "Save Project";
            this.ToolbarSave.ToolTipText = "Save Project";
            // 
            // ToolbarUndo
            // 
            this.ToolbarUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarUndo.Image = ((System.Drawing.Image)(resources.GetObject("ToolbarUndo.Image")));
            this.ToolbarUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarUndo.Name = "ToolbarUndo";
            this.ToolbarUndo.Size = new System.Drawing.Size(23, 22);
            this.ToolbarUndo.Text = "Undo";
            this.ToolbarUndo.ToolTipText = "Undo";
            // 
            // ToolbarRedo
            // 
            this.ToolbarRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarRedo.Image = ((System.Drawing.Image)(resources.GetObject("ToolbarRedo.Image")));
            this.ToolbarRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarRedo.Name = "ToolbarRedo";
            this.ToolbarRedo.Size = new System.Drawing.Size(23, 22);
            this.ToolbarRedo.Text = "Redo";
            this.ToolbarRedo.ToolTipText = "Redo";
            // 
            // ToolbarCopy
            // 
            this.ToolbarCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarCopy.Image = ((System.Drawing.Image)(resources.GetObject("ToolbarCopy.Image")));
            this.ToolbarCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarCopy.Name = "ToolbarCopy";
            this.ToolbarCopy.Size = new System.Drawing.Size(23, 22);
            this.ToolbarCopy.Text = "Copy";
            this.ToolbarCopy.ToolTipText = "Copy";
            // 
            // ToolbarPaste
            // 
            this.ToolbarPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarPaste.Image = ((System.Drawing.Image)(resources.GetObject("ToolbarPaste.Image")));
            this.ToolbarPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarPaste.Name = "ToolbarPaste";
            this.ToolbarPaste.Size = new System.Drawing.Size(23, 22);
            this.ToolbarPaste.Text = "Paste";
            this.ToolbarPaste.ToolTipText = "Paste";
            // 
            // ToolbarCut
            // 
            this.ToolbarCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarCut.Image = ((System.Drawing.Image)(resources.GetObject("ToolbarCut.Image")));
            this.ToolbarCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarCut.Name = "ToolbarCut";
            this.ToolbarCut.Size = new System.Drawing.Size(23, 22);
            this.ToolbarCut.Text = "Cut";
            this.ToolbarCut.ToolTipText = "Cut";
            // 
            // ToolbarLog
            // 
            this.ToolbarLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarLog.Image = ((System.Drawing.Image)(resources.GetObject("ToolbarLog.Image")));
            this.ToolbarLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarLog.Name = "ToolbarLog";
            this.ToolbarLog.Size = new System.Drawing.Size(23, 22);
            this.ToolbarLog.Text = "Show Log";
            // 
            // AppToolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ToolStrip);
            this.MinimumSize = new System.Drawing.Size(800, 25);
            this.Name = "AppToolbar";
            this.Size = new System.Drawing.Size(800, 25);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton ToolbarNewProject;
        private System.Windows.Forms.ToolStripButton ToolbarOpenProject;
        private System.Windows.Forms.ToolStripButton ToolbarSave;
        private System.Windows.Forms.ToolStripButton ToolbarUndo;
        private System.Windows.Forms.ToolStripButton ToolbarRedo;
        private System.Windows.Forms.ToolStripButton ToolbarCopy;
        private System.Windows.Forms.ToolStripButton ToolbarPaste;
        private System.Windows.Forms.ToolStripButton ToolbarCut;
        private System.Windows.Forms.ToolStripButton ToolbarLog;
    }
}
