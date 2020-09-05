using System;

using Avalonia.GameStudio.Presentation.Internal;

using Moq;

using Xunit;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class IntExtensionTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData("0")]
        public void IntExtension_should_provide_int_value(object arg)
        {
            // Arrange
            var instance = new IntExtension(arg);
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<int>(value);
            Assert.Equal(0, (int)value);
        }

        [Theory]
        [InlineData("-1.1")]
        [InlineData("a")]
        public void IntExtension_should_throw(object arg)
        {
            // Assert
            Assert.ThrowsAny<Exception>(() => new IntExtension(arg));
        }
    }

    public sealed class MaxIntExtensionTest
    {
        [Fact]
        public void MaxIntExtension_should_return_MaxValueBox()
        {
            // Arrange
            var instance = new MaxIntExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<int>(value);
            Assert.Same(Int32Boxes.MaxValueBox, value);
        }
    }

    public sealed class MinIntExtensionTest
    {
        [Fact]
        public void MinIntExtension_should_return_MinValueBox()
        {
            // Arrange
            var instance = new MinIntExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<int>(value);
            Assert.Same(Int32Boxes.MinValueBox, value);
        }
    }
}
