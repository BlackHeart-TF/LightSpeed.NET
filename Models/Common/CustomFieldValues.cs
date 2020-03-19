using System.Xml.Serialization;

namespace LightspeedNET.Models.Common
{
    [XmlType("CustomFieldValue")]
    public class CustomFieldValue
    {
        [XmlElement("customFieldValueID")]
        public int CustomFieldValueID { get; set; }
        [XmlElement("value")]
        public Value Value { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("type")]
        public string Type { get; set; }
        [XmlElement("deleted")]
        public bool Deleted { get; set; }
        [XmlElement("customFieldID")]
        public int CustomFieldID { get; set; }
    }

    //<value>
    //  <customFieldChoiceID>35</customFieldChoiceID>
    //  <value/>
    //  <name>3</name>
    //  <canBeDeleted readonly="true">false</canBeDeleted>
    //  <customFieldID>4</customFieldID>
    //</value>
    [XmlType("value")]
    public class Value
    {
        [XmlElement("customFieldChoiceID")]
        public int CustomFieldChoiceID { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("canBeDeleted")]
        public bool CanBeDeleted { get; set; }
        [XmlElement("customFieldID")]
        public int customFieldID { get; set; }
    }

    [XmlType("CustomFieldChoices")]
    public class CustomFieldValues
    {
        [XmlElement("CustomFieldChoice")]
        public Value[] CustomFieldChoices;

    }
}