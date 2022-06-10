using Domain.Data;
using Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ShopCartService
    {
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        private readonly IRepository<ShopCartItem> _shopCartItemRepository;
        private readonly IRepository<Furniture> _furnitureRepository;

        public ShopCartService(IRepository<ShopCartItem> ShopCartItemRepository, IRepository<Furniture> FurnitureRepository)
        {
            _shopCartItemRepository = ShopCartItemRepository;
            _furnitureRepository = FurnitureRepository;
        }

        public static ShopCartService GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            string shopCardId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            var shopCartItemRep = service.GetRequiredService<IRepository<ShopCartItem>>();
            var furnitureRep = service.GetRequiredService<IRepository<Furniture>>();
            session.SetString("CartId", shopCardId);
            return new ShopCartService(shopCartItemRep,furnitureRep) { ShopCartId = shopCardId };
        }

        public void AddToCart(int productId)
        {
            try
            {
                var result = _furnitureRepository.Get(productId);
                _shopCartItemRepository.Insert(new ShopCartItem
                {
                    ShopCartId = ShopCartId,
                    Furnitures = result
                });
            }
            catch
            {

            }
        }

        public List<ShopCartItem> GetShopItems()
        {
            return _shopCartItemRepository.GetAll(include => include.Furnitures, include => include.Furnitures.Category).Where(item => item.ShopCartId == ShopCartId).ToList();
        }

        public void SetShopItems(List<ShopCartItem> items)
        {
            ListShopItems = items;
        }
    }
}
