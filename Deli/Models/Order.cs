using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deli.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual User Users { get; set; }
        public virtual ICollection<Item> Items { get; set; }

    }
}
