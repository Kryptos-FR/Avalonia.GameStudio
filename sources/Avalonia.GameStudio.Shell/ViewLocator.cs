using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.GameStudio.Presentation.ViewModels;

namespace Avalonia.GameStudio.Shell
{
    public class ViewLocator : IDataTemplate
    {
        /// <inheritdoc />
        public bool SupportsRecycling => false;

        /// <inheritdoc />
        public IControl Build(object data)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type is not null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        /// <inheritdoc />
        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}