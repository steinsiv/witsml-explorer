using System.Collections.Generic;
using System.Xml.Serialization;

namespace Witsml.Data
{
    [XmlRoot("messageobjects", Namespace = "http://www.witsml.org/schemas/1series")]
    public class WitsmlMessageObjects : IWitsmlQueryType
    {
        // @TODO: To be checked
        // Rest of props

        [XmlAttribute("version")]
        public string Version = "1.4.1.1";

        [XmlElement("messageobject")]
        public List<WitsmlMessageObject> MessageObjects { get; set; } = new List<WitsmlMessageObject>();

        public string TypeName => "messageobject";
    }
}
