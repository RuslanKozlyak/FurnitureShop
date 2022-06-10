using Domain.ServiceInterfaces;
using FurnitureShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FurnitureShop.Controllers
{
    public class FurnitureController : Controller
    {
        private readonly IFurnitureService _furnitureService;

        public FurnitureController(IFurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }

        public IActionResult Index()
        {
            var result = _furnitureService.GetAllFurnitures();
            return View("GetFurnitureByQuery",result);
        }

        public ViewResult GetFurnitureCategory(int categoryId)
        {
            var result = _furnitureService.GetFurnitureCategory(categoryId);
            return View("GetFurnitureByQuery",result);
        }

        public ViewResult GetFurnitureByQuery(string query)
        {
            var result = _furnitureService.GetFurnitureByQuery(query);
            return View("GetFurnitureByQuery",result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ProductCard(int productId)
        {
            var result = _furnitureService.GetFurniture(productId);
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
