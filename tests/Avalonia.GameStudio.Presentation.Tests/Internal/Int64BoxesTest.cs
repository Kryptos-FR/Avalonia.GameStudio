using Xunit;

namespace Avalonia.GameStudio.Presentation.Internal
{
    public class Int64BoxesTest
    {
        [Fact]
        public void MaxValueBox_should_return_MaxValue()
        {
            // Act
            var value = (long)Int64Boxes.MaxValueBox;
            // Assert 
            Assert.Equal(long.MaxValue, value);
        }

        [Fact]
        public void MaxValueBox_should_return_same_instance()
        {
            // Act
            var value1 = Int64Boxes.MaxValueBox;
            var value2 = Int64Boxes.MaxValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }

        [Fact]
        public void MinValueBox_should_return_MinValue()
        {
            // Act
            var value = (long)Int64Boxes.MinValueBox;
            // Assert 
            Assert.Equal(long.MinValue, value);
        }

        [Fact]
        public void MinValueBox_should_return_same_instance()
        {
            // Act
            var value1 = Int64Boxes.MinValueBox;
            var value2 = Int64Boxes.MinValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }
    }
}
