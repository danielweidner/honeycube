#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// TODO
    /// </summary>
    public interface IAppLogPresenter : IPresenter<IAppLogWindow>
    {
        /// <summary>
        /// TODO
        /// </summary>
        bool ShowControl();

        /// <summary>
        /// TODO
        /// </summary>
        void HideControl();

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        void SelectionChanged(string name);

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        void SaveLog(string name, string path);

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        void ClearLog(string name);

        /// <summary>
        /// TODO
        /// </summary>
        void ClearAllLogs();

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        string SelectFilePath();
    }
}
