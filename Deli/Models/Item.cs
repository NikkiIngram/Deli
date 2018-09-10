using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Deli.Models._Enums;

namespace Deli.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public ItemType ItemType { get; set; }

    }
}
