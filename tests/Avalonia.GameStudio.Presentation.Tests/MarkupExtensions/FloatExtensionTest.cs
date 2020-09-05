using System;

using Avalonia.GameStudio.Presentation.Internal;

using Moq;

using Xunit;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class FloatExtensionTest
    {
        [Theory]
        [InlineData(0f)]
        [InlineData("0")]
        public void FloatExtension_should_provide_float_value(object arg)
        {
            // Arrange
            var instance = new FloatExtension(arg);
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<float>(value);
            Assert.Equal(0f, (float)value);
        }

        [Theory]
        [InlineData('a')]
        [InlineData("a")]
        public void FloatExtension_should_throw(object arg)
        {
            // Assert
            Assert.ThrowsAny<Exception>(() => new FloatExtension(arg));
        }
    }

    public sealed class MaxFloatExtensionTest
    {
        [Fact]
        public void MaxFloatExtension_should_return_MaxValueBox()
        {
            // Arrange
            var instance = new MaxFloatExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<float>(value);
            Assert.Same(SingleBoxes.MaxValueBox, value);
        }
    }

    public sealed class MinFloatExtensionTest
    {
        [Fact]
        public void MinFloatExtension_should_return_MinValueBox()
        {
            // Arrange
            var instance = new MinFloatExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<float>(value);
            Assert.Same(SingleBoxes.MinValueBox, value);
        }
    }
}
