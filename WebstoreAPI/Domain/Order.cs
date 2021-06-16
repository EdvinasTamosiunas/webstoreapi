using API.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public bool Delivery { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public Payment Payment { get; set; }
        public Buyer Buyer { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Order () { }
        public Order (OrderRequest orderRequest)
        {
            Delivery = orderRequest.Delivery;
            Country = orderRequest.Country;
            City = orderRequest.City;
            Street = orderRequest.Street;
            Zip = orderRequest.Zip;

        }
    }
}