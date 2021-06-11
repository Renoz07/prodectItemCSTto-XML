using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using ProcessItemsOrderCSVToXML.Model;

namespace ProcessItemsOrderCSVToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvRead = new CSVRead();
            csvRead.checkFolder();
        }
    }

    public class CSVRead
    {
        private List<Order> Orders = new List<Order>();
        public void checkFolder()
        {
            string[] filePaths = Directory.GetFiles(@".", "*.csv",
                                         SearchOption.TopDirectoryOnly);
            foreach (var file in filePaths)
            {
                processCSV(file);
            }
        }
        public void processCSV(string csvFile)
        {
            try
            {
                // Using CSVHelper library to read the CSV
                using (var reader = new StreamReader(csvFile))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<CSVItem>().ToList();
                    // set default currency to GBP and setup Order structure
                    foreach (var item in records)
                    {
                        if (string.IsNullOrEmpty(item.ItemCurrency))
                            item.ItemCurrency = "GBP";
                        var currentOrder = Orders.Where(o => o.OrderNo == item.OrderNo).SingleOrDefault();
                        if (currentOrder == null)
                        {
                            currentOrder = new Order() { OrderNo = item.OrderNo };
                            Orders.Add(currentOrder);
                        }
                        var currentConsignment = currentOrder.Consignments.Where(c => c.ConsignmentNo == item.ConsignmentNo).SingleOrDefault();
                        if (currentConsignment == null)
                        {
                            currentConsignment = new Consignment() { ConsignmentNo = item.ConsignmentNo };
                            currentOrder.Consignments.Add(currentConsignment);
                        }
                        var currentParcel = currentConsignment.Parcels.Where(p => p.ParcelCode == item.ParcelCode).SingleOrDefault();
                        if (currentParcel == null)
                        {
                            currentParcel = new Parcel() { ParcelCode = item.ParcelCode };
                            currentConsignment.Parcels.Add(currentParcel);
                        }
                        currentParcel.ConsigneeName = item.ConsigneeName;
                        currentParcel.Address1 = item.Address1;
                        currentParcel.Address2 = item.Address2;
                        currentParcel.City = item.City;
                        currentParcel.State = item.State;
                        currentParcel.CountryCode = item.CountryCode;
                        // no existing item to find. Creating a new item for each csv line added into the relevant parcel
                        var currentItem = new Item() { ItemCurrency = item.ItemCurrency, ItemDescription = item.ItemDescription, ItemQuantity = int.Parse(item.ItemQuantity), ItemValue = double.Parse(item.ItemValue), ItemWeight = double.Parse(item.ItemWeight) };
                        currentParcel.Items.Add(currentItem);
                    }
                    WriteXml(csvFile);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred:");
                Console.WriteLine(ex.ToString());
            }
        }

        public void WriteXml(string csvFile)

        {
            var xml = new XML() { Orders = Orders };
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(xml.GetType());
            var fileNoExt = csvFile.Split(".csv")[0];
            var xmlFile = fileNoExt + ".xml";
            using (StreamWriter writer = File.CreateText(xmlFile))
            {
                x.Serialize(writer, xml);
            }
        }
    }
}

