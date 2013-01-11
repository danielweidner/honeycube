#region Using Statements

using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// The view is a passive interface that displays all information of the 
    /// model and routes user commands to the presenter which in turn acts 
    /// upon the model.
    /// </summary>
    public interface IView { }

    /// <summary>
    /// The view is a passive interface that displays all information of the 
    /// model and routes user commands to the presenter which in turn acts 
    /// upon the model.
    /// </summary>
    public interface IView<TPresenter> : IView
        where TPresenter : class, IPresenter
    {
        TPresenter Presenter
        {
            get;
            set;
        }
    }
}
