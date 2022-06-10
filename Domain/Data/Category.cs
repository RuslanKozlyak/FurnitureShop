using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Data
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public ICollection<Furniture> Furnitures { get; set; }
    }
}
