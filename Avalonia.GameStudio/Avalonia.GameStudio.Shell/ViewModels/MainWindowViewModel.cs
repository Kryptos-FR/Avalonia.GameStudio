using Avalonia.GameStudio.Presentation.ViewModels;

namespace Avalonia.GameStudio.Shell.ViewModels
{
    /// <summary>
    /// View model for the main window.
    /// </summary>
    internal sealed class MainWindowViewModel : ViewModelBase
    {
        private string _title;

        /// <summary>
        /// Initializes a new instance of <see cref="MainWindowViewModel"/>.
        /// </summary>
        public MainWindowViewModel()
        {
            MainMenu = new MainMenuViewModel();
            Shell = new ShellViewModel();
            _title = "Avalonia Game Studio";
        }

        /// <summary>
        /// The title of the main window.
        /// </summary>
        public string Title
        {
            get { return _title; }
            private set { SetValue(ref _title, value); }
        }

        /// <summary>
        /// The main menu.
        /// </summary>
        public MainMenuViewModel MainMenu { get; }

        /// <summary>
        /// The shell.
        /// </summary>
        public ShellViewModel Shell { get; }
    }
}
