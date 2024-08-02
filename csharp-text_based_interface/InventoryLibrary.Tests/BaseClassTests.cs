using System;
using Xunit;

namespace InventoryLibrary.Tests
{
    public class BaseClassTests
    {
        [Fact]
        public void Properties_Should_Initialize_Correctly()
        {
            // Arrange
            var baseClass = new BaseClass();

            // Act & Assert
            Assert.Equal(string.Empty, baseClass.Id);
            Assert.Equal(DateTime.Now.Date, baseClass.DateCreated.Date);
            Assert.Equal(DateTime.Now.Date, baseClass.DateUpdated.Date);
        }
    }
}
