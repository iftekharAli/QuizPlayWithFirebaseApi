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
    
    public partial class tbl_Subscriber_QuizPlay
    {
        public string SubscriberID { get; set; }
        public int ServiceID { get; set; }
        public string MSISDN { get; set; }
        public string Operator { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SubscriptionSource { get; set; }
        public System.DateTime Reg_Date { get; set; }
        public Nullable<System.DateTime> ReactivationDate { get; set; }
        public Nullable<System.DateTime> DeactivationDate { get; set; }
        public int Reg_Status { get; set; }
        public string Charge_Status { get; set; }
        public Nullable<System.DateTime> LastChargedDate { get; set; }
        public string REG_AUTO { get; set; }
        public int MODIFY_COUNT { get; set; }
        public System.DateTime LAST_UPDATE { get; set; }
        public string Confirmation { get; set; }
        public string Subs_Pack { get; set; }
        public string ActivationSource { get; set; }
        public Nullable<int> ACB { get; set; }
        public Nullable<int> IsBlocked { get; set; }
        public string Source_URL_OA { get; set; }
        public Nullable<int> isGrace { get; set; }
        public Nullable<int> IsGraceDeactivate { get; set; }
        public Nullable<int> Is6888 { get; set; }
    }
}
