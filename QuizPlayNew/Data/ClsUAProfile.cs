using System.Web;
//using System.Web.Mobile;
//using System.Web.UI.MobileControls;
using System.Xml;
using System.Net;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Data;
using System.Text;

namespace UAprofileFinder
{
    public partial class UAProfile
    {

        //CDA oCDA = new CDA();

        HttpRequest Request = HttpContext.Current.Request;
        public string GetUserAgent()
        {
            string userAgent = string.Empty;

            if (!string.IsNullOrEmpty(Request.ServerVariables["HTTP_USER_AGENT"]))
            {
                userAgent = Request.ServerVariables["HTTP_USER_AGENT"];
            }
            if (!string.IsNullOrEmpty(Request.Headers["X-OperaMini-Phone-UA"]))
            {
                userAgent = Request.Headers["X-OperaMini-Phone-UA"];
            }
            if (!string.IsNullOrEmpty(Request.Headers["Device-Stock-UA"]))
            {
                userAgent = Request.Headers["Device-Stock-UA"];
            }

            return userAgent;
        }
        //----------------------- New code for MSISDN-----------------------
        #region"MSISDN"
        public string GetMSISDN() // Find out the MSISDN Number of GrameenPhone Mobile
        {
            string sMsisdnNo = string.Empty;

            try
            {
                string sMsisdn = string.Empty;

                sMsisdn = Request.ServerVariables.Get("HTTP_X_UP_CALLING_LINE_ID");

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.Headers["X-WAP-Network-Client-MSISDN"]; } // for Airtel

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables["HTTP_X_WAP_NETWORK_CLIENT_MSISDN"]; } // for Airtel

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables["HTTP_MSISDN"]; }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables.Get("HTTP_MSISDN"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.Headers["MSISDN"]; }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.Headers.Get("MSISDN"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables.Get("X-MSISDN"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables.Get("User-Identity-Forward-msisdn"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables.Get("HTTP_X_FH_MSISDN"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables.Get("HTTP_X_MSISDN"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables["http_msisdn"]; }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables.Get("http_msisdn"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.Headers["msisdn"]; }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.Headers["msisdn"]; }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.Headers.Get("msisdn"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.Headers.Get("msisdn"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables["HTTP_X_HTS_CLID"]; }


                if (sMsisdn.Length > 13)
                {
                    for (int iCount = 1; iCount < sMsisdn.Length; iCount += 2)
                    {
                        sMsisdnNo += sMsisdn[iCount].ToString();
                    }
                }
                else
                {
                    sMsisdnNo = sMsisdn;
                }
            }
            catch (Exception ex)
            {
                sMsisdnNo = "Error - " + ex.Message;
            }
            //sMsisdnNo = "8801813735883";
            //sMsisdnNo = "8801688278908";
            return sMsisdnNo;
        }
        #endregion"MSISDN"
        //----------------------- New Code for MSISDN-------------------------

        public string GetUAProfileXWap()
        {
            HttpRequest Request = HttpContext.Current.Request;
            string sUAProfile = string.Empty;

            string xWapProfile = Request.Headers["X-Wap-Profile"];

            if (string.IsNullOrEmpty(xWapProfile))
            {
                xWapProfile = Request.Headers["x-wap-profile"];
            }
            if (string.IsNullOrEmpty(xWapProfile))
            {
                xWapProfile = Request.Headers["X-WAP-PROFILE"];
            }
            if (string.IsNullOrEmpty(xWapProfile))
            {
                xWapProfile = Request.ServerVariables["HTTP_X_WAP_PROFILE"];
            }
            if (string.IsNullOrEmpty(xWapProfile))
            {
                xWapProfile = Request.Headers["19-profile"];
            }
            if (string.IsNullOrEmpty(xWapProfile))
            {
                xWapProfile = Request.Headers["wap-profile"];
            }

            if (string.IsNullOrEmpty(xWapProfile) == false)
            {
                int iIndex = xWapProfile.IndexOf(".xml");

                if (iIndex == -1)
                { iIndex = xWapProfile.IndexOf(".rdf"); }

                int iFIndex = xWapProfile.IndexOf("http");

                if (iFIndex == 0)
                {
                    sUAProfile = xWapProfile.Substring(iFIndex, iIndex + 4);
                }
                if (iFIndex == 1)
                {
                    sUAProfile = xWapProfile.Substring(iFIndex, iIndex + 3);
                }
            }
            //sUAProfile = "http://wap.samsungmobile.com/uaprof/GT-I9100.xml";

            return sUAProfile;
        }
        //--------------- End New Addition Kabir : 27/06/2011-------------------------


        protected internal static string GetUAProfileOpera()
        {
            string phpURL = "http://www.vumobile.biz/wurfl/check_wurfl.php?force_ua=";
            string userAgent = string.Empty;

            HttpRequest Request = HttpContext.Current.Request;
            //string xWapProfile = Request.Headers["X-OperaMini-Phone-UA"];
            ////xWapProfile = "Nokia# E71";
            ////xWapProfile = "Android";

            if (!string.IsNullOrEmpty(Request.ServerVariables["HTTP_USER_AGENT"]))
            {
                userAgent = Request.ServerVariables["HTTP_USER_AGENT"];
            }
            if (!string.IsNullOrEmpty(Request.Headers["X-OperaMini-Phone-UA"]))
            {
                userAgent = Request.Headers["X-OperaMini-Phone-UA"];
            }
            if (!string.IsNullOrEmpty(Request.Headers["Device-Stock-UA"]))
            {
                userAgent = Request.Headers["Device-Stock-UA"];
            }
            string getValue = TinyEAIPostRequest(phpURL + userAgent);

            //string sUAProfile = PageBase.oBllFacade.GetDeviceUAProfileUrl(xWapProfile);
            string sUAProfile = getUaProf(getValue);

            return sUAProfile;
            //return xWapProfile;
        }

        public string GetUAProfileUrl()  // Find out the Dimention of Mobile Device
        {
            string sUAProfile = string.Empty;

            sUAProfile = GetUAProfileXWap();

            if (string.IsNullOrEmpty(sUAProfile))
            {
                sUAProfile = GetUAProfileOpera();
            }

            //sUAProfile = "http://nds1.nds.nokia.com/uaprof/NN73-1r100-SB3G.xml";
            return sUAProfile;
        }

        protected internal static string TinyEAIPostRequest(string strURL)
        {
            HttpWebResponse objHttpWebResponse = null;
            UTF8Encoding encoding;
            string strResponse = "";

            HttpWebRequest objHttpWebRequest;
            objHttpWebRequest = (HttpWebRequest)WebRequest.Create(strURL);
            objHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            objHttpWebRequest.PreAuthenticate = true;

            objHttpWebRequest.Method = "POST";

            //Prepare the request stream
            if (strURL != null && strURL != string.Empty)
            {
                encoding = new UTF8Encoding();
                Stream objStream = objHttpWebRequest.GetRequestStream();
                Byte[] Buffer = encoding.GetBytes(strURL);
                // Post the request
                objStream.Write(Buffer, 0, Buffer.Length);
                objStream.Close();
            }
            objHttpWebResponse = (HttpWebResponse)objHttpWebRequest.GetResponse();
            encoding = new UTF8Encoding();
            StreamReader objStreamReader =
                new StreamReader(objHttpWebResponse.GetResponseStream(), encoding);
            strResponse = objStreamReader.ReadToEnd();
            string removeBreak = Regex.Replace(strResponse, "\n", "");
            string MobileXml = Regex.Replace(removeBreak, "\"", "'");
            objHttpWebResponse.Close();
            objHttpWebRequest = null;
            return MobileXml;
        }

        protected internal static string getUaProf(string Val)
        {
            string xmlValue = string.Empty;

            string Node = @"\<uaprof\>(.*?)\</uaprof\>";

            foreach (Match match in Regex.Matches(Val, Node))
            {
                xmlValue = match.Groups[1].Value;
            }
            return xmlValue;
        }

        public string GetDimension()  // Find out the Dimention of Mobile Device
        {
            string handsetDimension = string.Empty;
            string MHW = GetUAProfileUrl();

            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(MHW);
            reader.Read();
            doc.Load(reader);
            XmlNodeList prices = doc.GetElementsByTagName("prf:ScreenSize");
            XmlNode product = doc.GetElementsByTagName("prf:ScreenSize")[0];
            foreach (XmlNode price in prices)
            {
                handsetDimension = price.ChildNodes[0].Value;
            }
            return handsetDimension;
        }

        public string GetHandsetModel() // Find out the Mobile Device Model
        {
            string handsetModel = string.Empty;
            string MHW = GetUAProfileUrl();

            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(MHW);
            reader.Read();
            doc.Load(reader);
            XmlNodeList prices = doc.GetElementsByTagName("prf:Model");
            XmlNode product = doc.GetElementsByTagName("prf:Model")[0];
            foreach (XmlNode price in prices)
            {
                handsetModel = price.ChildNodes[0].Value;
            }
            return handsetModel;
        }

        public string GetHandsetManufacturer()  // Find out the Mobile Device Manufacturer or Vendor
        {
            string handsetManufacturer = string.Empty;
            string MHW = GetUAProfileUrl();

            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(MHW);
            reader.Read();
            doc.Load(reader);
            XmlNodeList prices = doc.GetElementsByTagName("prf:Vendor");
            XmlNode product = doc.GetElementsByTagName("prf:Vendor")[0];
            foreach (XmlNode price in prices)
            {
                handsetManufacturer = price.ChildNodes[0].Value;
            }
            return handsetManufacturer;
        }

        public string GetHandsetPolyToneFormat()  // Find out which polytone format is supported by a particular Mobile Device
        {
            bool Flg_MIDI = false;
            bool Flg_SPMIDI = false;
            bool Flg_MMF = false;

            string AudioFormat = string.Empty;
            string MHW = GetUAProfileUrl();

            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(MHW);
            reader.Read();
            doc.Load(reader);
            XmlNodeList prices = doc.GetElementsByTagName("rdf:li");
            XmlNode product = doc.GetElementsByTagName("rdf:li")[0];
            foreach (XmlNode price in prices)
            {
                AudioFormat += "," + price.ChildNodes[0].Value;
            }

            if (AudioFormat.Contains("audio/sp-midi"))
            {
                Flg_SPMIDI = true;
            }
            if (AudioFormat.Contains("audio/midi"))
            {
                Flg_MIDI = true;
            }
            if (AudioFormat.Contains("audio/mmf"))
            {
                Flg_MMF = true;
            }
            if (Flg_SPMIDI == true && Flg_MIDI == true && Flg_MMF == true)
            {
                AudioFormat = "MIDI";
            }
            if (Flg_SPMIDI == false && Flg_MIDI == true && Flg_MMF == true)
            {
                AudioFormat = "MIDI";
            }
            if (Flg_SPMIDI == true && Flg_MIDI == true && Flg_MMF == false)
            {
                AudioFormat = "MIDI";
            }
            if (Flg_SPMIDI == false && Flg_MIDI == true && Flg_MMF == false)
            {
                AudioFormat = "MIDI";
            }
            if (Flg_SPMIDI == true && Flg_MIDI == false && Flg_MMF == true)
            {
                AudioFormat = "SPMIDI";
            }
            if (Flg_SPMIDI == true && Flg_MIDI == false && Flg_MMF == false)
            {
                AudioFormat = "SPMIDI";
            }

            if (Flg_SPMIDI == false && Flg_MIDI == false && Flg_MMF == true)
            {
                AudioFormat = "MMF";
            }

            return AudioFormat;
        }

        public string GetHandsetTrueToneFormat()  // Find out which Truetone format is supported by a particular Mobile Device
        {
            bool Flg_AMR = false;
            bool Flg_MP3 = false;
            string AudioFormat = string.Empty;

            string MHW = GetUAProfileUrl();

            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(MHW);
            reader.Read();
            doc.Load(reader);
            XmlNodeList prices = doc.GetElementsByTagName("rdf:li");
            XmlNode product = doc.GetElementsByTagName("rdf:li")[0];
            foreach (XmlNode price in prices)
            {
                AudioFormat += "," + price.ChildNodes[0].Value;
            }

            if (AudioFormat.Contains("audio/amr"))
            {
                Flg_AMR = true;
            }

            if (AudioFormat.Contains("audio/mp3"))
            {
                Flg_MP3 = true;
            }

            if (Flg_MP3 == true && Flg_AMR == true)
            {
                AudioFormat = "MP3";
            }

            if (Flg_MP3 == true && Flg_AMR == false)
            {
                AudioFormat = "MP3";
            }

            if (Flg_MP3 == false && Flg_AMR == true)
            {
                AudioFormat = "AMR";
            }
            return AudioFormat;
        }

        public bool IsNumeric(string strTextEntry)
        {
            bool bIsNumeric = true;
            try
            {
                System.Text.RegularExpressions.Regex objNotWholePattern = new Regex("[^0-9]");
                bIsNumeric = !objNotWholePattern.IsMatch(strTextEntry);
            }
            catch
            {
                bIsNumeric = false;
            }

            return bIsNumeric;
        }

        public string GetHandsetVideoFormat()  // Find out which polytone format is supported by a particular Mobile Device
        {
            bool Flg_3GP = false;
            //bool Flg_MP4 = false;
            //bool Flg_MPEG = false;

            string VideoFormat = string.Empty;

            string MHW = GetUAProfileUrl();

            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(MHW);
            reader.Read();
            doc.Load(reader);
            XmlNodeList prices = doc.GetElementsByTagName("rdf:li");
            XmlNode product = doc.GetElementsByTagName("rdf:li")[0];
            foreach (XmlNode price in prices)
            {
                VideoFormat += "," + price.ChildNodes[0].Value;
            }

            if (VideoFormat.Contains("video/3gpp"))
            {
                Flg_3GP = true;
            }
            //if (VideoFormat.Contains("video/mp4"))
            //{
            //    Flg_MP4 = true;
            //}
            //if (VideoFormat.Contains("video/mpeg4"))
            //{
            //    Flg_MPEG = true;
            //}
            //if (Flg_MP4 == true && Flg_3GP == true && Flg_MPEG == true)
            //{
            //    VideoFormat = "3GP";
            //}
            //if (Flg_MP4 == false && Flg_3GP == true && Flg_MPEG == true)
            //{
            //    VideoFormat = "3GP";
            //}
            //if (Flg_MP4 == true && Flg_3GP == true && Flg_MPEG == false)
            //{
            //    VideoFormat = "MIDI";
            //}
            //if (Flg_MP4 == false && Flg_3GP == true && Flg_MPEG == false)
            //{
            //    VideoFormat = "MIDI";
            //}
            //if (Flg_MP4 == true && Flg_3GP == false && Flg_MPEG == true)
            //{
            //    VideoFormat = "SPMIDI";
            //}
            //if (Flg_MP4 == true && Flg_3GP == false && Flg_MPEG == false)
            //{
            //    VideoFormat = "SPMIDI";
            //}

            //if (Flg_MP4 == false && Flg_3GP == false && Flg_MPEG == true)
            //{
            //    VideoFormat = "MMF";
            //}
            if (Flg_3GP == true)
            {
                VideoFormat = "3GP";
            }
            return VideoFormat;
        }

        public string GetAPN() // Find out the MSISDN Number of GrameenPhone Mobile
        {
            string sAPN = string.Empty;

            try
            {

                string sLAPN = string.Empty;

                sLAPN = Request.Headers["APN"];

                if (string.IsNullOrEmpty(sLAPN))
                {
                    sLAPN = Request.Headers.Get("APN");
                }

                if (string.IsNullOrEmpty(sLAPN))
                {
                    sLAPN = Request.Headers["x-up-operator"];
                }

                if (string.IsNullOrEmpty(sLAPN))
                { sLAPN = Request.Headers["HTTP_X_UP_OPERATOR"]; }

                if (string.IsNullOrEmpty(sLAPN))
                { sLAPN = Request.ServerVariables.Get("x-up-operator"); }

                if (string.IsNullOrEmpty(sLAPN))
                { sLAPN = Request.ServerVariables.Get("HTTP_X_UP_OPERATOR"); }

                //if (string.IsNullOrEmpty(sLAPN))
                //{ sLAPN = curr.GatewayVersion; }

                if (string.IsNullOrEmpty(sLAPN))
                { sLAPN = string.Empty; }
                else
                {
                    sAPN = sLAPN;
                }

            }
            catch (Exception ex)
            {
                sAPN = "Error - " + ex.Message;
            }

            return sAPN;
        }

      

        public string Encode(string Encode)
        {
            string encodedText = string.Empty;
            try
            {
                byte[] bytesToEncode = Encoding.UTF8.GetBytes(Encode);
                encodedText = Convert.ToBase64String(bytesToEncode);                
            }
            catch { }
            return encodedText;
        }

        public string Decode(string Decode)
        {
            string decodedText = string.Empty;
            try
            {
                byte[] decodedBytes = Convert.FromBase64String(Decode);
                decodedText = Encoding.UTF8.GetString(decodedBytes);                
            }
            catch { }
            return decodedText;
        }

        public string GetUserIP()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return Request.ServerVariables["REMOTE_ADDR"];
        }

        #region"OS Detect"
        public string GetOS() // Find out the OS of Mobile
        {
            HttpRequest Request = HttpContext.Current.Request;
            string strUserAgent = Request.UserAgent.ToString().ToLower();
            string OS = "N/A";
            if (strUserAgent != null)
            {
                if (strUserAgent.Contains("j2me"))
                {
                    OS = "J2ME";
                }
                if (strUserAgent.Contains("bada"))
                {
                    OS = "Bada OS";
                }
                if (strUserAgent.Contains("opera mini"))
                {
                    OS = "Opera Mini";
                }
                if (strUserAgent.Contains("iphone"))
                {
                    OS = "Iphone";
                }
                if (strUserAgent.Contains("blackberry"))
                {
                    OS = "Blackberry";
                }
                if (strUserAgent.Contains("windows"))
                {
                    OS = "Windows";
                }
                if (strUserAgent.Contains("windows ce"))
                {
                    OS = "Windows Mobile";
                }
                if (strUserAgent.Contains("android"))
                {
                    OS = "Android";
                }
                if (strUserAgent.Contains("symbian"))
                {
                    OS = "Symbian";
                }
                if (strUserAgent.Contains("symbos"))
                {
                    OS = "Symbian";
                }
            }
            return OS;
        }
        #endregion"OS Detect"

        //public string MakeAbsolute(string partialPath)
        //{
        //    // Remove any leading directory markers.
        //    if (partialPath.StartsWith(Path.AltDirectorySeparatorChar.ToString()) ||
        //        partialPath.StartsWith(Path.DirectorySeparatorChar.ToString()))
        //        partialPath = partialPath.Substring(1, partialPath.Length - 1);
        //    // Combing with the application root.
        //    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, partialPath).Replace("/", "\\");
        //}
        
    }
}