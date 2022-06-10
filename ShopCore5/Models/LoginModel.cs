using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureShop.Models
{
    public class LoginModel
    {
        public string HumanId { get; set; }
        public Human Human { get; set; }
    }
}
