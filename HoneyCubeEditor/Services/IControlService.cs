#region Using Statements

using System.ComponentModel;

#endregion

namespace HoneyCube.Editor.Services
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IControlService
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        T GetControl<T>(string name) where T : Component;
    }
}
