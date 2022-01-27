using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Repository.Interfaces
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
    }
}
