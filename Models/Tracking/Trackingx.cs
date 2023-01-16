using System;
namespace CourierMate.Models.Tracking
{
    public class Trackingx
    {
        public string delivery_no { get; set; }
        public string branch_code { get; set; }
        public DateTime? event_date { get; set; }
        public string event_time { get; set; }
        public string utc_time_zone { get; set; }
        public string event_name { get; set; }
        public string event_code { get; set; }
        public string event_type { get; set; }
    }
}