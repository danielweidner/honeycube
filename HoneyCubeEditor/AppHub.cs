#region Using Statements

using System;
using HoneyCube.Editor.Commands;
using HoneyCube.Editor.Events;
using HoneyCube.Editor.Services;

#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// The ApplicationHub is an abstraction layer for core functionalites of 
    /// the application and allows for better decoupling of modules and root
    /// elements.
    /// </summary>
    public class AppHub: IAppHub
    {
        #region Fields

        private IEventPublisher _eventPublisher;

        private ICommandService _commands;
        private ICommandHistory<IUndoableCommand> _commandHistory;

        #endregion

        #region Properties

        /// <summary>
        /// Grants access to the EventPublisher which maintains event 
        /// subscription on application level.
        /// </summary>
        public IEventPublisher EventPublisher
        {
            get { return _eventPublisher; }
        }

        /// <summary>
        /// Maintains command execution and allows for simple undo/redo
        /// operations.
        /// </summary>
        public ICommandHistory<IUndoableCommand> History
        {
            get { return _commandHistory; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new application hub as seperation 
        /// layer between core concepts and modules.
        /// </summary>
        /// <param name="eventPublisher">Allows to maintain event subscriptions.</param>
        /// <param name="commands">The command service returns simple commands associated with a unique identifier.</param>
        /// <param name="history">The command history should track the execution of UndoableCommands.</param>
        public AppHub(IEventPublisher eventPublisher, ICommandService commands, ICommandHistory<IUndoableCommand> history)
        {
            _eventPublisher = eventPublisher;
            _commands = commands;

            _commandHistory = history;
            _commandHistory.StateChanged += new EventHandler(OnHistoryStateChanged);
        }

        #endregion

        #region IAppHub Members

        /// <summary>
        /// Tries to execute the associated command. Will do nothing when no
        /// command is available for the given identifier.
        /// </summary>
        /// <param name="identifier">The id of the command to execute.</param>
        public void Execute(string identifier)
        {
            if (!_commands.TryToExecuteCommand(identifier))
            {
                // TODO: Log -> No command associated with the given id.
            }
        }

        /// <summary>
        /// Registers the given command in the applications command history
        /// and executes it.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        public void Execute(UndoableCommand command)
        {
            _commandHistory.SaveAndExecute(command);
        }

        /// <summary>
        /// Undo the last command executed.
        /// </summary>
        /// <returns>True on success.</returns>
        public void Undo()
        {
            _commandHistory.Undo();
        }

        /// <summary>
        /// Redo the last command executed.
        /// </summary>
        /// <returns>True on success.</returns>
        public void Redo()
        {
            _commandHistory.Redo();
        }

        /// <summary>
        /// Flushes the command history of the application.
        /// </summary>
        public void ClearHistory()
        {
            _commandHistory.Clear();
        }

        /// <summary>
        /// Raise a certain event and notify all EventListeners.
        /// </summary>
        /// <typeparam name="T">The type of the event to raise.</typeparam>
        /// <param name="eventData">Some event data.</param>
        public void Raise<T>(T eventData)
        {
            _eventPublisher.Publish<T>(eventData);
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Is called everytime the state of the command history changes from which
        /// should be the case if new commands are available for undo/redo.
        /// </summary>
        /// <param name="sender">A reference to the command history.</param>
        /// <param name="e">Some event arguments.</param>
        protected virtual void OnHistoryStateChanged(object sender, EventArgs e)
        {
            // TODO: Raise an application event
        }

        #endregion
    }
}
