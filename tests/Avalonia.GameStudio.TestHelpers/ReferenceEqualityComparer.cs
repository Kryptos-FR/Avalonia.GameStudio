using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Avalonia.GameStudio.TestHelpers
{
    public sealed class ReferenceEqualityComparer : IEqualityComparer, IEqualityComparer<object>
    {
        public static ReferenceEqualityComparer Default { get; } = new ReferenceEqualityComparer();

        /// <inheritdoc/>
        public new bool Equals(object? x, object? y)
        {
            return ReferenceEquals(x, y);
        }

        /// <inheritdoc/>
        public int GetHashCode(object obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }
    }
}
