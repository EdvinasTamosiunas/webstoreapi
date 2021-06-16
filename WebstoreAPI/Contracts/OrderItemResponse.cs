using API.Models;

namespace API.DataTransferObjects
{
    public class OrderItemResponse
    {
        public string Id { get; set; }
        public ItemResponse ItemResponse { get; set; }
        public double Quantity { get; set; }

        public OrderItemResponse () { }
        public OrderItemResponse (OrderItem orderItem)
        {

            Id = orderItem.Id;
            ItemResponse = new ItemResponse(orderItem.Item);
            Quantity = orderItem.Quantity;

        }
    }
}