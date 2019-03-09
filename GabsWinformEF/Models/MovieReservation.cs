using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsWinformEF.Models
{
    class MovieReservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime ScreeningDate { get; set; }
        public int NumberOfSeats { get; set; }
    }

}
