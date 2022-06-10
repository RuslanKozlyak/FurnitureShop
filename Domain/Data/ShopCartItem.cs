using System.Collections.Generic;

namespace Domain.Data
{
    public class ShopCartItem : BaseEntity
    {
        public string ShopCartId { get; set; }

        public Furniture Furnitures { get; set; }
    }
}
