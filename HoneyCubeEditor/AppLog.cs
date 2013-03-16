#region Using Statements

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Forms;
using HoneyCube.Editor.Util;


#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// Enumeration of message types that can be added to the log.
    /// </summary>
    public enum LogMessageType
    {
        /// <summary>
        /// Used for all messages that are not flagged as a  warning or error.
        /// </summary>
        Default,

        /// <summary>
        /// Indicates that some logics reacted different from what we expected.
        /// </summary>
        Warning,

        /// <summary>
        /// Indicates that something went terribly wrong and should be fixed 
        /// or reported to the developer.
        /// </summary>
        Error
    }

    /// <summary>
    /// An application log bundles a series of log messages. A log message could
    /// basically be everything, an error, an action peformed or just some state
    /// information. Feel free to log what every you want.
    /// </summary>
    public class AppLog
    {
        #region Constants
        
        /// <summary>
        /// A text added to the log if a warning is created.
        /// </summary>
        public const string WarningText = "[WARNING] ";

        /// <summary>
        /// A text added to the log if an error is reported.
        /// </summary>
        public const string ErrorText = "[ERROR] ";
        
        #endregion

        #region Fields

        private string _name;
        private bool _isDirty = false;
        private string _cache = string.Empty;
        private StringBuilder _text = new StringBuilder();

        private bool _includeTimestamp = true;
        private int _limit = 20000;

        #endregion

        #region Properties

        /// <summary>
        /// The name of the current application log. Should be descriptive e.g.
        /// similar to a category name.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Contains all messages added to the current log instance.
        /// </summary>
        public string Text
        {
            get 
            {
                lock (_text)
                {
                    if (_isDirty)
                    {
                        _cache = _text.ToString();
                        _isDirty = false;
                    }
                }

                return _cache;
            }
        }

        /// <summary>
        /// The maximum number of characters to keep in the application log.
        /// </summary>
        public int Limit
        {
            get { return _limit; }
            set { _limit = value; }
        }

        /// <summary>
        /// Determines whether to include a formated timestamp in the log. Will
        /// use the general short time format DD.MM.YYYY HH:MM:SS.
        /// </summary>
        public bool IncludeTimestamp
        {
            get { return _includeTimestamp; }
            set { _includeTimestamp = value; }
        }

        /// <summary>
        /// Is raised when new log messages are added to the current log 
        /// instance.
        /// </summary>
        public event Action<AppLog> LogChanged;

        /// <summary>
        /// Is raised when a new application log is created.
        /// </summary>
        public static event Action<AppLog> LogAdded;

        /// <summary>
        /// Is raised when an existing application log is removed.
        /// </summary>
        public static event Action<AppLog> LogRemoved;

        #endregion

        #region Constructors

        /// <summary>
        /// Static constructor. Reads the name of the default log from the application 
        /// settings and assigns it to a static property.
        /// </summary>
        static AppLog()
        {
            string setting = ConfigurationManager.AppSettings["logs"];
            string defaultLog = "General";

            // Take the first log name from the settings as the default
            if (!string.IsNullOrWhiteSpace(setting))
            {
                string[] logs = setting.Split(';');
                defaultLog = logs != null && logs.Length > 0 ? logs[0] : "General";
            }

            // Use the default value, or the first value retrieved from the settings
            Default = GetLog(defaultLog);
        }

        /// <summary>
        /// Private constructor. Creates a new named application log. To create a new
        /// log use AppLog.GetLog(name) or the alias method AppLog.For(name)
        /// </summary>
        /// <param name="name">The name of the current log instance.</param>
        private AppLog(string name)
        {
            _name = name;
        }

        #endregion

        #region Static Members

        /// <summary>
        /// A collection holding all available application logs.
        /// </summary>
        public static readonly IDictionary<string, AppLog> Logs = new Dictionary<string, AppLog>();

        /// <summary>
        /// The default application log that holds mostly general log messages.
        /// </summary>
        public static readonly AppLog Default;  

        /// <summary>
        /// An alias for GetLog(name).
        /// </summary>
        /// <param name="name">The name of the log to retrieve.</param>
        /// <returns>The log instance with the given name.</returns>
        public static AppLog For(string name)
        {
            return GetLog(name);
        }

        /// <summary>
        /// Returns the application log with the given name. Creates a new
        /// log instance, if it does not exist yet.
        /// </summary>
        /// <param name="name">The name of the log to retrieve/create.</param>
        /// <returns>A log instance with the given name.</returns>
        public static AppLog GetLog(string name)
        {
            AppLog log = null;
            Logs.TryGetValue(name, out log);

            if (log == null)
            {
                log = new AppLog(name);
                Logs.Add(name, log);

                AppLog.OnLogAdded(log);
            }

            return log;
        }

        /// <summary>
        /// Removes the specified log.
        /// </summary>
        /// <param name="name">The log to remove.</param>
        /// <returns>Returns the removed log instance. Null if no log with the given name exists.</returns>
        public static AppLog RemoveLog(string name)
        {
            AppLog log = null;
            Logs.TryGetValue(name, out log);

            if (log != null)
            {
                Logs.Remove(name);

                AppLog.OnLogRemoved(log);
            }

            return log;
        }

        /// <summary>
        /// Combines all available logs into a single log file.
        /// </summary>
        public static void DumpAll()
        {
            string file = Application.UserAppDataPath + "\\log\\app.log";

            if (File.Exists(file))
                File.Delete(file);

            if (!Directory.Exists(Application.UserAppDataPath + "\\log\\"))
                Directory.CreateDirectory(Application.UserAppDataPath);

            string seperator = string.Empty;
            for (int i = 0, l = 80; i < l; i++)
                seperator += "-";

            using (StreamWriter stream = new StreamWriter(file))
            {
                foreach (KeyValuePair<string, AppLog> entry in Logs)
                {
                    stream.WriteLine(entry.Key + " " + seperator.Substring(0, 80 - entry.Key.Length));
                    stream.Write(Environment.NewLine);
                    stream.Write(entry.Value.Text);
                }
                stream.Close();
            }
        }

        /// <summary>
        /// Clears all instantiated application logs.
        /// </summary>
        public static void ClearAll()
        {
            foreach (KeyValuePair<string, AppLog> entry in Logs)
                entry.Value.Clear();
        }

        #endregion

        /// <summary>
        /// Adds a new message to the current log instance.
        /// </summary>
        /// <param name="message">The message to add.</param>
        public void Add(string message)
        {
            Add(message, LogMessageType.Default);
        }

        /// <summary>
        /// Adds a new message to the current log instance.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="type">The type of message to add.</param>
        public void Add(string message, LogMessageType type)
        {
            lock (_text)
            {
                if (_includeTimestamp)
                {
                    _text.Append(DateTime.Now.ToLocalTime());
                    _text.Append(": ");
                }

                switch (type)
                {
                    case LogMessageType.Warning:
                        _text.Append(WarningText);
                        break;
                    case LogMessageType.Error:
                        _text.Append(ErrorText);
                        break;
                }

                _text.Append(message);
                _text.Append(Environment.NewLine);                

                if (_text.Length > _limit)
                {
                    // Remove old entries to stay within the character limit
                    _text.Remove(0, _text.Length - _limit);

                    // Ensure that we have not fragmented some of the messages
                    int linebreakPos = _text.IndexOf(Environment.NewLine) + Environment.NewLine.Length;
                    if (linebreakPos > -1 && linebreakPos < _text.Length)
                        _text.Remove(0, linebreakPos);
                }

                _isDirty = true;
            }

            OnLogChanged();
        }

        /// <summary>
        /// Loads the message log contents of the current instance from a file.
        /// </summary>
        /// <param name="path">The path to the file to load.</param>
        public void LoadFrom(string path)
        {
            if (File.Exists(path))
            {
                lock (_text)
                {
                    using (StreamReader stream = File.OpenText(path))
                    {
                        _text.Clear();
                        _text.Append(stream.ReadToEnd());
                        _isDirty = true;
                        stream.Close();
                    }
                }
            }

            OnLogChanged();
        }

        /// <summary>
        /// Saves the contents of the current application log to a file.
        /// </summary>
        /// <param name="path">The file path of the file to create.</param>
        public void SaveTo(string path)
        {
            // Remove old log files
            if (File.Exists(path))
                File.Delete(path);

            // Ensure that the directory exists
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            lock (_text)
            {
                using (StreamWriter stream = new StreamWriter(path))
                {
                    stream.Write(Text);
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// Clears the current message log instance.
        /// </summary>
        public void Clear()
        {
            lock (_text)
            {
                _text.Clear();
                _isDirty = true;
            }

            OnLogChanged();
        }

        #region Event Handler

        /// <summary>
        /// Is called every time a new message is added to the current log
        /// instance.
        /// </summary>
        protected virtual void OnLogChanged()
        {
            if (LogChanged != null)
                LogChanged(this);
        }

        /// <summary>
        /// Is called every time a new log is created.
        /// </summary>
        /// <param name="log">The log created.</param>
        private static void OnLogAdded(AppLog log)
        {
            if (LogAdded != null)
                LogAdded(log);
        }

        /// <summary>
        /// Is called every time a log is removed from the collection.
        /// </summary>
        /// <param name="log">The log removed.</param>
        private static void OnLogRemoved(AppLog log)
        {
            if (LogRemoved != null)
                LogRemoved(log);
        }

        #endregion
    }
}
