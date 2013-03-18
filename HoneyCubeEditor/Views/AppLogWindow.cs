#region Using Statements

using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// The AppLogWindow is a form that displays the currently selected 
    /// application log in a RichTextBox and allows to highlight 
    /// certain keywords.
    /// </summary>
    public partial class AppLogWindow : Form, IAppLogWindow, ILocalizable
    {
        #region Properties

        /// <summary>
        /// The presenter controlling the behavior of the log form.
        /// </summary>
        public IAppLogPresenter Presenter
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new form that collects all log
        /// messages and displays them in one place.
        /// </summary>
        public AppLogWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region ILocalizable Members

        /// <summary>
        /// Localizes the application log window and all components attached to it.
        /// </summary>
        public void LocalizeComponent()
        {
            L10n.AssignIcon(this, "HoneyCube");
            L10n.AssignIcon(ClearLogs, "ClearContent");
            L10n.AssignIcon(AlwaysOnTop, "Pin");
            L10n.AssignIcon(SaveCurrentLog, "SaveFileDialog");
            L10n.LocalizeControl(this, "AppLog");
        }

        #endregion

        #region IAppLogWindow Members

        /// <summary>
        /// Opens the current form and makes it visible to the user.
        /// </summary>
        public void ShowControl()
        {
            Show();
        }

        /// <summary>
        /// Hides the current form from the user.
        /// </summary>
        public void HideControl()
        {
            Hide();
        }

        /// <summary>
        /// Includes the specified application log in the view. Will add an entry 
        /// to the DropDown list so the user can easily switch between the 
        /// different kinds of logs.
        /// </summary>
        /// <param name="name">The application log to include.</param>
        public void IncludeLog(string name)
        {
            AddToDropDown(name);
        }

        /// <summary>
        /// Selects the currently active application log.
        /// </summary>
        /// <param name="name">The name of the log to display.</param>
        public void SelectLog(string name)
        {
            // Add log to the drop down menu, if not already done
            AddToDropDown(name);

            // Select the given log if not already active
            if (!IsSelected(name))
                SelectDropDownItem(name);
        }

        /// <summary>
        /// Displays the text of the currently active application log in the
        /// associated textbox.
        /// </summary>
        /// <param name="name">The name of the application log to update.</param>
        /// <param name="text">The text of the application log to display.</param>
        public void UpdateLog(string name, string text)
        {
            if (IsSelected(name))
            {
                // Reset the selection
                CurrentLog.SelectionStart = 0;
                CurrentLog.SelectionLength = 1;
                CurrentLog.SelectionColor = DefaultForeColor;

                // Update the textbox
                CurrentLog.Text = text;
            }
        }

        /// <summary>
        /// Removes an application log from the DropDown list.
        /// </summary>
        /// <param name="name">The log to remove.</param>
        public void HideLog(string name)
        {
            RemoveFromDropDown(name);

            if (IsSelected(name))
                SelectDropDownItem(0);
        }

        /// <summary>
        /// Forces the current view to colorize the generated output.
        /// </summary>
        /// <param name="regex">The regular expression used to extract the elements that should be colorized.</param>
        /// <param name="colors">A color for each group.</param>
        public void ColorizeOutput(Regex regex, Color[] colors)
        {
            if (colors != null && colors.Length > 0)
            {
                foreach (Match match in regex.Matches(CurrentLog.Text))
                {
                    if (match.Success)
                    {
                        // Determine the group number. We have to skip the first 
                        // group as it matches the entire pattern.
                        int groupNumber = 0;
                        int totalGroups = match.Groups.Count;
                        while (groupNumber + 1 < totalGroups && match.Groups[groupNumber + 1].Value == string.Empty)
                            groupNumber++;
                        
                        // Pick the adequat color and highlight the selected text
                        CurrentLog.SelectionStart = match.Index;
                        CurrentLog.SelectionLength = match.Length;
                        CurrentLog.SelectionColor = groupNumber < colors.Length ? colors[groupNumber] : Color.Black;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the scroll position for the current log.
        /// </summary>
        /// <param name="line">The line to scroll to.</param>
        public void SetScrollPosition(int line)
        {
            CurrentLog.SelectionStart = CurrentLog.GetFirstCharIndexFromLine(line);
            CurrentLog.ScrollToCaret();
        }

        /// <summary>
        /// Forces the control element to scroll to the top of the rendered log messages.
        /// </summary>
        public void ScrollToTop()
        {
            CurrentLog.SelectionStart = 0;
            CurrentLog.ScrollToCaret();
        }

        /// <summary>
        /// Forces the control element to scroll to the bottom of the rendered log messages.
        /// </summary>
        public void ScrollToEnd()
        {
            CurrentLog.SelectionStart = CurrentLog.Text.Length;
            CurrentLog.ScrollToCaret();
        }

        #endregion

        #region Drop Down Manipulation

        /// <summary>
        /// Adds a new entry to the dropdown list displaying all available application logs.
        /// </summary>
        /// <param name="name">The name of the log to add to the list.</param>
        protected void AddToDropDown(string name)
        {
            if (!DropDownContains(name))
                LogDropDown.Items.Add(name);
        }

        /// <summary>
        /// Checks whether the given value is currently selected in the drop down menu.
        /// </summary>
        /// <param name="name">The value to check for.</param>
        /// <returns>True if the value is selected.</returns>
        protected bool IsSelected(string name)
        {
            return LogDropDown.SelectedItem != null
                && LogDropDown.SelectedItem.ToString() == name;
        }

        /// <summary>
        /// Makes the given value the currently selected one.
        /// </summary>
        /// <param name="item">The entry to select.</param>
        protected void SelectDropDownItem(string item)
        {
            LogDropDown.SelectedItem = item;
        }

        /// <summary>
        /// Selects a drop down entry by its index position.
        /// </summary>
        /// <param name="index">The index of the entry to select.</param>
        protected void SelectDropDownItem(int index)
        {
            int numItems = LogDropDown.Items.Count;
            index = Math.Max(index, 0);
            LogDropDown.SelectedItem = numItems > 0 ? LogDropDown.Items[Math.Min(index, numItems - 1)] : "";
        }

        /// <summary>
        /// Checks whether the drop down menu already contains a similar value.
        /// </summary>
        /// <param name="name">The value to check for.</param>
        /// <returns>True if the drop down list contains already the same value.</returns>
        protected bool DropDownContains(string name)
        {
            return LogDropDown.FindStringExact(name) > -1;
        }

        /// <summary>
        /// Removes an entry from the drop down menu with the given value.
        /// </summary>
        /// <param name="name">The value to remove from the drop down menu.</param>
        protected void RemoveFromDropDown(string name)
        {
            LogDropDown.Items.Remove(name);
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Is called every time a the user clicked on the save-log button.
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">Empty event argument.</param>
        private void SaveCurrentLog_Click(object sender, EventArgs e)
        {
            if (Presenter != null && LogDropDown.SelectedItem != null)
            {
                string current = LogDropDown.SelectedItem.ToString();
                string path = Presenter.GetFilePathForLogFile(current);

                if (!string.IsNullOrEmpty(path))
                    Presenter.SaveLog(current, path);
            }
        }

        /// <summary>
        /// Is called every time a the user clicked on the clear-log button.
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">Empty event argument.</param>
        private void ClearCurrentLog_Click(object sender, EventArgs e)
        {
            if (Presenter != null && LogDropDown.SelectedItem != null)
            {
                string current = LogDropDown.SelectedItem.ToString();
                Presenter.ClearLog(current);
            }
        }

        /// <summary>
        /// Is called every time a the user clicked on the clear-all-logs button.
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">Empty event argument.</param>
        private void ClearAllLogs_Click(object sender, EventArgs e)
        {
            if (Presenter != null)
                Presenter.ClearAllLogs();
        }

        /// <summary>
        /// Is called when the user clicked on the show-window-on-top button.
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">Empty event argument.</param>
        private void AlwaysOnTop_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        /// <summary>
        /// Is called once the currently selected value of the drop down menu 
        /// changes.
        /// </summary>
        /// <param name="sender">The drop down menu that has changed.</param>
        /// <param name="e">Empty event argument.</param>
        private void LogDropDown_SelectedChanged(object sender, EventArgs e)
        {
            if (Presenter != null && LogDropDown.SelectedItem != null)
            {
                string current = LogDropDown.SelectedItem.ToString();
                Presenter.SelectedLogChanged(current);
            }
        }

        /// <summary>
        /// Is called when the user has clicked the close button of the form.
        /// </summary>
        /// <param name="sender">The form closed.</param>
        /// <param name="e">Some additional form closing event arguments.</param>
        private void AppLogWindow_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        #endregion
    }
}
