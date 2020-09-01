using System.Runtime.Serialization;

using Avalonia.GameStudio.Presentation.Dock.Model.Core;

using Dock.Model;
using Dock.Model.Controls;

namespace Avalonia.GameStudio.Presentation.Dock.Model.Controls
{
    /// <summary>
    /// Splitter dock.
    /// </summary>
    [DataContract(IsReference = true)]
    public class SplitterDock : DockBase, ISplitterDock
    {
        /// <summary>
        /// Initializes new instance of the <see cref="SplitterDock"/> class.
        /// </summary>
        public SplitterDock()
        {
            Id = nameof(ISplitterDock);
            Title = nameof(ISplitterDock);
        }

        /// <inheritdoc/>
        public override IDockable? Clone()
        {
            return CloneHelper.CloneSplitterDock(this);
        }
    }
}
