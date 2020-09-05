using System;

using Avalonia.GameStudio.Presentation.Internal;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class FloatExtension : MarkupExtension
    {
        public float Value { get; set; }

        public FloatExtension(object value)
        {
            Value = Convert.ToSingle(value);
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }

    public sealed class MaxFloatExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return SingleBoxes.MaxValueBox;
        }
    }

    public sealed class MinFloatExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return SingleBoxes.MinValueBox;
        }
    }
}
