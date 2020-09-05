using System.Runtime.Serialization;

using Avalonia.GameStudio.Presentation.ViewModels;

using Dock.Model;
using Dock.Model.Controls;

namespace Avalonia.GameStudio.Presentation.Dock.Model.Core
{

    /// <summary>
    /// Dock window.
    /// </summary>
    [DataContract(IsReference = true)]
    public class DockWindow : ViewModelBase, IDockWindow
    {
        private IHostAdapter _hostAdapter;
        private string _id;
        private double _x;
        private double _y;
        private double _width;
        private double _height;
        private bool _topmost;
        private string _title;
        private IDockable? _owner;
        private IFactory? _factory;
        private IRootDock? _layout;
        private IHostWindow? _host;

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public string Id
        {
            get => _id;
            set => SetValue(ref _id, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = true, EmitDefaultValue = true)]
        public double X
        {
            get => _x;
            set => SetValue(ref _x, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = true, EmitDefaultValue = true)]
        public double Y
        {
            get => _y;
            set => SetValue(ref _y, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = true, EmitDefaultValue = true)]
        public double Width
        {
            get => _width;
            set => SetValue(ref _width, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = true, EmitDefaultValue = true)]
        public double Height
        {
            get => _height;
            set => SetValue(ref _height, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public bool Topmost
        {
            get => _topmost;
            set => SetValue(ref _topmost, value);
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
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public IRootDock? Layout
        {
            get => _layout;
            set => SetValue(ref _layout, value);
        }

        /// <inheritdoc/>
        [IgnoreDataMember]
        public IHostWindow? Host
        {
            get => _host;
            set => SetValue(ref _host, value);
        }

        /// <summary>
        /// Initializes new instance of the <see cref="DockWindow"/> class.
        /// </summary>
        public DockWindow()
        {
            _id = nameof(IDockWindow);
            _title = nameof(IDockWindow);
            _hostAdapter = new HostAdapter(this);
        }

        /// <inheritdoc/>
        public void Save()
        {
            _hostAdapter.Save();
        }

        /// <inheritdoc/>
        public void Present(bool isDialog)
        {
            _hostAdapter.Present(isDialog);
        }

        /// <inheritdoc/>
        public void Exit()
        {
            _hostAdapter.Exit();
        }

        /// <inheritdoc/>
        public IDockWindow? Clone()
        {
            return CloneHelper.CloneDockWindow(this);
        }
    }
}
