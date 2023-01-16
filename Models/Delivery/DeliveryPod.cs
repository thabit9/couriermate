using System;
namespace CourierMate.Models.Delivery
{
    public class DeliveryPod
    {
        public string delivery_no { get; set; }
        public DateTime? delivery_date { get; set; }
        public string delivery_time { get; set; }
        public string delivery_person { get; set; }
        public string delivery_comment { get; set; }
    }
}