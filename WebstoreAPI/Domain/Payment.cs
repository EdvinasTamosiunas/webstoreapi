using API.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string GatewayId { get; set; }
        public string PaymentMethod { get; set; }
        public string TimeCreated { get; set; }
        public double Total { get; set; }
        public bool Pending { get; set; }
        public bool Refundable { get; set; }
        public bool Refunded { get; set; }

        public Payment () { }
        public Payment (PaymentRequest paymentRequest)
        {

            GatewayId = paymentRequest.GatewayId;
            TimeCreated = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            PaymentMethod = paymentRequest.PaymentMethod;
            Total = paymentRequest.Total;
            Pending = true;
            Refundable = paymentRequest.Refundable;
            Refunded = false;

        }
    }
}