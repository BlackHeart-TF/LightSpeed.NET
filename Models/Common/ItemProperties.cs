using System;
using System.Xml.Serialization;
namespace LightspeedNET.Models.Common
{
    public class ItemAttributes
    {
        [XmlElement("attribute1")]
        public string Attribute1 { get; set; }
        [XmlElement("attribute2")]
        public string Attribute2 { get; set; }
        [XmlElement("attribute3")]
        public string Attribute3 { get; set; }
        [XmlElement("itemAttribueSetID")]
        public string ItemAttributeSetID { get; set; }
        [XmlElement("ItemAttributeSet")]
        public ItemAttributeSet ItemAttributeSet { get; set; }
    }
    public class Note
    {
        [XmlElement("note")]
        public string Text { get; set; }
        [XmlElement("isPublic")]
        public bool Public { get; set; }
        [XmlElement("timeStamp")]
        public System.DateTime TimeStamp { get; set; }
    }
    public class ItemShops
    {
        [XmlElement("itemShopID")]
        public int ItemShopID { get; set; }
        [XmlElement("qoh")]
        public int QuantityOnHand { get; set; }
        [XmlElement("backorder")]
        public int Backorders { get; set; }
        [XmlElement("componentQoh")]
        public int ComponentQOH { get; set; }
        [XmlElement("componentBackorder")]
        public int ComponentBackorders { get; set; }
        [XmlElement("reorderPoint")]
        public int ReorderPoint { get; set; }
        [XmlElement("reorderLevel")]
        public int ReorderLevel { get; set; }
        [XmlElement("timeStamp")]
        public System.DateTime TimeStamp { get; set; }
        [XmlElement("itemID")]
        public int ItemID { get; set; }
        [XmlElement("shopID")]
        public int ShopID { get; set; }
    }
    public class ItemComponent
    {
        [XmlElement("itemComponentID")]
        public int ItemComponentID { get; set; }
        [XmlElement("quantity")]
        public int Quantity { get; set; }
        [XmlElement("componentGroup")]
        public int ComponentGroup { get; set; }
        [XmlElement("assemblyItemID")]
        public int AssemblyItemID { get; set; }
        [XmlElement("componentItemID")]
        public int ComponentItemID { get; set; }
    }
    public class Season
    {
        [XmlElement("seasonID")]
        public int SeasonID { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
