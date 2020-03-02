using System;
using System.Xml.Serialization;
namespace LightspeedNET.Models.Common
{
    [XmlRoot(ElementName = "Orders")]
    public class Orders
    {
        [XmlElement("Order")]
        public Order[] Order;
    }

    [XmlRoot(ElementName = "Order")]
    public class Order
    {
        [XmlElement("orderID")]
        public int OrderID { get; set; }
        [XmlElement("stockInstructions")]
        public int StockInstructions { get; set; }
        [XmlElement("shipCost")]
        public float ShipCost { get; set; }
        [XmlElement("otherCost")]
        public float OtherCost { get; set; }
        [XmlElement("complete")]
        public bool Complete { get; set; }
        [XmlElement("archived")]
        public bool Archived { get; set; }
        [XmlElement("discount")]
        public float Discount { get; set; }
        [XmlElement("totalDiscount")]
        public float TotalDiscount { get; set; }
        [XmlElement("totalQuantity")]
        public int TotalQuantity { get; set; }
        [XmlElement("vendorID")]
        public int VendorID { get; set; }
        [XmlElement("noteID")]
        public int NoteID { get; set; }
        [XmlElement("shopID")]
        public int ShopID { get; set; }
        [XmlElement("refNum")]
        public int ReferenceNumber { get; set; }
        [XmlElement("Vendor")]
        public Vendor Vendor { get; set; }
        [XmlElement("Note")]
        public Note Note { get; set; }
        [XmlElement("Shop")]
        public Shop Shop { get; set; }
        [XmlElement("OrderLines")]
        public OrderLine[] OrderLines { get; set; }
        [XmlElement("CustomFieldValues")]
        public CustomFieldValue[] CustomFieldValues { get; set; }
        [XmlElement("timeStamp")]
        public DateTime TimeStamp { get; set; }

    }
    public class OrderLine
    {
        [XmlElement("orderLineID")]
        public int OrderLineID { get; set; }
        [XmlElement("quantity")]
        public int Quantity { get; set; }
        [XmlElement("price")]
        public float price { get; set; }
        [XmlElement("originalPrice")]
        public float OriginalPrice { get; set; }
        [XmlElement("checkedIn")]
        public int CheckedIn { get; set; }
        [XmlElement("numReceived")]
        public int NumReceived { get; set; }
        [XmlElement("orderID")]
        public int OrderID { get; set; }
        [XmlElement("itemID")]
        public int ItemID { get; set; }
        [XmlElement("timeStamp")]
        public DateTime TimeStamp { get; set; }
        [XmlElement("total")]
        public float Total { get; set; }
    }
}
