using System;
using Xunit;

namespace InventoryLibrary.Tests
{
    public class UserTests
    {
        [Fact]
        public void Properties_Should_Initialize_Correctly()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.Equal(string.Empty, user.Id);
            Assert.Equal(string.Empty, user.Name);
        }
    }
}
