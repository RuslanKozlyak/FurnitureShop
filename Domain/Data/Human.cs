using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Data
{
    public class Human : BaseEntity
    {
        [Required(ErrorMessage = "- Поле необходимо заполнить!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "- Поле необходимо заполнить!")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "- Поле необходимо заполнить!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "- Поле необходимо заполнить!")]
        public string Password { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
