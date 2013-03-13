namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// A command performs a certain operation on a subject. An UndoableCommand
    /// allows to revert the action previously performed by a command.
    /// </summary>
    public interface IUndoableCommand : ICommand
    {
        /// <summary>
        /// Reverts the action performed by the current command.
        /// </summary>
        void Undo();

        /// <summary>
        /// Executes the command again after the command has been undone.
        /// </summary>
        void Redo();
    }
}
