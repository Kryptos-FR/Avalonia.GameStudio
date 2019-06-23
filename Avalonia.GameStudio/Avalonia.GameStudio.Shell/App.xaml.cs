using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.GameStudio.Shell.ViewModels;
using Avalonia.GameStudio.Shell.Views;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Shell
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
