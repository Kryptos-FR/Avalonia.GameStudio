using System;

using Avalonia.GameStudio.Presentation.Internal;

using Moq;

using Xunit;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class LongExtensionTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData("0")]
        public void LongExtension_should_provide_long_value(object arg)
        {
            // Arrange
            var instance = new LongExtension(arg);
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<long>(value);
            Assert.Equal(0L, (long)value);
        }

        [Theory]
        [InlineData("-1.1")]
        [InlineData("a")]
        public void LongExtension_should_throw(object arg)
        {
            // Assert
            Assert.ThrowsAny<Exception>(() => new LongExtension(arg));
        }
    }

    public sealed class MaxLongExtensionTest
    {
        [Fact]
        public void MaxLongExtension_should_return_MaxValueBox()
        {
            // Arrange
            var instance = new MaxLongExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<long>(value);
            Assert.Same(Int64Boxes.MaxValueBox, value);
        }
    }

    public sealed class MinLongExtensionTest
    {
        [Fact]
        public void MinLongExtension_should_return_MinValueBox()
        {
            // Arrange
            var instance = new MinLongExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<long>(value);
            Assert.Same(Int64Boxes.MinValueBox, value);
        }
    }
}
