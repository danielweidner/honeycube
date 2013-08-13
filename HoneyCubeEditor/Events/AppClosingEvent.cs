namespace HoneyCube.Editor.Events
{
    /// <summary>
    /// An event that is raised every time the user has closed the application.
    /// Allows event handler to perform certain action on closing.
    /// </summary>
    public class AppClosingEvent
    {
        #region Fields

        private bool _canceled = false;

        #endregion

        #region Properties

        /// <summary>
        /// A flag indicating whether the closing process has been canceled.
        /// </summary>
        public bool Canceled
        {
            get { return _canceled; }
        }

        #endregion

        /// <summary>
        /// Cancels the application closing process (e.g. in terms the scene is
        /// not saved yet).
        /// </summary>
        public void Cancel()
        {
            _canceled = true;
        }
    }
}
