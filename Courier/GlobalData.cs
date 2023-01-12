using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Configuration;
using CourierMate.Models.GlobalData;

namespace CourierMate.Courier
{
    public class GlobalData: IGlobalData
    {
        #region Utilities
        /** Encode dictionary to Url string */
        public string ToUrlEncodedString(Dictionary<string, object> request)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string key in request.Keys)
            {
                builder.Append("&");
                builder.Append(key);
                builder.Append("=");
                builder.Append(HttpUtility.UrlEncode(request[key].ToString()));
            }

            string result = builder.ToString().TrimStart('&');

            return result;
        }
        /** Convert query string to dictionary */
        public Dictionary<string, object> ToDictionary(string response)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            string[] valuePairs = response.Split('&');
            foreach (string valuePair in valuePairs)
            {
                string[] values = valuePair.Split('=');
                result.Add(values[0], HttpUtility.UrlDecode(values[1]));
            }

            return result;
        }
        #endregion

        /*
        public async Task<List<Town>> GetTowms(Dictionary<string, object> towns)
        {   
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            List<Town> _towns = new List<Town>();
            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_towns");
            request.Add("town_name", (string)towns["town_name"]);
            request.Add("postal_code", (string)towns["postal_code"]);

            string requestString = ToUrlEncodedString(request);
            StringContent content = new StringContent(JsonConvert.SerializeObject(requestString), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PostAsync(end_point, content);
            // if the request did not succeed, this line will make the program crash
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                //Dictionary<string, string> results = _payment.ToDictionary(responseContent);
                var result = JsonConvert.DeserializeObject<GlobalResultModel>(responseContent);
                
                if (result.response_code == 0 && result.record_count != 0)
                {   
                    _towns = result.towns;
                }
            }
            return _towns;  
        }

        public async Task<List<Servicex>> GetServices()
        {   
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            List<Servicex> _services = new List<Servicex>();
            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_services");

            string requestString = ToUrlEncodedString(request);
            StringContent content = new StringContent(JsonConvert.SerializeObject(requestString), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PostAsync(end_point, content);
            // if the request did not succeed, this line will make the program crash
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                //Dictionary<string, string> results = _payment.ToDictionary(responseContent);
                var result = JsonConvert.DeserializeObject<GlobalResultModel>(responseContent);
                
                if (result.response_code == 0 && result.record_count != 0)
                {   
                    _services = result.servicex;
                }
            }
            return _services;  
        }

        public async Task<List<OtherServicex>> GetOtherServices()
        {   
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            List<OtherServicex> _otherServices = new List<OtherServicex>();
            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_other_services");

            string requestString = ToUrlEncodedString(request);
            StringContent content = new StringContent(JsonConvert.SerializeObject(requestString), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PostAsync(end_point, content);
            // if the request did not succeed, this line will make the program crash
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                //Dictionary<string, string> results = _payment.ToDictionary(responseContent);
                var result = JsonConvert.DeserializeObject<GlobalResultModel>(responseContent);
                
                if (result.response_code == 0 && result.record_count != 0)
                {   
                    _otherServices = result.otherServicex;
                }
            }
            return _otherServices;  
        }

        public async Task<List<Address>> GetAddresses()
        {   
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            List<Address> _addresses = new List<Address>();
            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_addresses");

            string requestString = ToUrlEncodedString(request);
            StringContent content = new StringContent(JsonConvert.SerializeObject(requestString), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PostAsync(end_point, content);
            // if the request did not succeed, this line will make the program crash
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                //Dictionary<string, string> results = _payment.ToDictionary(responseContent);
                var result = JsonConvert.DeserializeObject<GlobalResultModel>(responseContent);
                
                if (result.response_code == 0 && result.record_count != 0)
                {   
                    _addresses = result.Addresses;
                }
            }
            return _addresses;  
        }
        */


    }
}