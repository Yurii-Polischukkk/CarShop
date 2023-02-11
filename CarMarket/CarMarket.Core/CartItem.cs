using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Core
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Car Car { get; set; }
    }
}
