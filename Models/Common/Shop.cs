using System.Xml.Serialization;

namespace LightspeedNET.Models.Common
{
    [XmlRoot(ElementName = "Shop")]
    public class Shop
    {
        [XmlElement("shopID")]
        public int ShopID { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("serviceRate")]
        public float SrviceRate { get; set; }
        [XmlElement("timeZone")]
        public string TimeZone { get; set; }
        [XmlElement("taxLabor")]
        public bool TaxLabor { get; set; }
        [XmlElement("labelTitle")]
        public LabelTitle LabelTitle { get; set; }
        [XmlElement("labelMsrp")]
        public bool LabelMSRP { get; set; }
        [XmlElement("archived")]
        public bool Archived { get; set; }
        [XmlElement("contactID")]
        public int ContactID { get; set; }
        [XmlElement("taxCatgoryID")]
        public int TaxCategoryID { get; set; }
        [XmlElement("receiptSetupID")]
        public int ReceiptSetupID { get; set; }
        [XmlElement("ccGatewayID")]
        public int GatewayID { get; set; }
        [XmlElement("priceLevelID")]
        public int PriceLevelID { get; set; }
        [XmlElement("Contact")]
        public Contact Contact { get; set; }
        [XmlElement("TaxCategory")]
        public TaxCategory TaxCategory { get; set; }
        [XmlElement("ReceiptSetup")]
        public ReceptSetup ReceptSetup { get; set; }
        [XmlElement("CCGateway")]
        public CCGateway Gateway { get; set; }
        [XmlElement("PriceLevel")]
        public PriceLevel PriceLevel { get; set; }
        [XmlElement("Registers")]
        public Registers Registers { get; set; }

    }
    public enum LabelTitle
    {
        [XmlEnum(Name = "No Title")]
        NoTitle,
        [XmlEnum(Name = "Shop Name")]
        ShopName,
        [XmlEnum(Name = "Website")]
        Website,
        [XmlEnum(Name = "Phone")]
        Phone,
        [XmlEnum(Name = "Custom")]
        Custom
    }
}