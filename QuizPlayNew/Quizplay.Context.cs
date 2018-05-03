﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Partner_BasketEntities : DbContext
    {
        public Partner_BasketEntities()
            : base("name=Partner_BasketEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_QuizPlay_Access_Log> tbl_QuizPlay_Access_Log { get; set; }
        public virtual DbSet<tbl_QuizPlay_Played_Theme> tbl_QuizPlay_Played_Theme { get; set; }
        public virtual DbSet<tbl_QuizPlay_PlayHit_Log> tbl_QuizPlay_PlayHit_Log { get; set; }
        public virtual DbSet<tbl_QuizPlayDateThemeRelation> tbl_QuizPlayDateThemeRelation { get; set; }
        public virtual DbSet<tbl_QuizPlayFixRandomTheme> tbl_QuizPlayFixRandomTheme { get; set; }
        public virtual DbSet<tbl_QuizPlayQuestions> tbl_QuizPlayQuestions { get; set; }
        public virtual DbSet<tbl_QuizPlayResult> tbl_QuizPlayResult { get; set; }
        public virtual DbSet<tbl_QuizPlayResultBonusHour> tbl_QuizPlayResultBonusHour { get; set; }
        public virtual DbSet<tbl_QuizPlayTheme> tbl_QuizPlayTheme { get; set; }
        public virtual DbSet<tbl_QuizPlayUserAnswer> tbl_QuizPlayUserAnswer { get; set; }
        public virtual DbSet<tbl_QuizPlayUserAnswerBonusHour> tbl_QuizPlayUserAnswerBonusHour { get; set; }
        public virtual DbSet<tbl_QuizPlay_MyAccount> tbl_QuizPlay_MyAccount { get; set; }
        public virtual DbSet<tbl_QuizPlay_ThemeSet_Today> tbl_QuizPlay_ThemeSet_Today { get; set; }
        public virtual DbSet<tbl_QuizPlay_Played_Theme_Session> tbl_QuizPlay_Played_Theme_Session { get; set; }
        public virtual DbSet<tbl_Subscriber_QuizPlay> tbl_Subscriber_QuizPlay { get; set; }
        public virtual DbSet<tbl_QuizPlay_BonusHour_Played> tbl_QuizPlay_BonusHour_Played { get; set; }
        public virtual DbSet<tbl_Unsubscription> tbl_Unsubscription { get; set; }
        public virtual DbSet<tbl_LiveQuestionAnswer> tbl_LiveQuestionAnswer { get; set; }
        public virtual DbSet<tbl_QPFbInfo> tbl_QPFbInfo { get; set; }
        public virtual DbSet<tbl_QpIsLive> tbl_QpIsLive { get; set; }
        public virtual DbSet<tbl_QpTokenLog> tbl_QpTokenLog { get; set; }
        public virtual DbSet<tbl_QuizPlay_Live_MagicHour> tbl_QuizPlay_Live_MagicHour { get; set; }
        public virtual DbSet<Qp_Firebase_SendLog_Tables> Qp_Firebase_SendLog_Tables { get; set; }
        public virtual DbSet<Qp_Firebase_ClickLog_Tables> Qp_Firebase_ClickLog_Tables { get; set; }
        public virtual DbSet<tbl_LiveChallenge_Log> tbl_LiveChallenge_Log { get; set; }
    
        public virtual ObjectResult<Nullable<int>> spGetUserSession(Nullable<System.DateTime> date, string mSISDN)
        {
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spGetUserSession", dateParameter, mSISDNParameter);
        }
    
        public virtual int spQuizPlayGetTodayQuestionByMSISDN(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spQuizPlayGetTodayQuestionByMSISDN", mSISDNParameter);
        }
    
        public virtual ObjectResult<spQuizPlayGetTodayQuestion_Result> spQuizPlayGetTodayQuestion(string mSISDN, Nullable<long> todayThemeID, Nullable<long> questionID)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            var todayThemeIDParameter = todayThemeID.HasValue ?
                new ObjectParameter("TodayThemeID", todayThemeID) :
                new ObjectParameter("TodayThemeID", typeof(long));
    
            var questionIDParameter = questionID.HasValue ?
                new ObjectParameter("QuestionID", questionID) :
                new ObjectParameter("QuestionID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spQuizPlayGetTodayQuestion_Result>("spQuizPlayGetTodayQuestion", mSISDNParameter, todayThemeIDParameter, questionIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spGetQuestionCountBYMSISDN(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spGetQuestionCountBYMSISDN", mSISDNParameter);
        }
    
        public virtual ObjectResult<spGetTodayHomeThemeMessageAndImage_new_Result> spGetTodayHomeThemeMessageAndImage_new(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetTodayHomeThemeMessageAndImage_new_Result>("spGetTodayHomeThemeMessageAndImage_new", mSISDNParameter);
        }
    
        public virtual int spUpdateFixRandomTheme(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spUpdateFixRandomTheme", mSISDNParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spGetUserPlayingTime(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spGetUserPlayingTime", mSISDNParameter);
        }
    
        public virtual ObjectResult<spGetUserResultDailyWeekly_Result> spGetUserResultDailyWeekly(string mSISDN, Nullable<System.DateTime> stratDate, Nullable<System.DateTime> endDate)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            var stratDateParameter = stratDate.HasValue ?
                new ObjectParameter("stratDate", stratDate) :
                new ObjectParameter("stratDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetUserResultDailyWeekly_Result>("spGetUserResultDailyWeekly", mSISDNParameter, stratDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<spQuizPlayGetTodayScoreCardNew_Result> spQuizPlayGetTodayScoreCardNew(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spQuizPlayGetTodayScoreCardNew_Result>("spQuizPlayGetTodayScoreCardNew", mSISDNParameter);
        }
    
        public virtual ObjectResult<spQuizPlayMonthlyWinnersNew_Result> spQuizPlayMonthlyWinnersNew(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spQuizPlayMonthlyWinnersNew_Result>("spQuizPlayMonthlyWinnersNew", mSISDNParameter);
        }
    
        public virtual ObjectResult<spQuizPlayWeeklyWinnersNew_Result> spQuizPlayWeeklyWinnersNew(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spQuizPlayWeeklyWinnersNew_Result>("spQuizPlayWeeklyWinnersNew", mSISDNParameter);
        }
    
        public virtual ObjectResult<spGetQuizPlayMyAccount_Result> spGetQuizPlayMyAccount(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetQuizPlayMyAccount_Result>("spGetQuizPlayMyAccount", mSISDNParameter);
        }
    
        public virtual int spQuizPlayFeedback_Insert(string mSISDN, string message)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            var messageParameter = message != null ?
                new ObjectParameter("Message", message) :
                new ObjectParameter("Message", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spQuizPlayFeedback_Insert", mSISDNParameter, messageParameter);
        }
    
        public virtual int spInsertUserResult(string mSISDN, Nullable<long> timeTaken)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            var timeTakenParameter = timeTaken.HasValue ?
                new ObjectParameter("TimeTaken", timeTaken) :
                new ObjectParameter("TimeTaken", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertUserResult", mSISDNParameter, timeTakenParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spUpdateQuizPlayUserAnswer(string answer, string mSISDN, Nullable<long> questionNo, Nullable<long> timeTaken)
        {
            var answerParameter = answer != null ?
                new ObjectParameter("Answer", answer) :
                new ObjectParameter("Answer", typeof(string));
    
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            var questionNoParameter = questionNo.HasValue ?
                new ObjectParameter("QuestionNo", questionNo) :
                new ObjectParameter("QuestionNo", typeof(long));
    
            var timeTakenParameter = timeTaken.HasValue ?
                new ObjectParameter("TimeTaken", timeTaken) :
                new ObjectParameter("TimeTaken", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spUpdateQuizPlayUserAnswer", answerParameter, mSISDNParameter, questionNoParameter, timeTakenParameter);
        }
    
        public virtual ObjectResult<spScore_Result> spScore(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spScore_Result>("spScore", mSISDNParameter);
        }
    
        public virtual ObjectResult<string> spGetMegaImageForQuizPlay(string @operator, string type, Nullable<int> status)
        {
            var operatorParameter = @operator != null ?
                new ObjectParameter("operator", @operator) :
                new ObjectParameter("operator", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("spGetMegaImageForQuizPlay", operatorParameter, typeParameter, statusParameter);
        }
    
        public virtual ObjectResult<sp_fullvideoCatagory_cznew_test_Result> sp_fullvideoCatagory_cznew_test(Nullable<int> total)
        {
            var totalParameter = total.HasValue ?
                new ObjectParameter("total", total) :
                new ObjectParameter("total", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_fullvideoCatagory_cznew_test_Result>("sp_fullvideoCatagory_cznew_test", totalParameter);
        }
    
        public virtual ObjectResult<sp_GetVideoUrl_Result> sp_GetVideoUrl(string contentcode)
        {
            var contentcodeParameter = contentcode != null ?
                new ObjectParameter("contentcode", contentcode) :
                new ObjectParameter("contentcode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetVideoUrl_Result>("sp_GetVideoUrl", contentcodeParameter);
        }
    
        public virtual ObjectResult<sp_MoreContent_Playnwin_Result> sp_MoreContent_Playnwin(string content, Nullable<int> pagenumber)
        {
            var contentParameter = content != null ?
                new ObjectParameter("content", content) :
                new ObjectParameter("content", typeof(string));
    
            var pagenumberParameter = pagenumber.HasValue ?
                new ObjectParameter("pagenumber", pagenumber) :
                new ObjectParameter("pagenumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_MoreContent_Playnwin_Result>("sp_MoreContent_Playnwin", contentParameter, pagenumberParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_MoreContent_Playnwin_count()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_MoreContent_Playnwin_count");
        }
    
        public virtual int spInsertQuizPlayVideoLog(string contentCode)
        {
            var contentCodeParameter = contentCode != null ?
                new ObjectParameter("ContentCode", contentCode) :
                new ObjectParameter("ContentCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertQuizPlayVideoLog", contentCodeParameter);
        }
    
        public virtual ObjectResult<string> spGetMonhtlWeeklyImageForQuizPlay(string @operator, string type, Nullable<int> status)
        {
            var operatorParameter = @operator != null ?
                new ObjectParameter("operator", @operator) :
                new ObjectParameter("operator", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("spGetMonhtlWeeklyImageForQuizPlay", operatorParameter, typeParameter, statusParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spGetQuizPlayIsTodayPlayedThriceByMSISDN(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spGetQuizPlayIsTodayPlayedThriceByMSISDN", mSISDNParameter);
        }
    
        public virtual ObjectResult<spGetTodayResultByMSISDN_Result> spGetTodayResultByMSISDN(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetTodayResultByMSISDN_Result>("spGetTodayResultByMSISDN", mSISDNParameter);
        }
    
        public virtual ObjectResult<spQuizPlayIsBonusHour_Result> spQuizPlayIsBonusHour(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spQuizPlayIsBonusHour_Result>("spQuizPlayIsBonusHour", mSISDNParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spGetUserPlayingTimeBonusHour(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spGetUserPlayingTimeBonusHour", mSISDNParameter);
        }
    
        public virtual ObjectResult<spQuizPlayGetTodayQuestionByMSISDNBonusHour_Result> spQuizPlayGetTodayQuestionByMSISDNBonusHour(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spQuizPlayGetTodayQuestionByMSISDNBonusHour_Result>("spQuizPlayGetTodayQuestionByMSISDNBonusHour", mSISDNParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spUpdateQuizPlayUserAnswerBonusHour(string answer, string mSISDN, Nullable<long> questionNo, Nullable<long> timeTaken)
        {
            var answerParameter = answer != null ?
                new ObjectParameter("Answer", answer) :
                new ObjectParameter("Answer", typeof(string));
    
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            var questionNoParameter = questionNo.HasValue ?
                new ObjectParameter("QuestionNo", questionNo) :
                new ObjectParameter("QuestionNo", typeof(long));
    
            var timeTakenParameter = timeTaken.HasValue ?
                new ObjectParameter("TimeTaken", timeTaken) :
                new ObjectParameter("TimeTaken", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spUpdateQuizPlayUserAnswerBonusHour", answerParameter, mSISDNParameter, questionNoParameter, timeTakenParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spGetQuestionCountBYMSISDNBonusHour(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spGetQuestionCountBYMSISDNBonusHour", mSISDNParameter);
        }
    
        public virtual ObjectResult<spScoreBonus_Result> spScoreBonus(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spScoreBonus_Result>("spScoreBonus", mSISDNParameter);
        }
    
        public virtual ObjectResult<string> sp_QuizPlay_Subscribe_Unsubscribe(string mSISDN, string subscriptionSource, Nullable<int> reg_Status, string activationSource, string type)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            var subscriptionSourceParameter = subscriptionSource != null ?
                new ObjectParameter("SubscriptionSource", subscriptionSource) :
                new ObjectParameter("SubscriptionSource", typeof(string));
    
            var reg_StatusParameter = reg_Status.HasValue ?
                new ObjectParameter("Reg_Status", reg_Status) :
                new ObjectParameter("Reg_Status", typeof(int));
    
            var activationSourceParameter = activationSource != null ?
                new ObjectParameter("ActivationSource", activationSource) :
                new ObjectParameter("ActivationSource", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("sp_QuizPlay_Subscribe_Unsubscribe", mSISDNParameter, subscriptionSourceParameter, reg_StatusParameter, activationSourceParameter, typeParameter);
        }
    
        public virtual int spUnsubricbeQuizPlayRobiAirtel(string mSISDN)
        {
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spUnsubricbeQuizPlayRobiAirtel", mSISDNParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> spInsert_QuizPlay_ACCESS(string sOURCE_URL, string sERVICE_REQUEST, string mSISDN, string hS_MANUFACTURER, string hS_MODEL, string hS_DIM, string aPN, string pORTAL_FULLnSHORT, string cMPAIN_KEY, string iP, string oS, string uAHeader)
        {
            var sOURCE_URLParameter = sOURCE_URL != null ?
                new ObjectParameter("SOURCE_URL", sOURCE_URL) :
                new ObjectParameter("SOURCE_URL", typeof(string));
    
            var sERVICE_REQUESTParameter = sERVICE_REQUEST != null ?
                new ObjectParameter("SERVICE_REQUEST", sERVICE_REQUEST) :
                new ObjectParameter("SERVICE_REQUEST", typeof(string));
    
            var mSISDNParameter = mSISDN != null ?
                new ObjectParameter("MSISDN", mSISDN) :
                new ObjectParameter("MSISDN", typeof(string));
    
            var hS_MANUFACTURERParameter = hS_MANUFACTURER != null ?
                new ObjectParameter("HS_MANUFACTURER", hS_MANUFACTURER) :
                new ObjectParameter("HS_MANUFACTURER", typeof(string));
    
            var hS_MODELParameter = hS_MODEL != null ?
                new ObjectParameter("HS_MODEL", hS_MODEL) :
                new ObjectParameter("HS_MODEL", typeof(string));
    
            var hS_DIMParameter = hS_DIM != null ?
                new ObjectParameter("HS_DIM", hS_DIM) :
                new ObjectParameter("HS_DIM", typeof(string));
    
            var aPNParameter = aPN != null ?
                new ObjectParameter("APN", aPN) :
                new ObjectParameter("APN", typeof(string));
    
            var pORTAL_FULLnSHORTParameter = pORTAL_FULLnSHORT != null ?
                new ObjectParameter("PORTAL_FULLnSHORT", pORTAL_FULLnSHORT) :
                new ObjectParameter("PORTAL_FULLnSHORT", typeof(string));
    
            var cMPAIN_KEYParameter = cMPAIN_KEY != null ?
                new ObjectParameter("CMPAIN_KEY", cMPAIN_KEY) :
                new ObjectParameter("CMPAIN_KEY", typeof(string));
    
            var iPParameter = iP != null ?
                new ObjectParameter("IP", iP) :
                new ObjectParameter("IP", typeof(string));
    
            var oSParameter = oS != null ?
                new ObjectParameter("OS", oS) :
                new ObjectParameter("OS", typeof(string));
    
            var uAHeaderParameter = uAHeader != null ?
                new ObjectParameter("UAHeader", uAHeader) :
                new ObjectParameter("UAHeader", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("spInsert_QuizPlay_ACCESS", sOURCE_URLParameter, sERVICE_REQUESTParameter, mSISDNParameter, hS_MANUFACTURERParameter, hS_MODELParameter, hS_DIMParameter, aPNParameter, pORTAL_FULLnSHORTParameter, cMPAIN_KEYParameter, iPParameter, oSParameter, uAHeaderParameter);
        }
    
        public virtual ObjectResult<sp_GetLiveQuestions_Result> sp_GetLiveQuestions()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetLiveQuestions_Result>("sp_GetLiveQuestions");
        }
    
        public virtual ObjectResult<sp_GetTotalLiveRightAnswer_Result> sp_GetTotalLiveRightAnswer(Nullable<int> qid)
        {
            var qidParameter = qid.HasValue ?
                new ObjectParameter("Qid", qid) :
                new ObjectParameter("Qid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetTotalLiveRightAnswer_Result>("sp_GetTotalLiveRightAnswer", qidParameter);
        }
    
        public virtual ObjectResult<sp_GetUserLiveResult_Result> sp_GetUserLiveResult(string msisdn)
        {
            var msisdnParameter = msisdn != null ?
                new ObjectParameter("msisdn", msisdn) :
                new ObjectParameter("msisdn", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetUserLiveResult_Result>("sp_GetUserLiveResult", msisdnParameter);
        }
    
        public virtual int sp_GetLiveUserList(string fbid)
        {
            var fbidParameter = fbid != null ?
                new ObjectParameter("fbid", fbid) :
                new ObjectParameter("fbid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_GetLiveUserList", fbidParameter);
        }
    
        public virtual ObjectResult<sp_GetLiveUserList1_Result> sp_GetLiveUserList1(string fbid)
        {
            var fbidParameter = fbid != null ?
                new ObjectParameter("fbid", fbid) :
                new ObjectParameter("fbid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetLiveUserList1_Result>("sp_GetLiveUserList1", fbidParameter);
        }
    
        public virtual ObjectResult<sp_GetLiveQuestions_Challange_Result> sp_GetLiveQuestions_Challange(Nullable<int> qtypeid)
        {
            var qtypeidParameter = qtypeid.HasValue ?
                new ObjectParameter("qtypeid", qtypeid) :
                new ObjectParameter("qtypeid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetLiveQuestions_Challange_Result>("sp_GetLiveQuestions_Challange", qtypeidParameter);
        }
    
        public virtual int sp_GetTotalChallangeRightAnswer(string roomid, string type, Nullable<int> sessionNumber)
        {
            var roomidParameter = roomid != null ?
                new ObjectParameter("roomid", roomid) :
                new ObjectParameter("roomid", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            var sessionNumberParameter = sessionNumber.HasValue ?
                new ObjectParameter("sessionNumber", sessionNumber) :
                new ObjectParameter("sessionNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_GetTotalChallangeRightAnswer", roomidParameter, typeParameter, sessionNumberParameter);
        }
    
        public virtual ObjectResult<sp_GetTotalChallangeRightAnswer1_Result> sp_GetTotalChallangeRightAnswer1(string roomid, string type, Nullable<int> sessionNumber)
        {
            var roomidParameter = roomid != null ?
                new ObjectParameter("roomid", roomid) :
                new ObjectParameter("roomid", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            var sessionNumberParameter = sessionNumber.HasValue ?
                new ObjectParameter("sessionNumber", sessionNumber) :
                new ObjectParameter("sessionNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetTotalChallangeRightAnswer1_Result>("sp_GetTotalChallangeRightAnswer1", roomidParameter, typeParameter, sessionNumberParameter);
        }
    }
}
