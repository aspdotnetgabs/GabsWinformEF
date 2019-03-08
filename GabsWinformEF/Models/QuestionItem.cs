using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsWinformEF.Models
{
    class QuestionItem
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string CorrectAnsLetter { get; set; }
        public string ChoiceA { get; set; }
        public string ChoiceB { get; set; }
        public string ChoiceC { get; set; }
        public string ChoiceD { get; set; }
    }
}
