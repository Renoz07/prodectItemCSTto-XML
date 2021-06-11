using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProcessItemsOrderCSVToXML.Model
{
    public class Order
    {
        public Order()
        {
            Consignments = new List<Consignment>();
        }
        [XmlIgnoreAttribute]
        public string OrderNo { get; set; }
        public List<Consignment> Consignments { get; set; }
        public string TotalValue { get
            {
                double sum = 0.0;
                string currency = "";
                foreach(var consignment in Consignments)
                {
                    foreach(var parcel in consignment.Parcels)
                    {
                        foreach(var item in parcel.Items)
                        {
                            sum += item.ItemQuantity * item.ItemValue;
                            currency = item.ItemCurrency;
                        }
                    }
                }
                return sum + " " + currency;
            } }
        public string TotalWeight
        {
            get
            {
                double sum = 0.0;
                foreach (var consignment in Consignments)
                {
                    foreach (var parcel in consignment.Parcels)
                    {
                        foreach (var item in parcel.Items)
                        {
                            sum += item.ItemQuantity * item.ItemWeight;
                        }
                    }
                }
                return sum.ToString();
            }
        }
    }
}
