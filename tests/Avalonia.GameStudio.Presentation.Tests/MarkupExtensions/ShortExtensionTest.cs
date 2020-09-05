using System;

using Avalonia.GameStudio.Presentation.Internal;

using Moq;

using Xunit;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class ShortExtensionTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData("0")]
        public void ShortExtension_should_provide_short_value(object arg)
        {
            // Arrange
            var instance = new ShortExtension(arg);
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<short>(value);
            Assert.Equal((short)0, (short)value);
        }

        [Theory]
        [InlineData("-1.1")]
        [InlineData("a")]
        public void ShortExtension_should_throw(object arg)
        {
            // Assert
            Assert.ThrowsAny<Exception>(() => new ShortExtension(arg));
        }
    }

    public sealed class MaxShortExtensionTest
    {
        [Fact]
        public void MaxShortExtension_should_return_MaxValueBox()
        {
            // Arrange
            var instance = new MaxShortExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<short>(value);
            Assert.Same(Int16Boxes.MaxValueBox, value);
        }
    }

    public sealed class MinShortExtensionTest
    {
        [Fact]
        public void MinShortExtension_should_return_MinValueBox()
        {
            // Arrange
            var instance = new MinShortExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<short>(value);
            Assert.Same(Int16Boxes.MinValueBox, value);
        }
    }
}
