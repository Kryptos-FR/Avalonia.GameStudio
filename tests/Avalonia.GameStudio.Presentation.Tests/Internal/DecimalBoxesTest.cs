
using Xunit;

namespace Avalonia.GameStudio.Presentation.Internal
{
    public class DecimalBoxesTest
    {
        [Fact]
        public void MaxValueBox_should_return_MaxValue()
        {
            // Act
            var value = (decimal)DecimalBoxes.MaxValueBox;
            // Assert 
            Assert.Equal(decimal.MaxValue, value);
        }

        [Fact]
        public void MaxValueBox_should_return_same_instance()
        {
            // Act
            var value1 = DecimalBoxes.MaxValueBox;
            var value2 = DecimalBoxes.MaxValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }

        [Fact]
        public void MinValueBox_should_return_MinValue()
        {
            // Act
            var value = (decimal)DecimalBoxes.MinValueBox;
            // Assert 
            Assert.Equal(decimal.MinValue, value);
        }

        [Fact]
        public void MinValueBox_should_return_same_instance()
        {
            // Act
            var value1 = DecimalBoxes.MinValueBox;
            var value2 = DecimalBoxes.MinValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }
    }
}
