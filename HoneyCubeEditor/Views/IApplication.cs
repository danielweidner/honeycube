#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// Provides an interface for the main view of the application representing
    /// the editor with most of its controls.
    /// </summary>
    public interface IApplication : IView<IApplicationPresenter>
    {
        /// <summary>
        /// TODO
        /// </summary>
        bool IsSidebarVisible { get; }

        /// <summary>
        /// TODO
        /// </summary>
        bool IsProjectTreeVisible { get; }

        /// <summary>
        /// TODO
        /// </summary>
        bool IsInspectorVisible { get; }

        /// <summary>
        /// TODO
        /// </summary>
        void ShowSidebar();

        /// <summary>
        /// TODO
        /// </summary>
        void HideSidebar();

        /// <summary>
        /// TODO
        /// </summary>
        void ShowProjectTree();

        /// <summary>
        /// TODO
        /// </summary>
        void HideProjectTree();

        /// <summary>
        /// TODO
        /// </summary>
        void ShowInspector();

        /// <summary>
        /// TODO
        /// </summary>
        void HideInspector();
    }
}
