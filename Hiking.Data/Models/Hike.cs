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
        
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Difficulty { get; set; }

        [Required (AllowEmptyStrings = false)]
       
        public decimal Distance { get; set; }

        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^(?:[01][0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Invalid time format and hh:mm values.")]
        [DisplayFormat(DataFormatString =  @"{0:hh\hmm}")]
        public TimeSpan Duration { get; set; }

        [Required (AllowEmptyStrings = false, ErrorMessage = "The Height Difference is required")]
        public int Height_difference { get; set; }

        [Required]
        public string Available { get; set; }
    }
}
