
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{

    /// <summary>
    /// </summary>
    public class ServiceType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string ServiceTypeName{ get; set; }
        [StringLength(500)]
        public string ServiceTypeDescription{ get; set; }

    }
}
