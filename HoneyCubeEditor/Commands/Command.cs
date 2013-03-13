#region Using Statements

using System;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// A simple implementation of the ICommand interface. Allows inheriting 
    /// classes to run any logic on command execution without worrying about
    /// state management.
    /// </summary>
    public abstract class Command : ICommand
    {
        #region Fields

        private CommandState _state;
        private string _text;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether the current command has been executed.
        /// </summary>
        public bool IsExecuted
        {
            get { return (_state & CommandState.Executed) == CommandState.Executed; }
        }

        /// <summary>
        /// Indicates whether the current command is a clone of a previously 
        /// executed command.
        /// </summary>
        public bool IsClone
        {
            get { return (_state & CommandState.Cloned) == CommandState.Cloned; }
        }

        /// <summary>
        /// A flag describing the current state of the command.
        /// </summary>
        public CommandState State
        {
            get { return _state; }
            protected set { _state = value; }
        }

        /// <summary>
        ///  A text describing the current command. Could be displayed in 
        /// associated UI Elements.
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Public constructor. Creates a new command with no text 
        /// description.
        /// </summary>
        public Command()
            :this(string.Empty)
        {
            // Empty
        }

        /// <summary>
        /// Public constructor. Creates a new command.
        /// </summary>
        /// <param name="text">A description for the current command.</param>
        public Command(string text)
        {
            _text = text;
            _state = CommandState.Waiting;
        }

        #endregion

        #region ICommand Members

        /// <summary>
        /// Executes the command and performs the associated action.
        /// </summary>
        public virtual void Execute()
        {
            // Try to execute the actual command
            try
            {
                if (OnExecute())
                {
                    State |= CommandState.Executed;
                }
            }
            catch (Exception)
            {
                // Executed = false
                State &= ~CommandState.Executed;

                // TODO: Report error to the application console/log
            }
        }

        /// <summary>
        /// Is called every time the command is executed. Allows to implement
        /// custom behavior on inheriting classes and leaves state management 
        /// to the base class.
        /// </summary>
        /// <returns>Should return true if executed successfully. Otherwise false.</returns>
        protected abstract bool OnExecute();

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Creates a shallow copy of the current command.
        /// </summary>
        /// <returns>A copy of the current command.</returns>
        public virtual object Clone()
        {
            // Create a shallow copy
            Command clone = (Command)MemberwiseClone();

            // Enable the flag: Cloned = true
            clone.State |= CommandState.Cloned;

            return clone;
        }

        #endregion
    }
}
