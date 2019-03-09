using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsWinformEF.Models
{
    class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerContact { get; set; }
        public int Type { get; set; } // Dine in, Take out, delivery
        public int TransactionBy { get; set; } // User Id of logged-in cashier
    }
}
