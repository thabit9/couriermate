using System.Collections.Generic;
using System.Threading.Tasks;
using CourierMate.Models.GlobalData;

namespace CourierMate.Courier
{
    public interface IGlobalData
    {
        string ToUrlEncodedString(Dictionary<string, object> request);
        Dictionary<string, object> ToDictionary(string response);
        /*
        Task<List<Town>> GetTowms(Dictionary<string, object> towns);
        Task<List<Servicex>> GetServices();
        Task<List<OtherServicex>> GetOtherServices();
        Task<List<Address>> GetAddresses();
        */
        
    } 
}