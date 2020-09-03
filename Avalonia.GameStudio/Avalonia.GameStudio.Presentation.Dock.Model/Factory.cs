using System.Collections.Generic;
using System.Collections.ObjectModel;

using Avalonia.GameStudio.Presentation.Dock.Model.Controls;
using Avalonia.GameStudio.Presentation.Dock.Model.Core;

using Dock.Model;
using Dock.Model.Controls;

namespace Avalonia.GameStudio.Presentation.Dock.Model
{
    public abstract class Factory : FactoryBase
    {
        /// <inheritdoc/>
        public override IDockWindow CreateDockWindow()
        {
            return new DockWindow();
        }

        /// <inheritdoc/>
        public override IDocumentDock CreateDocumentDock()
        {
            return new DocumentDock();
        }

        /// <inheritdoc/>
        public override IList<T> CreateList<T>(params T[] items)
        {
            return new ObservableCollection<T>(items);
        }

        /// <inheritdoc/>
        public override IProportionalDock CreateProportionalDock()
        {
            return new ProportionalDock();
        }

        /// <inheritdoc/>
        public override IRootDock CreateRootDock()
        {
            return new RootDock();
        }

        /// <inheritdoc/>
        public override ISplitterDock CreateSplitterDock()
        {
            return new SplitterDock();
        }

        /// <inheritdoc/>
        public override IToolDock CreateToolDock()
        {
            return new ToolDock();
        }
    }
}
