using System;

namespace InventoryLibrary
{
    public class BaseClass
    {
        public string Id { get; set; } = string.Empty;  // Initialize with empty string
        public DateTime DateCreated { get; set; } = DateTime.Now;  // Initialize with current time
        public DateTime DateUpdated { get; set; } = DateTime.Now;  // Initialize with current time
    }
}
