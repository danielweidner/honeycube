#region Using Statements

using System;
using System.Windows.Forms;
using System.ComponentModel;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// TODO
    /// </summary>
    public class HideCommand : ChangePropertyCommand<Boolean>
    {
        #region Constructor

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="component"></param>
        public HideCommand(Component component)
            : base("Visible", component)
        {
            // Empty
        }

        #endregion

        #region ChangePropertyCommand Members

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public override bool OnExecute()
        {
            SetPropertyValue(true);
            return true;
        }

        #endregion
    }
}
