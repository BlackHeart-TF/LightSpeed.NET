using System.Xml.Serialization;

namespace LightspeedNET.Models.Common
{
    public class Contact
    {
        [XmlElement("address1")]
        public string Address1 { get; set; }
    [XmlElement("address2")]
    public string Address2 { get; set; }
[XmlElement("city")]
public string City { get; set; }
    [XmlElement("state")]
public string State { get; set; }
    [XmlElement("stateCode")]
public string StateCode { get; set; }
    [XmlElement("zip")]
public string PostalCode { get; set; }
    [XmlElement("country")]
public string Country { get; set; }
    [XmlElement("countryCode")]
public string CountryCode { get; set; }
}
}