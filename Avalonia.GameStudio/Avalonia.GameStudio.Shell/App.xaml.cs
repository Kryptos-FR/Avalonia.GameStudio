using System;

using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.GameStudio.Presentation.Windows;
using Avalonia.GameStudio.Shell.ViewModels;
using Avalonia.GameStudio.Shell.Views;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Shell
{
    /// <inheritdoc />
    internal sealed class App : Application
    {
        public static MainWindow? MainWindow { get; set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <inheritdoc />
        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is not IControlledApplicationLifetime controlled)
            {
                Console.Error.WriteLine("Unsupported environment.");
                Environment.Exit(-1);
                return;
            }

            controlled.Startup += OnApplicationStartup;
            controlled.Exit += OnApplicationExit;

            base.OnFrameworkInitializationCompleted();
        }

        private async void OnApplicationStartup(object? sender, ControlledApplicationLifetimeStartupEventArgs e)
        {
            switch (sender)
            {
                case IClassicDesktopStyleApplicationLifetime desktop:
                    desktop.ShutdownMode = ShutdownMode.OnMainWindowClose;

                    if (!Environment.Is64BitOperatingSystem || !Environment.Is64BitProcess)
                    {
                        await MessageBox.ShowAsync(null, "GameStudio requires a 64bit OS to run.", "GameStudio", MessageBoxButtons.Ok);
                        desktop.Shutdown(-2);
                        return;
                    }

                    desktop.MainWindow = MainWindow = new MainWindow
                    {
                        DataContext = new MainWindowViewModel(),
                    };
                    desktop.MainWindow.Show();
                    break;
            }
        }

        private void OnApplicationExit(object? sender, ControlledApplicationLifetimeExitEventArgs e)
        {
            // nothing for now
        }
    }
}
