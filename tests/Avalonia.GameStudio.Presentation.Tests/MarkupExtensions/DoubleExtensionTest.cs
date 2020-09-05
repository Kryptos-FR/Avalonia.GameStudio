using System;

using Avalonia.GameStudio.Presentation.Internal;

using Moq;

using Xunit;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class DoubleExtensionTest
    {
        [Theory]
        [InlineData(0d)]
        [InlineData("0")]
        public void DoubleExtension_should_provide_double_value(object arg)
        {
            // Arrange
            var instance = new DoubleExtension(arg);
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<double>(value);
            Assert.Equal(0d, (double)value);
        }

        [Theory]
        [InlineData('a')]
        [InlineData("a")]
        public void DoubleExtension_should_throw(object arg)
        {
            // Assert
            Assert.ThrowsAny<Exception>(() => new DoubleExtension(arg));
        }
    }

    public sealed class MaxDoubleExtensionTest
    {
        [Fact]
        public void MaxDoubleExtension_should_return_MaxValueBox()
        {
            // Arrange
            var instance = new MaxDoubleExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<double>(value);
            Assert.Same(DoubleBoxes.MaxValueBox, value);
        }
    }

    public sealed class MinDoubleExtensionTest
    {
        [Fact]
        public void MinDoubleExtension_should_return_MinValueBox()
        {
            // Arrange
            var instance = new MinDoubleExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<double>(value);
            Assert.Same(DoubleBoxes.MinValueBox, value);
        }
    }
}
