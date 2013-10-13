#region Using Statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// A dialog window that prompts for user (text) input.
    /// </summary>
    public partial class InputDialog : Form, IInputDialog
    {
        #region Properties

        /// <summary>
        ///  Gets or sets the text entered in the dialog by the user.
        /// </summary>
        public string UserInput
        {
            get;
            protected set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new input dialog.
        /// </summary>
        /// <param name="title">The title of the dialog.</param>
        /// <param name="heading">The heading displayed in the dialog.</param>
        /// <param name="description">The description displayed in the dialog.</param>
        public InputDialog(string title, string heading, string description)
        {
            InitializeComponent();

            Text = title;
            DialogHeading.Text = heading;
            DialogDescription.Text = description;
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Is called when the dialog is shown. Reset the input property in 
        /// case we have used it before.
        /// </summary>
        /// <param name="e">Some event arguments.</param>
        protected override void OnShown(EventArgs e)
        {
            UserInput = string.Empty;
            base.OnShown(e);
        }

        /// <summary>
        /// Is called when the user clicks the close button of the dialog. 
        /// Resets the input box on close.
        /// </summary>
        /// <param name="e">Some event arguments.</param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            DialogInputBox.Text = string.Empty;
            base.OnFormClosed(e);
        }

        /// <summary>
        /// Is raised when the user clicks the ok button. Copies the input
        /// value to the public input property.
        /// </summary>
        /// <param name="sender">Button clicked.</param>
        /// <param name="e">Some event arguments.</param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            UserInput = DialogInputBox.Text;
        }

        /// <summary>
        /// Is raised when the user clicks the cancel button. Clears the
        /// input box.
        /// </summary>
        /// <param name="sender">Button clicked.</param>
        /// <param name="e">Some event arguments.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogInputBox.Text = string.Empty;
        }

        #endregion
    }
}
