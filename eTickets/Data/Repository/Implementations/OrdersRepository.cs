using eTickets.Data.Repository.Interfaces;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Repository.Implementations
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly DataContext _context;

        public OrdersRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Movie)
                .Where(o => o.UserId == userId).ToListAsync();

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress,
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();


            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    OrderId = order.Id,
                    MovieId = item.Movie.Id,
                    Quantity = item.Quantity,
                    Price = item.Movie.Price
                };

                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
