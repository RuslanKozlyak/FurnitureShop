using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Domain.ServiceInterfaces;
using FurnitureShop.Models;
using System.Diagnostics;
using Domain.Data;
using Domain.ServiceInterfacesHuman;
using Microsoft.AspNetCore.Http;
using Service;

namespace CustomIdentityApp.Controllers
{
    public class AccountController : Controller
    {

        private readonly HumanService _humaneService;
        public AccountController(HumanService humanService)
        {
            _humaneService = humanService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult SignIn(string email, string password)
        {
            try
            {
                var result = _humaneService.GetHumanByQuery(email, password);
                if (result != null)
                    _humaneService.SetHuman(result);
                return RedirectToAction("Index","Furniture");
            }
            catch
            {
                return RedirectToAction("ShopCart", "Fail");
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Human human)
        {
            if (ModelState.IsValid)
            {
                _humaneService.AddHuman(human);
                var result = _humaneService.GetHumanByQuery(human.Email, human.Password);
                if (result != null)
                    _humaneService.SetHuman(result);
                return RedirectToAction("Index", "Furniture");
            }
            else
                return View(human);    
        }

        public IActionResult GetHumanOrder(string humanId)
        {
            var order = _humaneService.GetHumanOrder(humanId);
            return View(order);
        }
    }
}