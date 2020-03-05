using System;
using System.Xml.Serialization;


namespace LightspeedNET.Models.Common
{
    [XmlType("Image")]
    public class Image
    {
        [XmlElement("imageID")]
        public int ImageID { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("filename")]
        public string FileName { get; set; }
        [XmlElement("ordering")]
        public int OrderIndex { get; set; }
        [XmlElement("publicID")]
        public string PublicID { get; set; }
        [XmlElement("baseImageURL")]
        public string BaseImageURL { get; set; }
        [XmlElement("itemID")]
        public int ItemID { get; set; }
        [XmlElement("itemMatrixID")]
        public int ItemMatrixID { get; set; }
        [XmlElement("Item")]
        public LightspeedNET.Models.Common.Item Item { get; set; }
        [XmlElement("ItemMatrix")]
        public ItemMatrix ItemMatrix { get; set; }

        public string getImageUrl()
        {
            return $"{BaseImageURL}/{PublicID}.png";
        }

    }
}
