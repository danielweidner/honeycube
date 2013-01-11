#region Using Statements

using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// A Presenter acts upon the model and the view. Its main responsibility 
    /// is to retrieve data from the business model and pass it to the view 
    /// or to react on changes in the view and to update the model.
    /// </summary>
    public interface IPresenter { }

    /// <summary>
    /// A Presenter acts upon the model and the view. Its main responsibility 
    /// is to retrieve data from the business model and pass it to the view 
    /// or to react on changes in the view and to update the model.
    /// </summary>
    /// <typeparam name="TView">The type of view the presenter is acting on.</typeparam>
    /// <typeparam name="TModel">The type of model the presenter is acting on.</typeparam>
    public interface IPresenter<TView, TModel> : IPresenter
        where TView : class, IView
        where TModel : class
    {
        /// <summary>
        /// The view which routes events and commands to the presenter. 
        /// </summary>
        TView View
        {
            get;
        }

        /// <summary>
        /// The model represents the actual data beeing displayed.
        /// </summary>
        TModel Model
        {
            get;
        }
    }
}
