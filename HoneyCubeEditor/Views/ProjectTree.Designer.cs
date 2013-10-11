namespace HoneyCube.Editor.Views
{
    partial class ProjectTree
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Scene");
            this.Tree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // Tree
            // 
            this.Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tree.Enabled = false;
            this.Tree.Location = new System.Drawing.Point(0, 0);
            this.Tree.Name = "Tree";
            treeNode1.Name = "Root";
            treeNode1.Text = "Scene";
            this.Tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.Tree.Size = new System.Drawing.Size(280, 620);
            this.Tree.TabIndex = 0;
            // 
            // ProjectTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Tree);
            this.Name = "ProjectTree";
            this.Size = new System.Drawing.Size(280, 620);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView Tree;
    }
}
