using System;

using Avalonia.GameStudio.Presentation.Internal;

using Moq;

using Xunit;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class CharExtensionTest
    {
        [Theory]
        [InlineData('0')]
        [InlineData("0")]
        public void CharExtension_should_provide_char_value(object arg)
        {
            // Arrange
            var instance = new CharExtension(arg);
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<char>(value);
            Assert.Equal('0', (char)value);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData("aa")]
        public void CharExtension_should_throw(object arg)
        {
            // Assert
            Assert.ThrowsAny<Exception>(() => new CharExtension(arg));
        }
    }

    public sealed class MaxCharExtensionTest
    {
        [Fact]
        public void MaxCharExtension_should_return_MaxValueBox()
        {
            // Arrange
            var instance = new MaxCharExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<char>(value);
            Assert.Same(CharBoxes.MaxValueBox, value);
        }
    }

    public sealed class MinCharExtensionTest
    {
        [Fact]
        public void MinCharExtension_should_return_MinValueBox()
        {
            // Arrange
            var instance = new MinCharExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<char>(value);
            Assert.Same(CharBoxes.MinValueBox, value);
        }
    }
}
