using Domain.Data;
using Domain.ServiceInterfaces;
using FurnitureShop.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace FurnitureShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly HumanService _humanService;
        private readonly IOrderService _orderService;
        private readonly ShopCartService _shopCartService;
        private readonly IFurnitureService _furnitureService;

        public ShopCartController(HumanService humanService, ShopCartService shopCartService, IOrderService orderService, IFurnitureService furnitureSerivce)
        {
            _humanService = humanService;
            _orderService = orderService;
            _shopCartService = shopCartService;
            _furnitureService = furnitureSerivce;
        }

        public ActionResult Index()
        {
            var items = _shopCartService.GetShopItems();
            _shopCartService.SetShopItems(items);
            var model = new ShopCart
            {
                ShopCartId = _shopCartService.ShopCartId,
                ListShopItems = _shopCartService.ListShopItems
            };
            return View(model);
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult AddToCart(int id)
        {

            _shopCartService.AddToCart(id);
            return RedirectToAction("Index");
        }

        public ActionResult MakeOrder(string humanId)
        {
            try
            {
                var Now = DateTime.Now;
                var id = int.Parse(humanId);

                var order = new Order
                {
                    HumanId = id,
                    OrderTime = Now
                };

                var orderDetails = new List<OrderDatails>();
                var fullCost = 0.0;
                var shopCartItems = _shopCartService.GetShopItems();
                foreach (var product in shopCartItems)
                {
                    fullCost += product.Furnitures.Cost;
                    orderDetails.Add(new OrderDatails
                    {
                        ProductId = product.Furnitures.Id,
                    });
                }

                order.OrderDatails = orderDetails;

                _orderService.AddOrder(order);
                return View("CheckOut", shopCartItems);
            }
            catch(Exception ex)
            {
                return View("Fail");
            }
        }

        public ViewResult GetOrderDetails(int id)
        {
            var order = _orderService.GetOrder(id);
            var orderProducts = new List<Furniture>();
            foreach (var detail in order.OrderDatails)
            {
                orderProducts.Add(_furnitureService.GetFurniture(detail.ProductId));
            }
            return View(orderProducts);
        }
    }
}
