using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Models
{
    public class Minion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Eyes { get; set; }
    }
}
