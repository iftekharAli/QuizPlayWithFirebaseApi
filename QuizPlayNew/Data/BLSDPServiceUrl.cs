public class BLSDPServiceUrl
{

    private string appid { get; set; }
    private string apppass { get; set; }
    private string ano { get; set; }
    private string serviceid { get; set; }
    private string subscriptiongroupid { get; set; }
    private string bno { get; set; }
    private string contentid { get; set; }
    private string request_type { get; set; }
    private string apiurl { get; set; }


    public BLSDPServiceUrl()
    {
        appid = "bdtube";
        apppass = "mportal";

        apiurl = "http://103.239.252.108/blsdp_wap/consent.php?appid=" + appid + "&apppass=" + apppass;
    }

    public string GetSubcriptionUrl(string msisdn, string serviceid, string subscriptiongroupid, string shortcode, string backURL)
    {

        if (msisdn.StartsWith("880"))
        {
            msisdn = msisdn.Substring(3, msisdn.Length - 3);
        }
        else if (msisdn.StartsWith("0"))
        {

            msisdn = msisdn.Substring(1, msisdn.Length - 1);
        }


        apiurl = apiurl + "&subscriptiongroupid=" + subscriptiongroupid + "&serviceid=" + serviceid + "&ano=" + msisdn + "&bno=" + shortcode + "&contentid=1&api=http://wap.shabox.mobi/blsdpapi/" + "&back=" + backURL + "&referenceId=1&request_type=Subscription";

        return apiurl;

    }
    public string GetContentDownloadUrl(string msisdn, string serviceid, string subscriptiongroupid, string shortcode, string backURL)
    {

        if (msisdn.StartsWith("880"))
        {
            msisdn = msisdn.Substring(3, msisdn.Length - 3);
        }
        else if (msisdn.StartsWith("0"))
        {

            msisdn = msisdn.Substring(1, msisdn.Length - 1);
        }


        apiurl = apiurl + "&subscriptiongroupid=" + subscriptiongroupid + "&serviceid=" + serviceid + "&ano=" + msisdn + "&bno=" + shortcode + "&contentid=1&api=http://wap.shabox.mobi/blsdpapi/" + "&back=" + backURL + "&referenceId=1&request_type=Content";


        return apiurl;

    }
}