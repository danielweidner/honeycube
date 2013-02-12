#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// TODO
    /// </summary>
    [Flags]
    public enum CommandState : int
    {
        None = 1 << 0,
        Cloned = 1 << 1,
        Executed = 1 << 2,
        Undone = 1 << 3,
        All = Cloned | Executed | Undone
    }
}
