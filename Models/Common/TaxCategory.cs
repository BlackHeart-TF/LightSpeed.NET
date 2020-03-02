using System.Xml.Serialization;

namespace LightspeedNET.Models.Common
{
    public class TaxCategory
    {
        [XmlElement("taxCategoryID")]
        public int TaxCategoryID { get; set; }
        [XmlElement("isTaxIncusive")]
        public bool TaxExclusive { get; set; }
        [XmlElement("tax1Name")]
        public string Tax1Name { get; set; }
        [XmlElement("tax2Name")]
        public string Tax2Name { get; set; }
        [XmlElement("tax1Rate")]
        public float Tax1Rate { get; set; }
        [XmlElement("tax2Rate")]
        public float Tax2Rate { get; set; }
        [XmlElement("TaxCategoryClasses")]
        public TaxCategoryClass[] TaxCategoryClasses { get; set; }
        [XmlElement("timeStamp")]
        public System.DateTime TimeStamp { get; set; }
    }
}