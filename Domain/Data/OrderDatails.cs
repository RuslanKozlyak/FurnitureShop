using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Data
{
    public class OrderDatails:BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public Order Order { get; set; }
        public Furniture Furniture { get; set; }
    }
}
