using System.Collections.Generic;
using CourierMate.Models.Quotation;

namespace CourierMate.Models
{
    public abstract class _credentials
    {
        public string username { get; set; }
        public string password { get; set; }
        public string method { get; set; }
    }
    public class RequestModelQuote: _credentials{
        public string collection_name { get; set; }
        public string collection_address_1 { get; set; }
        public string collection_address_2 { get; set; }
        public string collection_address_3 { get; set; }
        public string collection_address_4 { get; set; }
        public string collection_postal_code { get; set; }
        public string collection_contact_name { get; set; }
        public string collection_phone_no { get; set; }
        public string origin_town_name { get; set; }
        public string delivery_name { get; set; }
        public string delivery_address_1 { get; set; }
        public string delivery_address_2 { get; set; }
        public string delivery_address_3 { get; set; }
        public string delivery_address_4 { get; set; }
        public string delivery_postal_code { get; set; }
        public string delivery_contact_name { get; set; }
        public string delivery_phone_no { get; set; }
        public string dest_town_name { get; set; }
        public string service_name { get; set; }
        public string reference_no { get; set; }
        public string insurance_value { get; set; }
        public string invoice_value { get; set; }
        public string total_pieces { get; set; }
        public string total_weight { get; set; }
        public List<ParcelDimension> parcel_dimensions { get; set; }
    }
    /*public class RequestModelServices: _credentials{

        public List<Servicex> records { get; set; }
    }
    public class RequestModelOtherServices: _credentials{
        public List<OtherServicex> records { get; set; }
    }
    public class RequestModelAddress: _credentials{
        public List<Address> records { get; set; }
    }*/
}