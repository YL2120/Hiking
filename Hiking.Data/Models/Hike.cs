using Microsoft.AspNetCore.Identity;
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
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Please enter a positive number with maximum two decimals.")]
        public decimal Distance { get; set; }

        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = "Time must be between 00:00 to 23:59")]
        [DisplayFormat(DataFormatString =  @"{0:hh\hmm}")]
        public TimeSpan Duration { get; set; }

        [Required (AllowEmptyStrings = false, ErrorMessage = "The Height Difference is required")]
        [RegularExpression(@"^[1-9]+[0-9]*$", ErrorMessage = "Please enter a positive number with no decimals.")]
        public int Height_difference { get; set; }

        [Required]
        public string Available { get; set; }

        
        
        [Column(TypeName = "nvarchar(256)")]
        public string UserName { get; set; }

        //[ForeignKey("UserId")]
        //public string UserId { get; set; }
        //public virtual IdentityUser User { get; set; }


    }
}
