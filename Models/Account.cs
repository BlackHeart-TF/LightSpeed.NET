using System;
using System.Xml.Serialization;
namespace LightspeedNET.Models
{
	[XmlRoot(ElementName = "link")]
	public class Link
	{
		[XmlAttribute(AttributeName = "href")]
		public string url { get; set; }
	}

	[XmlRoot(ElementName = "Account")]
	public class lsAccount
	{
		[XmlElement(ElementName = "accountID")]
		public string AccountID { get; set; }
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "link")]
		public Link Link { get; set; }
	}

	[XmlRoot(ElementName = "Accounts")]
	public class lsAccounts
	{
		[XmlElement(ElementName = "Account")]
		public lsAccount[] Account { get; set; }

	}


}
