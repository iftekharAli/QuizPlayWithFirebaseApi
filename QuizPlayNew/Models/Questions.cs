using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizPlayNew.Models
{
    public class Questions
    {
        public long ID { get; set; }
        public long QuestionThemeID { get; set; }
        public string QuestionImage { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Answer { get; set; }
    }
}