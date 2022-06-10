using Domain.Data;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    class OrderService:IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order GetOrder(DateTime now,int humanId)
        {
            return _orderRepository.GetAll().Where(order => order.OrderTime == now & order.HumanId == humanId).First();
        }

        public Order GetOrder( int orderId)
        {
            return _orderRepository.Get(orderId,include => include.OrderDatails, include => include.OrderDatails);
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Insert(order);
        }

        public void RemoveOrder(Order order)
        {
            _orderRepository.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
        }
    }
}
