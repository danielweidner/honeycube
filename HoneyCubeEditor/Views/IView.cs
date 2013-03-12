#region Using Statements

using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// Helps to identify View implementation.
    /// </summary>
    public interface IView 
    {
        // Empty
    }

    /// <summary>
    /// A View in our variation of the Model-View-Presenter pattern represents
    /// an UI element that delegates all interaction to their associated Presenter.
    /// </summary>
    /// <typeparam name="TPresenter">The type of the Presenter.</typeparam>
    public interface IView<TPresenter> : IView
        where TPresenter : class, IPresenter
    {
        /// <summary>
        /// The Presenter observes the Model for changes and informs the View 
        /// about possible modifications.
        /// </summary>
        TPresenter Presenter { get; set; }
    }
}
