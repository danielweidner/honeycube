#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Presenter;
using StructureMap;

#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// Specifies the contextual information about an application thread.
    /// </summary>
    public class AppContext : ApplicationContext
    {
        #region Fields

        private IContainer _container;

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a custom application context.
        /// </summary>
        /// <param name="container">The IoC container used to setup the application.</param>
        public AppContext(IContainer container)
        {
            _container = container;

            SetupApplication();
        }

        #endregion

        /// <summary>
        /// Prepares the application window for execution.
        /// </summary>
        private void SetupApplication()
        {
            // Create the core presenter which will resolve all dependencies (view etc.)
            IAppWindowPresenter presenter = _container.GetInstance<IAppWindowPresenter>();

            // Assign the view as main form of the application
            MainForm = presenter.View as Form;
        }
    }
}