using System.Runtime.Serialization;

using Avalonia.GameStudio.Presentation.Dock.Model.Core;

using Dock.Model;
using Dock.Model.Controls;

namespace Avalonia.GameStudio.Presentation.Dock.Model.Controls
{
    /// <summary>
    /// Document.
    /// </summary>
    [DataContract(IsReference = true)]
    public abstract class Document : DockableBase, IDocument
    {
        /// <summary>
        /// Initializes new instance of the <see cref="Document"/> class.
        /// </summary>
        public Document()
        {
            Id = nameof(IDocument);
            Title = nameof(IDocument);
        }

        /// <inheritdoc/>
        public override IDockable? Clone()
        {
            return this;
        }
    }
}
