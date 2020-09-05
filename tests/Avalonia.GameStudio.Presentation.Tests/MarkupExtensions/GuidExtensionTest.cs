using System;

using Avalonia.GameStudio.Presentation.Internal;

using Moq;

using Xunit;

namespace Avalonia.GameStudio.Presentation.MarkupExtensions
{
    public sealed class GuidExtensionTest
    {
        [Theory]
        [InlineData("12345678-9012-3456-7890-123456789012")]
        public void GuidExtension_should_provide_Guid_value(object arg)
        {
            // Arrange
            var instance = new GuidExtension(arg);
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<Guid>(value);
            Assert.Equal(new Guid("12345678-9012-3456-7890-123456789012"), (Guid)value);

        }

        [Theory]
        [InlineData("0")]
        [InlineData("invalid")]
        public void GuidExtension_should_return_EmptyBox(object arg)
        {
            // Arrange
            var instance = new GuidExtension(arg);
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<Guid>(value);
            Assert.Same(GuidBoxes.EmptyBox, value);

        }
    }

    public sealed class EmptyGuidExtensionTest
    {
        [Fact]
        public void EmptyGuidExtension_should_return_EmptyBox()
        {
            // Arrange
            var instance = new EmptyGuidExtension();
            var mockProvider = new Mock<IServiceProvider>();
            // Act
            var value = instance.ProvideValue(mockProvider.Object);
            // Assert
            Assert.IsType<Guid>(value);
            Assert.Same(GuidBoxes.EmptyBox, value);
        }
    }
}
