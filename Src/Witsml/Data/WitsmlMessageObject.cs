using System.Collections.Generic;
using System.Xml.Serialization;

namespace Witsml.Data
{
    [XmlRoot]
    public class WitsmlMessageObject
    {
        [XmlAttribute("uidWellbore")] public string UidWellbore { get; set; }
        [XmlElement("nameWell")] public string NameWell { get; set; }
        [XmlElement("nameWellbore")] public string NameWellbore { get; set; }
        [XmlAttribute("uidWell")] public string UidWell { get; set; }


        //.
        //.
        //.

        [XmlElement("commonData")] public WitsmlCommonData CommonData { get; set; }
    }
}
