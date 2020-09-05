using System;

using Avalonia.GameStudio.Presentation.Internal;

using Moq;

using Xunit;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class ByteExtensionTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData("0")]
        public void ByteExtension_should_provide_byte_value(object arg)
        {
            // Arrange
            var instance = new ByteExtension(arg);
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<byte>(value);
            Assert.Equal((byte)0, (byte)value);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData("a")]
        public void ByteExtension_should_throw(object arg)
        {
            // Assert
            Assert.ThrowsAny<Exception>(() => new ByteExtension(arg));
        }
    }

    public sealed class MaxByteExtensionTest
    {
        [Fact]
        public void MaxByteExtension_should_return_MaxValueBox()
        {
            // Arrange
            var instance = new MaxByteExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<byte>(value);
            Assert.Same(ByteBoxes.MaxValueBox, value);
        }
    }

    public sealed class MinByteExtensionTest
    {
        [Fact]
        public void MinByteExtension_should_return_MinValueBox()
        {
            // Arrange
            var instance = new MinByteExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<byte>(value);
            Assert.Same(ByteBoxes.MinValueBox, value);
        }
    }
}
