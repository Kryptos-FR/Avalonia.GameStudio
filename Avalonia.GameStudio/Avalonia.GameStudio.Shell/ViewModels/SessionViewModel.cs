using Avalonia.GameStudio.Presentation.ViewModels;
using Avalonia.GameStudio.Shell.Models;

namespace Avalonia.GameStudio.Shell.ViewModels
{
    internal sealed class SessionViewModel : ViewModelBase
    {
        public SessionViewModel()
        {
            Session = new Session();
        }

        public Session Session { get; }
    }
}
