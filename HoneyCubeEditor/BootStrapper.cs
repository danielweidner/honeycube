#region Using Statements

using System.Windows.Forms;
using StructureMap;

#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// The BootStrapper is responsible for the initialization of the application.
    /// It configurates the dependency injection framework and wires up all 
    /// library components to their actual implementation. The BootStrapper uses
    /// StructureMap as IoC framework.
    /// </summary>
    public class BootStrapper
    {
        #region Fields

        private IContainer _container;

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new BootStrapper instance.
        /// </summary>
        /// <param name="container">The IoC container used to wireup the actual component implementations.</param>
        public BootStrapper(IContainer container)
        {
            _container = container;
        }

        #endregion

        /// <summary>
        /// Returns the application context containing specific information about
        /// the currently applied application thread.
        /// </summary>
        /// <returns>A reference to the configured application context.</returns>
        public ApplicationContext GetAppContext()
        {
            _container.Configure(c => c.AddRegistry<DefaultRegistry>());
            return _container.GetInstance<ApplicationContext>();
        }
    }
}
