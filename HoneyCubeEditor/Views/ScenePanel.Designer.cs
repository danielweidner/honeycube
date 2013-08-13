namespace HoneyCube.Editor.Views
{
    partial class ScenePanel
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
            this.DefaultScene = new HoneyCube.Editor.Views.SceneViewer();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // DefaultScene
            // 
            this.DefaultScene.Location = new System.Drawing.Point(4, 22);
            this.DefaultScene.Name = "DefaultScene";
            this.DefaultScene.Padding = new System.Windows.Forms.Padding(3);
            this.DefaultScene.Size = new System.Drawing.Size(792, 574);
            this.DefaultScene.TabIndex = 0;
            this.DefaultScene.Text = "Scene 1";
            this.DefaultScene.UseVisualStyleBackColor = true;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.DefaultScene);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(800, 600);
            this.TabControl.TabIndex = 1;
            // 
            // ScenePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.TabControl);
            this.Name = "ScenePanel";
            this.Size = new System.Drawing.Size(800, 600);
            this.TabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HoneyCube.Editor.Views.SceneViewer DefaultScene;
        private System.Windows.Forms.TabControl TabControl;
    }
}
