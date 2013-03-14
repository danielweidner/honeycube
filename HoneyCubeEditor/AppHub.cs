#region Using Statements

using System;
using HoneyCube.Editor.Commands;
using HoneyCube.Editor.Events;


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

        private ICommandMap _commandMap;
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

        /// <summary>
        /// Holds associations of simple string identifiers or key 
        /// combinations to executable commands.
        /// </summary>
        public ICommandMap CommandMap
        {
            get { return _commandMap; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new application hub as seperation 
        /// layer between core concepts and modules.
        /// </summary>
        /// <param name="publisher">Allows to maintain event subscriptions.</param>
        /// <param name="history">The command history should track the execution of UndoableCommands.</param>
        /// <param name="map">A command map that associates, string identifiers or key shortcuts to specific commands.</param>
        public AppHub(IEventPublisher publisher, ICommandHistory<IUndoableCommand> history, ICommandMap map)
        {
            _commandMap = map;
            _eventPublisher = publisher;
            
            _commandHistory = history;
            _commandHistory.StateChanged += new EventHandler(OnHistoryStateChanged);
        }

        #endregion

        #region IAppHub Members

        /// <summary>
        /// Executes the given command. If the command provides any undo
        /// functionality the command will be registered within the 
        /// command history.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        public void Execute(ICommand command)
        {
            if (command is IUndoableCommand)
            {
                _commandHistory.SaveAndExecute(command as IUndoableCommand);
            }
            else
            {
                command.Execute();
            }
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
