using System;
using System.Xml.Serialization;

namespace LightspeedNET.Models
{
    public class Registers
    {
        [XmlElement("registerID")]
        public int RegisterID { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("open")]
        public bool Open { get; set; }
        [XmlElement("openTime")]
        public DateTime OpenTime { get; set; }
        [XmlElement("openEmployeeID")]
        public int OpenEmployeeID { get; set; }
        [XmlElement("shopID")]
        public int ShopID { get; set; }
    }
}