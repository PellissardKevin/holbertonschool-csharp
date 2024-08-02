using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Moq;
using InventoryLibrary;
using System.Linq;
using System;

namespace InventoryManagement.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void ShowClassNames_Should_Display_All_ClassNames()
        {
            // Arrange
            var mockStorage = new Mock<JSONStorage>();
            mockStorage.Setup(s => s.All()).Returns(new Dictionary<string, BaseClass>
            {
                { "Item.1", new Item() },
                { "User.1", new User() },
                { "Inventory.1", new Inventory() }
            });

            var output = new StringBuilder();
            Console.SetOut(new StringWriter(output));

            var program = new Program(mockStorage.Object);

            // Act
            program.ShowClassNames();

            // Assert
            var result = output.ToString().Split(Environment.NewLine);
            Assert.Contains("Available Class Names:", result);
            Assert.Contains("Item", result);
            Assert.Contains("User", result);
            Assert.Contains("Inventory", result);
        }

        [Fact]
        public void CreateObject_Should_Create_Item_Object()
        {
            // Arrange
            var mockStorage = new Mock<JSONStorage>();
            var program = new Program(mockStorage.Object);
            string className = "item";

            // Act
            program.CreateObject(className);

            // Assert
            mockStorage.Verify(s => s.New(It.Is<Item>(i => i.Name == "NewItem")), Times.Once);
            mockStorage.Verify(s => s.Save(), Times.Once);
        }

        [Fact]
        public void LoadStorage_Should_Call_Load_And_Handle_Exception()
        {
            // Arrange
            var mockStorage = new Mock<JSONStorage>();
            mockStorage.Setup(s => s.Load()).Throws(new Exception("Load error"));

            var output = new StringBuilder();
            Console.SetOut(new StringWriter(output));

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => program.LoadStorage());
            Assert.Equal("Load error", ex.Message);
        }

        [Fact]
        public void ShowAllObjects_Should_Display_All_Objects()
        {
            // Arrange
            var mockStorage = new Mock<JSONStorage>();
            mockStorage.Setup(s => s.All()).Returns(new Dictionary<string, BaseClass>
    {
        { "Item.1", new Item { Id = "1", Name = "Item1" } },
        { "User.1", new User { Id = "1", Name = "User1" } }
    });

            var output = new StringBuilder();
            Console.SetOut(new StringWriter(output));

            var program = new Program(mockStorage.Object);

            // Act
            program.ShowAllObjects();

            // Assert
            var result = output.ToString();
            Assert.Contains("Item.1: InventoryLibrary.Item", result);
            Assert.Contains("User.1: InventoryLibrary.User", result);
        }
    }
}
