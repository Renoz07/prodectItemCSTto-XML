using System;
using System.Xml.Serialization;

namespace ProcessItemsOrderCSVToXML.Model
{
    public class Item
    {
        public int ItemQuantity { get; set; }
        public double ItemValue { get; set; }
        public double ItemWeight { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCurrency { get; set; }
    }
}
