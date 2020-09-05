using Avalonia.Threading;

namespace Avalonia.GameStudio.Presentation.ViewModels
{
    public abstract class DispatcherViewModel : ViewModelBase
    {
        /// <inheritdoc />
        protected override void OnPropertyChanging(string propertyName)
        {
#if !DEBUG
            if (!HasPropertyChangingSubscriber) return;
#endif
            if (Dispatcher.UIThread.CheckAccess())
                base.OnPropertyChanging(propertyName);

            Dispatcher.UIThread.Post(() => base.OnPropertyChanging(propertyName));
        }

        /// <inheritdoc />
        protected override void OnPropertyChanged(string propertyName)
        {
#if !DEBUG
            if (!HasPropertyChangedSubscriber) return;
#endif
            if (Dispatcher.UIThread.CheckAccess())
                base.OnPropertyChanged(propertyName);

            Dispatcher.UIThread.Post(() => base.OnPropertyChanged(propertyName));
        }
    }
}
