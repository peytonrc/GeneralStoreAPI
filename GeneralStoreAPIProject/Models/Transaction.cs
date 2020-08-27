using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStoreAPIProject.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; } // Foreign Key
        public string ProductSKU { get; set; } // Foreign Key
        public int ItemCount { get; set; }
        public DateTime DateOfTransaction { get; set; }

    }
}