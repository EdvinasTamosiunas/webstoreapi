namespace API.DataTransferObjects
{
    public class OrderItemRequest
    {
        public string ItemId { get; set; }
        public double Quantity { get; set; }
    }
}