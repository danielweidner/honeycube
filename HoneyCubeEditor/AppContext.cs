﻿#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Presenter;
using StructureMap;
using HoneyCube.Editor.Views;
using HoneyCube.Editor.Events;

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
            // Services
            IEventPublisher _eventPublisher = _container.GetInstance<IEventPublisher>();

            // Create the presenter
            IAppWindowPresenter window = _container.GetInstance<IAppWindowPresenter>();
            IAppMenuPresenter menu = _container.GetInstance<IAppMenuPresenter>();
            IAppToolbarPresenter toolbar = _container.GetInstance<IAppToolbarPresenter>();
            IInspectorPresenter inspector = _container.GetInstance<IInspectorPresenter>();
            IProjectTreePresenter tree = _container.GetInstance<IProjectTreePresenter>();

            // Setup the main window
            window.View.AppMenu = menu.View;
            window.View.AppToolbar = toolbar.View;
            window.View.Inspector = inspector.View;
            window.View.ProjectTree = tree.View;

            // Automatic event handler registration
            foreach (IEventHandler handler in _container.Model.GetAllPossible<IEventHandler>())
                _eventPublisher.RegisterHandlers(handler);

            // Assign the view as main form of the application
            MainForm = window.View as Form;
            
            // Localize all components
            foreach (ILocalizable instance in _container.Model.GetAllPossible<ILocalizable>())
                instance.LocalizeComponent();

            // Report missing localization to a log file
            L10n.ReportMissingTranslations();
        }
    }
}