namespace HoneyCube.Editor.Events
{
    /// <summary>
    /// A generic event handler interface.
    /// </summary>
    public interface IEventHandler
    {
        // Empty
    }

    /// <summary>
    /// The IEventHandler interface allows an object to handle a certain 
    /// event type. Furthermore it allows the IEventPublisher to identify
    /// which event types the instance should be registered to as handler 
    /// (<see cref="HoneyCube.Editor.Events.EventPublisher.RegisterHandlers"/>).
    /// </summary>
    /// <typeparam name="T">The type of event to create a handler for.</typeparam>
    public interface IEventHandler<T> : IEventHandler
    {
        /// <summary>
        /// Allows the instance to handle a certain event type.
        /// </summary>
        /// <param name="args">Some event data.</param>
        void HandleApplicationEvent(T args);
    }
}
