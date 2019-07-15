using Avalonia.GameStudio.Presentation.ViewModels;

namespace Avalonia.GameStudio.Shell.ViewModels
{
    /// <summary>
    /// View model for the main window.
    /// </summary>
    internal sealed class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MainWindowViewModel"/>.
        /// </summary>
        public MainWindowViewModel()
        {
            MainMenu = new MainMenuViewModel();
        }

        /// <summary>
        /// A greeting message.
        /// </summary>
        public string Greeting => "Welcome to Avalonia Game Studio!";

        /// <summary>
        /// The main menu.
        /// </summary>
        public MainMenuViewModel MainMenu { get; }
    }
}
