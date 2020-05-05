using System.Xml.Serialization;
namespace LightspeedNET.Models
{
    public class ItemMatrix : Item
    {
        [XmlElement("itemAttributeSetID")]
        public string ItemAttributeSetID { get; set; }
        [XmlElement("ItemAttributeSet")]
        public ItemAttributeSet ItemAttributeSet { get; set; }
    }
}