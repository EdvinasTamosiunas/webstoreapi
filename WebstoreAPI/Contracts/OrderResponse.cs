using System.Collections.Generic;
using API.Models;

namespace API.DataTransferObjects
{
    public class OrderResponse
    {
        public string Id { get; set; }
        public bool Delivery { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public Payment Payment { get; set; }
        public Buyer Buyer { get; set; }
        public List<OrderItemResponse> OrderItemsResponse { get; set; }

        public OrderResponse () { }
        public OrderResponse (Order order, List<OrderItemResponse> orderItemResponses)
        {
            Id = order.Id;
            Delivery = order.Delivery;
            Country = order.Country;
            City = order.City;
            Street = order.Street;
            Zip = order.Zip;
            Payment = order.Payment;
            Buyer = order.Buyer;
            OrderItemsResponse = orderItemResponses;

        }
    }
}