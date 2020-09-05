using System;

using Avalonia.GameStudio.Presentation.Internal;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class TimeSpanExtension : MarkupExtension
    {
        public TimeSpan Value { get; set; }

        public TimeSpanExtension()
        {
            Value = TimeSpan.Zero;
        }

        public TimeSpanExtension(object value)
        {
            TimeSpan.TryParse(value as string, out TimeSpan timeSpan);
            Value = timeSpan;
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value == TimeSpan.Zero ? TimeSpanBoxes.ZeroBox : Value;
        }
    }

    public sealed class MaxTimeSpanExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return TimeSpanBoxes.MaxValueBox;
        }
    }

    public sealed class MinTimeSpanExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return TimeSpanBoxes.MinValueBox;
        }
    }
}
