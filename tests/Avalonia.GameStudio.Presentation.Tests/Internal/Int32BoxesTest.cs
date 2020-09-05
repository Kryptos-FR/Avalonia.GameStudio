using Xunit;

namespace Avalonia.GameStudio.Presentation.Internal
{
    public class Int32BoxesTest
    {
        [Fact]
        public void MaxValueBox_should_return_MaxValue()
        {
            // Act
            var value = (int)Int32Boxes.MaxValueBox;
            // Assert 
            Assert.Equal(int.MaxValue, value);
        }

        [Fact]
        public void MaxValueBox_should_return_same_instance()
        {
            // Act
            var value1 = Int32Boxes.MaxValueBox;
            var value2 = Int32Boxes.MaxValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }

        [Fact]
        public void MinValueBox_should_return_MinValue()
        {
            // Act
            var value = (int)Int32Boxes.MinValueBox;
            // Assert 
            Assert.Equal(int.MinValue, value);
        }

        [Fact]
        public void MinValueBox_should_return_same_instance()
        {
            // Act
            var value1 = Int32Boxes.MinValueBox;
            var value2 = Int32Boxes.MinValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }
    }
}
