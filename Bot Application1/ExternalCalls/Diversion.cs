using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotApplication1
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("diversion")]
    public class Diversion
    {
        public string id {get; set;}
        public string start { get; set; }
        public DateTime end { get; set; }
        public DiversionDuration duration { get; set; }
        public DiversionReason reason { get; set; }
        public string message { get; set; }
        public DiversionDestinationCode destination { get; set; }
        public Boolean active { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class DiversionDuration
    {
        public string id { get; set; }
        public string description { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class DiversionReason
    {
        public string id { get; set; }
        public string reason { get; set; }
        public DateTime defaultEnd { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class DiversionDestinationCode
    {
        public string destinationId { get; set; }
        public string actualDestination { get; set; }
        public string description { get; set; }
        public Boolean defaultDestination { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("diversionPreset")]
    public class DiversionPreset
    {
        public string id { get; set; }
        public DiversionReason reason { get; set; }
        public string label { get; set; }
        public string message { get; set; }
        public string text { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string duration { get; set; }
        public DiversionDestinationCode destination { get; set; }
        public DiversionDestinationCode divertTo { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("diversionPresets")]
    public class DiversionPresetList
    {
        [System.Xml.Serialization.XmlElementAttribute("diversionPreset")]
        public List<DiversionPreset> diversionPresets { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("diversionsResponse")]
    public class DiversionsResponse
    {
        public string availableAt { get; set; }
        public List<Diversion> diversions { get; set; }
        [System.Xml.Serialization.XmlArrayItemAttribute("preset", IsNullable = false)]
        public List<DiversionPreset> presets { get; set; }
        [System.Xml.Serialization.XmlArrayItemAttribute("reason", IsNullable = false)]
        public List<DiversionReason> reasons { get; set; }
        [System.Xml.Serialization.XmlArrayItemAttribute("destination", IsNullable = false)]
        public List<DiversionDestinationCode> destinations { get; set; }
        [System.Xml.Serialization.XmlArrayItemAttribute("duration", IsNullable = false)]
        public List<DiversionDuration> durations { get; set; }
    }
}

