#region Using Statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HoneyCube.Editor.Presenter;
using HoneyCube.Editor.Services;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// The project tree displays all scenes and game entities of the current 
    /// project in a hierarchical list.
    /// </summary>
    public partial class ProjectTree : UserControl, IProjectTree, ILocalizable
    {
        #region Property

        /// <summary>
        ///  The presenter controlling the behavior of the object property view. 
        /// </summary>
        public IProjectTreePresenter Presenter
        {
            get;
            set;
        }

        /// <summary>
        /// Returns the root node of the current tree view.
        /// </summary>
        public TreeNode Root
        {
            get
            {
                TreeNode[] nodes = Tree.Nodes.Find("Root", true);
                if (nodes != null && nodes.Length > 0)
                    return nodes[0];

                return null;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a project tree displaying project 
        /// entities.
        /// </summary>
        public ProjectTree()
        {
            InitializeComponent();
        }

        #endregion

        #region ILocalizable

        /// <summary>
        /// Localizes all elements attached to the current component.
        /// </summary>
        public void LocalizeComponent()
        {
            // Empty
        }

        #endregion

        #region IProjectTree

        /// <summary>
        /// Enables the project tree to allow user interaction.
        /// </summary>
        public void Enable()
        {
            Tree.Enabled = true;
        }

        /// <summary>
        /// Disables the project tree and blocks user interaction.
        /// </summary>
        public void Disable()
        {
            Tree.Enabled = false;
        }

        /// <summary>
        /// Creates the root node if not already done.
        /// </summary>
        public TreeNode CreateRoot()
        {
            TreeNode root = Root;

            // Create the root node if not already done
            if (root == null)
            {
                root = new TreeNode();
                root.Name = "Root";
                Tree.Nodes.Add(root);
            }

            return root;
        }

        /// <summary>
        /// Updates the root node of the project tree.
        /// </summary>
        /// <param name="project">Project that has changed.</param>
        public void UpdateRoot(IProjectManager project)
        {
            TreeNode root = Root;

            // Create the root node if not already done
            if (root == null)
                root = CreateRoot();

            root.Text = project.Name;
        }

        /// <summary>
        /// Updates the node representing the given scene.
        /// </summary>
        /// <param name="scene">Scene node to change.</param>
        public void UpdateNode(IScene scene)
        {
            TreeNode root = Root;

            if (root != null)
            {
                foreach (TreeNode node in root.Nodes)
                    if (node.Tag.Equals(scene))
                        node.Text = scene.Name;
            }
        }

        /// <summary>
        /// Updates the hierarchy of the project tree.
        /// </summary>
        /// <param name="scenes">A collection of scenes to display.</param>
        public void UpdateHierarchy(IList<IScene> scenes)
        {
            TreeNode root = Root;

            // Create the root node if not already done
            if (root == null)
                root = CreateRoot();

            // Populate the root with scene objects
            root.Nodes.Clear();
            if (scenes != null)
            {
                foreach (IScene scene in scenes)
                {
                    TreeNode node = new TreeNode(scene.Name);
                    node.Tag = scene;
                    root.Nodes.Add(node);
                }

                root.ExpandAll();
            }
        }

        /// <summary>
        /// Resets the project tree to its initial state. Stops the 
        /// project tree from displaying the currently active scene.
        /// </summary>
        public void Reset()
        {
            Tree.Nodes.Clear();
            Disable();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Is raised after a tree node has been selected.
        /// </summary>
        /// <param name="sender">TreeView</param>
        /// <param name="e">Some event arguments.</param>
        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;

            if (Presenter != null && node != null)
            {
                // Handle scene selection
                IScene scene = node.Tag as IScene;
                if (scene != null)
                    Presenter.HandleSceneSelection(scene);
            }
        }

        #endregion        
    }
}
