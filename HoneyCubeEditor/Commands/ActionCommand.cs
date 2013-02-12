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
    public class ActionCommand : UndoableCommand
    {
        #region Fields

        private Func<bool> _executeAction;
        private Action _undoAction;
        private Action _redoAction;

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new command delegating the actual 
        /// action to an external function.
        /// </summary>
        /// <param name="action">The funnction to call when the command is executed.</param>
        public ActionCommand(Func<bool> action)
        {
            _executeAction = action;
            _undoAction = null;
            _redoAction = null;
        }

        /// <summary>
        /// Public constructor. Creates a new command delegating the actual 
        /// action to an external function.
        /// </summary>
        /// <param name="execute">The funnction to call when the command is executed.</param>
        /// <param name="undo">The funnction to call when the action of the command should be reverted.</param>
        public ActionCommand(Func<bool> execute, Action undo)
        {
            _executeAction = execute;
            _undoAction = undo;
            _redoAction = null;
        }

        /// <summary>
        /// Public constructor. Creates a new command delegating the actual 
        /// action to an external function.
        /// </summary>
        /// /// <param name="execute">The funnction to call when the command is executed.</param>
        /// <param name="undo">The funnction to call when the action of the command should be reverted.</param>
        /// <param name="redo">The function to call when the command should be executed again, after an undo operation.</param>
        public ActionCommand(Func<bool> execute, Action undo, Action redo)
        {
            _executeAction = execute;
            _undoAction = undo;
            _redoAction = redo;
        }

        #endregion

        #region Command Members

        /// <summary>
        /// Executes the command and calls the associated delegate function.
        /// </summary>
        protected override bool OnExecute()
        {
            if (_executeAction != null)
                return _executeAction();

            return false;
        }

        /// <summary>
        /// Should revert the action performed by the current command. Will
        /// do nothing if no function is passed on construction.
        /// </summary>
        protected override void OnUndo()
        {
            if (_undoAction != null)
                _undoAction();
        }

        /// <summary>
        /// Executes the command again after an undo operation.
        /// </summary>
        protected override void OnRedo()
        {
            if (_redoAction != null)
                _redoAction();
            else if (_executeAction != null)
                _executeAction();
        }

        #endregion
    }
}
