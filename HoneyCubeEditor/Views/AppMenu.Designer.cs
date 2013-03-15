namespace HoneyCube.Editor.Views
{
    partial class AppMenu
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
            System.Windows.Forms.ToolStripMenuItem File;
            System.Windows.Forms.ToolStripMenuItem NewProject;
            System.Windows.Forms.ToolStripMenuItem OpenProject;
            System.Windows.Forms.ToolStripMenuItem OpenRecent;
            System.Windows.Forms.ToolStripSeparator Seperator01;
            System.Windows.Forms.ToolStripMenuItem ClearRecent;
            System.Windows.Forms.ToolStripSeparator Seperator02;
            System.Windows.Forms.ToolStripMenuItem CloseProject;
            System.Windows.Forms.ToolStripSeparator Seperator03;
            System.Windows.Forms.ToolStripMenuItem SaveProject;
            System.Windows.Forms.ToolStripMenuItem SaveProjectAs;
            System.Windows.Forms.ToolStripSeparator Seperator04;
            System.Windows.Forms.ToolStripMenuItem Import;
            System.Windows.Forms.ToolStripMenuItem ImportEntity;
            System.Windows.Forms.ToolStripMenuItem ImportComponent;
            System.Windows.Forms.ToolStripMenuItem Export;
            System.Windows.Forms.ToolStripSeparator Seperator05;
            System.Windows.Forms.ToolStripMenuItem Exit;
            System.Windows.Forms.ToolStripMenuItem Edit;
            System.Windows.Forms.ToolStripMenuItem Undo;
            System.Windows.Forms.ToolStripMenuItem Redo;
            System.Windows.Forms.ToolStripSeparator Seperator06;
            System.Windows.Forms.ToolStripMenuItem Copy;
            System.Windows.Forms.ToolStripMenuItem Paste;
            System.Windows.Forms.ToolStripMenuItem Cut;
            System.Windows.Forms.ToolStripMenuItem Delete;
            System.Windows.Forms.ToolStripSeparator Seperator07;
            System.Windows.Forms.ToolStripMenuItem Preferences;
            System.Windows.Forms.ToolStripMenuItem View;
            System.Windows.Forms.ToolStripMenuItem Sidebar;
            System.Windows.Forms.ToolStripMenuItem ToggleProjectTree;
            System.Windows.Forms.ToolStripMenuItem ToggleInspector;
            System.Windows.Forms.ToolStripSeparator Seperator08;
            System.Windows.Forms.ToolStripMenuItem ToggleSidebar;
            System.Windows.Forms.ToolStripSeparator Seperator10;
            System.Windows.Forms.ToolStripMenuItem ShowLog;
            System.Windows.Forms.ToolStripMenuItem Help;
            System.Windows.Forms.ToolStripMenuItem Documentation;
            System.Windows.Forms.ToolStripMenuItem Github;
            System.Windows.Forms.ToolStripSeparator Seperator09;
            System.Windows.Forms.ToolStripMenuItem About;
            File = new System.Windows.Forms.ToolStripMenuItem();
            NewProject = new System.Windows.Forms.ToolStripMenuItem();
            OpenProject = new System.Windows.Forms.ToolStripMenuItem();
            OpenRecent = new System.Windows.Forms.ToolStripMenuItem();
            Seperator01 = new System.Windows.Forms.ToolStripSeparator();
            ClearRecent = new System.Windows.Forms.ToolStripMenuItem();
            Seperator02 = new System.Windows.Forms.ToolStripSeparator();
            CloseProject = new System.Windows.Forms.ToolStripMenuItem();
            Seperator03 = new System.Windows.Forms.ToolStripSeparator();
            SaveProject = new System.Windows.Forms.ToolStripMenuItem();
            SaveProjectAs = new System.Windows.Forms.ToolStripMenuItem();
            Seperator04 = new System.Windows.Forms.ToolStripSeparator();
            Import = new System.Windows.Forms.ToolStripMenuItem();
            ImportEntity = new System.Windows.Forms.ToolStripMenuItem();
            ImportComponent = new System.Windows.Forms.ToolStripMenuItem();
            Export = new System.Windows.Forms.ToolStripMenuItem();
            Seperator05 = new System.Windows.Forms.ToolStripSeparator();
            Exit = new System.Windows.Forms.ToolStripMenuItem();
            Edit = new System.Windows.Forms.ToolStripMenuItem();
            Undo = new System.Windows.Forms.ToolStripMenuItem();
            Redo = new System.Windows.Forms.ToolStripMenuItem();
            Seperator06 = new System.Windows.Forms.ToolStripSeparator();
            Copy = new System.Windows.Forms.ToolStripMenuItem();
            Paste = new System.Windows.Forms.ToolStripMenuItem();
            Cut = new System.Windows.Forms.ToolStripMenuItem();
            Delete = new System.Windows.Forms.ToolStripMenuItem();
            Seperator07 = new System.Windows.Forms.ToolStripSeparator();
            Preferences = new System.Windows.Forms.ToolStripMenuItem();
            View = new System.Windows.Forms.ToolStripMenuItem();
            Sidebar = new System.Windows.Forms.ToolStripMenuItem();
            ToggleProjectTree = new System.Windows.Forms.ToolStripMenuItem();
            ToggleInspector = new System.Windows.Forms.ToolStripMenuItem();
            Seperator08 = new System.Windows.Forms.ToolStripSeparator();
            ToggleSidebar = new System.Windows.Forms.ToolStripMenuItem();
            Seperator10 = new System.Windows.Forms.ToolStripSeparator();
            ShowLog = new System.Windows.Forms.ToolStripMenuItem();
            Help = new System.Windows.Forms.ToolStripMenuItem();
            Documentation = new System.Windows.Forms.ToolStripMenuItem();
            Github = new System.Windows.Forms.ToolStripMenuItem();
            Seperator09 = new System.Windows.Forms.ToolStripSeparator();
            About = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // File
            // 
            File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            NewProject,
            OpenProject,
            OpenRecent,
            Seperator02,
            CloseProject,
            Seperator03,
            SaveProject,
            SaveProjectAs,
            Seperator04,
            Import,
            Export,
            Seperator05,
            Exit});
            File.Name = "File";
            File.Size = new System.Drawing.Size(37, 20);
            File.Text = "File";
            // 
            // NewProject
            // 
            NewProject.Name = "NewProject";
            NewProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            NewProject.Size = new System.Drawing.Size(288, 22);
            NewProject.Text = "New Project...";
            NewProject.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // OpenProject
            // 
            OpenProject.Name = "OpenProject";
            OpenProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            OpenProject.Size = new System.Drawing.Size(288, 22);
            OpenProject.Text = "Open Project...";
            OpenProject.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // OpenRecent
            // 
            OpenRecent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            Seperator01,
            ClearRecent});
            OpenRecent.Enabled = false;
            OpenRecent.Name = "OpenRecent";
            OpenRecent.Size = new System.Drawing.Size(288, 22);
            OpenRecent.Text = "Open Recent";
            // 
            // Seperator01
            // 
            Seperator01.Name = "Seperator01";
            Seperator01.Size = new System.Drawing.Size(119, 6);
            // 
            // ClearRecent
            // 
            ClearRecent.Name = "ClearRecent";
            ClearRecent.Size = new System.Drawing.Size(122, 22);
            ClearRecent.Text = "Clear List";
            ClearRecent.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Seperator02
            // 
            Seperator02.Name = "Seperator02";
            Seperator02.Size = new System.Drawing.Size(285, 6);
            // 
            // CloseProject
            // 
            CloseProject.Name = "CloseProject";
            CloseProject.Size = new System.Drawing.Size(288, 22);
            CloseProject.Text = "Close Project";
            CloseProject.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Seperator03
            // 
            Seperator03.Name = "Seperator03";
            Seperator03.Size = new System.Drawing.Size(285, 6);
            // 
            // SaveProject
            // 
            SaveProject.Name = "SaveProject";
            SaveProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            SaveProject.Size = new System.Drawing.Size(288, 22);
            SaveProject.Text = "Save Project";
            SaveProject.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // SaveProjectAs
            // 
            SaveProjectAs.Name = "SaveProjectAs";
            SaveProjectAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            SaveProjectAs.Size = new System.Drawing.Size(288, 22);
            SaveProjectAs.Text = "Save Project As...";
            SaveProjectAs.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Seperator04
            // 
            Seperator04.Name = "Seperator04";
            Seperator04.Size = new System.Drawing.Size(285, 6);
            // 
            // Import
            // 
            Import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ImportEntity,
            ImportComponent});
            Import.Name = "Import";
            Import.Size = new System.Drawing.Size(288, 22);
            Import.Text = "Import";
            // 
            // ImportEntity
            // 
            ImportEntity.Name = "ImportEntity";
            ImportEntity.Size = new System.Drawing.Size(147, 22);
            ImportEntity.Text = "Entity...";
            ImportEntity.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // ImportComponent
            // 
            ImportComponent.Name = "ImportComponent";
            ImportComponent.Size = new System.Drawing.Size(147, 22);
            ImportComponent.Text = "Component...";
            ImportComponent.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Export
            // 
            Export.Name = "Export";
            Export.Size = new System.Drawing.Size(288, 22);
            Export.Text = "Export";
            // 
            // Seperator05
            // 
            Seperator05.Name = "Seperator05";
            Seperator05.Size = new System.Drawing.Size(285, 6);
            // 
            // Exit
            // 
            Exit.Name = "Exit";
            Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            Exit.Size = new System.Drawing.Size(288, 22);
            Exit.Text = "Exit";
            Exit.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Edit
            // 
            Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            Undo,
            Redo,
            Seperator06,
            Copy,
            Paste,
            Cut,
            Delete,
            Seperator07,
            Preferences});
            Edit.Name = "Edit";
            Edit.Size = new System.Drawing.Size(39, 20);
            Edit.Text = "Edit";
            // 
            // Undo
            // 
            Undo.Name = "Undo";
            Undo.Size = new System.Drawing.Size(135, 22);
            Undo.Text = "Undo";
            Undo.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Redo
            // 
            Redo.Name = "Redo";
            Redo.Size = new System.Drawing.Size(135, 22);
            Redo.Text = "Redo";
            Redo.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Seperator06
            // 
            Seperator06.Name = "Seperator06";
            Seperator06.Size = new System.Drawing.Size(132, 6);
            // 
            // Copy
            // 
            Copy.Name = "Copy";
            Copy.Size = new System.Drawing.Size(135, 22);
            Copy.Text = "Copy";
            Copy.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Paste
            // 
            Paste.Name = "Paste";
            Paste.Size = new System.Drawing.Size(135, 22);
            Paste.Text = "Paste";
            Paste.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Cut
            // 
            Cut.Name = "Cut";
            Cut.Size = new System.Drawing.Size(135, 22);
            Cut.Text = "Cut";
            Cut.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Delete
            // 
            Delete.Name = "Delete";
            Delete.Size = new System.Drawing.Size(135, 22);
            Delete.Text = "Delete";
            Delete.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Seperator07
            // 
            Seperator07.Name = "Seperator07";
            Seperator07.Size = new System.Drawing.Size(132, 6);
            // 
            // Preferences
            // 
            Preferences.Name = "Preferences";
            Preferences.Size = new System.Drawing.Size(135, 22);
            Preferences.Text = "Preferences";
            Preferences.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // View
            // 
            View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            Sidebar,
            Seperator10,
            ShowLog});
            View.Name = "View";
            View.Size = new System.Drawing.Size(44, 20);
            View.Text = "View";
            // 
            // Sidebar
            // 
            Sidebar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ToggleProjectTree,
            ToggleInspector,
            Seperator08,
            ToggleSidebar});
            Sidebar.Name = "Sidebar";
            Sidebar.Size = new System.Drawing.Size(126, 22);
            Sidebar.Text = "Sidebar";
            // 
            // ToggleProjectTree
            // 
            ToggleProjectTree.Checked = true;
            ToggleProjectTree.CheckOnClick = true;
            ToggleProjectTree.CheckState = System.Windows.Forms.CheckState.Checked;
            ToggleProjectTree.Name = "ToggleProjectTree";
            ToggleProjectTree.Size = new System.Drawing.Size(141, 22);
            ToggleProjectTree.Tag = "";
            ToggleProjectTree.Text = "Project";
            ToggleProjectTree.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // ToggleInspector
            // 
            ToggleInspector.Checked = true;
            ToggleInspector.CheckOnClick = true;
            ToggleInspector.CheckState = System.Windows.Forms.CheckState.Checked;
            ToggleInspector.Name = "ToggleInspector";
            ToggleInspector.Size = new System.Drawing.Size(141, 22);
            ToggleInspector.Tag = "";
            ToggleInspector.Text = "Inspector";
            ToggleInspector.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Seperator08
            // 
            Seperator08.Name = "Seperator08";
            Seperator08.Size = new System.Drawing.Size(138, 6);
            // 
            // ToggleSidebar
            // 
            ToggleSidebar.Name = "ToggleSidebar";
            ToggleSidebar.Size = new System.Drawing.Size(141, 22);
            ToggleSidebar.Tag = "";
            ToggleSidebar.Text = "Hide Sidebar";
            ToggleSidebar.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Seperator10
            // 
            Seperator10.Name = "Seperator10";
            Seperator10.Size = new System.Drawing.Size(123, 6);
            // 
            // ShowLog
            // 
            ShowLog.Name = "ShowLog";
            ShowLog.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            ShowLog.Size = new System.Drawing.Size(168, 22);
            ShowLog.Text = "Show Log";
            ShowLog.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Help
            // 
            Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            Documentation,
            Github,
            Seperator09,
            About});
            Help.Name = "Help";
            Help.Size = new System.Drawing.Size(44, 20);
            Help.Text = "Help";
            // 
            // Documentation
            // 
            Documentation.Name = "Documentation";
            Documentation.Size = new System.Drawing.Size(176, 22);
            Documentation.Text = "Documentation";
            Documentation.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Github
            // 
            Github.Name = "Github";
            Github.Size = new System.Drawing.Size(176, 22);
            Github.Text = "Github";
            Github.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Seperator09
            // 
            Seperator09.Name = "Seperator09";
            Seperator09.Size = new System.Drawing.Size(173, 6);
            // 
            // About
            // 
            About.Name = "About";
            About.Size = new System.Drawing.Size(176, 22);
            About.Text = "About Honey Cube";
            About.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // AppMenu
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            File,
            Edit,
            View,
            Help});
            this.ResumeLayout(false);

        }

        #endregion

    }
}
