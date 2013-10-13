#region Using Statements

using System;

#endregion

namespace HoneyCube
{
    /// <summary>
    /// The IEntity interface allows to identify or select an entity by id, 
    /// name or a custom tag.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// The unique id of the entity.
        /// </summary>
        int Id
        {
            get;
        }

        /// <summary>
        /// A human readable name for the entity.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// A tag value that can be assigned to the entity. E.g. this can be 
        /// useful to query for a group of entities sharing the same tag value.
        /// </summary>
        string Tag
        {
            get;
        }

        /// <summary>
        /// Every entity should be assigned to a scene which from the concept 
        /// represents a level of the current game. The Scene maintains and 
        /// updatesall entities and its components.
        /// </summary>
        IScene Scene
        {
            get;
        }
    }
}
