using System;
using System.Xml.Serialization;

namespace LightspeedNET.Models
{
    [XmlType("Categories")]
    public class CategoryArray
    {
        [XmlElement("Category")]
        public Category[] Category { get; set; }
    }
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
        public int ParentID { get; set; }

        [XmlElement("Parent")]
        private Category _parent { get; set; }
        [XmlIgnore]
        public Category Parent { 
            get 
            {
                if (_parent == null)
                {
                    _parent= Categories.GetCategory(ParentID.ToString());
                }
                return _parent;
            } 
            set { _parent = value; } }

        public Category()
        {

        }
        public Category(string name, string path, int parent)
        {
            Name = name;
            FullPathName = path;
            ParentID = parent;
        }
}
}
