using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CourierMate.Models;
using CourierMate.Courier;
using System.Text;
using Newtonsoft.Json;
using CourierMate.Models.GlobalData;
using System.Web;

namespace CourierMate.Controllers
{
    public class CourierController : Controller
    {
        private IGlobalData _globalData = new GlobalData();
        
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            //var results = GetRequest();
            return View();
        }
        #region Courier Methods

        [Route("getowns")]
        public async Task<JsonResult> GetTowns()
        {
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            //Add values to dictionary
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_towns");
            request.Add("town_name", "Pretoria");
            request.Add("postal_code", "0187");

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject(responseContent);
                return Json(result);
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }

        }

        [Route("getservices")]
        public async Task<JsonResult> GetServices()
        {
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            //Add values to dictionary
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_services");

            var jsonString = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GlobalResultModel>(responseContent);

            if (result.response_code == -1){
                return Json( new 
                    {
                        success = false,
                        message = result.response_message
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            else
            {
                return Json(result, 
                        new Newtonsoft.Json.JsonSerializerSettings());
            }    
        }

        [Route("getotherservices")]
        public async Task<JsonResult> GetOtherServices()
        {
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            //Add values to dictionary
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_other_services");

            var jsonString = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GlobalResultModel>(responseContent);

            if (result.response_code == -1){
                return Json( new 
                    {
                        success = false,
                        message = result.response_message
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            else
            {
                return Json(result, 
                        new Newtonsoft.Json.JsonSerializerSettings());
            }         
        }
        
        [Route("getaddresses")]
        public async Task<JsonResult> GetAddresses()
        {
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            //Add values to dictionary
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_addresses");

            var jsonString = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GlobalResultModel>(responseContent);

            if (result.response_code == -1){
                return Json( new 
                    {
                        success = false,
                        message = result.response_message
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            else
            {
                return Json(result, 
                        new Newtonsoft.Json.JsonSerializerSettings());
            }           
        }
                
        
        #endregion
    }
}
