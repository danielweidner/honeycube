#region Using Statements

using HoneyCube.Editor.Views;
using System.Windows.Forms;

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
        /// <param name="view"></param>
        public ApplicationMenuPresenter(IApplicationMenu view)
        {
            _view = view;
            _view.Presenter = this;
        }

        #endregion

        #region IApplicationMenuPresenter

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="item"></param>
        public void MenuItemClicked(ToolStripMenuItem item)
        {
            // TODO: Implement action
            System.Diagnostics.Debug.WriteLine(item.Text);
        }

        #endregion
    }
}
