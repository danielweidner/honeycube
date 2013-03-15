#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;
using HoneyCube.Editor.Util;

#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// TODO
    /// </summary>
    public class AppLog
    {
        /// <summary>
        /// Enumeration of message types that can be added to the log.
        /// </summary>
        public enum MessageType
        {
            /// <summary>
            /// Used for all messages that are not flagged as a  warning or
            /// error.
            /// </summary>
            Default,

            /// <summary>
            /// Indicates that some logics reacted different from what we 
            /// expected.
            /// </summary>
            Warning,

            /// <summary>
            /// Indicates that something went terribly wrong and should be 
            /// fixed or reported to the developer.
            /// </summary>
            Error
        }

        #region Constants

        public const string NewLine = "\r\n";
        public const string Seperator = ": ";
        public const string WarningText = "[WARNING] ";
        public const string ErrorText = "[ERROR] ";
        
        #endregion

        #region Fields

        private static readonly Dictionary<string, AppLog> _logs = new Dictionary<string, AppLog>();

        private string _name;
        private StringBuilder _text = new StringBuilder();

        private bool _includeTimestamp = true;
        private int _limit = 20000;

        #endregion

        #region Properties

        /// <summary>
        /// TODO
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string Text
        {
            get 
            {
                lock (_text)
                {
                    return _text.ToString();
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public int Limit
        {
            get { return _limit; }
            set { _limit = value; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool IncludeTimestamp
        {
            get { return _includeTimestamp; }
            set { _includeTimestamp = value; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public event Action<AppLog> LogChanged;

        /// <summary>
        /// TODO
        /// </summary>
        public static event Action<AppLog> LogAdded;

        /// <summary>
        /// TODO
        /// </summary>
        public static event Action<AppLog> LogRemoved;

        #endregion

        #region Constructor

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        private AppLog(string name)
        {
            _name = name;
        }

        #endregion

        #region Static Members

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static AppLog For(string name)
        {
            return GetLog(name);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static AppLog GetLog(string name)
        {
            AppLog log = null;
            _logs.TryGetValue(name, out log);

            if (log == null)
            {
                log = new AppLog(name);
                _logs.Add(name, log);

                AppLog.OnLogAdded(log);
            }

            return log;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static AppLog RemoveLog(string name)
        {
            AppLog log = null;
            _logs.TryGetValue(name, out log);

            if (log != null)
            {
                _logs.Remove(name);

                AppLog.OnLogRemoved(log);
            }

            return log;
        }

        /// <summary>
        /// TODO
        /// </summary>
        public static void ClearAll()
        {
            foreach (KeyValuePair<string, AppLog> entry in _logs)
                entry.Value.Clear();
        }

        #endregion

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="message"></param>
        public void Add(string message)
        {
            Add(message, MessageType.Default);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public void Add(string message, MessageType type)
        {
            lock (_text)
            {
                if (_includeTimestamp)
                {
                    _text.Append(DateTime.Now.ToLocalTime());
                    _text.Append(Seperator);
                }

                switch (type)
                {
                    case MessageType.Warning:
                        _text.Append(WarningText);
                        break;
                    case MessageType.Error:
                        _text.Append(ErrorText);
                        break;
                }

                _text.Append(message);
                _text.Append(NewLine);                

                if (_text.Length > _limit)
                {
                    // Remove old entries to stay within the character limit
                    _text.Remove(0, _text.Length - _limit);

                    // Ensure that we have not fragmented some of the messages
                    int linebreakPos = _text.IndexOf(NewLine) + NewLine.Length;
                    if (linebreakPos > -1 && linebreakPos < _text.Length)
                        _text.Remove(0, linebreakPos);
                }
            }

            OnLogChanged();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="path"></param>
        public void LoadFrom(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    lock (_text)
                    {
                        using (StreamReader stream = File.OpenText(path))
                        {
                            _text.Clear();
                            _text.Append(stream.ReadToEnd());
                            stream.Close();
                        }
                    }
                }                
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException)
                    MessageBox.Show("Log file not found: " + path);

                if (e is DirectoryNotFoundException)
                    MessageBox.Show("The specified directory does not exist: " + path);

                _text.Clear();
            }

            OnLogChanged();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="path"></param>
        public void SaveTo(string path)
        {
            // Handle: Nothing to save
            if (_text.Length == 0)
                return;

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
                    stream.Write(_text.ToString());
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void Clear()
        {
            lock (_text)
            {
                _text.Clear();
            }

            OnLogChanged();
        }

        #region Event Handler

        /// <summary>
        /// TODO
        /// </summary>
        protected virtual void OnLogChanged()
        {
            if (LogChanged != null)
                LogChanged(this);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="log"></param>
        private static void OnLogAdded(AppLog log)
        {
            if (LogAdded != null)
                LogAdded(log);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="log"></param>
        private static void OnLogRemoved(AppLog log)
        {
            if (LogRemoved != null)
                LogRemoved(log);
        }

        #endregion
    }
}
