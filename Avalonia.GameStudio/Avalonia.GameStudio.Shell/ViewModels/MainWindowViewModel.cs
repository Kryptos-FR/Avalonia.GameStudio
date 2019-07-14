using Avalonia.GameStudio.Presentation.ViewModels;

namespace Avalonia.GameStudio.Shell.ViewModels
{
    internal sealed class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            MainMenu = new MainMenuViewModel();
        }

        public string Greeting => "Welcome to Avalonia!";

        public MainMenuViewModel MainMenu { get; }
    }
}
