using System;
using Xunit;

namespace InventoryLibrary.Tests
{
    public class ItemTests
    {
        [Fact]
        public void Setting_Price_Should_Round_To_Two_Decimal_Places()
        {
            // Arrange
            var item = new Item();

            // Act
            item.Price = 10.1234f;

            // Assert
            Assert.Equal(10.12f, item.Price);
        }

        [Fact]
        public void Tags_Should_Initialize_As_Empty_List()
        {
            // Arrange
            var item = new Item();

            // Act & Assert
            Assert.Empty(item.Tags);
        }
    }
}
