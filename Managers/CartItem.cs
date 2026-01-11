using System;

namespace MotorPartsInventoryManagement.Models
{
    public class CartItem
    {
        public int PartID { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public string Brand { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        // Discount properties
        public string DiscountType { get; set; } // "None", "Percentage", "Fixed"
        public decimal DiscountValue { get; set; } // e.g., 10 for 10% or ₱10

        // Calculated properties
        public decimal Subtotal
        {
            get { return UnitPrice * Quantity; }
        }

        public decimal DiscountAmount
        {
            get
            {
                if (DiscountType == "Percentage")
                {
                    return Subtotal * (DiscountValue / 100);
                }
                else if (DiscountType == "Fixed")
                {
                    return DiscountValue * Quantity;
                }
                return 0;
            }
        }

        public decimal Total
        {
            get { return Subtotal - DiscountAmount; }
        }
    }
}