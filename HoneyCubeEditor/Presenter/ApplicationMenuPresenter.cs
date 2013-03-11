#region Using Statements

using HoneyCube.Editor.Views;
using System.Windows.Forms;
using HoneyCube.Editor.Services;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// TODO
    /// </summary>
    public class ApplicationMenuPresenter : IApplicationMenuPresenter
    {
        #region Fields

        private IApplicationMenu _view;
        private IApplicationController _app;

        #endregion

        #region Properties

        /// <summary>
        /// TODO
        /// </summary>
        public IApplicationMenu View
        {
            get { return _view; }
            set 
            { 
                _view = value;
                _view.Presenter = this;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="app"></param>
        /// <param name="view"></param>
        public ApplicationMenuPresenter(IApplicationController app, IApplicationMenu view)
        {
            _view = view;
            _view.Presenter = this;
            _app = app;
        }

        #endregion

        #region IApplicationMenuPresenter

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="item"></param>
        public void MenuItemClicked(ToolStripMenuItem item)
        {
            // Expect every MenuItem to define the command to execute on the
            // tag property.
            if (item.Tag != null && item.Tag is string)
                _app.Execute(item.Tag as string);
        }

        #endregion
    }
}
