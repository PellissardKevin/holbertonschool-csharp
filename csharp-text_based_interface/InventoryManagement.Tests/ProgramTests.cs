using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using Xunit;
using InventoryLibrary;
using InventoryManager;  // Import the namespace for Program

namespace InventoryManagement.Tests
{
    public class ProgramTests
    {
        private readonly Mock<JSONStorage> _mockStorage;
        private readonly StringWriter _output;

        public ProgramTests()
        {
            _mockStorage = new Mock<JSONStorage>();
            _output = new StringWriter();
            Console.SetOut(_output);
        }

        [Fact]
        public void ShowClassNames_PrintsClassNames()
        {
            // Arrange
            var classes = new Dictionary<string, BaseClass>
            {
                { "Item.testId", new Item { Name = "TestItem" } },
                { "User.testId", new User { Name = "TestUser" } }
            };
            _mockStorage.Setup(s => s.All()).Returns(classes);

            // Act
            Program.ShowClassNames();  // Ensure this method is defined in the Program class

            // Assert
            var result = _output.ToString();
            Assert.Contains("Item", result);
            Assert.Contains("User", result);
        }
    }
}
