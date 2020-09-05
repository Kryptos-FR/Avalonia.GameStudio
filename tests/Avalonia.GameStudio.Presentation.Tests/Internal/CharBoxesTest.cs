
using Xunit;

namespace Avalonia.GameStudio.Presentation.Internal
{
    public class CharBoxesTest
    {
        [Fact]
        public void MaxValueBox_should_return_MaxValue()
        {
            // Act
            var value = (char)CharBoxes.MaxValueBox;
            // Assert 
            Assert.Equal(char.MaxValue, value);
        }

        [Fact]
        public void MaxValueBox_should_return_same_instance()
        {
            // Act
            var value1 = CharBoxes.MaxValueBox;
            var value2 = CharBoxes.MaxValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }

        [Fact]
        public void MinValueBox_should_return_MinValue()
        {
            // Act
            var value = (char)CharBoxes.MinValueBox;
            // Assert 
            Assert.Equal(char.MinValue, value);
        }

        [Fact]
        public void MinValueBox_should_return_same_instance()
        {
            // Act
            var value1 = CharBoxes.MinValueBox;
            var value2 = CharBoxes.MinValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }
    }
}
