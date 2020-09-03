using System;
using System.Collections.Generic;

using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.GameStudio.Presentation.Dock.Model;
using Avalonia.GameStudio.Presentation.Dock.Model.Controls;

using Dock.Avalonia.Controls;
using Dock.Model;
using Dock.Model.Controls;

namespace Avalonia.GameStudio.Shell
{
    internal sealed class MainDockFactory : Factory
    {
        /// <inheritdoc />
        public override IDock CreateLayout()
        {
            var mainLayout = new ProportionalDock
            {
                Id = "MainLayout",
                Title = "MainLayout",
                Proportion = double.NaN,
                Orientation = Orientation.Horizontal,
                ActiveDockable = null,
                VisibleDockables = CreateList<IDockable>(
                   new ProportionalDock
                   {
                       Id = "LeftPane",
                       Title = "LeftPane",
                       Proportion = double.NaN,
                       Orientation = Orientation.Vertical,
                       ActiveDockable = null
                   },
                   new SplitterDock()
                   {
                       Id = "LeftSplitter",
                       Title = "LeftSplitter"
                   },
                   new DocumentDock
                   {
                       Id = "DocumentsPane",
                       Title = "DocumentsPane",
                       Proportion = double.NaN,
                       ActiveDockable = null,
                   },
                   new SplitterDock()
                   {
                       Id = "RightSplitter",
                       Title = "RightSplitter"
                   },
                   new ProportionalDock
                   {
                       Id = "RightPane",
                       Title = "RightPane",
                       Proportion = double.NaN,
                       Orientation = Orientation.Vertical,
                       ActiveDockable = null,
                   })
            };

            var mainView = new RootDock
            {
                Id = "Main",
                Title = "Main",
                ActiveDockable = mainLayout,
                VisibleDockables = CreateList<IDockable>(mainLayout)
            };

            var root = CreateRootDock();
            root.ActiveDockable = mainView;
            root.DefaultDockable = mainView;
            root.VisibleDockables = CreateList<IDockable>(mainView);
            return root;
        }

        /// <inheritdoc />
        public override IRootDock CreateRootDock()
        {
            var root = base.CreateRootDock();
            root.Id = "Root";
            root.Title = "Root";
            return root;
        }

        /// <inheritdoc />
        public override void InitLayout(IDockable layout)
        {
            var dummyContext = new object();
            ContextLocator = new Dictionary<string, Func<object>>
            {
                [nameof(IRootDock)] = () => dummyContext,
                [nameof(IProportionalDock)] = () => dummyContext,
                [nameof(IDocumentDock)] = () => dummyContext,
                [nameof(IToolDock)] = () => dummyContext,
                [nameof(ISplitterDock)] = () => dummyContext,
                [nameof(IDockWindow)] = () => dummyContext,
                [nameof(IDocument)] = () => dummyContext,
                [nameof(ITool)] = () => dummyContext,
            };

            HostWindowLocator = new Dictionary<string, Func<IHostWindow>>
            {
                [nameof(IDockWindow)] = () =>
                {
                    var hostWindow = new HostWindow()
                    {
                        [!Window.TitleProperty] = new Binding("ActiveDockable.Title")
                    };
                    return hostWindow;
                }
            };

            DockableLocator = new Dictionary<string, Func<IDockable>>
            {
            };

            base.InitLayout(layout);
        }
    }
}
