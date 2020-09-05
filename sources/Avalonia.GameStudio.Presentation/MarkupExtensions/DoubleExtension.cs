using System;

using Avalonia.GameStudio.Presentation.Internal;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class DoubleExtension : MarkupExtension
    {
        public double Value { get; set; }

        public DoubleExtension(object value)
        {
            Value = Convert.ToDouble(value);
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }

    public sealed class MaxDoubleExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return DoubleBoxes.MaxValueBox;
        }
    }

    public sealed class MinDoubleExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return DoubleBoxes.MinValueBox;
        }
    }
}
