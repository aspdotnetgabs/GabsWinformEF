using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsWinformEF.Models
{
    class StudyLoad
    {
        public int Id { get; set; }
        public string StudentId { get; set; }

        public int SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public int SubjectCreditUnit { get; set; }
    }
}
