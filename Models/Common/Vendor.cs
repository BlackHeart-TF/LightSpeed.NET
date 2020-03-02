using System;
using System.Xml.Serialization;

namespace LightspeedNET.Models.Common
{
    public class Vendor
    {
        [XmlElement("vendorID")]
        public int VendorID { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("archived")]
        public bool Archived { get; set; }
        [XmlElement("accountNumber")]
        public string AccountNumber { get; set; }
        [XmlElement("priceLevel")]
        public string PriceLevel { get; set; }
        [XmlElement("updatePrice")]
        public bool UpdatePrice { get; set; }
        [XmlElement("updateCost")]
        public bool UpdateCost { get; set; }
        [XmlElement("updateDescription")]
        public bool UpdateDescription { get; set; }
        [XmlElement("shareSellThrough")]
        public bool ShareSellThrough { get; set; }
        [XmlElement("timeStamp")]
        public DateTime TimeStamp { get; set; }
        [XmlElement("Contact")]
        public Contact Contact { get; set; }
        [XmlElement("Reps")]
        public string[] Reps { get; set; }
    }

}