using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Shell.Views
{
    /// <summary>
    /// View for the main window.
    /// </summary>
    public class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MainWindow"/>.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
