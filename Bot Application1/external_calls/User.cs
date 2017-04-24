using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Telenor_Dashboard
{
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRoot("user")]
    public class User
    {
        public long id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string allowEmail { get; set; }
        [XmlElementAttribute("msisdns")]
        public List<Msisdn> msisdns { get; set; }
        [XmlIgnoreAttribute]
        public string selectedMsisdn { get; set; }
    }

    [XmlRoot("msisdns")]
    public class Msisdn
    {
        public string msisdn { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public long id { get; set; }
        public string type { get; set; }
    }

 }
