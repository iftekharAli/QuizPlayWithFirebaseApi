//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuizPlayNew
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_QuizPlayUserAnswerBonusHour
    {
        public long ID { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public string MSISDN { get; set; }
        public long QuestionID { get; set; }
        public string Answer { get; set; }
        public long SessionNumber { get; set; }
        public bool isCompleted { get; set; }
        public string HS_MODEL { get; set; }
        public string HS_MANUFACTURER { get; set; }
        public string HS_DIM { get; set; }
        public string APN { get; set; }
        public string IP { get; set; }
        public string OS { get; set; }
        public string UAHeader { get; set; }
    
        public virtual tbl_QuizPlayQuestions tbl_QuizPlayQuestions { get; set; }
    }
}
