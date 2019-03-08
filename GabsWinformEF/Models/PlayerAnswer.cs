using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsWinformEF.Models
{
    class PlayerAnswer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestionItemId { get; set; }
        public int AnsLetter { get; set; }
        public bool AnsweredCorrectly { get; set; }
    }
}
