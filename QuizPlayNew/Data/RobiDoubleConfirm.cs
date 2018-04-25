using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HC.UI.Model
{
    public class RobiDoubleConfirm
    {
        public string GetLink(string msisdn, string callBackUrl, string productID, string spid = "200004")
        {


            string nonce = DateTime.Now.ToString("yyyyMMddHHmmssms");
            string time = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            var alg = SHA256.Create();
            alg.ComputeHash(Encoding.UTF8.GetBytes(nonce + time + "Robi1234"));
            string base64 = Convert.ToBase64String(alg.Hash);
            string urlSafe = Uri.EscapeDataString(base64);
            string transactionId = getRandomNumber();
            callBackUrl = Uri.EscapeDataString(callBackUrl);
            string url = "https://consent.robi.com.bd/store/wapconfirm?spid=" + spid + "&passwordDigest=" + urlSafe + "&msisdn=" + msisdn + "&language=bn&transactionId=" + transactionId + "&callbackURL=" + callBackUrl + "&productID=" + productID + "&nonce=" + nonce + "&created=" + time;
            return url;
        }

        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        private static string getRandomNumber()
        {
            //Random rand = new Random();
            string randomTranID = "";
            lock (syncLock)
            { // synchronize
                randomTranID = ((long)(getrandom.NextDouble() * 10000001) + 99999999).ToString();
            }
            string _nowTime = DateTime.Now.ToString("mmssff");
            randomTranID += DateTime.Now.ToString("mmssff");
            return randomTranID;
        }
    }
}