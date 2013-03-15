#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// An IAppLogPresenter controls the behavior of an associated 
    /// application log window.
    /// </summary>
    public interface IAppLogPresenter : IPresenter<IAppLogWindow>
    {
        /// <summary>
        /// Saves the specified log to a text file at the given path.
        /// </summary>
        /// <param name="name">The name of the log to save.</param>
        /// <param name="path">The path to save the log file to.</param>
        void SaveLog(string name, string path);

        /// <summary>
        /// Clears the specified application log.
        /// </summary>
        /// <param name="name">The name of the log to clear.</param>
        void ClearLog(string name);

        /// <summary>
        /// Clears all created application logs.
        /// </summary>
        void ClearAllLogs();

        /// <summary>
        /// Generates a valid file path that can be used to dump the log contents
        /// to a text file.
        /// </summary>
        /// <param name="name">The name of the log to generate a file path for.</param>
        /// <returns>A path at which the specified log can be saved.</returns>
        string GetFilePathForLogFile(string name);

        /// <summary>
        /// Should be called, if the user decides to view the associated control.
        /// </summary>
        void ShowClicked();

        /// <summary>
        /// Should be called, if the user decides to hide the associated control.
        /// </summary>
        void HideClicked();

        /// <summary>
        /// Should be called once the user has chosen a different application log
        /// as the currently active one.
        /// </summary>
        /// <param name="name">The name of the log selected.</param>
        void SelectedLogChanged(string name);
    }
}
