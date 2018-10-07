﻿using Orders.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> GetOrderByIdAsync(string id);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> CreateAsync(Order order);
        Task<Order> StartAsync(string orderId);
    }
}
