
using Xunit;

namespace Avalonia.GameStudio.Presentation.Internal
{
    public class ByteBoxesTest
    {
        [Fact]
        public void MaxValueBox_should_return_MaxValue()
        {
            // Act
            var value = (byte)ByteBoxes.MaxValueBox;
            // Assert 
            Assert.Equal(byte.MaxValue, value);
        }

        [Fact]
        public void MaxValueBox_should_return_same_instance()
        {
            // Act
            var value1 = ByteBoxes.MaxValueBox;
            var value2 = ByteBoxes.MaxValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }

        [Fact]
        public void MinValueBox_should_return_MinValue()
        {
            // Act
            var value = (byte)ByteBoxes.MinValueBox;
            // Assert 
            Assert.Equal(byte.MinValue, value);
        }

        [Fact]
        public void MinValueBox_should_return_same_instance()
        {
            // Act
            var value1 = ByteBoxes.MinValueBox;
            var value2 = ByteBoxes.MinValueBox;
            // Assert 
            Assert.Same(value1, value2);
        }
    }
}
