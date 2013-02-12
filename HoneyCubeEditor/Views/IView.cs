#region Using Statements

using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// TODO
    /// </summary>
    public interface IView 
    {
        // Empty
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <typeparam name="TPresenter"></typeparam>
    public interface IView<TPresenter> : IView
        where TPresenter : class, IPresenter
    {
        /// <summary>
        /// TODO
        /// </summary>
        TPresenter Presenter { set; }
    }
}
