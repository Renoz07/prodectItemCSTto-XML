using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProcessItemsOrderCSVToXML.Model
{
    public class Parcel
    {
        public Parcel()
        {
            Items = new List<Item>();
        }
        // Using ParcelItems and ParcelItem without a space as the space is written as _x0020_
        [XmlArray("ParcelItems")]
        [XmlArrayItem("ParcelItem")]
        public List<Item> Items;
        public string ParcelCode { get; set; }
        public string ConsigneeName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
    }
}
