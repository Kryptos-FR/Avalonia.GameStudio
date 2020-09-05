using System;

using Avalonia.GameStudio.Presentation.Internal;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class ShortExtension : MarkupExtension
    {
        public short Value { get; set; }

        public ShortExtension(object value)
        {
            Value = Convert.ToInt16(value);
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }

    public sealed class MaxShortExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Int16Boxes.MaxValueBox;
        }
    }

    public sealed class MinShortExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Int16Boxes.MinValueBox;
        }
    }
}
