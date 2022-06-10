using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFurnitureService _furnitureService;

        public HomeController(IFurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }



        public ViewResult About()
        {
            return View();
        }
    }
}
