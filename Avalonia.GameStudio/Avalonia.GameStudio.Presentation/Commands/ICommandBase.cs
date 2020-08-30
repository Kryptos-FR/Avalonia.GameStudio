using System.Windows.Input;

namespace Avalonia.GameStudio.Presentation.Commands
{
    /// <summary>
    /// An interface representing an implementation of <see cref="ICommand"/> with additional properties.
    /// </summary>
    public interface ICommandBase : ICommand
    {
        /// <summary>
        /// Indicates whether the command can be executed or not.
        /// </summary>
        bool IsEnabled { get; set; }

        /// <summary>
        /// Executes the command with a <c>null</c> parameter.
        /// </summary>
        void Execute();
    }
}
