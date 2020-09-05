using System.Collections.ObjectModel;

using Avalonia.GameStudio.Presentation.ViewModels;

namespace Avalonia.GameStudio.Shell.ViewModels
{
    internal sealed class DirectoryViewModel : ViewModelBase
    {
        private readonly ObservableCollection<DirectoryViewModel> _subDirectories = new ObservableCollection<DirectoryViewModel>();

        public DirectoryViewModel()
        {
            SubDirectories = new ReadOnlyObservableCollection<DirectoryViewModel>(_subDirectories);
        }

        public DirectoryViewModel? Parent { get; set; }

        public ReadOnlyObservableCollection<DirectoryViewModel> SubDirectories { get; }

        private void UpdateParent(DirectoryViewModel? oldParent, DirectoryViewModel? newParent)
        {
            oldParent?._subDirectories.Remove(this);
            newParent?._subDirectories.Add(this);
        }
    }
}
