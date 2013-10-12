namespace HoneyCube.Editor.Views
{
    partial class InputDialog
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
            this.Layout = new System.Windows.Forms.TableLayoutPanel();
            this.Heading = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.Layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // Layout
            // 
            this.Layout.AutoSize = true;
            this.Layout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Layout.ColumnCount = 2;
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.Layout.Controls.Add(this.Heading, 0, 0);
            this.Layout.Controls.Add(this.Description, 0, 1);
            this.Layout.Controls.Add(this.InputBox, 0, 2);
            this.Layout.Controls.Add(this.OkButton, 0, 3);
            this.Layout.Controls.Add(this.CancelButton, 1, 3);
            this.Layout.Dock = System.Windows.Forms.DockStyle.Top;
            this.Layout.Location = new System.Drawing.Point(20, 20);
            this.Layout.Name = "Layout";
            this.Layout.RowCount = 4;
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Layout.Size = new System.Drawing.Size(354, 124);
            this.Layout.TabIndex = 0;
            // 
            // Heading
            // 
            this.Heading.AutoEllipsis = true;
            this.Heading.AutoSize = true;
            this.Layout.SetColumnSpan(this.Heading, 2);
            this.Heading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Heading.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Heading.Location = new System.Drawing.Point(3, 0);
            this.Heading.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.Heading.Name = "Heading";
            this.Heading.Size = new System.Drawing.Size(348, 21);
            this.Heading.TabIndex = 0;
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Layout.SetColumnSpan(this.Description, 2);
            this.Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Description.Location = new System.Drawing.Point(3, 31);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(348, 15);
            this.Description.TabIndex = 1;
            // 
            // InputBox
            // 
            this.Layout.SetColumnSpan(this.InputBox, 2);
            this.InputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBox.Location = new System.Drawing.Point(3, 56);
            this.InputBox.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(348, 29);
            this.InputBox.TabIndex = 2;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(201, 98);
            this.OkButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(282, 98);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(69, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // InputDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(394, 222);
            this.Controls.Add(this.Layout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 28);
            this.Name = "InputDialog";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Layout.ResumeLayout(false);
            this.Layout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Layout;
        private System.Windows.Forms.Label Heading;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;

    }
}