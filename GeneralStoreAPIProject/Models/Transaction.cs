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


        public int CustomerId { get; set; } // Foreign Key git g
        public virtual Customer Customer { get; set; }


        public string ProductId { get; set; } // Foreign Key
        public virtual Product Product { get; set; }


        public int ItemCount { get; set; }
        public DateTime DateOfTransaction { get; set; }

    }
}