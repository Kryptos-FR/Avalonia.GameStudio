using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Shell.Views
{
    /// <summary>
    /// View for the shell.
    /// </summary>
    public class ShellView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ShellView"/>.
        /// </summary>
        public ShellView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
