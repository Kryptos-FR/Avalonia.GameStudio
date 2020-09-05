using System;

using Avalonia.GameStudio.Presentation.Internal;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class DateTimeExtension : MarkupExtension
    {
        public DateTime Value { get; set; }

        public DateTimeExtension(object value)
        {
            Value = Convert.ToDateTime(value);
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }

    public sealed class MaxDateTimeExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return DateTimeBoxes.MaxValueBox;
        }
    }

    public sealed class MinDateTimeExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return DateTimeBoxes.MinValueBox;
        }
    }
}
