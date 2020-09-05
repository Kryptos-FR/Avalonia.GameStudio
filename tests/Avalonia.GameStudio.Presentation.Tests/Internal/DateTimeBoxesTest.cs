using System;

using Xunit;

namespace Avalonia.GameStudio.Presentation.Internal
{
    public class DateTimeBoxesTest
    {
        [Fact]
        public void MaxValueBox_should_return_MaxValue()
        {
            // Act
            var value = (DateTime)DateTimeBoxes.MaxValueBox;
            // Assert 
            Assert.Equal(DateTime.MaxValue, value);
        }

        [Fact]
        public void MaxValueBox_should_return_same_instance()
        {
            // Act
            var value1 = DateTimeBoxes.MaxValueBox;
            var value2 = DateTimeBoxes.MaxValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }

        [Fact]
        public void MinValueBox_should_return_MinValue()
        {
            // Act
            var value = (DateTime)DateTimeBoxes.MinValueBox;
            // Assert 
            Assert.Equal(DateTime.MinValue, value);
        }

        [Fact]
        public void MinValueBox_should_return_same_instance()
        {
            // Act
            var value1 = DateTimeBoxes.MinValueBox;
            var value2 = DateTimeBoxes.MinValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }
    }
}
