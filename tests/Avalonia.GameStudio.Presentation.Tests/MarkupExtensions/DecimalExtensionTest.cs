using System;

using Avalonia.GameStudio.Presentation.Internal;

using Moq;

using Xunit;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class DecimalExtensionTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData("0")]
        public void DecimalExtension_should_provide_decimal_value(object arg)
        {
            // Arrange
            var instance = new DecimalExtension(arg);
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<decimal>(value);
            Assert.Equal(0m, (decimal)value);
        }

        [Theory]
        [InlineData('a')]
        [InlineData("a")]
        public void DecimalExtension_should_throw(object arg)
        {
            // Assert
            Assert.ThrowsAny<Exception>(() => new DecimalExtension(arg));
        }
    }

    public sealed class MaxDecimalExtensionTest
    {
        [Fact]
        public void MaxDecimalExtension_should_return_MaxValueBox()
        {
            // Arrange
            var instance = new MaxDecimalExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<decimal>(value);
            Assert.Same(DecimalBoxes.MaxValueBox, value);
        }
    }

    public sealed class MinDecimalExtensionTest
    {
        [Fact]
        public void MinDecimalExtension_should_return_MinValueBox()
        {
            // Arrange
            var instance = new MinDecimalExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<decimal>(value);
            Assert.Same(DecimalBoxes.MinValueBox, value);
        }
    }
}
