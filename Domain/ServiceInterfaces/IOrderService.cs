using Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ServiceInterfaces
{
    public interface IOrderService
    {
        public Order GetOrder(DateTime now, int humanId);
        public Order GetOrder(int orderId);
        public void AddOrder(Order order);
        public void RemoveOrder(Order order);
        public void UpdateOrder(Order order);
    }
}
