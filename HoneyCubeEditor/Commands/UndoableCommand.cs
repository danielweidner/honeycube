#region Using Statements

using System;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// An UndoableCommand allows to revert the action previously performed.
    /// </summary>
    public abstract class UndoableCommand : Command, IUndoableCommand
    {
        #region Properties

        /// <summary>
        /// Indicates whether the current command can be undone. Undo 
        /// operations are only possible if the command has been executed
        /// before and has not been undone yet.
        /// </summary>
        public bool IsUndoable
        {
            get { return IsExecuted && !IsUndone; }
        }

        /// <summary>
        /// Indicates whether the current command can be redone. A redo
        /// operation is only possible if the command has been undone
        /// previously.
        /// </summary>
        public bool IsRedoable
        {
            get { return IsUndone; }
        }

        /// <summary>
        /// Indicates whether the current command has been successfully
        /// undone.
        /// </summary>
        public bool IsUndone
        {
            get { return (State & CommandState.Undone) == CommandState.Undone; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new command that allows to
        /// undo the performed operation.
        /// </summary>
        public UndoableCommand()
            : this(string.Empty)
        {
            // Empty
        }

        /// <summary>
        /// Public constructor. Creates a new command that allows to
        /// undo the performed operation.
        /// </summary>
        /// <param name="text">A description for the current command.</param>
        public UndoableCommand(string text)
            : base(text)
        {
            // Empty
        }

        #endregion

        #region Command Members

        /// <summary>
        /// Executes the command and performs the associated action.
        /// </summary>
        public override void Execute()
        {
            // Skip execution for clones. As they should be only undo/redoable
            if (IsClone) return;

            // Try to execute the actual command
            try
            {
                if (OnExecute())
                {
                    State |= CommandState.Executed;
                }
            }
            catch (Exception e)
            {
                // Executed = false
                State &= ~CommandState.Executed;

                // Report the failure
                AppLog.Default.Add(
                    string.Format("The {0} command could not be executed. A {1} exception was catched.", GetType().Name, e.GetType().Name),
                    LogMessageType.Warning
                );
            }

            // Undone = false
            State &= ~CommandState.Undone;
        }

        #endregion

        #region IUndoableCommand Members

        /// <summary>
        /// Reverts the action performed by the current command.
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
            catch (Exception e)
            {
                // Report the failure
                AppLog.Default.Add(
                    string.Format("The {0} command could not be undone. A {1} exception was catched.", GetType().Name, e.GetType().Name),
                    LogMessageType.Warning
                );
            }

            // Undone = true
            State |= CommandState.Undone;
        }

        /// <summary>
        /// Is called every time an undo operation is requested. Allows 
        /// to run custom logic on inheriting classes without corrupting 
        /// the internal state of the command.
        /// </summary>
        protected abstract void OnUndo();

        /// <summary>
        /// Executes the command again after the command has been undone.
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
            catch (Exception e)
            {
                // Report the failure
                AppLog.Default.Add(
                    string.Format("The {0} command could not be redone. A {1} exception was catched.", GetType().Name, e.GetType().Name),
                    LogMessageType.Warning
                );
            }

            // Undone = false
            State &= ~CommandState.Undone;
        }

        /// <summary>
        /// Is called every time a redo operation is requested. Allows 
        /// to run custom logic on inheriting classes without corrupting 
        /// the internal state of the command.
        /// </summary>
        protected abstract void OnRedo();

        #endregion

        #region ICloneable

        /// <summary>
        /// Creates a shallow copy of the current command.
        /// </summary>
        /// <returns>A shallow copy or null if the command is not cloneable.</returns>
        public override object Clone()
        {
            // Only allow to clone already executed commands
            if (!IsExecuted)
                return null;

            // Create a shallow copy
            UndoableCommand clone = (UndoableCommand)MemberwiseClone();

            // Enable the flag: Cloned = true
            clone.State |= CommandState.Cloned;

            return clone;
        }

        #endregion
    }
}
