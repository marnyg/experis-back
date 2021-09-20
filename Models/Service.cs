

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{

    /// <summary>
    /// </summary>
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ServiceTypeId { get; set; }
        [Required]
        public ServiceType ServiceType { get; set; }
        [Required]
        public DateTime Date{ get; set; }
    }
}
