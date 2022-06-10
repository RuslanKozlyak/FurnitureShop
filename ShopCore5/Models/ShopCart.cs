using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureShop.Models
{
    public class ShopCart
    {
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }
    }
}
