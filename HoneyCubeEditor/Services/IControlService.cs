#region Using Statements

using System.ComponentModel;

#endregion

namespace HoneyCube.Editor.Services
{
    /// <summary>
    /// Describes a service which allows to retrieve a generic control 
    /// element by its name.
    /// </summary>
    public interface IControlService
    {
        /// <summary>
        /// Searches all attached control elements and returns the first element
        /// with the given name.
        /// </summary>
        /// <typeparam name="T">The type of the control element to find.</typeparam>
        /// <param name="name">The name of the element to find.</param>
        /// <returns>A reference to the found element. Null if not found or of wrong type.</returns>
        T GetControl<T>(string name) where T : Component;
    }
}
