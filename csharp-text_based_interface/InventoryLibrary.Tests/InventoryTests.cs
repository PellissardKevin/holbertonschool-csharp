using System;
using Xunit;

namespace InventoryLibrary.Tests
{
    public class InventoryTests
    {
        [Fact]
        public void Default_Constructor_Should_Set_Quantity_To_One()
        {
            // Arrange
            var inventory = new Inventory();

            // Act & Assert
            Assert.Equal(1, inventory.Quantity);
        }

        [Fact]
        public void Setting_Quantity_Should_Throw_Exception_If_Less_Than_Zero()
        {
            // Arrange
            var inventory = new Inventory();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => inventory.Quantity = -1);
            Assert.Equal("Quantity cannot be less than 0", exception.Message);
        }
    }
}
