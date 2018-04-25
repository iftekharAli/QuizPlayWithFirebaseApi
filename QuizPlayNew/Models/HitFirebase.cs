using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace QuizPlayNew.Models
{
    public class HitFirebase
    {
        public static string SendPushNotification(string token, object ro)
        {

            try
            {

                string applicationID = "AAAAbtIlWIM:APA91bFrihGGwNpf3JM4S1QyGT_OBm88T29F3Fx0ARy_dFfjP9tysL0a-an13pzlnULeApKi_h4OdsFSgYNE57rEhxvgOxL78Lh3zQsUZprUiaGjri6Z5Qkqu9n2PLfn8JZPjtzV67Fs";

                //string senderId = "633921246089";

                string deviceId = token;

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(ro);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                //tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                string str = sResponseFromServer;
                                return str;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return str;
            }
        }
       
    }
}