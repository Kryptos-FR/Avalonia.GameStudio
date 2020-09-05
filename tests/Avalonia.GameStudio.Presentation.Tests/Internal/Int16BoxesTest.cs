using Xunit;

namespace Avalonia.GameStudio.Presentation.Internal
{
    public class Int16BoxesTest
    {
        [Fact]
        public void MaxValueBox_should_return_MaxValue()
        {
            // Act
            var value = (short)Int16Boxes.MaxValueBox;
            // Assert 
            Assert.Equal(short.MaxValue, value);
        }

        [Fact]
        public void MaxValueBox_should_return_same_instance()
        {
            // Act
            var value1 = Int16Boxes.MaxValueBox;
            var value2 = Int16Boxes.MaxValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }

        [Fact]
        public void MinValueBox_should_return_MinValue()
        {
            // Act
            var value = (short)Int16Boxes.MinValueBox;
            // Assert 
            Assert.Equal(short.MinValue, value);
        }

        [Fact]
        public void MinValueBox_should_return_same_instance()
        {
            // Act
            var value1 = Int16Boxes.MinValueBox;
            var value2 = Int16Boxes.MinValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }
    }
}
