using API.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
        public double Quantity { get; set; }

        public OrderItem () { }
        public OrderItem (Order order, Item item, double quantity)
        {

            Order = order;
            Item = item;
            Quantity = quantity;
        }
    }
}