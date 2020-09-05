using System.Collections.Generic;
using System.Runtime.Serialization;

using Dock.Model;

namespace Avalonia.GameStudio.Presentation.Dock.Model.Core
{
    /// <summary>
    /// Dock base class.
    /// </summary>
    [DataContract(IsReference = true)]
    public abstract class DockBase : DockableBase, IDock
    {
        internal INavigateAdapter _navigateAdapter;
        private IList<IDockable>? _visibleDockables;
        private IList<IDockable>? _hiddenDockables;
        private IList<IDockable>? _pinnedDockables;
        private IDockable? _activeDockable;
        private IDockable? _defaultDockable;
        private IDockable? _focusedDockable;
        private double _proportion = double.NaN;
        private bool _isActive;
        private bool _isCollapsable = true;

        /// <summary>
        /// Initializes new instance of the <see cref="DockBase"/> class.
        /// </summary>
        public DockBase()
        {
            _navigateAdapter = new NavigateAdapter(this);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public IList<IDockable>? VisibleDockables
        {
            get => _visibleDockables;
            set => SetValue(ref _visibleDockables, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public IList<IDockable>? HiddenDockables
        {
            get => _hiddenDockables;
            set => SetValue(ref _hiddenDockables, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public IList<IDockable>? PinnedDockables
        {
            get => _pinnedDockables;
            set => SetValue(ref _pinnedDockables, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public IDockable? ActiveDockable
        {
            get => _activeDockable;
            set
            {
                if (!SetValue(ref _activeDockable, value)) return;
                if (value is not null)
                {
                    Factory?.UpdateDockable(value, this);
                    value.OnSelected();
                    Factory?.SetFocusedDockable(this, value);
                }
                RaisePropertyChanged(nameof(CanGoBack));
                RaisePropertyChanged(nameof(CanGoForward));
            }
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public IDockable? DefaultDockable
        {
            get => _defaultDockable;
            set => SetValue(ref _defaultDockable, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public IDockable? FocusedDockable
        {
            get => _focusedDockable;
            set => SetValue(ref _focusedDockable, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public double Proportion
        {
            get => _proportion;
            set => SetValue(ref _proportion, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public bool IsActive
        {
            get => _isActive;
            set => SetValue(ref _isActive, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public bool IsCollapsable
        {
            get => _isCollapsable;
            set => SetValue(ref _isCollapsable, value);
        }

        /// <inheritdoc/>
        [IgnoreDataMember]
        public bool CanGoBack => _navigateAdapter?.CanGoBack ?? false;

        /// <inheritdoc/>
        [IgnoreDataMember]
        public bool CanGoForward => _navigateAdapter?.CanGoForward ?? false;

        /// <inheritdoc/>
        public virtual void GoBack()
        {
            _navigateAdapter?.GoBack();
        }

        /// <inheritdoc/>
        public virtual void GoForward()
        {
            _navigateAdapter?.GoForward();
        }

        /// <inheritdoc/>
        public virtual void Navigate(object root)
        {
            _navigateAdapter?.Navigate(root, true);
        }

        /// <inheritdoc/>
        public virtual void Close()
        {
            _navigateAdapter?.Close();
        }
    }
}
