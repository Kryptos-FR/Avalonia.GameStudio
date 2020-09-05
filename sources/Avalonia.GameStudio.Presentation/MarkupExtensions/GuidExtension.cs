using System;

using Avalonia.GameStudio.Presentation.Internal;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class GuidExtension : MarkupExtension
    {
        public Guid Value { get; set; }

        public GuidExtension(object value)
        {
            Guid.TryParse(value as string, out Guid guid);
            Value = guid;
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value == Guid.Empty ? GuidBoxes.EmptyBox : Value;
        }
    }

    public sealed class EmptyGuidExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return GuidBoxes.EmptyBox;
        }
    }
}
