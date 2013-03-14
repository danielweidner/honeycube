#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Commands;

#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// The DefaultCommandMap contains all methods to bind certain commands to 
    /// a set of identifiers or key combinations.
    /// </summary>
    public class DefaultCommandMap : CommandMap
    {
        /// <summary>
        /// Public constructor. Creates a default set of commands that can be
        /// triggered throughout the entire application.
        /// </summary>
        public DefaultCommandMap()
        {
            #region Application Menu Commands

            // TODO: Specify command mappings

            When(Keys.Control | Keys.D)
                .Execute(new ActionCommand(() => {
                    System.Diagnostics.Debug.WriteLine("Executed");
                    return true;
                 }));

            #endregion
        }
    }
}
