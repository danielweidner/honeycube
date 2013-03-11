#region Using Statements

using System;
using System.Collections.Generic;
using HoneyCube.Editor.Commands;
using HoneyCube.Editor.Events;
using HoneyCube.Editor.Services;

#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// The ApplicationController represents a central point to synchronize
    /// different user controls or to control the overal flow of the 
    /// application. Therefore the ApplicationController provides access to
    /// a custom event system (observer pattern) and allows to invoke generic
    /// commands (command pattern).
    /// </summary>
    public class ApplicationController: IApplicationController
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
        /// Public constructor. Creates a new application controller.
        /// </summary>
        /// <param name="eventPublisher">An EventPublisher which maintains event subscription.</param>
        /// <param name="history">Keeps track of a command sequence. Allows to undo/redo certain commands.</param>
        public ApplicationController(IEventPublisher eventPublisher, ICommandService commands, ICommandHistory<IUndoableCommand> history)
        {
            _eventPublisher = eventPublisher;
            _commands = commands;
            _commandHistory = history;

            _commandHistory.StateChanged += new EventHandler(OnHistoryStateChanged);
        }

        #endregion

        #region IApplicationController Members

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="command"></param>
        public void Execute(string command)
        {
            if (!_commands.ExecuteCommand(command))
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
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnHistoryStateChanged(object sender, EventArgs e)
        {
            // TODO: Raise an application event
        }

        #endregion
    }
}
