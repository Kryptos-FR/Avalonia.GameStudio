using System;

using Xunit;

namespace Avalonia.GameStudio.Presentation.Internal
{
    public class TimeSpanBoxesTest
    {
        [Fact]
        public void MaxValueBox_should_return_MaxValue()
        {
            // Act
            var value = (TimeSpan)TimeSpanBoxes.MaxValueBox;
            // Assert 
            Assert.Equal(TimeSpan.MaxValue, value);
        }

        [Fact]
        public void MaxValueBox_should_return_same_instance()
        {
            // Act
            var value1 = TimeSpanBoxes.MaxValueBox;
            var value2 = TimeSpanBoxes.MaxValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }

        [Fact]
        public void MinValueBox_should_return_MinValue()
        {
            // Act
            var value = (TimeSpan)TimeSpanBoxes.MinValueBox;
            // Assert 
            Assert.Equal(TimeSpan.MinValue, value);
        }

        [Fact]
        public void MinValueBox_should_return_same_instance()
        {
            // Act
            var value1 = TimeSpanBoxes.MinValueBox;
            var value2 = TimeSpanBoxes.MinValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }

        [Fact]
        public void ZeroBox_should_return_Zero()
        {
            // Act
            var value = (TimeSpan)TimeSpanBoxes.ZeroBox;
            // Assert 
            Assert.Equal(TimeSpan.Zero, value);
        }

        [Fact]
        public void ZeroBox_should_return_same_instance()
        {
            // Act
            var value1 = TimeSpanBoxes.ZeroBox;
            var value2 = TimeSpanBoxes.ZeroBox;
            // Assert 
            Assert.Same(value1, value2);
        }
    }
}
