#region Using Statements

using System;
using System.Configuration;
using System.Windows.Forms;
using HoneyCube.Editor.Views;
using System.Text.RegularExpressions;
using System.Drawing;
using HoneyCube.Editor.Events;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// The AppLogPresenter controls the overall behavior of the AppLogWindow.
    /// An instance queries for all available logs and passes their messages 
    /// to the associated control.
    /// </summary>
    public class AppLogPresenter : IAppLogPresenter
    {
        #region Fields

        public static Regex ColorizePattern;
        public static Color[] ColorPalette;

        private AppLog _activeLog;

        private IAppHub _hub;
        private IAppLogWindow _view;
        private SaveFileDialog _dialog;

        #endregion

        #region Properties

        /// <summary>
        /// The view holding the controls used to display created application
        /// logs.
        /// </summary>
        public IAppLogWindow View
        {
            get { return _view; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Static constructor. Generates the pattern used to colorize particular
        /// strings of the output text.
        /// </summary>
        static AppLogPresenter()
        {
            // Generate the pattern
            // TODO: Not very flexible, would break once the used date format 
            // would change
            string date = @"(\d{2,2}\.\d{2,2}\.\d{4,4}\s{1}\d{2,2}:\d{2,2}:\d{2,2})";
            string warning = "(" + Regex.Escape(AppLog.WarningText) + ")";
            string error = "(" + Regex.Escape(AppLog.ErrorText) + ")";
            ColorizePattern = new Regex(date + "|" + warning + "|" + error);

            // Select a color for each group
            ColorPalette = new Color[] {
                Color.Gray,
                Color.FromArgb(255, 220, 0),
                Color.FromArgb(255, 60, 60)
            };
        }

        /// <summary>
        /// Public constructor. Creates a new AppLogPresenter which maintains
        /// available application logs and prepares them for display.
        /// </summary>
        /// <param name="hub">The application hub providing elemental functionality.</param>
        /// <param name="view">The associated view.</param>
        /// <param name="dialog">A SaveFileDialog used to select a valid path for log files.</param>
        public AppLogPresenter(IAppHub hub, IAppLogWindow view, SaveFileDialog dialog)
        {
            _hub = hub;
            _view = view;
            _view.Presenter = this;
            _dialog = dialog;

            SetupView();
        }

        #endregion

        /// <summary>
        /// Registers the presenter for log events and tell the view what 
        /// to display.
        /// </summary>
        private void SetupView()
        {
            // Retrieve the list of default logs to create
            string[] logs = ConfigurationManager.AppSettings["logs"].Split(';');

            if (logs.Length > 0)
            {
                // Create a control representation for each log
                foreach (string name in logs)
                {
                    AppLog log = AppLog.GetLog(name);
                    log.LogChanged += new Action<AppLog>(AppLog_LogChanged);
                    _view.IncludeLog(name);
                }

                // Select first log in list by default
                _view.SelectLog(logs[0]);
            }

            // Allow to dynamically add new logs and show them in the GUI
            AppLog.LogAdded += new Action<AppLog>(AppLog_LogAdded);
            AppLog.LogRemoved += new Action<AppLog>(AppLog_LogRemoved);
        }

        /// <summary>
        /// Updates the associated view.
        /// </summary>
        private void UpdateView()
        {
            if (_view.Visible && _activeLog != null)
            {
                _view.UpdateLog(_activeLog.Name, _activeLog.Text);
                _view.ColorizeOutput(ColorizePattern, ColorPalette);
                _view.ScrollToEnd();
            }
        }

        /// <summary>
        /// Should be called, if the user decides to view the associated control.
        /// </summary>
        public void ShowClicked()
        {
            _view.ShowControl();
            _hub.Raise<AppLogActiveEvent>(new AppLogActiveEvent());
            UpdateView();
        }

        /// <summary>
        /// Should be called, if the user decides to hide the associated control.
        /// </summary>
        public void HideClicked()
        {
            _view.HideControl();
            _hub.Raise<AppLogClosingEvent>(new AppLogClosingEvent());
        }

        /// <summary>
        /// Should be called once the user has chosen a different application log
        /// as the currently active one.
        /// </summary>
        /// <param name="name">The name of the log selected.</param>
        public void SelectedLogChanged(string name)
        {
            _activeLog = AppLog.GetLog(name);
            _view.SelectLog(name);
            UpdateView();
        }

        /// <summary>
        /// Saves the specified log to a text file at the given path.
        /// </summary>
        /// <param name="name">The name of the log to save.</param>
        /// <param name="path">The path to save the log file to.</param>
        public void SaveLog(string name, string path)
        {
            AppLog.For(name).SaveTo(path);
        }

        /// <summary>
        /// Clears the specified application log.
        /// </summary>
        /// <param name="name">The name of the log to clear.</param>
        public void ClearLog(string name)
        {
            AppLog.For(name).Clear();
        }

        /// <summary>
        /// Clears all created application logs.
        /// </summary>
        public void ClearAllLogs()
        {
            AppLog.ClearAll();
        }

        /// <summary>
        /// Opens a new dialog which allows the user to select a valid file path.
        /// </summary>
        /// <param name="name">The name of the log to generate a file path for.</param>
        /// <returns>A path at which the specified log can be saved.</returns>
        public string GetFilePathForLogFile(string name)
        {
            _dialog.RestoreDirectory = true;
            _dialog.Title = "Select a Folder and File Name for the Logfile";
            _dialog.DefaultExt = "log";
            _dialog.Filter = "log files (*.log)|*.log|All files (*.*)|*.*";
            _dialog.CheckPathExists = true;

            if (_dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = _dialog.FileName;
                _dialog.Reset();
                return filename;
            }

            return string.Empty;
        }

        #region Event Handlers

        /// <summary>
        /// Is called when a new application log is created.
        /// </summary>
        /// <param name="log">The new application log.</param>
        private void AppLog_LogAdded(AppLog log)
        {
            log.LogChanged += AppLog_LogChanged;

            _view.IncludeLog(log.Name);
        }

        /// <summary>
        /// Is called when one of the observed application log has received 
        /// new messages.
        /// </summary>
        /// <param name="log">The log that has changed</param>
        private void AppLog_LogChanged(AppLog log)
        {
            if (_activeLog != null && _activeLog.Name == log.Name)
                UpdateView();
        }

        /// <summary>
        /// Is called when one of the observed application logs has been
        /// removed.
        /// </summary>
        /// <param name="log">The log to remove/delete.</param>
        private void AppLog_LogRemoved(AppLog log)
        {
            log.LogChanged -= AppLog_LogChanged;

            _view.HideLog(log.Name);
        }

        #endregion        
    }
}
