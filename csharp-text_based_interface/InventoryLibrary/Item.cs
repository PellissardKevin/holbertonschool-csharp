using System;
using System.Collections.Generic;

namespace InventoryLibrary
{
    public class Item : BaseClass
    {
        public string Name { get; set; }  // Required property

        public string Description { get; set; }  // Optional property

        private float price;
        public float Price
        {
            get => price;
            set => price = Math.Round(value, 2);  // Limit to 2 decimal points
        }

        public List<string> Tags { get; set; } = new List<string>();  // Optional property
    }
}
