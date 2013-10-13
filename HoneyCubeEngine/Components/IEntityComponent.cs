#region Using Statements

using Microsoft.Xna.Framework;

#endregion

namespace HoneyCube.Components
{
    /// <summary>
    /// The IEntityComponent interface describes a generic entity component.
    /// </summary>
    public interface IEntityComponent : IUpdateable
    {
        /// <summary>
        /// Indicates whether the current component is already initialized.
        /// </summary>
        bool Initialized
        {
            get;
        }

        /// <summary>
        /// Indicates whether the current component has been started already.
        /// </summary>
        bool Started
        {
            get;
        }

        /// <summary>
        /// The unique id of the entity component.
        /// </summary>
        int Id
        {
            get;
        }

        /// <summary>
        /// The human readable name of the current component. Is not 
        /// necessarily unique!
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// A tag value that can be assigned to the current component. E.g. this 
        /// can be useful to query for a group of components sharing the same
        /// tag value.
        /// </summary>
        string Tag
        {
            get;
        }

        /// <summary>
        /// The entity the component is attached to.
        /// </summary>
        Entity Entity
        {
            get;
        }

        /// <summary>
        /// Allows to initialize all properties of the component.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Is called once before the first call of Update(). As an example it 
        /// could be used to query for components.
        /// </summary>
        void Start();
    }
}
