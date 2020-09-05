using System.Runtime.Serialization;

using Avalonia.GameStudio.Presentation.ViewModels;

using Dock.Model;

namespace Avalonia.GameStudio.Presentation.Dock.Model.Core
{
    /// <summary>
    /// Dockable base class.
    /// </summary>
    [DataContract(IsReference = true)]
    public abstract class DockableBase : ViewModelBase, IDockable
    {
        private string _id = string.Empty;
        private string _title = string.Empty;
        private object? _context;
        private IDockable? _owner;
        private IFactory? _factory;

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public string Id
        {
            get => _id;
            set => SetValue(ref _id, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public string Title
        {
            get => _title;
            set => SetValue(ref _title, value);
        }

        /// <inheritdoc/>
        [IgnoreDataMember]
        public object? Context
        {
            get => _context;
            set => SetValue(ref _context, value);
        }

        /// <inheritdoc/>
        [IgnoreDataMember]
        public IDockable? Owner
        {
            get => _owner;
            set => SetValue(ref _owner, value);
        }

        /// <inheritdoc/>
        [IgnoreDataMember]
        public IFactory? Factory
        {
            get => _factory;
            set => SetValue(ref _factory, value);
        }

        /// <inheritdoc/>
        public virtual bool OnClose()
        {
            return true;
        }

        /// <inheritdoc/>
        public virtual void OnSelected()
        {
        }

        /// <inheritdoc/>
        public abstract IDockable? Clone();
    }
}
