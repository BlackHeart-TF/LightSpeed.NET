using System;
using System.Xml.Serialization;
namespace LightspeedNET.Models.Common
{
    public class ReceptSetup
    {
        [XmlElement("receptSetupID")]
        public int ReceptSetupID { get; set; }
        [XmlElement("generalMsg")]
        public string GeneralMessage { get; set; }
        [XmlElement("workorderAgree")]
        public string WorkorderAgree { get; set; }
        [XmlElement("creditcardAgree")]
        public string CreditCardAgree { get; set; }
        [XmlElement("logo")]
        public string Logo { get; set; }
        [XmlElement("logoHeight")]
        public int LogoHeight { get; set; }
        [XmlElement("LogoWidth")]
        public int LogoWidth { get; set; }
        [XmlElement("header")]
        public string Header { get; set; }
    }
}