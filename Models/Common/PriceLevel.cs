using System.Xml.Serialization;

namespace LightspeedNET.Models.Common
{
    public class PriceLevel
    {
        [XmlElement("priceLevelID")]
        public int PriceLevelID { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("archived")]
        public bool Archived { get; set; }
        [XmlElement("canBeArchived")]
        public bool CanBeArchived { get; set; }
        [XmlElement("type")]
        public PriceLevelType Type { get; set; }
        [XmlElement("Calculation")]
        public object Calculation { get; set; }
    }

    public enum PriceLevelType
    {
        [XmlEnum("fixed")]
        Fixed,
    }
}