using System.Collections.Generic;
using System.Runtime.Serialization;

using Avalonia.GameStudio.Presentation.Dock.Model.Core;

using Dock.Model;
using Dock.Model.Controls;

namespace Avalonia.GameStudio.Presentation.Dock.Model.Controls
{
    /// <summary>
    /// Root dock.
    /// </summary>
    [DataContract(IsReference = true)]
    public class RootDock : DockBase, IRootDock
    {
        private bool _isFocusableRoot;
        private IDockWindow? _window;
        private IList<IDockWindow>? _windows;

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public bool IsFocusableRoot
        {
            get => _isFocusableRoot;
            set => SetValue(ref _isFocusableRoot, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public IDockWindow? Window
        {
            get => _window;
            set => SetValue(ref _window, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public IList<IDockWindow>? Windows
        {
            get => _windows;
            set => SetValue(ref _windows, value);
        }

        /// <summary>
        /// Initializes new instance of the <see cref="RootDock"/> class.
        /// </summary>
        public RootDock()
        {
            Id = nameof(IRootDock);
            Title = nameof(IRootDock);
        }

        /// <inheritdoc/>
        public virtual void ShowWindows()
        {
            _navigateAdapter?.ShowWindows();
        }

        /// <inheritdoc/>
        public virtual void ExitWindows()
        {
            _navigateAdapter?.ExitWindows();
        }

        /// <inheritdoc/>
        public override IDockable? Clone()
        {
            return CloneHelper.CloneRootDock(this);
        }
    }
}
