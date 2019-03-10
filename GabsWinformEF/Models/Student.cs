using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsWinformEF.Models
{
    class Student
    {
        [Key]
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int CourseId { get; set; }
        // Add more student profile info
    }
}
