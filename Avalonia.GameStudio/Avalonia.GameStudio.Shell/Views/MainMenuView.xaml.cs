using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Shell.Views
{
    /// <summary>
    /// View for the main menu.
    /// </summary>
    public class MainMenuView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MainMenuView"/>.
        /// </summary>
        public MainMenuView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
