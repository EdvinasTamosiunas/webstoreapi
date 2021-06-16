using API.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API.Models
{
    public partial class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public double Price { get; set; }
        public bool Weighed { get; set; }

        public Item () { }
        public Item (Item oldItem, Item newItem)
        {
            Id = oldItem.Id;
            Name = newItem.Name;
            Price = newItem.Price;
            Weighed = newItem.Weighed;
            Image = oldItem.Image;
        }
    }
}