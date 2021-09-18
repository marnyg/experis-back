using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task13_MovieAPI.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId{ get; set; }
        public int FromAddressId{ get; set; }
        public int ToAddressId{ get; set; }
        public ICollection<int> ServiceIds{ get; set; }
        public string OrderComment{ get; set; }
    }
}
