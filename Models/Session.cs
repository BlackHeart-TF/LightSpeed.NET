using System;
using LightspeedNET.Models.Common;
using System.Xml.Serialization;
using System.Collections.Generic;

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
        

        [XmlElement("Rights")]
        public Dictionary<string, bool> Rights
        {
            get; set;
        }
    }

    [XmlType("Rights")]
    public class Rights
    {
        [XmlElement("admin")]
        public bool admin { get; set; }
        [XmlElement("admin_employees")]
        public bool admin_employees { get; set; }
        [XmlElement("admin_inventory")]
        public bool admin_inventory { get; set; }
        [XmlElement("admin_purchases")]
        public bool admin_purchases { get; set; }
        [XmlElement("admin_shops")]
        public bool admin_shops { get; set; }
        [XmlElement("admin_void_sale")]
        public bool admin_void_sale { get; set; }
        [XmlElement("allow_login")]
        public bool allow_login { get; set; }
        [XmlElement("categories")]
        public bool categories { get; set; }
        [XmlElement("customers")]
        public bool customers { get; set; }
        [XmlElement("customers_credit_limit")]
        public bool customers_credit_limit { get; set; }
        [XmlElement("customers_export")]
        public bool customers_export { get; set; }
        [XmlElement("customers_read")]
        public bool customers_read { get; set; }
        [XmlElement("customers_view_gift_card_numbers")]
        public bool customers_view_gift_card_numbers { get; set; }
        [XmlElement("ecom")]
        public bool ecom { get; set; }
        [XmlElement("inventory_base")]
        public bool inventory_base { get; set; }
        [XmlElement("inventory_counts")]
        public bool inventory_counts { get; set; }
        [XmlElement("inventory_counts_reconcile")]
        public bool inventory_counts_reconcile { get; set; }
        [XmlElement("inventory_import")]
        public bool inventory_import { get; set; }
        [XmlElement("inventory_read")]
        public bool inventory_read { get; set; }
        [XmlElement("manufacturers")]
        public bool manufacturers { get; set; }
        [XmlElement("product_cost")]
        public bool product_cost { get; set; }
        [XmlElement("product_edit")]
        public bool product_edit { get; set; }
        [XmlElement("purchase_orders")]
        public bool purchase_orders { get; set; }
        [XmlElement("purchase_orders_receive")]
        public bool purchase_orders_receive { get; set; }
        [XmlElement("register")]
        public bool register { get; set; }
        [XmlElement("register_catalogs")]
        public bool register_catalogs { get; set; }
        [XmlElement("register_close")]
        public bool register_close { get; set; }
        [XmlElement("register_layaway")]
        public bool register_layaway { get; set; }
        [XmlElement("register_line_discount")]
        public bool register_line_discount { get; set; }
        [XmlElement("register_open")]
        public bool register_open { get; set; }
        [XmlElement("register_price")]
        public bool register_price { get; set; }
        [XmlElement("register_read")]
        public bool register_read { get; set; }
        [XmlElement("register_refund")]
        public bool register_refund { get; set; }
        [XmlElement("register_transaction_discount")]
        public bool register_transaction_discount { get; set; }
        [XmlElement("register_withdraw")]
        public bool register_withdraw { get; set; }
        [XmlElement("reports")]
        public bool reports { get; set; }
        [XmlElement("special_orders")]
        public bool special_orders { get; set; }
        [XmlElement("tags")]
        public bool tags { get; set; }
        [XmlElement("transfers")]
        public bool transfers { get; set; }
        [XmlElement("transfers_send_stock")]
        public bool transfers_send_stock { get; set; }
        [XmlElement("vendor_returns")]
        public bool vendor_returns { get; set; }
        [XmlElement("vendors")]
        public bool vendors { get; set; }
        [XmlElement("vr_reasons")]
        public bool vr_reasons { get; set; }
        [XmlElement("workbench")]
        public bool workbench { get; set; }
    }
}
