using NUnit.Framework;
using System;
using InventoryLibrary;
using System.IO;

namespace InventoryManagement.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("seting up");
            File.Copy("../../../../storage/inventory_manager.json", "../../../../storage/backup_inventory_manager.json", overwrite: true);
        }
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("tearing down");
            File.Copy("../../../../storage/backup_inventory_manager.json", "../../../../storage/inventory_manager.json", overwrite: true);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
    }
}
