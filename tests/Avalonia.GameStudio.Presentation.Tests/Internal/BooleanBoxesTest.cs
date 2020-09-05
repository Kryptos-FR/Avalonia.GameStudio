using Avalonia.GameStudio.TestHelpers;

using Xunit;

namespace Avalonia.GameStudio.Presentation.Internal
{
    public sealed class BooleanBoxesTest
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Box_should_return_instance(bool value)
        {
            // Act
            var result = BooleanBoxes.Box(value);
            Assert.Contains(result, new[] { BooleanBoxes.FalseBox, BooleanBoxes.TrueBox }, ReferenceEqualityComparer.Default);
        }

        [Fact]
        public void FalseBox_should_return_false()
        {
            // Act
            var value = (bool)BooleanBoxes.FalseBox;
            // Assert 
            Assert.False(value);
        }

        [Fact]
        public void FalseBox_should_return_same_instance()
        {
            // Act
            var value1 = BooleanBoxes.FalseBox;
            var value2 = BooleanBoxes.FalseBox;
            // Assert 
            Assert.Same(value1, value2);
        }

        [Fact]
        public void TrueBox_should_return_true()
        {
            // Act
            var value = (bool)BooleanBoxes.TrueBox;
            // Assert 
            Assert.True(value);
        }

        [Fact]
        public void TrueBox_should_return_same_instance()
        {
            // Act
            var value1 = BooleanBoxes.TrueBox;
            var value2 = BooleanBoxes.TrueBox;
            // Assert 
            Assert.Same(value1, value2);
        }
    }
}
