#region Using Statements 

using System.Drawing;
using System.Text.RegularExpressions;
using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// Describes an interface for a control element that allows to display 
    /// multiple application logs to the user.
    /// </summary>
    public interface IAppLogWindow : IView<IAppLogPresenter>
    {
        /// <summary>
        /// Indicates whether the control is currently visible.
        /// </summary>
        bool Visible
        {
            get;
        }

        /// <summary>
        /// Shows the control element (e.g. in case it is hidden).
        /// </summary>
        void ShowControl();

        /// <summary>
        /// Hide the control element from the user.
        /// </summary>
        void HideControl();

        /// <summary>
        /// Includes the specified application log in the control.
        /// </summary>
        /// <param name="name">The application log to include.</param>
        void IncludeLog(string name);

        /// <summary>
        /// Selects the currently active application log.
        /// </summary>
        /// <param name="name">The name of the log to display.</param>
        void SelectLog(string name);

        /// <summary>
        /// Updates the representation of the specified application log.
        /// </summary>
        /// <param name="name">The name of the application log to update.</param>
        /// <param name="text">The text of the application log to display.</param>
        void UpdateLog(string name, string text);

        /// <summary>
        /// Hides a certain application log from the control.
        /// </summary>
        /// <param name="name">The log to hide.</param>
        void HideLog(string name);

        /// <summary>
        /// Forces the control element to colorize the generated output.
        /// </summary>
        /// <param name="regex"></param>
        /// <param name="colors"></param>
        void ColorizeOutput(Regex regex, Color[] colors);

        /// <summary>
        /// Sets the scroll position for the current log.
        /// </summary>
        /// <param name="line">The line to scroll to.</param>
        void SetScrollPosition(int line);

        /// <summary>
        /// Forces the control element to scroll to the top of the rendered log messages.
        /// </summary>
        void ScrollToTop();

        /// <summary>
        /// Forces the control element to scroll to the bottom of the rendered log messages.
        /// </summary>
        void ScrollToEnd();
    }
}
