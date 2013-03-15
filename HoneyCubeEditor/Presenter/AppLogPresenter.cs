#region Using Statements

using System;
using System.Configuration;
using System.Windows.Forms;
using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// TODO
    /// </summary>
    public class AppLogPresenter : IAppLogPresenter
    {
        #region Fields

        private AppLog _activeLog;

        private IAppLogWindow _view;
        private SaveFileDialog _dialog;

        #endregion

        #region Properties

        /// <summary>
        /// TODO
        /// </summary>
        public IAppLogWindow View
        {
            get { return _view; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="view"></param>
        /// <param name="dialog"></param>
        public AppLogPresenter(IAppLogWindow view, SaveFileDialog dialog)
        {
            _view = view;
            _view.Presenter = this;
            _dialog = dialog;

            SetupView();
        }

        #endregion

        /// <summary>
        /// TODO
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

            // Allow to dynamically add new logs
            AppLog.LogAdded += new Action<AppLog>(AppLog_LogAdded);
            AppLog.LogRemoved += new Action<AppLog>(AppLog_LogRemoved);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public bool ShowControl()
        {
            _view.ShowControl();
            UpdateControl();
            return true;
        }

        /// <summary>
        /// TODO
        /// </summary>
        private void UpdateControl()
        {
            if (_view.Visible && _activeLog != null)
            {
                _view.UpdateLog(_activeLog.Name, _activeLog.Text);
                _view.ColorizeOutput(null, null);
                _view.ScrollToEnd();
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void HideControl()
        {
            _view.HideControl();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        public void SelectionChanged(string name)
        {
            _activeLog = AppLog.GetLog(name);
            _view.SelectLog(name);
            UpdateControl();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        public void SaveLog(string name, string path)
        {
            AppLog log = AppLog.GetLog(name);
            log.SaveTo(path);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        public void ClearLog(string name)
        {
            AppLog log = AppLog.GetLog(name);
            log.Clear();
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void ClearAllLogs()
        {
            AppLog.ClearAll();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public string SelectFilePath()
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
        /// TODO
        /// </summary>
        /// <param name="log"></param>
        private void AppLog_LogAdded(AppLog log)
        {
            log.LogChanged += AppLog_LogChanged;

            _view.IncludeLog(log.Name);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="log"></param>
        private void AppLog_LogChanged(AppLog log)
        {
            if (_activeLog != null && _activeLog.Name == log.Name)
                UpdateControl();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="log"></param>
        private void AppLog_LogRemoved(AppLog log)
        {
            log.LogChanged -= AppLog_LogChanged;

            _view.HideLog(log.Name);
        }

        #endregion        
    }

    // Convert the general ShortDateTime format to a regular expression
    //string ds = Regex.Escape(DateTimeFormatInfo.CurrentInfo.DateSeparator);
    //string ts = Regex.Escape(DateTimeFormatInfo.CurrentInfo.TimeSeparator);
    //string date = @"\d{2,2}" + ds + @"\d{2,2}" + ds + @"\d{4,4}\s{1}\d{2,2}" + ts + @"\d{2,2}" + ts + @"\d{2,2}";
            
    //// Convert the warning and error labels to regular expression
    //string warning = Regex.Escape(AppLog.WarningText);
    //string error = Regex.Escape(AppLog.ErrorText);

    //// Colorize date, warning messages and error messages by default
    //_regex = new Regex("(" + date + ")|(" + warning + ")|(" + error +  ")");

    ///// <summary>
    ///// The color used to highlight the timestamp of a log message.
    ///// </summary>
    //public static Color TimeColor = Color.Gray;

    ///// <summary>
    ///// The color used to highlight a warning message.
    ///// </summary>
    //public static Color WarningColor = Color.FromArgb(255, 220, 0);

    ///// <summary>
    ///// The color used to highlight an error message.
    ///// </summary>
    //public static Color ErrorColor = Color.FromArgb(255, 60, 60);
}
