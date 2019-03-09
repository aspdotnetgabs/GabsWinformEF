using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsWinformEF.Models
{
    class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string MenuName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
