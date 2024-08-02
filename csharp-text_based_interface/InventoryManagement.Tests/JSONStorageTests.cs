using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using InventoryLibrary;
using InventoryManager;

namespace InventoryManagement.Tests
{
    public class JSONStorageTests
    {
        private readonly JSONStorage _storage;
        private readonly string _testFilePath;

        public JSONStorageTests()
        {
            _storage = new JSONStorage();
            var parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
            var directoryPath = Path.Combine(parentDirectory ?? string.Empty, "storage");
            Directory.CreateDirectory(directoryPath);
            _testFilePath = Path.Combine(directoryPath, "inventory_manager.json");
        }

        [Fact]
        public void Save_StoresObjectsInFile()
        {
            var obj = new Item
            {
                Id = "testId",
                Name = "TestItem"
            };
            _storage.New(obj);
            _storage.Save();

            var fileContent = File.ReadAllText(_testFilePath);
            Assert.Contains("testId", fileContent);
        }

        [Fact]
        public void Load_LoadsObjectsFromFile()
        {
            var obj = new Item
            {
                Id = "testId",
                Name = "TestItem"
            };
            _storage.New(obj);
            _storage.Save();
            _storage.All().Clear(); // Clear the in-memory storage

            _storage.Load();
            var loadedObjects = _storage.All();
            Assert.True(loadedObjects.ContainsKey("Item.testId"));
            Assert.Equal("TestItem", ((Item)loadedObjects["Item.testId"]).Name);
        }

        [Fact]
        public void New_ThrowsExceptionForDuplicateKeys()
        {
            var obj = new Item
            {
                Id = "testId",
                Name = "TestItem"
            };
            _storage.New(obj);
            Assert.Throws<InvalidOperationException>(() => _storage.New(obj));
        }
    }
}
