using Xunit;

namespace Avalonia.GameStudio.Presentation.Internal
{
    public class SingleBoxesTest
    {
        [Fact]
        public void MaxValueBox_should_return_MaxValue()
        {
            // Act
            var value = (float)SingleBoxes.MaxValueBox;
            // Assert 
            Assert.Equal(float.MaxValue, value);
        }

        [Fact]
        public void MaxValueBox_should_return_same_instance()
        {
            // Act
            var value1 = SingleBoxes.MaxValueBox;
            var value2 = SingleBoxes.MaxValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }

        [Fact]
        public void MinValueBox_should_return_MinValue()
        {
            // Act
            var value = (float)SingleBoxes.MinValueBox;
            // Assert 
            Assert.Equal(float.MinValue, value);
        }

        [Fact]
        public void MinValueBox_should_return_same_instance()
        {
            // Act
            var value1 = SingleBoxes.MinValueBox;
            var value2 = SingleBoxes.MinValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }
    }
}
