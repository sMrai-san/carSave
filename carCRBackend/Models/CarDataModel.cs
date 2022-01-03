using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace carCRBackend.Models
{
    public class CarDataModel
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? CarMake { get; set; }

        [Required]
        [MaxLength(100)]
        public string? CarModel { get; set; }

        [Required]
        [Range(1900, 9999)]
        public int CarDate { get; set; }
    }
}
