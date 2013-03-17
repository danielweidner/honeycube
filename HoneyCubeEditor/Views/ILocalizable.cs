namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// An interface describing an element that needs to localize certain 
    /// values.
    /// </summary>
    public interface ILocalizable
    {
        /// <summary>
        /// Localizes the current component and all its elements attached.
        /// </summary>
        void LocalizeComponent();
    }
}
