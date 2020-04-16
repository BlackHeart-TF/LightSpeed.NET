using System;
using LightspeedNET.Models.Common;
using System.Xml.Serialization;
namespace LightspeedNET.Models
{
    [XmlType("Session")]
    public class Session
    {
        [XmlElement("employeeID")]
        public int EmployeeID { get; set; }
        [XmlElement("systemCustomerID")]
        public string SystemCustomerID { get; set; }
        [XmlElement("systemCustomerName")]
        public string SystemCustomerName { get; set; }
        [XmlElement("systemUserID")]
        public int SystemUserID { get; set; }
        [XmlElement("systemAPIClientID")]
        public int SystemAPIClientID { get; set; }
        [XmlElement("shopCount")]
        public int ShopCount { get; set; }
        [XmlElement("Employee")]
        public Employee Employee { get; set; }
    }
}
