using System.Runtime.Serialization;

using Avalonia.GameStudio.Presentation.Dock.Model.Core;

using Dock.Model;
using Dock.Model.Controls;

namespace Avalonia.GameStudio.Presentation.Dock.Model.Controls
{
    /// <summary>
    /// Proportional dock.
    /// </summary>
    [DataContract(IsReference = true)]
    public class ProportionalDock : DockBase, IProportionalDock
    {
        private Orientation _orientation;

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public Orientation Orientation
        {
            get => _orientation;
            set => SetValue(ref _orientation, value);
        }

        /// <summary>
        /// Initializes new instance of the <see cref="ProportionalDock"/> class.
        /// </summary>
        public ProportionalDock()
        {
            Id = nameof(IProportionalDock);
            Title = nameof(IProportionalDock);
        }

        /// <inheritdoc/>
        public override IDockable? Clone()
        {
            return CloneHelper.CloneProportionalDock(this);
        }
    }
}
