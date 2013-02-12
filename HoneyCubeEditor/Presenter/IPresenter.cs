#region Using Statements

using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// TODO
    /// </summary>
    public interface IPresenter 
    { 
        // Empty 
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    public interface IPresenter<TView> : IPresenter
        where TView : class, IView
    {
        /// <summary>
        /// TODO
        /// </summary>
        TView View { get; set; }
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public interface IPresenter<TView, TModel> : IPresenter<TView>
        where TView : class, IView
        where TModel : class
    {
        /// <summary>
        /// TODO
        /// </summary>
        TModel Model { get; set; }
    }
}
