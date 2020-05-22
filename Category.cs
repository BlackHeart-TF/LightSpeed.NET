using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using LightspeedNET.Models;

namespace LightspeedNET
{
    public static class Categories
    {
        public static Category GetCategory(string ID)
        {
            var response = Lightspeed.AuthenticationClient.GetRequest(Lightspeed.host + $"/API/Account/{Lightspeed.Session.SystemCustomerID}/Category/{ID}");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);
            //check if an item was actually returned
            var node = doc.SelectSingleNode("Categories");
            if (int.Parse(node.Attributes["count"].Value) <= 0)
                return null;
            var elem = doc.DocumentElement.FirstChild.OuterXml;
            TextReader TextReader = new StringReader(elem);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Category));
            var category = (Category)Deserializer.Deserialize(TextReader);
            return category;
        }

        public static Category getCategoryByPath(string path)
        {
            return GetAllCategories().Where(x => x.FullPathName == path).FirstOrDefault();
        }

        public static Category[] GetAllCategories()
        {
            var response = Lightspeed.AuthenticationClient.GetRequest(Lightspeed.host + $"/API/Account/{Lightspeed.Session.SystemCustomerID}/Category/");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);
            //check if an item was actually returned
            var node = doc.SelectSingleNode("Categories");
            int count = int.Parse(node.Attributes["count"].Value);
            if (count <= 0)
                return null;
            
            TextReader TextReader = new StringReader(response);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(CategoryArray));
            var category = (CategoryArray)Deserializer.Deserialize(TextReader);
            TextReader.Dispose();
            var categories = new List<Category>();
            categories.AddRange(category.Category);
            if (count > 100)
            {
                for (int i = 100; i <= count-1; i = i + 100)
                {
                    response = Lightspeed.AuthenticationClient.GetRequest(Lightspeed.host + $"/API/Account/{Lightspeed.Session.SystemCustomerID}/Category?offset={i}");
                    TextReader newReader = new StringReader(response);
                    var newcats = (CategoryArray)Deserializer.Deserialize(newReader);
                    foreach (var cat in newcats.Category)
                        categories.Add(cat);
                    newReader.Dispose();
                }
            }
            return categories.ToArray();
        }

        public static Item[] GetItemsByCategory(int CategoryID)
        {
            var response = Lightspeed.AuthenticationClient.GetRequest(Lightspeed.host + $"/API/Account/{Lightspeed.Session.SystemCustomerID}/Item?categoryID={CategoryID}&load_relations=[\"Images\",\"Category\"]");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);
            //check if an item was actually returned
            var node = doc.SelectSingleNode("Items");
            if (int.Parse(node.Attributes["count"].Value) <= 0)
                return null;
            TextReader TextReader = new StringReader(response);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(ItemArray));
            var item = (ItemArray)Deserializer.Deserialize(TextReader);
            return item.Item;
        }

        public static void UpdateCategory(Category category)
        {
            //var json = changes.ToJSON();
            string data;
            using (var ms = new MemoryStream())
            using (var x = new XmlTextWriter(ms, Encoding.ASCII))
            {
                var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Category));
                Deserializer.Serialize(x, category);
                data = Encoding.ASCII.GetString(ms.ToArray());
            }
                Lightspeed.AuthenticationClient.PutRequest($"https://api.lightspeedapp.com/API/Account/{Lightspeed.Session.SystemCustomerID}/Category/{category.CategoryID}", data);
        }

        public static void DeleteCategory(Category category)
        {
            if (category == null) return;
            var allCats = Categories.GetAllCategories();
            var children = allCats.Where(x => x.ParentID == category.CategoryID);
            foreach(var child in children)
            {
                Lightspeed.AuthenticationClient.DeleteRequest(Lightspeed.host + $"/API/Account/{Lightspeed.Session.SystemCustomerID}/Category/{child.CategoryID}");
                
            }
            Lightspeed.AuthenticationClient.DeleteRequest(Lightspeed.host + $"/API/Account/{Lightspeed.Session.SystemCustomerID}/Category/{category.CategoryID}");

        }

        public static Category CreateCategory(string name, string path, int parentId = 0)
        {
            var newCat = new Category(name,path,parentId);
            var Deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Category));
            byte[] buffer = new byte[1000];
            var writer = new MemoryStream(buffer);
            Deserializer.Serialize(writer, newCat);
            char[] newstring = new char[writer.Length];
            writer.ToArray().CopyTo(newstring, 0);
            var cont = new string(newstring);
            var response = Lightspeed.AuthenticationClient.PostRequest(Lightspeed.host + $"/API/Account/{Lightspeed.Session.SystemCustomerID}/Category/", cont);
            TextReader TextReader = new StringReader(response);
            
            var category = (Category)Deserializer.Deserialize(TextReader);
            return category;
        }
    }
}
