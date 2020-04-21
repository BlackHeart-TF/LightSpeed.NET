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
        public Rights Rights { get; set; }
    }

    [XmlType("Rights")]
    public class Rights
    {
        [XmlElement("admin")]
        public bool Admin { get; set; }
        [XmlElement("admin_employees")]
        public bool EmployeesAdmin { get; set; }
        [XmlElement("admin_inventory")]
        public bool InventoryAdmin { get; set; }
        [XmlElement("admin_purchases")]
        public bool PurchasesAdmin { get; set; }
        [XmlElement("admin_shops")]
        public bool ShopsAdmin { get; set; }
        [XmlElement("admin_void_sale")]
        public bool VoidSaleAdmin { get; set; }
        [XmlElement("allow_login")]
        public bool AllowLogin { get; set; }
        [XmlElement("categories")]
        public bool Categories { get; set; }
        [XmlElement("customers")]
        public bool Customers { get; set; }
        [XmlElement("customers_credit_limit")]
        public bool CustomersCreditLimit { get; set; }
        [XmlElement("customers_export")]
        public bool ExportCustomers { get; set; }
        [XmlElement("customers_read")]
        public bool ReadCustomers { get; set; }
        [XmlElement("customers_view_gift_card_numbers")]
        public bool CustomersViewGiftCardNumbers { get; set; }
        [XmlElement("ecom")]
        public bool ECom { get; set; }
        [XmlElement("inventory_base")]
        public bool InventoryBase { get; set; }
        [XmlElement("inventory_counts")]
        public bool InventoryCounts { get; set; }
        [XmlElement("inventory_counts_reconcile")]
        public bool InventoryCountsReconcile { get; set; }
        [XmlElement("inventory_import")]
        public bool InventoryImport { get; set; }
        [XmlElement("inventory_read")]
        public bool InventoryRead { get; set; }
        [XmlElement("manufacturers")]
        public bool Manufacturers { get; set; }
        [XmlElement("product_cost")]
        public bool ProductCost { get; set; }
        [XmlElement("product_edit")]
        public bool ProductEdit { get; set; }
        [XmlElement("purchase_orders")]
        public bool PurchaseOrders { get; set; }
        [XmlElement("purchase_orders_receive")]
        public bool PurchaseOrdersReceive { get; set; }
        [XmlElement("register")]
        public bool Register { get; set; }
        [XmlElement("register_catalogs")]
        public bool RegisterCatalogs { get; set; }
        [XmlElement("register_close")]
        public bool RegisterClose { get; set; }
        [XmlElement("register_layaway")]
        public bool RegisterLayaway { get; set; }
        [XmlElement("register_line_discount")]
        public bool RegisterLineDiscount { get; set; }
        [XmlElement("register_open")]
        public bool RegisterOpen { get; set; }
        [XmlElement("register_price")]
        public bool RegisterPrice { get; set; }
        [XmlElement("register_read")]
        public bool RegisterRead { get; set; }
        [XmlElement("register_refund")]
        public bool RegisterRefund { get; set; }
        [XmlElement("register_transaction_discount")]
        public bool RegisterTransactionDiscount { get; set; }
        [XmlElement("register_withdraw")]
        public bool RegisterWithdraw { get; set; }
        [XmlElement("reports")]
        public bool Reports { get; set; }
        [XmlElement("special_orders")]
        public bool SpecialOrders { get; set; }
        [XmlElement("tags")]
        public bool Tags { get; set; }
        [XmlElement("transfers")]
        public bool Transfers { get; set; }
        [XmlElement("transfers_send_stock")]
        public bool TransfersSendStock { get; set; }
        [XmlElement("vendor_returns")]
        public bool VendorReturns { get; set; }
        [XmlElement("vendors")]
        public bool Vendors { get; set; }
        [XmlElement("vr_reasons")]
        public bool VrReasons { get; set; }
        [XmlElement("workbench")]
        public bool Workbench { get; set; }
    }
}
