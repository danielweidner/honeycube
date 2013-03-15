#region Using Statements

using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// Helps to identify Presenter implementations.
    /// </summary>
    public interface IPresenter 
    { 
        // Empty 
    }

    /// <summary>
    /// A Presenter in our variation of the Model-View-Presenter pattern represents
    /// a class that handles the interaction of the associated View. Furthermore it
    /// observeres the model for changes and initiates a refresh on the View.
    /// </summary>
    /// <typeparam name="TView">The type of the associated view.</typeparam>
    public interface IPresenter<TView> : IPresenter
        where TView : class, IView
    {
        /// <summary>
        /// Returns the associated view.
        /// </summary>
        TView View { get; }
    }

    /// <summary>
    /// A Presenter in our variation of the Model-View-Presenter pattern represents
    /// a class that handles the interaction of the associated View. Furthermore it
    /// observeres the model for changes and initiates a refresh on the View.
    /// </summary>
    /// <typeparam name="TView">The type of the associated view.</typeparam>
    /// <typeparam name="TModel">The type of the associated model.</typeparam>
    public interface IPresenter<TView, TModel> : IPresenter<TView>
        where TView : class, IView
        where TModel : class
    {
        /// <summary>
        /// Returns the associated model.
        /// </summary>
        TModel Model { get; }
    }
}
