using System;

using Avalonia.GameStudio.Presentation.Internal;

using Moq;

using Xunit;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class FalseExtensionTest
    {
        [Fact]
        public void FalseExtension_should_provide_FalseBox()
        {
            // Arrange
            var instance = new FalseExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.Same(BooleanBoxes.FalseBox, value);
        }
    }

    public sealed class TrueExtensionTest
    {
        [Fact]
        public void TrueExtension_should_provide_TrueBox()
        {
            // Arrange
            var instance = new TrueExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.Same(BooleanBoxes.TrueBox, value);
        }
    }
}
