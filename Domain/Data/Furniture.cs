using System.Collections.Generic;

namespace Domain.Data
{
    public class Furniture : BaseEntity
    {
        public string ProductName { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Size { get; set; }
        public int Weight { get; set; }
        public string Img { get; set; }
        public int? CartItemId { get; set; }
        public int? CategoryId { get; set; }

        public ShopCartItem ShopCartItem { get; set; }
        public Category Category { get; set; }
        public OrderDatails OrderDatails { get; set; }
    }
}
