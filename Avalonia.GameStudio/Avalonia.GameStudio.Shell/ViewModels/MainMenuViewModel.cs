using System;
using System.Text;
using System.Threading.Tasks;

using Avalonia.GameStudio.Presentation.Commands;
using Avalonia.GameStudio.Presentation.ViewModels;
using Avalonia.GameStudio.Presentation.Windows;

namespace Avalonia.GameStudio.Shell.ViewModels
{
    /// <summary>
    /// View model for the main menu.
    /// </summary>
    internal sealed class MainMenuViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MainMenuViewModel"/>.
        /// </summary>
        public MainMenuViewModel()
        {
            AboutCommand = new AnonymousTaskCommand(AboutCommandImpl);
            ExitCommand = new AnonymousCommand(ExitCommandImpl);
        }

        /// <summary>
        /// When executed, displays information about the application.
        /// </summary>
        public ICommandBase AboutCommand { get; }

        /// <summary>
        /// When executed, closes the application.
        /// </summary>
        public ICommandBase ExitCommand { get; }

        /// <summary>
        /// Implements the <see cref="AboutCommand"/>.
        /// </summary>
        private async Task AboutCommandImpl()
        {
            var message = new StringBuilder()
                .AppendLine("Avalonia GameStudio 0.1")
                .AppendLine("========================")
                .AppendLine("Copyright 2020 - Nicolas Musset");
            await MessageBox.ShowAsync(App.MainWindow, message.ToString(), "About Avalonia GameStudio", MessageBoxButtons.Ok);
        }

        /// <summary>
        /// Implements the <see cref="ExitCommand"/>.
        /// </summary>
        private void ExitCommandImpl()
        {
            var lifetime = Application.Current.ApplicationLifetime;
            if (lifetime is Controls.ApplicationLifetimes.IControlledApplicationLifetime controlled)
            {
                controlled.Shutdown();
                return;
            }

            Environment.Exit(0);
        }
    }
}
