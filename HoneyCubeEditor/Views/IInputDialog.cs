#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// A generic interface for a simple input dialog.
    /// </summary>
    public interface IInputDialog
    {
        /// <summary>
        /// Gets the text entered in the dialog by the user.
        /// </summary>
        string UserInput
        {
            get;
        }

        /// <summary>
        /// Opens the dialog window and prompts the user for input.
        /// </summary>
        /// <returns>Indicates whether the user has accepted or canceled the dialog.</returns>
        DialogResult ShowDialog();
    }
}
