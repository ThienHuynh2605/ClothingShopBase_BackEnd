using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingShop.Core.Common;

namespace ClothingShop.Core.Entities
{
    public class Product:BaseEntity
    {
        public int CategoryId { get; set; }
        public int BranchId { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Name { get; set; }
       
    }
}
