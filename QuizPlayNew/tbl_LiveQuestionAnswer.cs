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
    
    public partial class tbl_LiveQuestionAnswer
    {
        public long Id { get; set; }
        public string MSISDN { get; set; }
        public string QuestionId { get; set; }
        public string Answer { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
        public Nullable<int> TimeTaken { get; set; }
    }
}