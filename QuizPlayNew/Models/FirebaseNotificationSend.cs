using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizPlayNew.Models
{
    public class FirebaseNotificationSend
    {

    }

    public class LiveChallange
    {
        public string to { get; set; }
        public LiveData data { get; set; }
    }

    public class LiveData
    {
        public string Type { get; set; }
        public string RoomId { get; set; }
        public string Message { get; set; }
    }
    public class RootFirbaseSend
    {
        public string to { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public string message { get; set; }
    }

    public class RootFirebaseResponse
    {
        public long multicast_id { get; set; }
        public int success { get; set; }
        public int failure { get; set; }
        public int canonical_ids { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string message_id { get; set; }
    }
}