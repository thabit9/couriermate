using System.Collections.Generic;

namespace CourierMate.Models.GlobalData
{
    public class GlobalResultModel
    {
        public string response_message { get; set; }
        public int response_code { get; set; }
        public int record_count { get; set; }
        public List<Town> towns { get; set; }
        public List<Servicex> servicex { get; set; }
        public List<OtherServicex> otherServicex { get; set; }
        public List<Address> Addresses { get; set; }
    }
}