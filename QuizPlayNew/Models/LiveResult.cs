using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizPlayNew.Models
{
    public class LiveResult
    {
        public int Id { get; set; }
    }
    public class LiveResultUser
    {
        public string MSISDN { get; set; }
    }
    public class OnlineStatus
    {
        public string FbId { get; set; }
        public int IsActive { get; set; }
    }
}