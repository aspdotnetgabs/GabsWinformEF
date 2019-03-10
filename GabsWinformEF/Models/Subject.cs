using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsWinformEF.Models
{
    class Subject
    {
        public int Id { get; set; }
        public string Code { get; set; } // ITE-233, FIL-101
        public string Name { get; set; } // Computer Programming 2, Pagbasa
        public int CreditUnit { get; set; } // 3 units, 4 units
    }
}
