using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataTransferObjects;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace WebstoreAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly DatabaseContext _context;
        private readonly IPaymentService paymentService;
        private readonly IBuyerService buyerService;
        private readonly IItemService itemService;

        public OrderService(DatabaseContext dbContext, IPaymentService paymentService,
            IBuyerService buyerService, IItemService itemService)

        {
            _context = dbContext;
            this.paymentService = paymentService;
            this.buyerService = buyerService;
            this.itemService = itemService;
        }

        public async Task<List<OrderResponse>> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.Buyer)
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Item)
                .Include(o => o.Payment)
                .ToListAsync();

            var orderResponses = MapOrdersToOrderResponses(orders);

            return orderResponses;
        }

        private static List<OrderResponse> MapOrdersToOrderResponses(IEnumerable<Order> orders)
        {
            var orderResponses = new List<OrderResponse>();
            foreach (var order in orders)
            {
                var orderItemResponses = order.OrderItems
                    .Select(orderItem => new OrderItemResponse(orderItem)).ToList();

                var orderResponse = new OrderResponse(order, orderItemResponses);
                orderResponses.Add(orderResponse);
            }

            return orderResponses;
        }

        public async Task<Order> PostOrder(OrderRequest orderRequest)
        {
            var order = new Order(orderRequest)
            {
                Payment = await paymentService.PostPaymentToDb(orderRequest.PaymentRequest),
                Buyer = await buyerService.PostBuyerToDb(orderRequest.BuyerRequest)
            };
            var items = await MapOrderItemsToItems(orderRequest, order);
            order.OrderItems = items;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            
            return order;
        }

        private async Task<List<OrderItem>> MapOrderItemsToItems(OrderRequest orderRequest, Order order)
        {
            var items = new List<OrderItem>();
            foreach (var orderItemRequest in orderRequest.OrderItems)
            {
                var item = await itemService.GetItemById(orderItemRequest.ItemId);
                var orderItem = new OrderItem(order, item, orderItemRequest.Quantity);
                items.Add(orderItem);
            }

            return items;
        }
    }
}