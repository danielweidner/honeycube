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
            this.DialogLayout = new System.Windows.Forms.TableLayoutPanel();
            this.DialogHeading = new System.Windows.Forms.Label();
            this.DialogDescription = new System.Windows.Forms.Label();
            this.DialogInputBox = new System.Windows.Forms.TextBox();
            this.DialogOkButton = new System.Windows.Forms.Button();
            this.DialogCancelButton = new System.Windows.Forms.Button();
            this.DialogLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // DialogLayout
            // 
            this.DialogLayout.AutoSize = true;
            this.DialogLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DialogLayout.ColumnCount = 2;
            this.DialogLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DialogLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.DialogLayout.Controls.Add(this.DialogHeading, 0, 0);
            this.DialogLayout.Controls.Add(this.DialogDescription, 0, 1);
            this.DialogLayout.Controls.Add(this.DialogInputBox, 0, 2);
            this.DialogLayout.Controls.Add(this.DialogOkButton, 0, 3);
            this.DialogLayout.Controls.Add(this.DialogCancelButton, 1, 3);
            this.DialogLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.DialogLayout.Location = new System.Drawing.Point(20, 20);
            this.DialogLayout.Name = "DialogLayout";
            this.DialogLayout.RowCount = 4;
            this.DialogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.DialogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.DialogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.DialogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.DialogLayout.Size = new System.Drawing.Size(354, 124);
            this.DialogLayout.TabIndex = 0;
            // 
            // DialogHeading
            // 
            this.DialogHeading.AutoEllipsis = true;
            this.DialogHeading.AutoSize = true;
            this.DialogLayout.SetColumnSpan(this.DialogHeading, 2);
            this.DialogHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DialogHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DialogHeading.Location = new System.Drawing.Point(3, 0);
            this.DialogHeading.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.DialogHeading.Name = "DialogHeading";
            this.DialogHeading.Size = new System.Drawing.Size(348, 21);
            this.DialogHeading.TabIndex = 0;
            // 
            // DialogDescription
            // 
            this.DialogDescription.AutoSize = true;
            this.DialogLayout.SetColumnSpan(this.DialogDescription, 2);
            this.DialogDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DialogDescription.Location = new System.Drawing.Point(3, 31);
            this.DialogDescription.Name = "DialogDescription";
            this.DialogDescription.Size = new System.Drawing.Size(348, 15);
            this.DialogDescription.TabIndex = 1;
            // 
            // DialogInputBox
            // 
            this.DialogLayout.SetColumnSpan(this.DialogInputBox, 2);
            this.DialogInputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DialogInputBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DialogInputBox.Location = new System.Drawing.Point(3, 56);
            this.DialogInputBox.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.DialogInputBox.Name = "DialogInputBox";
            this.DialogInputBox.Size = new System.Drawing.Size(348, 29);
            this.DialogInputBox.TabIndex = 2;
            // 
            // DialogOkButton
            // 
            this.DialogOkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DialogOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.DialogOkButton.Location = new System.Drawing.Point(201, 98);
            this.DialogOkButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.DialogOkButton.Name = "DialogOkButton";
            this.DialogOkButton.Size = new System.Drawing.Size(75, 23);
            this.DialogOkButton.TabIndex = 3;
            this.DialogOkButton.Text = "Ok";
            this.DialogOkButton.UseVisualStyleBackColor = true;
            this.DialogOkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // DialogCancelButton
            // 
            this.DialogCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DialogCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DialogCancelButton.Location = new System.Drawing.Point(282, 98);
            this.DialogCancelButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.DialogCancelButton.Name = "DialogCancelButton";
            this.DialogCancelButton.Size = new System.Drawing.Size(69, 23);
            this.DialogCancelButton.TabIndex = 4;
            this.DialogCancelButton.Text = "Cancel";
            this.DialogCancelButton.UseVisualStyleBackColor = true;
            this.DialogCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // InputDialog
            // 
            this.AcceptButton = this.DialogOkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(394, 222);
            this.Controls.Add(this.DialogLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 28);
            this.Name = "InputDialog";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.DialogLayout.ResumeLayout(false);
            this.DialogLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel DialogLayout;
        private System.Windows.Forms.Label DialogHeading;
        private System.Windows.Forms.Label DialogDescription;
        private System.Windows.Forms.TextBox DialogInputBox;
        private System.Windows.Forms.Button DialogOkButton;
        private System.Windows.Forms.Button DialogCancelButton;

    }
}