using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deli.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public  int ItemTypeId { get; set;  }

        public virtual ItemType ItemType { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<Item_Ingredient> Ingredients{ get; set; }
    }
}
