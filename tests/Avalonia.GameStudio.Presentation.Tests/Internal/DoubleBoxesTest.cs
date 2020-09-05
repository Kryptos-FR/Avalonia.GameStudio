
using Xunit;

namespace Avalonia.GameStudio.Presentation.Internal
{
    public class DoubleBoxesTest
    {
        [Fact]
        public void MaxValueBox_should_return_MaxValue()
        {
            // Act
            var value = (double)DoubleBoxes.MaxValueBox;
            // Assert 
            Assert.Equal(double.MaxValue, value);
        }

        [Fact]
        public void MaxValueBox_should_return_same_instance()
        {
            // Act
            var value1 = DoubleBoxes.MaxValueBox;
            var value2 = DoubleBoxes.MaxValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }

        [Fact]
        public void MinValueBox_should_return_MinValue()
        {
            // Act
            var value = (double)DoubleBoxes.MinValueBox;
            // Assert 
            Assert.Equal(double.MinValue, value);
        }

        [Fact]
        public void MinValueBox_should_return_same_instance()
        {
            // Act
            var value1 = DoubleBoxes.MinValueBox;
            var value2 = DoubleBoxes.MinValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }
    }
}
