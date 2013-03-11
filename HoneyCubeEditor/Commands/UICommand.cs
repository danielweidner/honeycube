#region Using Statements

using System;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// TODO
    /// </summary>
    public abstract class UICommand : ICommand
    {
        #region Fields

        private CommandState _flags;
        private string _text;

        #endregion

        #region Properties

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsClone
        {
            get { return (_flags & CommandState.Cloned) == CommandState.Cloned; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsExecuted
        {
            get { return (_flags & CommandState.Executed) == CommandState.Executed; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// TODO
        /// </summary>
        public UICommand()
            :this(string.Empty)
        {
            // Empty
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="text"></param>
        public UICommand(string text)
        {
            _text = text;
            _flags = CommandState.Waiting;
        }

        #endregion

        #region ICommand

        /// <summary>
        /// TODO
        /// </summary>
        public void Execute()
        {
            // Try to execute the actual command
            try
            {
                if (OnExecute())
                {
                    _flags |= CommandState.Executed;
                }
            }
            catch (Exception)
            {
                // Executed = false
                _flags &= ~CommandState.Executed;

                // TODO: Report error to the console
            }
        }

        public abstract bool OnExecute();

        #endregion

        #region ICloneable

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            // Create a shallow copy
            UICommand clone = (UICommand)MemberwiseClone();

            // Enable the flag: Cloned = true
            clone._flags |= CommandState.Cloned;

            return clone;
        }

        #endregion
    }
}
