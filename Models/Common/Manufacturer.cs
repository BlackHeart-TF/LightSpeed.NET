using System;
using System.Xml.Serialization;

namespace LightspeedNET.Models.Common
{
    public class Manufacturer
    {
        [XmlElement("manufacturerID")]
        public int ManufacturerID { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("createTime")]
        public DateTime CreateTime { get; set; }
        [XmlElement("timeStamp")]
        public DateTime TimeStamp { get; set; }
}
}