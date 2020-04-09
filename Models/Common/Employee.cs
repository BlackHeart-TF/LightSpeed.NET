using System;
using System.Xml.Serialization;

namespace LightspeedNET.Models.Common
{
    [XmlType("employee")]
    public class Employee
    {
        [XmlElement("employeeID")]
        public int EmployeeID { get; set; }
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; }
        [XmlIgnore]
        public string FullName { get { return FirstName + " " + LastName; } }
        [XmlElement("lockOut")]
        public bool LockedOut { get; set; }
        [XmlElement("archived")]
        public bool Archived { get; set; }
        [XmlElement("contactID")]
        public int ContactID { get; set; }
        [XmlElement("clockInEmployeeHoursID")]
        public int ClockInEmployeeHoursID { get; set; }
        [XmlElement("employeeRoleID")]
        public int EmployeeRoleID { get; set; }
        [XmlElement("limitToShopID")]
        public int LimitToShopID { get; set; }
        [XmlElement("lastShopID")]
        public int LastShopID { get; set; }
        [XmlElement("lastSaleID")]
        public int LastSaleID { get; set; }
        [XmlElement("lastRegisterID")]
        public int LastRegisterID { get; set; }
        [XmlElement("Contact")]
        public Contact Contact { get; set; }
        [XmlElement("EmployeeRole")]
        public EmployeeRole EmployeeRole { get; set; }
        [XmlElement("EmplyeeRights")]
        public EmployeeRights EmployeeRights { get; set; }
        [XmlElement("timeStamp")]
        public DateTime TimeStamp { get; set; }

    }

    public class EmployeeRights
    {
        [XmlElement("employeeRightID")]
        public int EmplyeeRightID { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
    }

    [XmlType("employeeRole")]
    public class EmployeeRole
    {
        [XmlElement("employeeRoleID")]
        public int EmployeeRoleID { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("EmployeeRights")]
        public EmployeeRights EmployeeRights { get; set; }
    }
}
