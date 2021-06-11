using System;
using CsvHelper.Configuration.Attributes;
namespace ProcessItemsOrderCSVToXML.Model
{
    /* CSV header line Order No, Consignment No, Parcel Code,Consignee Name, Address 1, Address 2, City, State, Country Code,Item Quantity, Item Value, Item Weight, Item Description,Item Currency
     * renamed to
     * Order No,Consignment No,Parcel Code,Consignee Name,Address 1,Address 2,City,State,Country Code,Item Quantity,Item Value,Item Weight,Item Description,Item Currency
     * in order to eliminate white spaces in the header names.
     * 
     * Match the CSV using header name and column index
     */
    public class CSVItem
    {
        [Index(0)]
        [Name("Order No")]
        public string OrderNo { get; set; }

        [Index(1)]
        [Name("Consignment No")]
        public string ConsignmentNo { get; set; }

        [Index(2)]
        [Name("Parcel Code")]
        public string ParcelCode { get; set; }

        [Index(3)]
        [Name("Consignee Name")]
        public string ConsigneeName { get; set; }

        [Index(4)]
        [Name("Address 1")]
        public string Address1 { get; set; }

        [Index(5)]
        [Name("Address 2")]
        public string Address2 { get; set; }

        [Index(6)]
        [Name("City")]
        public string City { get; set; }

        [Index(7)]
        [Name("State")]
        public string State { get; set; }

        [Index(8)]
        [Name("Country Code")]
        public string CountryCode { get; set; }

        [Index(9)]
        [Name("Item Quantity")]
        public string ItemQuantity { get; set; }

        [Index(10)]
        [Name("Item Value")]
        public string ItemValue { get; set; }

        [Index(11)]
        [Name("Item Weight")]
        public string ItemWeight { get; set; }

        [Index(12)]
        [Name("Item Description")]
        public string ItemDescription { get; set; }

        [Index(13)]
        [Name("Item Currency")]
        public string ItemCurrency { get; set; }
    }
}