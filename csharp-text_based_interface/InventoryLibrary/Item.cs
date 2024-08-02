using System;
using System.Collections.Generic;

namespace InventoryLibrary
{
    public class Item : BaseClass
    {
        public string Name { get; set; } = string.Empty;  // Initialize with empty string
        public string? Description { get; set; }  // Optional, so make it nullable
        private float price;
        public float Price
        {
            get => price;
            set => price = (float)Math.Round(value, 2);  // Limit to 2 decimal points
        }
        public List<string> Tags { get; set; } = new List<string>();  // Initialize with empty list
    }
}
