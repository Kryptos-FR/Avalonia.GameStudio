using System;

namespace Avalonia.GameStudio.Presentation.Internal
{
    internal static class BooleanBoxes
    {
        /// <summary>
        /// An object representing the value <c>false</c>.
        /// </summary>
        internal static readonly object FalseBox = false;
        /// <summary>
        /// An object representing the value <c>true</c>.
        /// </summary>
        internal static readonly object TrueBox = true;

        /// <summary>
        /// Returns an object representing the provided <see cref="bool"/> <paramref name="value"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>A boxed <see cref="bool"/> equivalent to the provided <paramref name="value"/>.</returns>
        internal static object Box(this bool value)
        {
            return value ? TrueBox : FalseBox;
        }
    }

    internal static class ByteBoxes
    {
        /// <summary>
        /// An object representing the value <c>byte.MaxValue</c>.
        /// </summary>
        internal static readonly object MaxValueBox = byte.MaxValue;
        /// <summary>
        /// An object representing the value <c>byte.MinValue</c>.
        /// </summary>
        internal static readonly object MinValueBox = byte.MinValue;
    }

    internal static class CharBoxes
    {
        /// <summary>
        /// An object representing the value <c>char.MaxValue</c>.
        /// </summary>
        internal static readonly object MaxValueBox = char.MaxValue;
        /// <summary>
        /// An object representing the value <c>char.MinValue</c>.
        /// </summary>
        internal static readonly object MinValueBox = char.MinValue;
    }

    internal static class DateTimeBoxes
    {
        /// <summary>
        /// An object representing the value <c>DateTime.MaxValue</c>.
        /// </summary>
        internal static readonly object MaxValueBox = DateTime.MaxValue;
        /// <summary>
        /// An object representing the value <c>DateTime.MinValue</c>.
        /// </summary>
        internal static readonly object MinValueBox = DateTime.MinValue;
    }

    internal static class DecimalBoxes
    {
        /// <summary>
        /// An object representing the value <c>decimal.MaxValue</c>.
        /// </summary>
        internal static readonly object MaxValueBox = decimal.MaxValue;
        /// <summary>
        /// An object representing the value <c>decimal.MinValue</c>.
        /// </summary>
        internal static readonly object MinValueBox = decimal.MinValue;
    }

    internal static class DoubleBoxes
    {
        /// <summary>
        /// An object representing the value <c>double.MaxValue</c>.
        /// </summary>
        internal static readonly object MaxValueBox = double.MaxValue;
        /// <summary>
        /// An object representing the value <c>double.MinValue</c>.
        /// </summary>
        internal static readonly object MinValueBox = double.MinValue;
    }

    internal static class GuidBoxes
    {
        /// <summary>
        /// An object representing the value <c>Guid.Empty</c>.
        /// </summary>
        internal static readonly object EmptyBox = Guid.Empty;
    }

    internal static class Int16Boxes
    {
        /// <summary>
        /// An object representing the value <c>short.MaxValue</c>.
        /// </summary>
        internal static readonly object MaxValueBox = short.MaxValue;
        /// <summary>
        /// An object representing the value <c>short.MinValue</c>.
        /// </summary>
        internal static readonly object MinValueBox = short.MinValue;
    }

    internal static class Int32Boxes
    {
        /// <summary>
        /// An object representing the value <c>int.MaxValue</c>.
        /// </summary>
        internal static readonly object MaxValueBox = int.MaxValue;
        /// <summary>
        /// An object representing the value <c>int.MinValue</c>.
        /// </summary>
        internal static readonly object MinValueBox = int.MinValue;
    }

    internal static class Int64Boxes
    {
        /// <summary>
        /// An object representing the value <c>long.MaxValue</c>.
        /// </summary>
        internal static readonly object MaxValueBox = long.MaxValue;
        /// <summary>
        /// An object representing the value <c>long.MinValue</c>.
        /// </summary>
        internal static readonly object MinValueBox = long.MinValue;
    }

    internal static class SingleBoxes
    {
        /// <summary>
        /// An object representing the value <c>float.MaxValue</c>.
        /// </summary>
        internal static readonly object MaxValueBox = float.MaxValue;
        /// <summary>
        /// An object representing the value <c>float.MinValue</c>.
        /// </summary>
        internal static readonly object MinValueBox = float.MinValue;
    }

    internal static class TimeSpanBoxes
    {
        /// <summary>
        /// An object representing the value <c>TimeSpan.MaxValue</c>.
        /// </summary>
        internal static readonly object MaxValueBox = TimeSpan.MaxValue;
        /// <summary>
        /// An object representing the value <c>TimeSpan.MinValue</c>.
        /// </summary>
        internal static readonly object MinValueBox = TimeSpan.MinValue;
        /// <summary>
        /// An object representing the value <c>TimeSpan.Zero</c>.
        /// </summary>
        internal static readonly object ZeroBox = TimeSpan.Zero;
    }
}
