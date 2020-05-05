using System.Xml.Serialization;

namespace LightspeedNET.Models
{
    [XmlType("CustomField")]
    public class CustomField
    {
        [XmlElement("customFieldID")]
        public int CustomFieldValueID { get; set; }
        [XmlElement("uom")]
        public string UnitOfMeasure { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("type")]
        public CustomFieldType Type { get; set; }
        [XmlElement("decimalPrecision")]
        public int DecimalPrecision { get; set; }
        [XmlElement("archived")]
        public bool Archived { get; set; }
        [XmlElement("default")]
        public CustomFieldValue Default { get; set; }
    }


    [XmlRoot("CustomFields")]
    public class CustomFields
    {
        [XmlElement("CustomField")]
        public CustomFieldValue[] CustomField { get; set; }
    }


    public enum CustomFieldType
    {
        [XmlEnum(Name = "default")]
        String,
        [XmlEnum(Name = "non_inventory")]
        Text,
        [XmlEnum(Name = "serialized")]
        Url,
        [XmlEnum(Name = "box")]
        Email,
        [XmlEnum(Name = "serialized_assembly")]
        DateTime,
        [XmlEnum(Name = "assembly")]
        Date,
        [XmlEnum(Name = "boolean")]
        Boolean,
        [XmlEnum(Name = "integer")]
        Integer,
        [XmlEnum(Name = "float")]
        Float,
        [XmlEnum(Name = "single_choice")]
        SingleChoice,
        [XmlEnum(Name = "multi_choice")]
        MultipleChoice
    }
}