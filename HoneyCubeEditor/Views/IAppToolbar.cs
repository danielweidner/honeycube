#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// A generic interface for the application toolbar.
    /// </summary>
    public interface IAppToolbar : IView<IAppToolbarPresenter>
    {
        // Empty
    }
}
