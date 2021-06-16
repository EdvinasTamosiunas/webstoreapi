using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataTransferObjects;
using API.Models;

namespace WebstoreAPI.Services
{
    public interface IOrderService
    {
        public Task<Order> PostOrder(OrderRequest orderRequest);
        public Task<List<OrderResponse>> GetOrders();
    }
}