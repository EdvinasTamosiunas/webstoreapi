namespace API.DataTransferObjects
{
    public class PaymentRequest
    {
        public string GatewayId { get; set; }
        public double Total { get; set; }
        public bool Refundable { get; set; }
        public string PaymentMethod { get; set; }
    }
}