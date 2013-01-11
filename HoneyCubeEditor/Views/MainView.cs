#region Using Statements

using System;
using System.Windows.Forms;
using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// Represents the main view within the application. Holds most of the
    /// control elements.
    /// </summary>
    public partial class MainView : Form, IMainView
    {
        #region Fields

        private MainPresenter _presenter;

        #endregion

        #region Properties

        /// <summary>
        /// The presenter controlling the behavior of the main view.
        /// </summary>
        public MainPresenter Presenter
        {
            get { return _presenter; }
            set { _presenter = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new form element holding the general 
        /// controls of the application.
        /// </summary>
        public MainView()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// Is raised every time the exit button in the main menu is clicked.
        /// </summary>
        /// <param name="sender">A reference to the menu item.</param>
        /// <param name="e">Empty event argument.</param>
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Is raised every time a close of the form is requested.
        /// </summary>
        /// <param name="sender">The form that is going to be closed.</param>
        /// <param name="e">Some event arguments (e.g. the closing reason).</param>
        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Presenter.CloseRequested();
        }
    }
}