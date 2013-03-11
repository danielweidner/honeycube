#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// TODO
    /// </summary>
    public abstract class UndoableCommand : IUndoableCommand
    {
        #region Fields

        private CommandState _flags = CommandState.Waiting;
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
        public bool IsUndone
        {
            get { return (_flags & CommandState.Undone) == CommandState.Undone; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsUndoable
        {
            get { return IsExecuted && !IsUndone; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsRedoable
        {
            get { return IsUndone; }
        }

        /// <summary>
        /// A text value that can be displayed within the User Interface. Should
        /// describe the command adequatly in short.
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public event EventHandler StateChanged;

        #endregion

        #region Constructor

        /// <summary>
        /// TODO
        /// </summary>
        public UndoableCommand()
            : this(string.Empty)
        {
            // Empty
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="text"></param>
        public UndoableCommand(string text)
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
            // Skip execution for clones. As they should be only undo/redoable
            if (IsClone) return;

            // Remember the current state to check what has changed afterwards
            bool wasUndoable = IsUndoable;
            bool wasRedoable = IsRedoable;

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

            // Undone = false
            _flags &= ~CommandState.Undone;

            // Check whether the current command state has changed
            if (wasUndoable != IsUndoable || wasRedoable != IsUndoable)
            {
                OnStateChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        protected abstract bool OnExecute();

        #endregion

        #region IUndoableCommand

        /// <summary>
        /// TODO
        /// </summary>
        public void Undo()
        {
            // Ensure that we have anything to undo
            if (!IsUndoable) return;

            // Try to undo the current command
            try
            {
                OnUndo();
            }
            catch (Exception)
            {
                // TODO: Notify the application log
            }

            // Undone = true
            _flags |= CommandState.Undone;

            // Notify subscribers
            OnStateChanged(EventArgs.Empty);
        }

        /// <summary>
        /// TODO
        /// </summary>
        protected abstract void OnUndo();

        /// <summary>
        /// TODO
        /// </summary>
        public void Redo()
        {
            // Ensure that we have undone the current command
            if (!IsRedoable) return;

            // Try to perform the redo command
            try
            {
                OnRedo();
            }
            catch (Exception)
            {
                // TODO: Notify the application log
            }

            // Undone = false
            _flags &= ~CommandState.Undone;

            // Notify subscribers
            OnStateChanged(EventArgs.Empty);
        }

        /// <summary>
        /// TODO
        /// </summary>
        protected abstract void OnRedo();

        #endregion

        #region ICloneable

        /// <summary>
        /// Creates a shallow copy of the current command.
        /// </summary>
        /// <returns>A shallow copy or null.</returns>
        public virtual object Clone()
        {
            // Only allow to clone already executed commands
            if (!IsExecuted)
                return null;

            // Create a shallow copy
            UndoableCommand clone = (UndoableCommand)MemberwiseClone();

            // Enable the flag: Cloned = true
            clone._flags |= CommandState.Cloned;

            return clone;
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnStateChanged(EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, e);
        }

        #endregion
    }
}
