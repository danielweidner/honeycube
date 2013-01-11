#region Using Statements

using System;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// The ActionCommand class offers a possibility to create a unique command
    /// without the need to implement the overal logic within a seperate class.
    /// Therefore the class offers a parameterless delegate to hook up the 
    /// relevant functions.
    /// </summary>
    public class ActionCommand : ICommand
    {
        #region Fields

        private Action _executeAction;
        private Action _undoAction;
        private Action _redoAction;

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new command delegating the actual 
        /// action to an external function.
        /// </summary>
        /// <param name="action">The funnction to call when the command is executed.</param>
        public ActionCommand(Action action)
        {
            _executeAction = action;
            _undoAction = null;
            _redoAction = action;
        }

        /// <summary>
        /// Public constructor. Creates a new command delegating the actual 
        /// action to an external function.
        /// </summary>
        /// <param name="execute">The funnction to call when the command is executed.</param>
        /// <param name="undo">The funnction to call when the action of the command should be reverted.</param>
        public ActionCommand(Action execute, Action undo)
        {
            _executeAction = execute;
            _undoAction = undo;
            _redoAction = execute;
        }

        /// <summary>
        /// Public constructor. Creates a new command delegating the actual 
        /// action to an external function.
        /// </summary>
        /// /// <param name="execute">The funnction to call when the command is executed.</param>
        /// <param name="undo">The funnction to call when the action of the command should be reverted.</param>
        /// <param name="redo">The function to call when the command should be executed again, after an undo operation.</param>
        public ActionCommand(Action execute, Action undo, Action redo)
        {
            _executeAction = execute;
            _undoAction = undo;
            _redoAction = redo;
        }

        #endregion

        #region ICommand

        /// <summary>
        /// Executes the command and calls the associated delegate function.
        /// </summary>
        public void Execute()
        {
            if (_executeAction != null)
                _executeAction();
        }

        /// <summary>
        /// Should revert the action performed by the current command. Will
        /// do nothing if no function is passed on construction.
        /// </summary>
        public void Undo()
        {
            if (_undoAction != null)
                _undoAction();
        }

        /// <summary>
        /// Executes the command again after an undo operation.
        /// </summary>
        public void Redo()
        {
            if (_redoAction != null)
                _redoAction();
        }

        #endregion

        #region ICloneable

        /// <summary>
        /// Creates a shallow copy of the command.
        /// </summary>
        /// <returns>A shallow copy of the command.</returns>
        public virtual object Clone()
        {
            return new ActionCommand(_executeAction);
        }

        #endregion
    }
}
