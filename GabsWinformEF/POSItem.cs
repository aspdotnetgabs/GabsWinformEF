using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsWinformEF
{
    class POSItem
    {
        public string ItemName { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
