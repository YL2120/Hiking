using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Data.Models
{
    [Table("Hikes")]
    public class Hike
    {
        [Key] //Primary key
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Difficulty { get; set; }

        [Required]
        public decimal Distance { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public int Height_difference { get; set; }
    }
}
