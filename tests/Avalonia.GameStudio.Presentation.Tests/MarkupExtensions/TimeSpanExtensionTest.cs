using System;

using Avalonia.GameStudio.Presentation.Internal;

using Moq;

using Xunit;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class TimeSpanExtensionTest
    {
        [Theory]
        [InlineData("00:10")]
        public void TimeSpanExtension_should_provide_TimeSpan_value(object arg)
        {
            // Arrange
            var instance = new TimeSpanExtension(arg);
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<TimeSpan>(value);
            Assert.Equal(TimeSpan.FromMinutes(10), (TimeSpan)value);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData("a")]
        public void TimeSpanExtension_should_return_ZeroBox(object arg)
        {
            // Arrange
            var instance = new TimeSpanExtension(arg);
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<TimeSpan>(value);
            Assert.Same(TimeSpanBoxes.ZeroBox, value);
        }
    }

    public sealed class MaxTimeSpanExtensionTest
    {
        [Fact]
        public void MaxTimeSpanExtension_should_return_MaxValueBox()
        {
            // Arrange
            var instance = new MaxTimeSpanExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<TimeSpan>(value);
            Assert.Same(TimeSpanBoxes.MaxValueBox, value);
        }
    }

    public sealed class MinTimeSpanExtensionTest
    {
        [Fact]
        public void MinTimeSpanExtension_should_return_MinValueBox()
        {
            // Arrange
            var instance = new MinTimeSpanExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<TimeSpan>(value);
            Assert.Same(TimeSpanBoxes.MinValueBox, value);
        }
    }
}
