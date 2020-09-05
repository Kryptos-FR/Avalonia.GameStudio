using System;

using Avalonia.GameStudio.Presentation.Internal;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class ByteExtension : MarkupExtension
    {
        public byte Value { get; set; }

        public ByteExtension(object value)
        {
            Value = Convert.ToByte(value);
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }

    public sealed class MaxByteExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return ByteBoxes.MaxValueBox;
        }
    }

    public sealed class MinByteExtension : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return ByteBoxes.MinValueBox;
        }
    }
}
