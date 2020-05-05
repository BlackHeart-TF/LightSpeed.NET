using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace LightspeedNET.Models
{
    [XmlType("Item")]
    public class Item
    {
        [XmlElement("itemID")]
        public int ItemID { get; set; }
        [XmlElement("systemSku")]
        public int SystemSKU { get; }
        [XmlElement("defaultCost")]
        public float DefaultCost { get; set; }
        [XmlElement("avgCost")]
        public float AverageCost { get; set; }
        [XmlElement("tax")]
        public bool Taxable { get; set; }
        [XmlElement("archived")]
        public bool Archived { get; set; }
        [XmlElement("discountable")]
        public bool Discountable { get; set; }
        [XmlElement("itemType")]
        public itemType ItemType { get; set; }
        [XmlElement("serialized")]
        public bool Serialized { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("modelYear")]
        public int ModelYear { get; set; }
        [XmlElement("upc")]
        public string UPC { get; set; }
        [XmlElement("ean")]
        public string EAN { get; set; }
        [XmlElement("customSku")]
        public string CustomSKU { get; set; }
        [XmlElement("manufacturerSku")]
        public string ManufacurerSKU { get; set; }
        [XmlElement("timeStamp")]
        public DateTime TimeStamp { get; set; }
        [XmlElement("createTime")]
        public DateTime CreateTime { get; set; }
        [XmlElement("publishToEcom")]
        public bool PublishToEcom { get; set; }
        [XmlElement("categoryID")]
        public int CategoryID { get; set; }
        [XmlElement("taxClassID")]
        public int TaxClassID { get; set; }
        [XmlElement("departmentID")]
        public int DepartmentID { get; set; }
        [XmlElement("itemMatrixID")]
        public int ItemMatrixID { get; set; }
        [XmlElement("manufacturerID")]
        public int ManufacturerID { get; set; }
        [XmlElement("seasonID")]
        public int SeasonID { get; set; }
        [XmlElement("defaultVendorID")]
        public int DefaultVendorID { get; set; }
        [XmlElement("Category")]
        public Category Category { get; set; }
        [XmlElement("TaxClass")]
        public TaxClass TaxClass { get; set; }
        [XmlElement("Department")]
        public Department Department { get; set; }
        [XmlElement("ItemAttributes")]
        public ItemAttributes ItemAttributes { get; set; }
        [XmlElement("Manufacturer")]
        public Manufacturer Manufacturer { get; set; }
        [XmlElement("Note")]
        public Note Note { get; set; }
        [XmlElement("Season")]
        public Season Season { get; set; }
        [XmlElement("ItemShops")]
        public ItemShops ItemShops { get; set; }
        [XmlElement("ItemComponents")]
        public ItemComponent[] ItemComponents { get; set; }
        [XmlElement("ItemVendorNums")]
        public int[] ItemVendorNums { get; set; }
        [XmlArray("CustomFieldValues")]
        public CustomFieldValue[] CustomFieldValues { get; set; }
        [XmlArray("Images")]
        public Image[] Images { get; set; }
        [XmlIgnore]
        public string FirstImage { get { return Images[0].getImageUrl(); } }



    public enum itemType
        {
            [XmlEnum(Name = "default")]
            Default,
            [XmlEnum(Name = "non_inventory")]
            NonInventory,
            [XmlEnum(Name = "serialized")]
            Serialized,
            [XmlEnum(Name = "box")]
            Box,
            [XmlEnum(Name = "serialized_assembly")]
            SerializedAssembly,
            [XmlEnum(Name = "assembly")]
            Assembly
        }

    }


}
