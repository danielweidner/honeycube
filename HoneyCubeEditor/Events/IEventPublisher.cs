namespace HoneyCube.Editor.Events
{
    /// <summary>
    /// IEventPublisher descibes an interface that allows to manage event
    /// subscription for different event types.
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        /// Registers a handler for a specific event type.
        /// </summary>
        /// <typeparam name="T">The event type to register for.</typeparam>
        /// <param name="eventHandler">The object to register as event handler.</param>
        void RegisterHandler<T>(IEventHandler<T> eventHandler);

        /// <summary>
        /// Registers a handler for a set of event types (determined by 
        /// the implementation of the generic IEventHandler interface).
        /// </summary>
        /// <param name="eventHandler">The object to register as event handler.</param>
        void RegisterHandlers(object eventHandler);

        /// <summary>
        /// Removes registration of the handler for a specific event type.
        /// </summary>
        /// <typeparam name="T">The event type to cancel registration for.</typeparam>
        /// <param name="eventHandler">The object to remove as event handler.</param>
        void RemoveHandler<T>(IEventHandler<T> eventHandler);

        /// <summary>
        /// Cancels registration of the handler for a set of event types 
        /// (determined by the implementation of the generic IEventHandler 
        /// interface).
        /// </summary>
        /// <param name="eventHandler">The object to remove as event handler.</param>
        void RemoveHandlers(object eventHandler);

        /// <summary>
        /// Publishes a certain event to all subscribers.
        /// </summary>
        /// <typeparam name="T">The event to publish.</typeparam>
        /// <param name="eventData">Some event data.</param>
        void Publish<T>(T eventData);
    }
}
