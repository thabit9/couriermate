namespace CourierMate.Models.Quotation
{
    public class QuoteCharge
    {
        public string service_name { get; set; }
        public string service_code { get; set; }
        public string currency { get; set; }
        public decimal freight_charge { get; set; }
        public decimal invoice_charge { get; set; }
        public decimal insurance_charge { get; set; }
        public decimal fuel_charge { get; set; }
        public decimal toll_charge { get; set; }
        public decimal doc_charge { get; set; }
        public decimal origin_surcharge { get; set; }
        public decimal dest_surcharge { get; set; }
        public decimal excluding_vat { get; set; }
        public decimal vat { get; set; }
        public decimal including_vat { get; set; }
    }
}