using API.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API.Models
{
    public class Buyer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Buyer () { }
        public Buyer (BuyerRequest buyer)
        {
            Name = buyer.Name;
            LastName = buyer.LastName;
            Email = buyer.Email;
            Phone = buyer.Phone;
        }
    }
}