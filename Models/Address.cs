
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    /// <summary>
    /// </summary>
    public class Address
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string AddressText{ get; set; }
    }
}
