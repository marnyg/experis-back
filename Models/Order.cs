

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    /// <summary>
    /// </summary>
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId{ get; set; }
        [Required]
        public Customer Customer{ get; set; }
        [Required]
        public int FromAddressId{ get; set; }
        [Required]
        public Address FromAddress{ get; set; }
        [Required]
        public int ToAddressId{ get; set; }
        [Required]
        public Address ToAddress{ get; set; }
        public ICollection<Service> Services{ get; set; }
        [StringLength(500)]
        public string OrderComment{ get; set; }

    }
}
