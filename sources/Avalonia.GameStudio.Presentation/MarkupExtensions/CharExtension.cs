using System;

using Avalonia.GameStudio.Presentation.Internal;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class CharExtension : MarkupExtension
    {
        public char Value { get; set; }

        public CharExtension(object value)
        {
            Value = Convert.ToChar(value);
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }

    public sealed class MaxCharExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CharBoxes.MaxValueBox;
        }
    }

    public sealed class MinCharExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CharBoxes.MinValueBox;
        }
    }
}
