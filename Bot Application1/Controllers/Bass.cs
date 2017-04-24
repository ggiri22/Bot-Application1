using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Collections.Generic;


namespace BotApplication1
{

    public class MyCustDetails
    {
        public string FirstName { get; set; } 
    }

    [Serializable]
    public class AskBassForCustomerDetails
    {

        public static List< MyCustDetails> GetCustDetails(string number)
        {
            List<MyCustDetails> Result = new List<MyCustDetails>();

            System.Xml.XmlDocument Doc = GetCustDetailsXml(number);

            System.Xml.XmlNodeList ContractNodes = Doc.GetElementsByTagName("CUSTOMER_DATA");
            foreach (System.Xml.XmlNode ContractNodeObj in ContractNodes)
            {
                MyCustDetails MyItem = new MyCustDetails();
                MyItem.FirstName = ContractNodeObj["PRICEPLAN"].InnerXml;
                Result.Add(MyItem);
            }

            return Result;
        }

        public static System.Xml.XmlDocument GetCustDetailsXml(string Number)
        {
            string SPD_Url = "http://prodbass.europolitan.se:9011/";
            SPD_Url += "BASSCUST/MSISDN/";
            SPD_Url += Number; 

            //Create a web request
            HttpWebRequest WebRequestObj = (HttpWebRequest)WebRequest.Create(SPD_Url);

            //Execute the request
            HttpWebResponse WebResponseObj = (HttpWebResponse)WebRequestObj.GetResponse();

            //Read the responce into a Stream reader
            StreamReader reader = new StreamReader(WebResponseObj.GetResponseStream(), System.Text.Encoding.GetEncoding("ISO-8859-1"));

            //Create an XML document
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(reader);

            //Close the Web request
            WebResponseObj.Close();
            WebResponseObj = null;

            return doc;
        }


    }
}

