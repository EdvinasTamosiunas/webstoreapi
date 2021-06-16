using System.Collections.Generic;

namespace API.DataTransferObjects
{
    public class OrderRequest
    {
        public bool Delivery { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public PaymentRequest PaymentRequest { get; set; }
        public BuyerRequest BuyerRequest { get; set; }
        public List<OrderItemRequest> OrderItems { get; set; }
    }
}