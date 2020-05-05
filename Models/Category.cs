using System;
using System.Xml.Serialization;

namespace LightspeedNET.Models
{
    public class Category
    {
        [XmlElement("categoryID")]
        public int CategoryID { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("nodeDepth")]
        public string NodeDepth { get; set; }
        [XmlElement("fullPathName")]
        public string FullPathName { get; set; }
        [XmlElement("leftNode")]
        public int LeftNode { get; set; }
        [XmlElement("rightNode")]
        public int RightNode { get; set; }
        [XmlElement("createTime")]
        public DateTime CreateTime { get; set; }
        [XmlElement("timeStamp")]
        public DateTime TimeStamp { get; set; }
        [XmlElement("parentID")]
        public int PartentID { get; set; }
        [XmlElement("Parent")]
        public Category Parent { get; set; }


}
}
