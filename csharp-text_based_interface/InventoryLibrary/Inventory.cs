using System;

namespace InventoryLibrary
{
    public class Inventory : BaseClass
    {
        private int quantity;
        public string UserId { get; set; }  // Required property, should be linked to User Id
        public string ItemId { get; set; }  // Required property, should be linked to Item Id
        public int Quantity
        {
            get => quantity;
            set => quantity = value < 0 ? throw new ArgumentException("Quantity cannot be less than 0") : value;  // Ensure non-negative
        }

        public Inventory()
        {
            Quantity = 1;  // Default value
        }
    }
}
