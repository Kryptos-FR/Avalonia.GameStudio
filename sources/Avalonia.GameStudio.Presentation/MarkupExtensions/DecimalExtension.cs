using System;

using Avalonia.GameStudio.Presentation.Internal;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class DecimalExtension : MarkupExtension
    {
        public decimal Value { get; set; }

        public DecimalExtension(object value)
        {
            Value = Convert.ToDecimal(value);
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }

    public sealed class MaxDecimalExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return DecimalBoxes.MaxValueBox;
        }
    }

    public sealed class MinDecimalExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return DecimalBoxes.MinValueBox;
        }
    }
}
