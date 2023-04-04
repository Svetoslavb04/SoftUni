﻿using Library.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(0.00, 10.00)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
