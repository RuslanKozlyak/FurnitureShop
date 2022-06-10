using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    class GroupCategory:BaseEntity
    {
        public string GroupName { get; set; }
        public string CategoryName { get; set; }
    }
}
