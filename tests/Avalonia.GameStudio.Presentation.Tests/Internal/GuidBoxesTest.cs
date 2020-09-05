using System;

using Xunit;

namespace Avalonia.GameStudio.Presentation.Internal
{
    public class GuidBoxesTest
    {
        [Fact]
        public void MaxValueBox_should_return_MaxValue()
        {
            // Act
            var value = (Guid)GuidBoxes.EmptyBox;
            // Assert 
            Assert.Equal(Guid.Empty, value);
        }

        [Fact]
        public void MaxValueBox_should_return_same_instance()
        {
            // Act
            var value1 = GuidBoxes.EmptyBox;
            var value2 = GuidBoxes.EmptyBox;
            // Assert 
            Assert.Same(value1, value2);
        }
    }
}
