using System;
namespace CourierMate.Models.Collection
{
    public class CollectionStatus
    {
        public int collection_id { get; set; }
        public DateTime? collection_date { get; set; }
        public string collection_time { get; set; }
        public string collection_comment { get; set; }
        public int collected { get; set; }
        public string delivery_no { get; set; }

    }
}