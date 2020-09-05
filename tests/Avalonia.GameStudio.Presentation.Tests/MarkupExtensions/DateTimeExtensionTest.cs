using System;

using Avalonia.GameStudio.Presentation.Internal;

using Moq;

using Xunit;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class DateTimeExtensionTest
    {
        [Theory]
        [InlineData("2020-01-01")]
        [InlineData("2020/01/01")]
        public void DateTimeExtension_should_provide_DateTime_value(object arg)
        {
            // Arrange
            var instance = new DateTimeExtension(arg);
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<DateTime>(value);
            Assert.Equal(DateTime.Parse("2020-01-01"), (DateTime)value);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData("a")]
        public void DateTimeExtension_should_throw(object arg)
        {
            // Assert
            Assert.ThrowsAny<Exception>(() => new DateTimeExtension(arg));
        }
    }

    public sealed class MaxDateTimeExtensionTest
    {
        [Fact]
        public void MaxDateTimeExtension_should_return_MaxValueBox()
        {
            // Arrange
            var instance = new MaxDateTimeExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<DateTime>(value);
            Assert.Same(DateTimeBoxes.MaxValueBox, value);
        }
    }

    public sealed class MinDateTimeExtensionTest
    {
        [Fact]
        public void MinDateTimeExtension_should_return_MinValueBox()
        {
            // Arrange
            var instance = new MinDateTimeExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<DateTime>(value);
            Assert.Same(DateTimeBoxes.MinValueBox, value);
        }
    }
}
