#region Using Statements

using System;
using System.Collections.Generic;

#endregion

namespace HoneyCube.Editor.Events
{
    /// <summary>
    /// The EventPubslisher is a simple implementation of the EventAggregator 
    /// pattern. Handler can subscribe for a certain event and get notified as
    /// soon as the corresponding event is raised.
    /// </summary>
    public class EventPublisher : IEventPublisher
    {
        #region Fields

        private IDictionary<Type, IList<object>> _handlers = new Dictionary<Type, IList<object>>();
        private IList<Type> _locks = new List<Type>();

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new EventPublisher.
        /// </summary>
        public EventPublisher()
        {
            // Empty
        }

        #endregion        

        /// <summary>
        /// Registers an object as event handler for a certain event type.
        /// </summary>
        /// <typeparam name="T">The type of event to register for.</typeparam>
        /// <param name="eventHandler">The object to register as event handler.</param>
        public void RegisterHandler<T>(IEventHandler<T> eventHandler)
        {
            Type eventType = typeof(T);
            AddHandler(eventType, eventHandler);
        }

        /// <summary>
        /// Registers an object as event handler for all given event types 
        /// implemented. Therefore this method will look up each IEventHandler 
        /// interface using reflection and register the object for each event 
        /// type properly as event handler. The handler should implement 
        /// IEventHandler to allow for the automatic detection.
        /// </summary>
        /// <param name="eventHandler">The object to register as event handler.</param>
        public void RegisterHandlers(object eventHandler)
        {
            Type[] handlerTypes = eventHandler.GetType().GetInterfaces();
            Type genericHandlerType = typeof(IEventHandler<>);

            foreach (Type handlerType in handlerTypes)
            {
                if (handlerType.Name.Equals(genericHandlerType.Name))
                {
                    Type eventType = handlerType.GetGenericArguments()[0];
                    AddHandler(eventType, eventHandler);
                }
            }
        }

        /// <summary>
        /// Removes the object as event handler for the given event type.
        /// </summary>
        /// <typeparam name="T">The type of event to cancel registration for.</typeparam>
        /// <param name="eventHandler">The object to remove as event handler.</param>
        public void RemoveHandler<T>(IEventHandler<T> eventHandler)
        {
            Type eventType = typeof(T);
            RemoveHandler(eventType, eventHandler);
        }

        /// <summary>
        /// Removes the object as event handler for all implemented event types.
        /// <see cref="HoneyCube.Editor.Events.EventPublisher.RegisterHandlers"/> for
        /// more details.
        /// </summary>
        /// <param name="eventHandler">The object to remove as event handler.</param>
        public void RemoveHandlers(object eventHandler)
        {
            Type[] handlerTypes = eventHandler.GetType().GetInterfaces();
            Type genericHandlerType = typeof(IEventHandler<>);

            foreach (Type handlerType in handlerTypes)
            {
                if (handlerType.Name.Equals(genericHandlerType.Name))
                {
                    Type eventType = handlerType.GetGenericArguments()[0];
                    RemoveHandler(eventType, eventHandler);
                }
            }
        }

        /// <summary>
        /// Raises a certain event and notifies all event handlers. Will lock 
        /// event publishing for the given event type to avoid callback loops
        /// (e.g. in case of cascades).
        /// </summary>
        /// <typeparam name="T">The type of event to raise.</typeparam>
        /// <param name="eventData">Some event data.</param>
        public void Publish<T>(T eventData)
        {
            Type eventType = typeof(T);

            // Do not raise the given event when a previous call is still 
            // running
            if (_locks.Contains(eventType))
                return;

            // Lock the event while we are notifing all handlers
            _locks.Add(eventType);

            if (_handlers.ContainsKey(eventType))
            {
                // Create a copy of the registered handlers in case the 
                // collection is changed during iteration
                IList<object> handlers = new List<object>(_handlers[eventType]);

                // Notify each handler registered for the current event
                foreach (object handler in handlers)
                {
                    IEventHandler<T> eventHandler = handler as IEventHandler<T>;
                    if (eventHandler != null)
                        eventHandler.Handle(eventData);
                }
            }

            // We are finished. Allow the event to be published again.
            _locks.Remove(eventType);
        }

        /// <summary>
        /// A small helper function to add a handler properly to the 
        /// dictionary.
        /// </summary>
        /// <param name="eventType">The type of the event to register for.</param>
        /// <param name="eventHandler">The object to register as event handler.</param>
        private void AddHandler(Type eventType, object eventHandler)
        {
            // Check whether this is the first entry for that event type
            if (!_handlers.ContainsKey(eventType))
                _handlers[eventType] = new List<object>();

            // Add the handler to the collection
            _handlers[eventType].Add(eventHandler);
        }

        /// <summary>
        /// A small helper function to remove a handler properly from the 
        /// dictionary.
        /// </summary>
        /// <param name="eventType">The type of the event to cancel registration for.</param>
        /// <param name="eventHandler">The object to remove as event handler.</param>
        private void RemoveHandler(Type eventType, object eventHandler)
        {
            if (_handlers.ContainsKey(eventType))
            {
                IList<object> handlers = _handlers[eventType];
                handlers.Remove(eventHandler);
            }
        }
    }
}
