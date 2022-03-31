using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace databases_pos_vs.Models
{
    public class Products
    {
        public int product_id { get; set; } = 0;
        public int size { get; set; } = 0;
        public decimal price { get; set; } = 0;
        public string name { get; set; } = string.Empty;
        public int category_id { get; set; } = 0;
        public int vendor_id { get; set; } = 0;
    }
}
