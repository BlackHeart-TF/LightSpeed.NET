using System.Xml.Serialization;

namespace LightspeedNET.Models
{
    public class TaxCategoryClass
    {
        [XmlElement("timeStamp")]
        public System.DateTime TimeStamp { get; set; }
    }
    public class TaxClass
    {
        [XmlElement("taxClassID")]
        public int TaxClassID { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlArray("SaleLines")]
        public string[] SaleLines { get; set; }
        [XmlArray("Items")]
        public Item[] Items { get; set; }
        [XmlElement("timeStamp")]
        public System.DateTime TimeStamp { get; set; }
    }
}