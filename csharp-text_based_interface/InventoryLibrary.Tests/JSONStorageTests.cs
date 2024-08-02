using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace InventoryLibrary.Tests
{
    public class JSONStorageTests
    {
        private const string TestFilePath = "test_inventory_manager.json";

        [Fact]
        public void New_Should_Add_Object_To_Storage()
        {
            // Arrange
            var storage = new JSONStorage();
            var item = new Item { Id = "1", Name = "TestItem" };

            // Act
            storage.New(item);
            var allObjects = storage.All();

            // Assert
            Assert.True(allObjects.ContainsKey($"Item.{item.Id}"));
        }

        [Fact]
        public void New_Should_Throw_Exception_When_Adding_Duplicate()
        {
            // Arrange
            var storage = new JSONStorage();
            var item = new Item { Id = "1", Name = "TestItem" };
            storage.New(item);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => storage.New(item));
            Assert.Equal("Object with key Item.1 already exists.", exception.Message);
        }

        [Fact]
        public void Save_Should_Create_File()
        {
            // Arrange
            var storage = new JSONStorage();
            var item = new Item { Id = "1", Name = "TestItem" };
            storage.New(item);

            string directoryPath = "storage";
            string filePath = Path.Combine(directoryPath, "inventory_manager.json");

            // Ensure any pre-existing file is removed
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Act
            storage.Save();

            // Assert
            Assert.True(File.Exists(filePath));

            // Clean up
            File.Delete(filePath);
        }


        [Fact]
        public void Load_Should_Throw_Exception_If_File_Does_Not_Exist()
        {
            // Arrange
            var storage = new JSONStorage();
            string testFilePath = Path.Combine("storage", "inventory_manager.json");

            // Ensure the file does not exist
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => storage.Load());
        }
    }
}
