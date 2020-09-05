using Avalonia.GameStudio.Presentation.ViewModels;

using Dock.Model;

namespace Avalonia.GameStudio.Shell.ViewModels
{
    /// <summary>
    /// View model for the shell.
    /// </summary>
    internal sealed class ShellViewModel : ViewModelBase
    {
        private IFactory _factory;
        private IDock _layout;

        public ShellViewModel()
        {
            var factory = new MainDockFactory();
            var layout = factory.CreateLayout();
            factory.InitLayout(layout);

            _factory = factory;
            _layout = layout;
        }

        public IFactory Factory
        {
            get => _factory;
        }

        public IDock Layout
        {
            get => _layout;
            set => SetValue(ref _layout, value);
        }
    }
}
