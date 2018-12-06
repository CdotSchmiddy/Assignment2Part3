using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("movies")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Genre { get; set; }

        [Required]
        public int Duration { get; set; }
    }
}
