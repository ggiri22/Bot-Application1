using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml.Serialization;

namespace Telenor_Dashboard
{
    class DiversionDomain
    {

        public static List<DiversionDestinationCode> Destinations {  get; set; }

        public static List<DiversionReason> Reasons { get; set; }

        public static DiversionsResponse GetDiversion()
        {
            string CommandString = "/users/{username}/{msisdn}/diversion";

            CommandString = AppApiDomain.CompileCommand(CompileOptions.UserNameAndMsisdn, CommandString);

            HttpWebRequest webRequestObj = AppApiDomain.CreateWebRequest(CommandString, "GET");
            WebResponse webResponceObj = webRequestObj.GetResponse();
            StreamReader reader = new StreamReader(webResponceObj.GetResponseStream());

            XmlSerializer serializer = new XmlSerializer(typeof(DiversionsResponse));
            DiversionsResponse diversionsResponseObj = (DiversionsResponse)serializer.Deserialize(reader);

            webResponceObj.Close();

            DiversionReason diversionsResponseReasonObj = new DiversionReason();
            diversionsResponseReasonObj.reason = "Ingen";
            diversionsResponseObj.reasons.Insert(0, diversionsResponseReasonObj);

            Destinations = diversionsResponseObj.destinations;
            Reasons = diversionsResponseObj.reasons;

            return diversionsResponseObj;
        }

        //public static DiversionsResponse GetDiversion()
        //{
        //    string CommandString = "/users/{username}/{msisdn}/diversion";

        //    Dictionary<string, string> arguments = new Dictionary<string, string>();
        //    arguments.Add("username", "johan.x.svensson@telenor.com");
        //    arguments.Add("msisdn", "46709614660");

        //    CommandString = AppApiDomain.CompileCommand(CommandString, arguments);

        //    HttpWebRequest webRequestObj = AppApiDomain.CreateWebRequest(CommandString, "GET");

        //    WebResponse webResponceObj = webRequestObj.GetResponse();

        //    StreamReader reader = new StreamReader(webResponceObj.GetResponseStream());

        //    //MyUtilities.DebugXml(reader);

        //    XmlSerializer serializer = new XmlSerializer(typeof(DiversionsResponse));
        //    DiversionsResponse diversionsResponseObj = (DiversionsResponse)serializer.Deserialize(reader);
            
        //    webResponceObj.Close();

        //    DiversionReason diversionsResponseReasonObj = new DiversionReason();
        //    diversionsResponseReasonObj.reason = "Ingen";
        //    diversionsResponseObj.reasons.Insert(0, diversionsResponseReasonObj);

        //    Destinations = diversionsResponseObj.destinations;
        //    Reasons = diversionsResponseObj.reasons;

        //    return diversionsResponseObj;
        //}

        public static List<DiversionPreset> GetDiversionPresets()
        {
            string CommandString = "/users/{username}/{msisdn}/diversion/presets";

            CommandString = AppApiDomain.CompileCommand(CompileOptions.UserNameAndMsisdn,CommandString);

            HttpWebRequest webRequestObj = AppApiDomain.CreateWebRequest(CommandString, "GET");

            WebResponse webResponceObj = webRequestObj.GetResponse();

            StreamReader reader = new StreamReader(webResponceObj.GetResponseStream());

            XmlSerializer serializer = new XmlSerializer(typeof(DiversionPresetList));
            DiversionPresetList DiversionPresetList = (DiversionPresetList)serializer.Deserialize(reader);
            reader.Close();
            webResponceObj.Close();

            DiversionPreset DiversionPresetObj = new DiversionPreset();
            DiversionPresetObj.text = "Ingen";

            DiversionPresetList.diversionPresets.Insert(0, DiversionPresetObj);

            return DiversionPresetList.diversionPresets;
        }

        public static DiversionsResponse SetDiversion(Diversion DiversionObj)
        {
            string CommandString = "/users/{username}/{msisdn}/diversion";

            CommandString = AppApiDomain.CompileCommand(CompileOptions.UserNameAndMsisdn,CommandString);

            HttpWebRequest webRequestObj = AppApiDomain.CreateWebRequest(CommandString, "POST");

            Stream requestStream = webRequestObj.GetRequestStream();

            XmlSerializer serializer = new XmlSerializer(typeof(Diversion));

            serializer.Serialize(requestStream, DiversionObj);

            WebResponse webResponceObj = webRequestObj.GetResponse();

            StreamReader reader = new StreamReader(webResponceObj.GetResponseStream());

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(reader);
            webResponceObj.Close();

            return null;
        }

        public static void DeleteAllDiversions()
        {
            string CommandString = "/users/{username}/{msisdn}/diversion";

            CommandString = AppApiDomain.CompileCommand(CompileOptions.UserNameAndMsisdn,CommandString);

            HttpWebRequest webRequestObj = AppApiDomain.CreateWebRequest(CommandString, "DELETE");

            WebResponse webResponceObj = webRequestObj.GetResponse();

            StreamReader reader = new StreamReader(webResponceObj.GetResponseStream());

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(reader);
            webResponceObj.Close();
        }

        public static void DeleteDiversion(string id)
        {
            string CommandString = "/users/{username}/{msisdn}/diversion/{id}";

            Dictionary<string, string> arguments = new Dictionary<string, string>();
            arguments.Add("username", "johan.x.svensson@telenor.com");
            arguments.Add("msisdn", "46709614660");
            arguments.Add("id", id);

            CommandString = AppApiDomain.CompileCommand(CompileOptions.UserNameAndMsisdn,CommandString,id);

            HttpWebRequest webRequestObj = AppApiDomain.CreateWebRequest(CommandString, "DELETE");

            WebResponse webResponceObj = webRequestObj.GetResponse();

            StreamReader reader = new StreamReader(webResponceObj.GetResponseStream());

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(reader);
            webResponceObj.Close();
        }
    }
}
