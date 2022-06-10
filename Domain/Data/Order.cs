using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Data
{
    public class Order:BaseEntity
    {
        public DateTime OrderTime { get; set; }
        public double FullCost { get; set; }
        public int HumanId { get; set; }
        public Human Human { get; set; }
        public ICollection<OrderDatails> OrderDatails { get; set; }
    }
}
