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
            System.Windows.Forms.TableLayoutPanel WelcomePageLayout;
            System.Windows.Forms.Panel WelcomePageNavigation;
            System.Windows.Forms.Label WelcomePageLabelOpenedRecently;
            System.Windows.Forms.Panel WelcomePageContent;
            this.WelcomePageNavigationSeperator = new System.Windows.Forms.PictureBox();
            this.WelcomePageLinkOpenProject = new System.Windows.Forms.LinkLabel();
            this.WelcomePageLinkNewProject = new System.Windows.Forms.LinkLabel();
            this.WelcomePageLogo = new System.Windows.Forms.PictureBox();
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.WorkspaceSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SceneViewer = new System.Windows.Forms.TabControl();
            this.WelcomePage = new System.Windows.Forms.TabPage();
            this.SidebarSplitContainer = new System.Windows.Forms.SplitContainer();
            WelcomePageLayout = new System.Windows.Forms.TableLayoutPanel();
            WelcomePageNavigation = new System.Windows.Forms.Panel();
            WelcomePageLabelOpenedRecently = new System.Windows.Forms.Label();
            WelcomePageContent = new System.Windows.Forms.Panel();
            WelcomePageLayout.SuspendLayout();
            WelcomePageNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WelcomePageNavigationSeperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WelcomePageLogo)).BeginInit();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkspaceSplitContainer)).BeginInit();
            this.WorkspaceSplitContainer.Panel1.SuspendLayout();
            this.WorkspaceSplitContainer.Panel2.SuspendLayout();
            this.WorkspaceSplitContainer.SuspendLayout();
            this.SceneViewer.SuspendLayout();
            this.WelcomePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SidebarSplitContainer)).BeginInit();
            this.SidebarSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // WelcomePageLayout
            // 
            WelcomePageLayout.ColumnCount = 2;
            WelcomePageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            WelcomePageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            WelcomePageLayout.Controls.Add(WelcomePageNavigation, 0, 0);
            WelcomePageLayout.Controls.Add(WelcomePageContent, 1, 0);
            WelcomePageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            WelcomePageLayout.Location = new System.Drawing.Point(0, 0);
            WelcomePageLayout.Name = "WelcomePageLayout";
            WelcomePageLayout.Padding = new System.Windows.Forms.Padding(12);
            WelcomePageLayout.RowCount = 1;
            WelcomePageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            WelcomePageLayout.Size = new System.Drawing.Size(778, 642);
            WelcomePageLayout.TabIndex = 0;
            // 
            // WelcomePageNavigation
            // 
            WelcomePageNavigation.Controls.Add(this.WelcomePageNavigationSeperator);
            WelcomePageNavigation.Controls.Add(WelcomePageLabelOpenedRecently);
            WelcomePageNavigation.Controls.Add(this.WelcomePageLinkOpenProject);
            WelcomePageNavigation.Controls.Add(this.WelcomePageLinkNewProject);
            WelcomePageNavigation.Controls.Add(this.WelcomePageLogo);
            WelcomePageNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
            WelcomePageNavigation.Location = new System.Drawing.Point(15, 15);
            WelcomePageNavigation.Name = "WelcomePageNavigation";
            WelcomePageNavigation.Padding = new System.Windows.Forms.Padding(0, 0, 24, 0);
            WelcomePageNavigation.Size = new System.Drawing.Size(294, 612);
            WelcomePageNavigation.TabIndex = 0;
            // 
            // WelcomePageNavigationSeperator
            // 
            this.WelcomePageNavigationSeperator.Location = new System.Drawing.Point(192, 288);
            this.WelcomePageNavigationSeperator.Margin = new System.Windows.Forms.Padding(0);
            this.WelcomePageNavigationSeperator.Name = "WelcomePageNavigationSeperator";
            this.WelcomePageNavigationSeperator.Size = new System.Drawing.Size(100, 2);
            this.WelcomePageNavigationSeperator.TabIndex = 4;
            this.WelcomePageNavigationSeperator.TabStop = false;
            // 
            // WelcomePageLabelOpenedRecently
            // 
            WelcomePageLabelOpenedRecently.AutoSize = true;
            WelcomePageLabelOpenedRecently.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            WelcomePageLabelOpenedRecently.ForeColor = System.Drawing.SystemColors.GrayText;
            WelcomePageLabelOpenedRecently.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            WelcomePageLabelOpenedRecently.Location = new System.Drawing.Point(3, 277);
            WelcomePageLabelOpenedRecently.Name = "WelcomePageLabelOpenedRecently";
            WelcomePageLabelOpenedRecently.Size = new System.Drawing.Size(183, 20);
            WelcomePageLabelOpenedRecently.TabIndex = 3;
            WelcomePageLabelOpenedRecently.Text = "Projects opened recently";
            // 
            // WelcomePageLinkOpenProject
            // 
            this.WelcomePageLinkOpenProject.ActiveLinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.WelcomePageLinkOpenProject.AutoSize = true;
            this.WelcomePageLinkOpenProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WelcomePageLinkOpenProject.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.WelcomePageLinkOpenProject.LinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.WelcomePageLinkOpenProject.Location = new System.Drawing.Point(16, 219);
            this.WelcomePageLinkOpenProject.Name = "WelcomePageLinkOpenProject";
            this.WelcomePageLinkOpenProject.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.WelcomePageLinkOpenProject.Size = new System.Drawing.Size(104, 15);
            this.WelcomePageLinkOpenProject.TabIndex = 2;
            this.WelcomePageLinkOpenProject.TabStop = true;
            this.WelcomePageLinkOpenProject.Text = "Open Project...";
            this.WelcomePageLinkOpenProject.VisitedLinkColor = System.Drawing.SystemColors.MenuHighlight;
            // 
            // WelcomePageLinkNewProject
            // 
            this.WelcomePageLinkNewProject.ActiveLinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.WelcomePageLinkNewProject.AutoSize = true;
            this.WelcomePageLinkNewProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WelcomePageLinkNewProject.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.WelcomePageLinkNewProject.LinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.WelcomePageLinkNewProject.Location = new System.Drawing.Point(16, 192);
            this.WelcomePageLinkNewProject.Name = "WelcomePageLinkNewProject";
            this.WelcomePageLinkNewProject.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.WelcomePageLinkNewProject.Size = new System.Drawing.Size(99, 15);
            this.WelcomePageLinkNewProject.TabIndex = 1;
            this.WelcomePageLinkNewProject.TabStop = true;
            this.WelcomePageLinkNewProject.Text = "New Project...";
            this.WelcomePageLinkNewProject.VisitedLinkColor = System.Drawing.SystemColors.MenuHighlight;
            // 
            // WelcomePageLogo
            // 
            this.WelcomePageLogo.Location = new System.Drawing.Point(0, 24);
            this.WelcomePageLogo.Name = "WelcomePageLogo";
            this.WelcomePageLogo.Size = new System.Drawing.Size(270, 130);
            this.WelcomePageLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.WelcomePageLogo.TabIndex = 0;
            this.WelcomePageLogo.TabStop = false;
            // 
            // WelcomePageContent
            // 
            WelcomePageContent.Dock = System.Windows.Forms.DockStyle.Fill;
            WelcomePageContent.Location = new System.Drawing.Point(315, 15);
            WelcomePageContent.Name = "WelcomePageContent";
            WelcomePageContent.Padding = new System.Windows.Forms.Padding(12);
            WelcomePageContent.Size = new System.Drawing.Size(462, 612);
            WelcomePageContent.TabIndex = 1;
            WelcomePageContent.Paint += new System.Windows.Forms.PaintEventHandler(this.WelcomePageContent_Paint);
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Controls.Add(this.WorkspaceSplitContainer, 0, 2);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 4;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.LayoutPanel.Size = new System.Drawing.Size(1264, 762);
            this.LayoutPanel.TabIndex = 1;
            // 
            // WorkspaceSplitContainer
            // 
            this.WorkspaceSplitContainer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.WorkspaceSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkspaceSplitContainer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkspaceSplitContainer.Location = new System.Drawing.Point(3, 54);
            this.WorkspaceSplitContainer.Name = "WorkspaceSplitContainer";
            // 
            // WorkspaceSplitContainer.Panel1
            // 
            this.WorkspaceSplitContainer.Panel1.Controls.Add(this.SceneViewer);
            this.WorkspaceSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.WorkspaceSplitContainer.Panel1MinSize = 300;
            // 
            // WorkspaceSplitContainer.Panel2
            // 
            this.WorkspaceSplitContainer.Panel2.Controls.Add(this.SidebarSplitContainer);
            this.WorkspaceSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 27, 5, 5);
            this.WorkspaceSplitContainer.Panel2MinSize = 200;
            this.WorkspaceSplitContainer.Size = new System.Drawing.Size(1258, 680);
            this.WorkspaceSplitContainer.SplitterDistance = 796;
            this.WorkspaceSplitContainer.SplitterIncrement = 10;
            this.WorkspaceSplitContainer.SplitterWidth = 1;
            this.WorkspaceSplitContainer.TabIndex = 3;
            // 
            // SceneViewer
            // 
            this.SceneViewer.Controls.Add(this.WelcomePage);
            this.SceneViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneViewer.Location = new System.Drawing.Point(5, 5);
            this.SceneViewer.Multiline = true;
            this.SceneViewer.Name = "SceneViewer";
            this.SceneViewer.SelectedIndex = 0;
            this.SceneViewer.Size = new System.Drawing.Size(786, 670);
            this.SceneViewer.TabIndex = 0;
            this.SceneViewer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SceneViewer_MouseClick);
            // 
            // WelcomePage
            // 
            this.WelcomePage.Controls.Add(WelcomePageLayout);
            this.WelcomePage.Location = new System.Drawing.Point(4, 24);
            this.WelcomePage.Name = "WelcomePage";
            this.WelcomePage.Size = new System.Drawing.Size(778, 642);
            this.WelcomePage.TabIndex = 0;
            this.WelcomePage.Text = "Start";
            this.WelcomePage.UseVisualStyleBackColor = true;
            // 
            // SidebarSplitContainer
            // 
            this.SidebarSplitContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.SidebarSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SidebarSplitContainer.Location = new System.Drawing.Point(0, 27);
            this.SidebarSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.SidebarSplitContainer.Name = "SidebarSplitContainer";
            // 
            // SidebarSplitContainer.Panel1
            // 
            this.SidebarSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.SidebarSplitContainer.Panel1MinSize = 100;
            // 
            // SidebarSplitContainer.Panel2
            // 
            this.SidebarSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.SidebarSplitContainer.Panel2MinSize = 100;
            this.SidebarSplitContainer.Size = new System.Drawing.Size(456, 648);
            this.SidebarSplitContainer.SplitterDistance = 226;
            this.SidebarSplitContainer.SplitterIncrement = 10;
            this.SidebarSplitContainer.SplitterWidth = 1;
            this.SidebarSplitContainer.TabIndex = 0;
            // 
            // AppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 762);
            this.Controls.Add(this.LayoutPanel);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AppWindow";
            this.Text = "Honey Cube Editor";
            WelcomePageLayout.ResumeLayout(false);
            WelcomePageNavigation.ResumeLayout(false);
            WelcomePageNavigation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WelcomePageNavigationSeperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WelcomePageLogo)).EndInit();
            this.LayoutPanel.ResumeLayout(false);
            this.WorkspaceSplitContainer.Panel1.ResumeLayout(false);
            this.WorkspaceSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WorkspaceSplitContainer)).EndInit();
            this.WorkspaceSplitContainer.ResumeLayout(false);
            this.SceneViewer.ResumeLayout(false);
            this.WelcomePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SidebarSplitContainer)).EndInit();
            this.SidebarSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.SplitContainer WorkspaceSplitContainer;
        private System.Windows.Forms.TabControl SceneViewer;
        private System.Windows.Forms.TabPage WelcomePage;
        private System.Windows.Forms.PictureBox WelcomePageNavigationSeperator;
        private System.Windows.Forms.LinkLabel WelcomePageLinkOpenProject;
        private System.Windows.Forms.LinkLabel WelcomePageLinkNewProject;
        private System.Windows.Forms.PictureBox WelcomePageLogo;
        private System.Windows.Forms.SplitContainer SidebarSplitContainer;

    }
}

