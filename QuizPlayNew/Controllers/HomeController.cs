using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaxMind.GeoIP2;
using UAprofileFinder;

namespace QuizPlayNew.Controllers
{
    public class HomeController : Controller
    {
        private UAProfile oUa = new UAProfile();
        // GET: Home
        private Partner_BasketEntities context = new Partner_BasketEntities();
        public ActionResult ThemeToday()
        {
            if (CheckSubscription())
            {
                return View();
            }
            return RedirectToAction("Default");
        }
        public ActionResult QuizPlay()
        {
            if (CheckSubscription())
            {
                if (isPlayCompletedForToday())
                {
                    return Redirect("http://wap.shabox.mobi/quizplaynew/Home/Finished?id=1");
                }
                if (isPlayCompletedThreeTimesToday())
                {
                    return Redirect("http://wap.shabox.mobi/quizplaynew/Home/Finished?id=3");
                }
                return View();
            }

            return RedirectToAction("Default");
        }

        public ActionResult QuizPlayBonusHour()
        {
            if (!oUa.GetMSISDN().StartsWith("88019"))
            {
                return RedirectToAction("Default");
            }
            if (isPlayBonusToday())
            {
                return Redirect("http://wap.shabox.mobi/quizplaynew/Home/Finished?id=1");
            }
            return View();
        }


        public ActionResult ScoreView()
        {
            return View();
        }
        public ActionResult ScoreViewBonus()
        {
            return View();
        }
        public ActionResult ScoreCardView()
        {
            return View();
        }
        public ActionResult RobiAirtelFaq()
        {
            return View();
        }
        public ActionResult Faq()
        {
            return View();
        }
        public ActionResult TermsCondition()
        {
            return View();
        }
        public ActionResult MyAccount()
        {
            return View();
        }
        public ActionResult Feedback()
        {
            return View();
        }
        public ActionResult Default()
        {
            return View();
        }
        public ActionResult Download(string id)
        {
            var result = context.Database.SqlQuery<sp_GetVideoUrl_Result>(
                "EXEC sp_GetVideoUrl @contentcode", new SqlParameter(
                    "@contentcode", id)).ToList();

            ViewBag.physicalfilename = result.Select(x=>x.physicalfilename).First();
            ViewBag.imageUrl = result.Select(x=>x.imageUrl).First();
            ViewBag.video = result.Select(x=>x.video).First();


            return View();
        }
        public ActionResult More(string id)
        {
            return View();
        }
        public ActionResult Prizes()
        {
            return View();
        }
        public ActionResult Finished()
        {
            return View();
        }
        public ActionResult RobiUnsubscriptionSuccessfull()
        {
            return View();
        }
        public ActionResult UnsubscriptionSuccessfull()
        {
            return View();
        }

        public bool isPlayCompletedForToday()
        {
            var msisdn = oUa.GetMSISDN();
            DateTime date = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"));
            var res = context.tbl_QuizPlayResult.Any(x => x.MSISDN.Equals(msisdn) && x.Date.Equals(date));
            
            if (res)
            {
                //lblTodayResultScore.Text = dt.Rows[0]["TotalRight"].ToString();
                return true;
            }

            return false;
        }

        public bool isPlayCompletedThreeTimesToday()
        {
            var msisdn = oUa.GetMSISDN();
            
            DateTime date = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"));
            var r = context.tbl_QuizPlay_Played_Theme_Session
                .Where(x => x.MSISDN.Equals(msisdn))
                .OrderByDescending(x=>x.TimeStamp)
                .Take(1);

            var c = r.AsEnumerable().Where(x => x.TimeStamp.Date.Equals(date))
                .Select(x=>x.Session)
                .FirstOrDefault();

            if (c>3)
            {
                 return true;
                
            }

            return false;
        }
        public bool isPlayBonusToday()
        {
            var msisdn = oUa.GetMSISDN();

            DateTime date = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"));
            var r = context.tbl_QuizPlay_BonusHour_Played
                .Where(x => x.MSISDN.Equals(msisdn))
                .OrderByDescending(x => x.TimeStamp);

            var c = r.AsEnumerable().Count(x => x.TimeStamp.Date.Equals(date));

            if (c>1)
            {
                return true;

            }

            return false;
        }
        public string checkIP(string ip)
        {
            using (var reader = new DatabaseReader(Server.MapPath("~/DB/GeoIP2-ISP.mmdb")))
            {
                String isp = string.Empty;
                try
                {
                    var response = reader.Isp(ip);
                    isp = response.Isp;
                    if (isp.Contains("GrameenPhone") || isp.Contains("gp"))
                    {
                        return "GrameenPhone";
                    }
                    else if (isp.Contains("Banglalink") || isp.Contains("DeVoteD NBN"))
                    {
                        return "Banglalink";
                    }
                    else if (isp.Contains("Robi") || isp.Contains("TM International") || isp.Contains("Robi Axiata Limited") || isp.Contains("Axiata"))
                    {
                        return "Robi";
                    }
                    else if (isp.Contains("airtel Bangladesh"))
                    {
                        return "Airtel";
                    }
                    else if (isp.Contains("Teletalk"))
                    {
                        return "Teletalk";
                    }
                    else
                    {
                        return "Wi-Fi";

                    }
                }
                catch
                {
                    return "Wi-Fi";
                }

            }
        }

        public bool CheckSubscription()
        {
            var msisdn = oUa.GetMSISDN();
            var res = context.tbl_Subscriber_QuizPlay.Any(
                x => x.MSISDN.Equals(msisdn) && x.Reg_Status.Equals(1));



            if (res)
            {
                return true;
            }

            return false;
        }


    }
}