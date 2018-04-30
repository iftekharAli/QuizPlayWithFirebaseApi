using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizPlayNew.Models
{
    public class Notify
    {
        public string Token { get; set; }
    }

    public class GetLiveList
    {
        public string FbId { get; set; }
    }

    public class LiveQuestions
    {
        public string RoomId { get; set; }
    }

    public class ChallangeResult
    {
        public string RoomId { get; set; }
        public string Type { get; set; }
        public int SessionNumber { get; set; }
    }
}