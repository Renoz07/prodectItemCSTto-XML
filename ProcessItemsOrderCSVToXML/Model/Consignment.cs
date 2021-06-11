using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProcessItemsOrderCSVToXML.Model
{
    public class Consignment
    {
        public Consignment()
        {
            Parcels = new List<Parcel>();
        }
        public string ConsignmentNo { get; set; }
        public List<Parcel> Parcels { get; set; }
    }
}
