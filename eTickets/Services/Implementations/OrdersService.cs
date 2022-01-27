using eTickets.Data.Repository.Interfaces;
using eTickets.Models;
using eTickets.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Services.Implementations
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return _ordersRepository.GetOrdersByUserIdAsync(userId);
        }

        public Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            return _ordersRepository.StoreOrderAsync(items, userId, userEmailAddress);
        }
    }
}
