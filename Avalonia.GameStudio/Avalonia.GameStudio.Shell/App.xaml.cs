using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.GameStudio.Shell.ViewModels;
using Avalonia.GameStudio.Shell.Views;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Shell
{
    /// <inheritdoc />
    internal sealed class App : Application
    {
        /// <inheritdoc />
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <inheritdoc />
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
