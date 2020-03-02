using System;
using System.Xml.Serialization;

namespace LightspeedNET.Models.Common
{
    public class CCGateway
    {
        [XmlElement("ccGatewayID")]
        public int GatewayID { get; set; }
        [XmlElement("login")]
        public string Login { get; set; }
        [XmlElement("marketType")]
        public string MarketType { get; set; }
        [XmlElement("transKey")]
        public string TransKey { get; set; }
        [XmlElement("deviceType")]
        public int DeviceType { get; set; }
        [XmlElement("hashValue")]
        public string HashValue { get; set; }
        [XmlElement("enabled")]
        public bool Enabled { get; set; }
        [XmlElement("testMode")]
        public bool TestMode { get; set; }
        [XmlElement("gateway")]
        public string Gateway { get; set; }
        [XmlElement("accountNum")]
        public string AccountNum { get; set; }
        [XmlElement("terminalNum")]
        public string TerminalNum { get; set; }
        [XmlElement("allowCredits")]
        public bool AllowCredits { get; set; }
        [XmlElement("otherCredentials1")]
        public string OtherCredentials1 { get; set; }
        [XmlElement("otherCredentials2")]
        public string OtherCredentials2 { get; set; }
        [XmlElement("visaPaymentTypeID")]
        public int VisaPaymentTypeID { get; set; }
        [XmlElement("masterPaymentTypeID")]
        public int MasterPaymentTypeID { get; set; }
        [XmlElement("discorverPaymentTypeID")]
        public int DiscoverPaymentTypeID { get; set; }
        [XmlElement("americanPaymentTypeID")]
        public int AmericanPaymentTypeID { get; set; }
        [XmlElement("debitPaymentTypeID")]
        public int DebitPaymentTypeID { get; set; }

    }
}