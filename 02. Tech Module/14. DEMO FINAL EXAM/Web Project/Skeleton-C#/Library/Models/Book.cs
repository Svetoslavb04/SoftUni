using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string author { get; set; }

        [Required]
        public double price { get; set; }
    }
}
