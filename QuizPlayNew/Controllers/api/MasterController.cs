using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using HC.UI.Model;
using Newtonsoft.Json.Linq;
using QuizPlayNew.Models;
using UAprofileFinder;


namespace QuizPlayNew.Controllers.api
{
    public class MasterController : ApiController
    {
        private UAProfile oUa = new UAProfile();
        RobiDoubleConfirm robidoubleconfirm = new RobiDoubleConfirm();

        private Partner_BasketEntities context = new Partner_BasketEntities();
        private RobiSDPContext _context = new RobiSDPContext();
        private BLinkContext __context = new BLinkContext();
        [HttpGet]
        public IHttpActionResult getTodayTheme()
        {
            //DateTime date = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"));
            //var theme = context.tbl_QuizPlayDateThemeRelation.Join
            //    (context.tbl_QuizPlayTheme, x => x.ThemeID, y => y.ID,
            //    (x, y) =>new{Date=x.Date,ID=y.ID, HomeTheme=y.HomeTheme, HomeThemeImage = y.HomeThemeImage})
            //    .Where(x=>x.Date.Equals(date))
            //    .OrderBy(x=>new Guid())
            //    .Take(1).ToList();
            var msisdn = oUa.GetMSISDN();
            var theme = context.Database.SqlQuery<spGetTodayHomeThemeMessageAndImage_new_Result>(
                "EXEC spGetTodayHomeThemeMessageAndImage_new @MSISDN",
                new SqlParameter("@MSISDN", msisdn));

            return Ok(theme);
        }
        [HttpGet]
        public IHttpActionResult getQuestion()
        {
            var msisdn = oUa.GetMSISDN();
            var question = context.Database.SqlQuery<Questions>(
                "EXEC spQuizPlayGetTodayQuestionByMSISDN @MSISDN",
                new SqlParameter("@MSISDN", msisdn));

            return Ok(question);
        }
        [HttpGet]
        public IHttpActionResult getQuestionBonus()
        {
            var msisdn = oUa.GetMSISDN();
            var question = context.Database.SqlQuery<Questions>(
                "EXEC spQuizPlayGetTodayQuestionByMSISDNBonusHour @MSISDN",
                new SqlParameter("@MSISDN", msisdn));

            return Ok(question);
        }

        [HttpGet]
        public IHttpActionResult getHeaderFooterImage()
        {
            var msisdn = oUa.GetMSISDN();
            if (msisdn.StartsWith("88018") || msisdn.StartsWith("88016"))
            {
                return Ok(new Master()
                {
                    HeaderImage = "http://wap.shabox.mobi/quizplaynew/Images/play_n_win.jpg",
                    FaqUrl = "Home/RobiAirtelFaq",
                    AccountQuestionUrl = "Home/MyAccount",
                    AccountQuestionImage = "http://wap.shabox.mobi/quizplaynew/Images/Quizplay_graphics/account.png"
                });
            }
            if (msisdn.StartsWith("88019"))
            {
                return Ok(new Master()
                {
                    HeaderImage = "http://wap.shabox.mobi/quizplaynew/Images/QuizPlay_Header.jpg",
                    FaqUrl = "Home/Faq",
                    AccountQuestionUrl = "Home/Feedback",
                    AccountQuestionImage = "http://wap.shabox.mobi/quizplaynew/Images/Quizplay_graphics/q.png"
                });
            }
            return Ok(new Master()
            {
                HeaderImage = "http://wap.shabox.mobi/quizplaynew/Images/QuizPlay_Header.jpg",
                FaqUrl = "Home/Faq",
                AccountQuestionUrl = "Home/Feedback",
                AccountQuestionImage = "http://wap.shabox.mobi/quizplaynew/Images/Quizplay_graphics/q.png"
            });

        }
        [HttpGet]
        public IHttpActionResult getRobiAirtelFaq()
        {
            var msisdn = oUa.GetMSISDN();
            if (msisdn.StartsWith("88018"))
            {
                return Ok(new
                {
                    helpline = "8801814426426",
                    start = " • Type START QP to 6000 FOR DAILY AUTO-RENEWAL<br />" +
                           " • Type START QP1 to 6000 FOR DAILY NON AUTO-RENEWAL ",
                    stop = " • TYPE STOP QP TO 6000 FOR DAILY AUTO RENEWAL <br/>" +
                          "• TYPE STOP QP1 TO 6000 FOR DAILY NON AUTO-RENEWAL <br/>"
                });
            }
            if (msisdn.StartsWith("88016"))
            {
                return Ok(new
                {
                    helpline = "8801674985965",
                    start = " • Type START PNW to 6000 FOR DAILY AUTO-RENEWAL<br />",
                    stop = " • TYPE STOP PNW TO 6000 FOR DAILY AUTO RENEWAL <br/>"
                });
            }
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult getTermsAndConditon()
        {
            var msisdn = oUa.GetMSISDN();
            if (msisdn.StartsWith("88018"))
            {
                return Ok(new
                {
                    helpline = "8801814426426",
                    start = " • Type START QP to 6000 FOR DAILY AUTO-RENEWAL<br />" +
                            " • Type START QP1 to 6000 FOR DAILY NON AUTO-RENEWAL ",
                    stop = " • TYPE STOP QP TO 6000 FOR DAILY AUTO RENEWAL <br/>" +
                           "• TYPE STOP QP1 TO 6000 FOR DAILY NON AUTO-RENEWAL <br/>",
                    pricea = "5",
                    pricen = "5",
                    samtahik =
                    " সমস্ত সাপ্তাহিক এবং মাসিক  বিজয়ীদেরকে ফেইসবুক মন্তব্যের উপর পুরস্কার দাবি করতে হবে এবং তাদের প্রোফাইলে 24 ঘন্টার মধ্যে একটি পাবলিক স্ট্যাটাস পোস্ট করতে হবে .",
                    name = "PLAY N WIN",
                    na = 1
                });
            }
            if (msisdn.StartsWith("88016"))
            {
                return Ok(new
                {
                    helpline = "8801674985965",
                    start = " • Type START PNW to 6000 FOR DAILY AUTO-RENEWAL<br />",
                    stop = " • TYPE STOP PNW TO 6000 FOR DAILY AUTO RENEWAL <br/>",
                    pricea = "5",
                    samtahik =
                    " সমস্ত সাপ্তাহিক এবং মাসিক  বিজয়ীদেরকে ফেইসবুক মন্তব্যের উপর পুরস্কার দাবি করতে হবে এবং তাদের প্রোফাইলে 24 ঘন্টার মধ্যে একটি পাবলিক স্ট্যাটাস পোস্ট করতে হবে .",
                    name = "PLAY N WIN",
                    na = 0
                });
            }
            if (msisdn.StartsWith("88019"))
            {
                return Ok(new
                {
                    helpline = "8801992303765, 8801936236705",
                    start = " • টাইপ  START QPLAY to ৬৬২৪",
                    stop = "• টাইপ   STOP QPLAY to ৬৬২৪",
                    samtahik = " সমস্ত দৈনিক এবং সাপ্তাহিক বিজয়ীদেরকে ফেইসবুক মন্তব্যের উপর পুরস্কার দাবি করতে হবে এবং তাদের প্রোফাইলে 24 ঘন্টার মধ্যে একটি পাবলিক স্ট্যাটাস পোস্ট করতে হবে .",
                    pricea = "2",
                    name = "Quzi Play",
                    na = 0
                });
            }
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult getQuestionCount()
        {
            var msisdn = oUa.GetMSISDN();
            int count = context.Database.SqlQuery<int>(
                "EXEC spGetQuestionCountBYMSISDN @MSISDN",
                new SqlParameter("@MSISDN", msisdn)).FirstOrDefault();

            return Ok(count);
        }
        [HttpGet]
        public IHttpActionResult getQuestionCountBonus()
        {
            var msisdn = oUa.GetMSISDN();
            int count = context.Database.SqlQuery<int>(
                "EXEC spGetQuestionCountBYMSISDNBonusHour @MSISDN",
                new SqlParameter("@MSISDN", msisdn)).FirstOrDefault();

            return Ok(count);
        }

        [HttpGet]
        public IHttpActionResult getMyAccount()
        {
            var msisdn = oUa.GetMSISDN();
            var myaccount = context.Database.SqlQuery<spGetQuizPlayMyAccount_Result>(
                "EXEC spGetQuizPlayMyAccount @MSISDN",
                new SqlParameter("@MSISDN", msisdn));

            return Ok(myaccount);
        }
        [HttpPost]
        public IHttpActionResult PostFeedback(Feedbackp f)
        {
            context.Database.ExecuteSqlCommand(
                "EXEC spQuizPlayFeedback_Insert @MSISDN",
                new SqlParameter("@MSISDN", f.msisdn),
                new SqlParameter("@Message", f.message));

            return Ok();
        }
        [HttpGet]
        public IHttpActionResult getMSISDN()
        {
            var msisdn = oUa.GetMSISDN();

            return Ok(msisdn);
        }

        [HttpPost]
        public IHttpActionResult Insertanswer(string response, int quesionid, int? time)
        {
            var msisdn = oUa.GetMSISDN();
            int count = context.Database.SqlQuery<int>(
                "EXEC spUpdateQuizPlayUserAnswer @Answer,@MSISDN,@QuestionNo",
                new SqlParameter("@Answer", response),
                new SqlParameter("@MSISDN", msisdn),
                new SqlParameter("@QuestionNo", quesionid)).FirstOrDefault();

            return Ok(count);
        }
        [HttpPost]
        public IHttpActionResult InsertanswerBonus(string response, int quesionid, int? time)
        {
            var msisdn = oUa.GetMSISDN();
            int count = context.Database.SqlQuery<int>(
                "EXEC spUpdateQuizPlayUserAnswerBonusHour @Answer,@MSISDN,@QuestionNo",
                new SqlParameter("@Answer", response),
                new SqlParameter("@MSISDN", msisdn),
                new SqlParameter("@QuestionNo", quesionid)).FirstOrDefault();

            return Ok(count);
        }

        [HttpPost]
        public IHttpActionResult QuizPlay(int? themeid)
        {
            var msisdn = oUa.GetMSISDN();
            int? Session = 0;
            DateTime date = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"));
            Session = context.Database.SqlQuery<int>("EXEC spGetUserSession @date,@MSISDN",
                new SqlParameter("@date", date),
                new SqlParameter("@MSISDN", msisdn)).FirstOrDefault();

            context.tbl_QuizPlay_Played_Theme_Session.Add(new tbl_QuizPlay_Played_Theme_Session
            {
                MSISDN = msisdn,
                Theme = themeid,
                Session = Session
            });
            context.SaveChanges();

            if (!isPlayCompletedThreeTimesToday())
            {
                context.Database.ExecuteSqlCommand("EXEC spUpdateFixRandomTheme @MSISDN", new SqlParameter(
                    "@MSISDN", msisdn
                ));
            }


            return Ok();
        }


        [HttpPost]
        public IHttpActionResult PostBonusLog()
        {
            var msisdn = oUa.GetMSISDN();

            context.tbl_QuizPlay_BonusHour_Played.Add(new tbl_QuizPlay_BonusHour_Played
            {
                MSISDN = msisdn
            }
            );
            context.SaveChanges();
            return Ok();
        }


        [HttpGet]
        public IHttpActionResult GetUserPlayingTime()
        {
            var msisdn = oUa.GetMSISDN();
            var time = context.Database.SqlQuery<int>("EXEC spGetUserPlayingTime @MSISDN", new SqlParameter(
                "@MSISDN", msisdn));

            return Ok(time);
        }
        [HttpGet]
        public IHttpActionResult GetUserPlayingTimeBonusHour()
        {
            var msisdn = oUa.GetMSISDN();
            var time = context.Database.SqlQuery<int>("EXEC spGetUserPlayingTimeBonusHour @MSISDN", new SqlParameter(
                "@MSISDN", msisdn));

            return Ok(time);
        }
        public struct DateRange
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }

        DateRange drThisWeek;
        public DateRange ThisWeek(DateTime date)
        {
            DateRange range = new DateRange();
            if (System.DateTime.Now.ToString("dddd") == "Friday" || System.DateTime.Now.ToString("dddd") == "Saturday")
            {
                if (System.DateTime.Now.ToString("dddd") == "Friday")
                {
                    range.Start = date.Date;
                    range.End = range.Start.AddDays(7).AddSeconds(-1);
                }

                if (System.DateTime.Now.ToString("dddd") == "Saturday")
                {
                    range.Start = date.Date.AddDays(-1);
                    range.End = range.Start.AddDays(7).AddSeconds(-1);
                }
            }
            else
            {
                range.Start = date.Date.AddDays(-(int)date.DayOfWeek);
                range.End = range.Start.AddDays(7).AddSeconds(-1);

                // begin: customize the week start and end date as friday to thursday
                range.Start = range.Start.AddDays(-2);
                range.End = range.End.AddDays(-2);
                // end: customize the week start and end date as friday to thursday
            }
            return range;
        }

        [HttpGet]
        public IHttpActionResult GetUserResultDailyWeekly()
        {
            var msisdn = oUa.GetMSISDN();
            drThisWeek = ThisWeek(DateTime.Now);
            var result = context.Database.SqlQuery<spGetUserResultDailyWeekly_Result>(
                "EXEC spGetUserResultDailyWeekly @MSISDN,@stratDate,@endDate",
                new SqlParameter("@MSISDN", msisdn),
                new SqlParameter("@stratDate", drThisWeek.Start),
                new SqlParameter("@endDate", drThisWeek.End));

            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetScore()
        {
            var msisdn = oUa.GetMSISDN();
            var result = context.Database.SqlQuery<spScore_Result>(
                "EXEC spScore @MSISDN",
                new SqlParameter("@MSISDN", msisdn));

            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetScoreBonus()
        {
            var msisdn = oUa.GetMSISDN();
            var result = context.Database.SqlQuery<spScoreBonus_Result>(
                "EXEC spScoreBonus @MSISDN",
                new SqlParameter("@MSISDN", msisdn));

            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult CheckSubscription()
        {
            var msisdn = oUa.GetMSISDN();
            var res = context.tbl_Subscriber_QuizPlay.Any(
                x => x.MSISDN.Equals(msisdn) && x.Reg_Status.Equals(1));



            if (res)
            {
                return Ok(1);
            }

            return Ok(0);
        }
        [HttpGet]
        public IHttpActionResult GetSubUrl(string type)
        {
            var msisdn = oUa.GetMSISDN();
            if (msisdn.StartsWith("88018"))
            {
                if (type == "nauto")
                {
                    return Ok(robidoubleconfirm.GetLink(msisdn,
                        "http://quizplay.mobi", "0300409782"));
                }
                else
                {
                    return Ok(robidoubleconfirm.GetLink(msisdn,
                        "http://quizplay.mobi", "0300409780"));
                }
            }
            if (msisdn.StartsWith("88016"))
            {
                return Ok(robidoubleconfirm.GetLink(msisdn,
                    "http://quizplay.mobi", "0300409924"));
            }
            if (msisdn.StartsWith("88019"))
            {
                BLSDPServiceUrl blsdp = new BLSDPServiceUrl();
                return Ok(blsdp.GetSubcriptionUrl(msisdn, "6624_Quiz_Play_Daily", "6624_Quiz_Play_Daily", "6624", "http://quizplay.mobi"));

            }

            return Ok(0);
        }
        [HttpGet]
        public IHttpActionResult GetWeeklyBigImage()
        {
            var msisdn = oUa.GetMSISDN();
            var op = string.Empty;
            var type = string.Empty;
            if (msisdn.StartsWith("88018") || msisdn.StartsWith("88016"))
            {
                op = "Robi";
            }
            else if (msisdn.StartsWith("88019"))
            {

                op = "Banglalink";
            }
            else
            {

                op = "Banglalink";
            }

            var result = context.Database.SqlQuery<string>(
                "EXEC spGetMonhtlWeeklyImageForQuizPlay @operator,@type",
                new SqlParameter("@operator", op),
                new SqlParameter("@type", "WP"));

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetMonthlyBigImage()
        {
            var msisdn = oUa.GetMSISDN();
            var op = string.Empty;
            var type = string.Empty;
            if (msisdn.StartsWith("88018") || msisdn.StartsWith("88016"))
            {
                op = "Robi";
            }
            else if (msisdn.StartsWith("88019"))
            {

                op = "Banglalink";
            }

            var result = context.Database.SqlQuery<string>(
                "EXEC spGetMonhtlWeeklyImageForQuizPlay @operator,@type",
                new SqlParameter("@operator", op),
                new SqlParameter("@type", "MP"));

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetWeeklyImage()
        {
            var msisdn = oUa.GetMSISDN();
            var type = string.Empty;
            if (msisdn.StartsWith("88018") || msisdn.StartsWith("88016"))
            {
                type = "WPR";
            }
            else if (msisdn.StartsWith("88019"))
            {

                type = "HP";
            }
            else
            {

                type = "HP";
                msisdn = "88019";
            }

            var result = context.Database.SqlQuery<string>(
                "EXEC spGetMegaImageForQuizPlay @operator,@type",
                new SqlParameter("@operator", msisdn),
                new SqlParameter("@type", type));

            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetMonthlyImage()
        {
            var msisdn = oUa.GetMSISDN();
            var type = string.Empty;
            if (msisdn.StartsWith("88018") || msisdn.StartsWith("88016"))
            {
                type = "MPR";
            }
            else if (msisdn.StartsWith("88019"))
            {

                type = "MP";
            }

            var result = context.Database.SqlQuery<string>(
                "EXEC spGetMegaImageForQuizPlay @operator,@type",
                new SqlParameter("@operator", msisdn),
                new SqlParameter("@type", type));

            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetTodayScoreCard()
        {
            var msisdn = oUa.GetMSISDN();
            var result = context.Database.SqlQuery<spQuizPlayGetTodayScoreCardNew_Result>(
                "EXEC spQuizPlayGetTodayScoreCardNew @MSISDN",
                new SqlParameter("@MSISDN", msisdn));

            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetVideo()
        {

            var result = context.Database.SqlQuery<sp_fullvideoCatagory_cznew_test_Result>(
                "EXEC sp_fullvideoCatagory_cznew_test ");

            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetVideo(string id)
        {

            var result = context.Database.SqlQuery<sp_GetVideoUrl_Result>(
                "EXEC sp_GetVideoUrl @contentcode", new SqlParameter(
                    "@contentcode", id));

            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetRelatedVideo(int num)
        {

            var result = context.Database.SqlQuery<sp_MoreContent_Playnwin_Result>(
                "EXEC sp_MoreContent_Playnwin @content,@pagenumber", new SqlParameter(
                    "@content", "video"), new SqlParameter("@pagenumber", num));

            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetRelatedVideoCount()
        {

            var result = context.Database.SqlQuery<int>(
                "EXEC sp_MoreContent_Playnwin_count");



            return Ok(result);
        }
        [HttpPost]
        public IHttpActionResult VideoLog(string id)
        {

            context.Database.ExecuteSqlCommand(
                "EXEC spInsertQuizPlayVideoLog @ContentCode", new SqlParameter(
                    "@ContentCode", id));



            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetWeeklyWiner()
        {
            var msisdn = oUa.GetMSISDN();
            var result = context.Database.SqlQuery<spQuizPlayWeeklyWinnersNew_Result>(
                "EXEC spQuizPlayWeeklyWinnersNew @MSISDN",
                new SqlParameter("@MSISDN", msisdn.Substring(0, 5)));

            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetMonthlyWiner()
        {
            var msisdn = oUa.GetMSISDN();
            var result = context.Database.SqlQuery<spQuizPlayMonthlyWinnersNew_Result>(
                "EXEC spQuizPlayMonthlyWinnersNew @MSISDN",
                new SqlParameter("@MSISDN", msisdn.Substring(0, 5)));

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetNumberOfPlay()
        {
            var msisdn = oUa.GetMSISDN();

            DateTime date = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"));
            var r = context.tbl_QuizPlayUserAnswer
                .Where(x => x.MSISDN.Equals(msisdn))
                .OrderByDescending(x => x.TimeStamp)
                .Take(1);


            var c = r.AsEnumerable().Where(x => x.TimeStamp.Date.Equals(date))
                .Select(x => x.SessionNumber)
                .FirstOrDefault();

            var t = context.tbl_QuizPlayResult.Any(x => x.Date.Equals(date) && x.MSISDN.Equals(msisdn));

            if (t)
            {
                return Ok("");
            }

            if (c == 0)
            {
                return Ok("আজকে আপনি আর ৩ বার খেলতে পারবেন");

            }
            if (c == 1)
            {
                return Ok("আজকে আপনি আর 2 বার খেলতে পারবেন");

            }
            if (c == 2)
            {
                return Ok("আজকে আপনি আর ১ বার খেলতে পারবেন");

            }
            if (c == 3)
            {
                return Ok("");

            }

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult CheckIsBonusHour()
        {
            var msisdn = oUa.GetMSISDN();

            var isBonus = context.Database.SqlQuery<spQuizPlayIsBonusHour_Result>("EXEC spQuizPlayIsBonusHour @MSISDN", new SqlParameter(
                "@MSISDN", msisdn));


            return Ok(isBonus);
        }

        [HttpPost]
        public IHttpActionResult Unsubscription()
        {
            var msisdn = oUa.GetMSISDN();
            if (msisdn.StartsWith("88018"))
            {
                var sub = context.tbl_Subscriber_QuizPlay.Where(x => x.MSISDN.Equals(msisdn))
                    .Select(x => x.Subs_Pack).First();

                if (sub == "DA")
                {
                    _context.Database.ExecuteSqlCommand("Exec spInsertSubscriptionQ_To_SDP_channelID_1 @userID,@serviceId,@productID,@updateDesc",
                        new SqlParameter("@userID", msisdn),
                        new SqlParameter("@serviceId", "0303905017"),
                        new SqlParameter("@productID", "0300409780"),
                        new SqlParameter("@updateDesc", "Deletion"));
                }
                else
                {
                    _context.Database.ExecuteSqlCommand("Exec spInsertSubscriptionQ_To_SDP_channelID_1 @userID,@serviceId,@productID,@updateDesc",
                        new SqlParameter("@userID", msisdn),
                        new SqlParameter("@serviceId", "0303905018"),
                        new SqlParameter("@productID", "0300409782"),
                        new SqlParameter("@updateDesc", "Deletion"));
                }
            }
            else if (msisdn.StartsWith("88016"))
            {
                _context.Database.ExecuteSqlCommand("Exec spInsertSubscriptionQ_To_SDP_channelID_1 @userID,@serviceId,@productID,@updateDesc",
                    new SqlParameter("@userID", msisdn),
                    new SqlParameter("@serviceId", "0303905019"),
                    new SqlParameter("@productID", "0300409924"),
                    new SqlParameter("@updateDesc", "Deletion"));
            }
            else if (msisdn.StartsWith("88019"))
            {
                var msg =
                    "Your Quiz Play service is turned Off. To start again send START QPLAY to 6624 at TK2.44/day. Help: 01992303765";
                context.Database.ExecuteSqlCommand("EXEC spUnsubricbeQuizPlayRobiAirtel @MSISDN",
                    new SqlParameter("@MSISDN", msisdn));
                __context.Database.ExecuteSqlCommand("EXEC spSendSingleMsg_6624 @MobileNo,@msg,@service_id",
                    new SqlParameter("@MobileNo", msisdn),
                    new SqlParameter("@msg", msg),
                    new SqlParameter("@service_id", "76"));
            }

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AccessLog(string sourceurl, string useragent)
        {

            var hs = HS();
            var msisdn = oUa.GetMSISDN();
            context.Database.ExecuteSqlCommand(
                "EXEC spInsert_QuizPlay_ACCESS @SOURCE_URL,@SERVICE_REQUEST,@MSISDN,@HS_MANUFACTURER,@HS_MODEL,@HS_DIM,@APN,@PORTAL_FULLnSHORT,@CMPAIN_KEY,@IP,@OS,@UAHeader",
                new SqlParameter("@SOURCE_URL", sourceurl),
                new SqlParameter("@SERVICE_REQUEST", ""),
                new SqlParameter("@MSISDN", msisdn),
                new SqlParameter("@HS_MANUFACTURER", hs.HS_MANUFAC),
                new SqlParameter("@HS_MODEL", hs.HS_MOD),
                new SqlParameter("@HS_DIM", hs.HS_DIM),
                new SqlParameter("@APN", ""),
                new SqlParameter("@PORTAL_FULLnSHORT", "QuizPlay"),
                new SqlParameter("@CMPAIN_KEY", ""),
                new SqlParameter("@IP", oUa.GetUserIP()),
                new SqlParameter("@OS", oUa.GetOS()),
                new SqlParameter("@UAHeader", useragent)
            );

            return Ok();
        }

        public HSResult HS()
        {
            string UAPROF_URL = oUa.GetUserAgent();
            string UserAgentBrowser = UAPROF_URL;
            HSP.Service Profile = new HSP.Service();
            var HSProfiling = Profile.HansetDetection(UAPROF_URL, oUa.GetUAProfileXWap());

            return new HSResult
            {
                HS_MANUFAC = HSProfiling.Manufacturer,
                HS_MOD = HSProfiling.Model,
                HS_DIM = HSProfiling.Dimension,
                HS_OS = HSProfiling.OS
            };
        }


        [HttpGet]
        public IHttpActionResult Check()
        {
            if (CheckSubscriptions())
            {
                if (isPlayCompletedForToday())
                {
                    return Ok(new { result = 1 });
                }
                if (isPlayCompletedThreeTimesToday())
                {
                    return Ok(new { result = 3 });
                }
                return Ok(new { result = 0 });
            }

            return Ok(new { result = 2 }); ;
        }


        [HttpGet]
        public IHttpActionResult isPlayBonusToday()
        {
            var msisdn = oUa.GetMSISDN();

            DateTime date = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"));
            var r = context.tbl_QuizPlay_BonusHour_Played
                .Where(x => x.MSISDN.Equals(msisdn))
                .OrderByDescending(x => x.TimeStamp);

            var c = r.AsEnumerable().Count(x => x.TimeStamp.Date.Equals(date));

            if (c > 1)
            {
                return Ok(new { res = "1" });

            }

            return Ok(new { res = "0" });
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
                .OrderByDescending(x => x.TimeStamp)
                .Take(1);

            var c = r.AsEnumerable().Where(x => x.TimeStamp.Date.Equals(date))
                .Select(x => x.Session)
                .FirstOrDefault();

            if (c > 3)
            {
                return true;

            }

            return false;
        }

        public bool CheckSubscriptions()
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


        [HttpGet]
        public IHttpActionResult GetLiveQuestions()
        {


            var ss = context.Database.SqlQuery<sp_GetLiveQuestions_Result>("sp_GetLiveQuestions");
            return Ok(ss);
        }
        [HttpPost]
        public IHttpActionResult InsertLiveAnswer(tbl_LiveQuestionAnswer a)
        {
            a.TimeStamp = DateTime.Now;
            a.Type = "Live";
            a.RoomId = "";
            context.tbl_LiveQuestionAnswer.Add(a);
            context.SaveChanges();
            return Ok(new
            {

                result = "Success"
            });
        }
        [HttpPost]
        public IHttpActionResult GetLiveResult(LiveResult a)
        {

            var result = context.Database.SqlQuery<sp_GetTotalLiveRightAnswer_Result>("sp_GetTotalLiveRightAnswer @Qid",
                new SqlParameter("@Qid", a.Id)).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult SetFbInfo(tbl_QPFbInfo qpInfo)
        {
            var ifExistsFbid = context.tbl_QPFbInfo.Any(x => x.FbId == qpInfo.FbId);
            if (!ifExistsFbid)
            {
                context.tbl_QPFbInfo.Add(qpInfo);
                context.SaveChanges();

            }

            return Ok(new
            {

                result = !ifExistsFbid ? "Success" : "Already Exists"
            });

        }
        [HttpPost]
        public IHttpActionResult GetLiveResultUserWise(LiveResultUser a)
        {

            var result = context.Database.SqlQuery<sp_GetUserLiveResult_Result>("sp_GetUserLiveResult @msisdn",
                new SqlParameter("@msisdn", a.MSISDN)).ToList();
            return Ok(result);
        }
        [HttpPost]
        public IHttpActionResult OnlineStatusUpdate(tbl_QpIsLive isLive)
        {
            var ifexists = context.tbl_QpIsLive.Any(x => x.FbId == isLive.FbId);
            if (ifexists)
            {
                var userToUpdate = context.tbl_QpIsLive.First(x => x.FbId == isLive.FbId);
                userToUpdate.IsActive = isLive.IsActive;
                userToUpdate.TimeStamp = DateTime.Now;
                var resultOfMsisdn = userToUpdate.MSISDN == "" ? true : false;
                if (resultOfMsisdn)
                {
                    userToUpdate.MSISDN = string.IsNullOrWhiteSpace(isLive.MSISDN) ? "" : isLive.MSISDN;
                }
            }
            else
            {
                isLive.TimeStamp = DateTime.Now;
                isLive.MSISDN = string.IsNullOrWhiteSpace(isLive.MSISDN) ? "" : isLive.MSISDN;
                context.tbl_QpIsLive.Add(isLive);
            }

            context.SaveChanges();

            return Ok(

                new
                {

                    result = ifexists ? "Status Updated" : "Success"
                });
        }

        [HttpGet]
        public IHttpActionResult GetOnlineUsersCount([FromUri] GetLiveList getLiveList)
        {

            var onlineuserListCount = context.tbl_QpIsLive.Count(x => x.IsActive == 1 && x.FbId != getLiveList.FbId);

            //var liveUserInfoList = context.tbl_QpIsLive.Where(x => x.IsActive == 1)
            //    .Join(context.tbl_QPFbInfo, live => live.FbId,
            //        fbinfo => fbinfo.FbId, (live, fbinfo) => new
            //        {
            //            live,
            //            fbinfo
            //        }).Join(context.tbl_QpTokenLog, pre => new { fbid = pre.fbinfo.FbId }, token => new
            //        {
            //            fbid = token.FbId
            //        }, (pre, token) =>
            //            new
            //            {
            //                Name = pre.fbinfo.FbName,
            //                ImageUrl = pre.fbinfo.FbImageUrl,
            //                Token = token.Token,
            //                FbId = token.FbId
            //            }).GroupJoin(context.tbl_LiveChallenge_Log, x=>x.FbId, li=>li.FbIdSender, (x,li)=> new
            //    {
            //        x,
            //        li
            //    }).SelectMany(z=>z.li.DefaultIfEmpty(), (a,b)=> new
            //    {


            //        a,b
            //    });



            //   var aa = Partition(liveUserInfoList, 2);
            var ss = context.Database.SqlQuery<sp_GetLiveUserList1_Result>("sp_GetLiveUserList @fbid",
                new SqlParameter("@fbid", getLiveList.FbId));
            return Ok(new
            {
                result = new
                {
                    Total = onlineuserListCount,
                    FbInfo = new
                    {
                        liveUserInfoList = ss

                    }
                }
            });
        }
        public static IEnumerable<List<T>> Partition<T>(IList<T> source, Int32 size)
        {
            for (int i = 0; i < Math.Ceiling(source.Count / (Double)size); i++)
                yield return new List<T>(source.Skip(size * i).Take(size));
        }

        [HttpPost]
        public IHttpActionResult SetLiveToken(tbl_QpTokenLog token)
        {
            var ifexists = context.tbl_QpTokenLog.Any(x => x.FbId == token.FbId);

            if (ifexists)
            {
                var userToUpdate = context.tbl_QpTokenLog.First(x => x.FbId == token.FbId);
                userToUpdate.IsActive = token.IsActive;
                userToUpdate.TimeStamp = DateTime.Now;
                userToUpdate.Token = token.Token;
                var resultOfMsisdn = userToUpdate.MSISDN == "" ? true : false;
                if (resultOfMsisdn)
                {
                    userToUpdate.MSISDN = string.IsNullOrWhiteSpace(token.MSISDN) ? "" : token.MSISDN;
                }


            }
            else
            {
                token.TimeStamp = DateTime.Now;
                token.MSISDN = string.IsNullOrWhiteSpace(token.MSISDN) ? "" : token.MSISDN;
                context.tbl_QpTokenLog.Add(token);
                context.SaveChanges();

            }

            return Ok(new
            {
                result = "Success"
            });
        }

        [HttpGet]
        public IHttpActionResult GetLiveTime()
        {

            //new DateTime(x.Date.Value.Year, x.Date.Value.Month, x.Date.Value.Day,
            //    Convert.ToInt16(x.Hour)
            //    , 0, 0).ToString()


            DateTime date = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"));


            var aa =
                context.tbl_QuizPlay_Live_MagicHour.Where(x =>
                    DbFunctions.TruncateTime(x.Date) == date.Date
                    ).ToList().Select(x =>
                    x.Date.Value.AddHours(Convert.ToInt32(x.Hour)));

            if (aa.ToList().Count > 0)
            {
                var rr = Convert.ToDateTime(aa.ToList().First()).ToString("yyyy-MM-dd HH:mm:ss");

                return Ok(new
                {
                    result = rr
                });
            }
            else
            {
                return Ok(new
                {
                    result = "No"
                });
            }

        }

        [HttpPost]
        public IHttpActionResult NotifyLive(Notify notify)
        {
            var tokenList = context.tbl_QpTokenLog.Where(x => x.Token != notify.Token && x.IsActive == 1).ToList();
            foreach (var list in tokenList)
            {

                var fbaseData = new RootFirbaseSend()
                {
                    to = list.Token,
                    data = new Data()
                    {
                        message = "Admin is live now",
                    }
                };

                var response = HitFirebase.SendPushNotification(list.Token, fbaseData);
                RootFirebaseResponse resultOfSending = Newtonsoft.Json.JsonConvert.DeserializeObject<RootFirebaseResponse>(response);
                Qp_Firebase_SendLog_Tables sendLogs;
                sendLogs = new Qp_Firebase_SendLog_Tables
                {
                    IsSuccess = resultOfSending.success == 1 ? 1 : 0,
                    RefId = Convert.ToInt32(list.Id),
                    TimeStamp = DateTime.Now,
                    Token = list.Token
                };
                context.Qp_Firebase_SendLog_Tables.Add(sendLogs);
                context.SaveChanges();

            }
            return Ok(new
            {
                result = "Success"
            });
        }

        [HttpPost]
        public IHttpActionResult ClickLog(Notify notify)
        {
            var refid = context.tbl_QpTokenLog
                .OrderByDescending(x => x.TimeStamp)
                .FirstOrDefault(x => x.Token == notify.Token);
            context.Qp_Firebase_ClickLog_Tables.Add(new Qp_Firebase_ClickLog_Tables
            {
                Token = notify.Token,
                RefId = Convert.ToInt32(refid.Id)
            });
            context.SaveChanges();

            return Ok(new
            {
                result = "Success"
            });
        }

        [HttpPost]
        public IHttpActionResult RequestLiveChallange(tbl_LiveChallenge_Log liveChallangeLog)
        {
            liveChallangeLog.IsActive = 1;
            liveChallangeLog.IsAccepted = 0;
            liveChallangeLog.TimeStamp = DateTime.Now;
            var ifExists = context.tbl_LiveChallenge_Log.Any(x =>
            x.FbIdSender == liveChallangeLog.FbIdSender && x.FbIdReceiver == liveChallangeLog.FbIdReceiver && x.IsActive == 1);
            if (!ifExists)
            {
                context.tbl_LiveChallenge_Log.Add(liveChallangeLog);
                context.SaveChanges();


                var senderName = context.tbl_QPFbInfo.First(x => x.FbId == liveChallangeLog.FbIdSender);
                var liveRequestSend = new LiveChallange()
                {
                    to = liveChallangeLog.Receiver,
                    data = new LiveData()
                    {
                        RoomId = liveChallangeLog.FbIdSender.ToString() + "_" + liveChallangeLog.FbIdReceiver.ToString(),
                        Type = "ChallangeSent",
                        Message = senderName.FbName + " request you for a challange"

                    }

                };
                HitFirebase.SendPushNotification("", liveRequestSend);
            }

            return Ok(new
            {
                result = !ifExists ? "Success" : "Already Sent"
            });
        }

        [HttpPost]
        public IHttpActionResult AcceptLiveChallange(tbl_LiveChallenge_Log liveChallangeLog)
        {
            //liveChallangeLog.IsActive = 0;
            //liveChallangeLog.IsAccepted = 1;
            var userToUpdate = context.tbl_LiveChallenge_Log.OrderByDescending(x => x.Id).First(x => x.Receiver == liveChallangeLog.Receiver && x.FbIdReceiver == liveChallangeLog.FbIdReceiver);
            userToUpdate.IsActive = 0;
            userToUpdate.IsAccepted = liveChallangeLog.IsAccepted;
            userToUpdate.AcceptedTime = DateTime.Now;
            context.SaveChanges();
            var senderName = context.tbl_QPFbInfo.OrderByDescending(x => x.TimeStamp).First(x => x.FbId == liveChallangeLog.FbIdReceiver);
            var liveRequestAccept = new LiveChallange()
            {
                to = userToUpdate.Sender,
                data = new LiveData()
                {
                    RoomId = userToUpdate.FbIdSender.ToString() + "_" + liveChallangeLog.FbIdReceiver.ToString(),
                    Type = liveChallangeLog.IsAccepted == 1 ? "ChallangeAccepted" : "ChallangeRejected",
                    Message = senderName.FbName + (liveChallangeLog.IsAccepted == 1 ? " accepted your challange" : " rejected your challange")

                }

            };
            var response = HitFirebase.SendPushNotification("", liveRequestAccept);
            return Ok(new { result = "Success" });
        }


        [HttpPost]
        public IHttpActionResult LiveQuestionSet(LiveQuestions liveChallangeLog)
        {
            //liveChallangeLog.IsActive = 0;
            //liveChallangeLog.IsAccepted = 1;
            DateTime date = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"));
            var maxCount =
                context.tbl_LiveChallenge_Log.OrderByDescending(x =>
                x.Id).Count(x => x.FbIdSender + "_" + x.FbIdReceiver == liveChallangeLog.RoomId && DbFunctions.TruncateTime(x.TimeStamp) == date.Date);

            var RoomQid = context.tbl_LiveChallenge_Log.OrderByDescending(x => x.Id).FirstOrDefault(x =>
                  x.FbIdSender + "_" + x.FbIdReceiver == liveChallangeLog.RoomId && x.IsActive == 0 && x.IsAccepted == 1);

            var ss = context.Database.SqlQuery<sp_GetLiveQuestions_Challange_Result>("sp_GetLiveQuestions_Challange @qtypeid",
                new SqlParameter("@qtypeid", RoomQid.QuestionTypeId));

            return Ok(new
            {
                QuestionsResult = ss,
                SessionNumber = maxCount + 1
            });
        }


        [HttpGet]
        public IHttpActionResult GetChallangeTheme()
        {
            //liveChallangeLog.IsActive = 0;
            //liveChallangeLog.IsAccepted = 1;
            var liveTheme = (context.tbl_QuizPlayTheme.Where(x => x.HomeTheme.Contains("লাইভ")).ToList()).Select(x => new
            {
                x.ID,
                ThemeName = x.HomeTheme,
                Image = "http://wap.shabox.mobi/cms/content/QuizPlay/Theme/" + x.HomeThemeImage
            });

            return Ok(new
            {
                result = liveTheme
            });
        }

        [HttpPost]
        public IHttpActionResult InsertChallangeAnswer(tbl_LiveQuestionAnswer a)
        {
            a.TimeStamp = DateTime.Now;
            a.Type = "Challange";
            context.tbl_LiveQuestionAnswer.Add(a);
            context.SaveChanges();
            return Ok(new
            {
                result = "Success"
            });
        }

        [HttpPost]
        public IHttpActionResult GetChallangeResult(ChallangeResult a)
        {
            //sp_GetTotalChallangeRightAnswer
            var ScoreChallange = context.Database.SqlQuery<sp_GetTotalChallangeRightAnswer1_Result>("sp_GetTotalChallangeRightAnswer @roomid,@type,@sessionNumber",
                new SqlParameter("@roomid", a.RoomId),
                new SqlParameter("@type", a.Type),
                new SqlParameter("@sessionNumber", a.SessionNumber)
                );
            return Ok(new
            {
                ChallangeResult = ScoreChallange
            });
        }

    }
}
