#region Using Statements

using System.Collections.Generic;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// A simple implementation of a CommandHistory. Allows to log a sequence 
    /// of commands and to perform basic undo/redo functionality.
    /// </summary>
    public class CommandHistory : ICommandHistory
    {
        #region Fields

        private LinkedList<ICommand> _undos = new LinkedList<ICommand>();
        private LinkedList<ICommand> _redos = new LinkedList<ICommand>();
        
        private int _limit;

        #endregion

        #region Properties

        /// <summary>
        /// The number of commands registered in the command history.
        /// </summary>
        public int Count 
        { 
            get { return _undos.Count; } 
        }

        /// <summary>
        /// The maximum number of elements logged in the command history. Once 
        /// the number of elements exceeds the specified limit, the oldest 
        /// commands in the history will be discarded.
        /// </summary>
        public int Limit
        {
            get { return _limit; }
            set 
            {
                if (_limit > 0)
                {
                    _limit = value;
                    TrimHistoryLength();
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a command history keeping track of a 
        /// sequence of commands.
        /// </summary>
        public CommandHistory()
        {
            _limit = int.MaxValue;
        }

        /// <summary>
        /// Public constructor. Creates a command history keeping track of a 
        /// sequence of commands.
        /// </summary>
        /// <param name="limit">The maximum number of commands to hold in the history.</param>
        public CommandHistory(int limit)
        {
            _limit = limit;
        }

        #endregion

        /// <summary>
        /// Saves the command in a sorted list (by time) and executes it.
        /// Only command saved in the history can be undone later safely.
        /// </summary>
        /// <param name="command">The command to save in history.</param>
        public void SaveAndExecute(ICommand command)
        {
            if (command != null)
            {
                // Ensure that the history does not contain more elements than
                // specified as limit.
                TrimHistoryLength();

                // Insert the command into the undo history
                _undos.AddFirst(command);

                // Reset the redo history as it now invalid
                _redos.Clear();

                // Finally execute the command.
                command.Execute();
            }
        }

        /// <summary>
        /// Reverts the last command executed.
        /// </summary>
        public void Undo()
        {
            Undo(1);
        }

        /// <summary>
        /// Reverts the latest commands executed.
        /// </summary>
        /// <param name="numberOfCommands">The number of commands to revert.</param>
        public void Undo(int numberOfCommands)
        {
            for (int i = 0; _undos.Count > 0 && i < numberOfCommands; i++)
            {
                // The latest command in the history is always at the first
                // position of the list
                ICommand command = _undos.First.Value;
                _undos.RemoveFirst();

                // Undo the current command
                command.Undo();

                // Allow to redo the current command.
                _redos.AddFirst(command);
            }
        }

        /// <summary>
        /// Executes a undone command a second time.
        /// </summary>
        public void Redo()
        {
            Redo(1);
        }

        /// <summary>
        /// Executes undone commands again. 
        /// </summary>
        /// <param name="numberOfCommands">The number of commands to redo.</param>
        public void Redo(int numberOfCommands)
        {
            for (int i = 0; _redos.Count > 0 && i < numberOfCommands; i++)
            {
                // The command we have undone the latest is always at the
                // first position of the list
                ICommand command = _redos.First.Value;
                _redos.RemoveFirst();

                // Execute the command again
                command.Redo();

                // Allow to undo the command again.
                _undos.AddFirst(command);
            }
        }

        /// <summary>
        /// Flushes the entire command history.
        /// </summary>
        public void Clear()
        {
            _undos.Clear();
            _redos.Clear();
        }

        /// <summary>
        /// A small helper function to ensure that the number of commands 
        /// tracked within the history does not exceed the given limit.
        /// </summary>
        private void TrimHistoryLength()
        {
            int length = _undos.Count;
            while (length >= _limit)
                _undos.RemoveLast();
        }
    }
}
