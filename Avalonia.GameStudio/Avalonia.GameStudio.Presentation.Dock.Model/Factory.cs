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
        public override IDockWindow CreateDockWindow()
        {
            return new DockWindow();
        }

        public override IDocumentDock CreateDocumentDock()
        {
            return new DocumentDock();
        }

        public override IList<T> CreateList<T>(params T[] items)
        {
            return new ObservableCollection<T>(items);
        }

        public override IPinDock CreatePinDock()
        {
            return new PinDock();
        }

        public override IProportionalDock CreateProportionalDock()
        {
            return new ProportionalDock();
        }

        public override IRootDock CreateRootDock()
        {
            return new RootDock();
        }

        public override ISplitterDock CreateSplitterDock()
        {
            return new SplitterDock();
        }

        public override IToolDock CreateToolDock()
        {
            return new ToolDock();
        }
    }
}
