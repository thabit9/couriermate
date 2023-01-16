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
using CourierMate.Models.Quotation;
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
#region Global Data
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
            request.Add("postal_code", "");

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelTowns>(responseContent);
                return new JsonResult(new { result });
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
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelServices>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
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
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelOtherServices>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
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
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelAddress>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }        
        }

#endregion                
        
#region Quotation
        [Route("createquote")]
        public async Task<JsonResult> CreateQuote()
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
            request.Add("method", "create_quote");

            request.Add("collection_name", "ABC COMPANY");
            request.Add("collection_address_1", "123 RED STREET");
            request.Add("collection_address_2", "REDROCKS");
            request.Add("collection_address_3", "SANDTON");
            request.Add("collection_address_4", "JOHANNESBURG");
            request.Add("collection_postal_code", "1123");
            request.Add("collection_contact_name", "JAMES DOE");
            request.Add("collection_phone_no", "0119135647");
            request.Add("origin_town_name", "JOHANNESBURG");
            request.Add("delivery_name", "ABC COMPANY");
            request.Add("delivery_address_1", "123 RED STREET");
            request.Add("delivery_address_2", "REDROCKS");
            request.Add("delivery_address_3", "SANDTON");
            request.Add("delivery_address_4", "JOHANNESBURG");
            request.Add("delivery_postal_code", "1123");
            request.Add("delivery_contact_name", "JAMES DOE");
            request.Add("delivery_phone_no", "0119135647");
            request.Add("dest_town_name", "DURBAN");
            request.Add("service_name", "ECONOMY");
            request.Add("reference_no", "REF193728");
            request.Add("insurance_value", 150.00);
            request.Add("invoice_value", 235.00);
            request.Add("total_pieces", 2);
            request.Add("total_weight", 2); 
            //Parcel Dimensions
            var _dimensions = new List<ParcelDimension>{
                new ParcelDimension
                { 
                    pieces = 1,
                    length = 1.2,
                    height = 1.6,
                    breadth = 2,
                    weight = 1.00,
                    description = "BOX"
                },
                new ParcelDimension
                { 
                    pieces = 1,
                    length = 1,
                    height = 2,
                    breadth = 2.2,
                    weight = 1.00,
                    description = "PARCEL"
                }
            };          
            request.Add("parcel_dimensions", _dimensions);

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelQuote>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }

        }
        [Route("acceptquote")]
        public async Task<JsonResult> AcceptQuote()
        {   
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            //List<AcceptQuotex> _accept_quotes = new List<AcceptQuotex>();
            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "accept_quote");
            request.Add("quote_no", 2);
            request.Add("accept_person", "Kevin");

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelQuote>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }
        } 
        [Route("getquotedoc")]
        public async Task<JsonResult> GetQuoteDoc()
        {   
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            //List<AcceptQuotex> _accept_quotes = new List<AcceptQuotex>();
            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_quote_doc");
            request.Add("quote_no", 2);

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelQuoteDoc>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }
        } 
        [Route("getquotecharge")]
        public async Task<JsonResult> GetQuoteChange()
        {   
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            //List<AcceptQuotex> _accept_quotes = new List<AcceptQuotex>();
            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_quote_charges");
            request.Add("origin_town_name", "JOHANNESBURG");
            request.Add("origin_postal_code", "1123");
            request.Add("dest_town_name", "DURBAN");
            request.Add("dest_postal_code", "1123");
            request.Add("total_pieces", 2);
            request.Add("total_weight", 2);
            //Parcel Dimensions
            var _dimensions = new List<ParcelDimension>{
                new ParcelDimension
                { 
                    pieces = 1,
                    length = 1.2,
                    height = 1.6,
                    breadth = 2,
                    weight = 1.00,
                    description = "BOX"
                },
                new ParcelDimension
                { 
                    pieces = 1,
                    length = 1,
                    height = 2,
                    breadth = 2.2,
                    weight = 1.00,
                    description = "PARCEL"
                }
            };          
            request.Add("parcel_dimensions", _dimensions);

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelQuoteChange>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }
        } 

#endregion

#region Collection
        [Route("createcollection")]
        public async Task<JsonResult> CreateCollection()
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
            request.Add("method", "create_collection");

            request.Add("collection_date", "2022-01-05"); //(YYYY-MM-DD)
            request.Add("collection_name", "ABC COMPANY");
            request.Add("collection_address_1", "123 RED STREET");
            request.Add("collection_address_2", "REDROCKS");
            request.Add("collection_address_3", "SANDTON");
            request.Add("collection_address_4", "JOHANNESBURG");
            request.Add("collection_postal_code", "1123");
            request.Add("collection_contact_name", "JAMES DOE");
            request.Add("collection_phone_no", "0119135647");
            request.Add("collection_cell_no", "+27191356470");
            request.Add("collection_email", "test@test.com");
            request.Add("origin_town_name", "JOHANNESBURG");
            request.Add("delivery_name", "ABC COMPANY");
            request.Add("delivery_address_1", "123 RED STREET");
            request.Add("delivery_address_2", "REDROCKS");
            request.Add("delivery_address_3", "SANDTON");
            request.Add("delivery_address_4", "JOHANNESBURG");
            request.Add("delivery_postal_code", "1123");
            request.Add("delivery_contact_name", "JAMES DOE");
            request.Add("delivery_phone_no", "0119135647");
            request.Add("delivery_cell_no", "+27191356470");
            request.Add("delivery_email", "test@test.com");
            request.Add("dest_town_name", "DURBAN");
            request.Add("service_name", "ECONOMY");
            request.Add("reference_no", "REF193728");
            request.Add("special_instr", "RING BELL");
            request.Add("total_pieces", 2);
            request.Add("total_weight", 2); 
            //Parcel Dimensions
            var _dimensions = new List<ParcelDimension>{
                new ParcelDimension
                { 
                    pieces = 1,
                    length = 1.2,
                    height = 1.6,
                    breadth = 2,
                    weight = 1.00,
                    description = "BOX"
                },
                new ParcelDimension
                { 
                    pieces = 1,
                    length = 1,
                    height = 2,
                    breadth = 2.2,
                    weight = 1.00,
                    description = "PARCEL"
                }
            };          
            request.Add("parcel_dimensions", _dimensions);

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelCollection>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }

        }
        [Route("getcollectionstatus")]
        public async Task<JsonResult> GetCollectionStatus()
        {   
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            //List<AcceptQuotex> _accept_quotes = new List<AcceptQuotex>();
            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_collection_status");
            request.Add("collection_no", 2);

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelCollectionStatus>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }
        } 
        [Route("getcollectiondoc")]
        public async Task<JsonResult> GetCollectionDoc()
        {   
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            //List<AcceptQuotex> _accept_quotes = new List<AcceptQuotex>();
            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_collection_doc");
            request.Add("collection_no", 2);

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelCollectionDoc>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }
        } 

#endregion

#region Collection
        [Route("createdelivery")]
        public async Task<JsonResult> CreateDelivery()
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
            request.Add("method", "create_delivery");

            request.Add("delivery_no", "WB59859485");
            request.Add("collection_name", "ABC COMPANY");
            request.Add("collection_address_1", "123 RED STREET");
            request.Add("collection_address_2", "REDROCKS");
            request.Add("collection_address_3", "SANDTON");
            request.Add("collection_address_4", "JOHANNESBURG");
            request.Add("collection_postal_code", "1123");
            request.Add("collection_contact_name", "JAMES DOE");
            request.Add("collection_phone_no", "0119135647");
            request.Add("collection_cell_no", "+27191356470");
            request.Add("collection_email", "test@test.com");
            request.Add("origin_town_name", "JOHANNESBURG");
            request.Add("delivery_name", "ABC COMPANY");
            request.Add("delivery_address_1", "123 RED STREET");
            request.Add("delivery_address_2", "REDROCKS");
            request.Add("delivery_address_3", "SANDTON");
            request.Add("delivery_address_4", "JOHANNESBURG");
            request.Add("delivery_postal_code", "1123");
            request.Add("delivery_contact_name", "JAMES DOE");
            request.Add("delivery_phone_no", "0119135647");
            request.Add("delivery_cell_no", "+27191356470");
            request.Add("delivery_email", "test@test.com");
            request.Add("dest_town_name", "DURBAN");
            request.Add("service_name", "ECONOMY");
            request.Add("reference_no", "REF193728");
            request.Add("special_instr", "RING BELL");
            request.Add("total_pieces", 2);
            request.Add("total_weight", 2); 
            //Parcel Dimensions
            var _dimensions = new List<ParcelDimension>{
                new ParcelDimension
                { 
                    pieces = 1,
                    length = 1.2,
                    height = 1.6,
                    breadth = 2,
                    weight = 1.00,
                    description = "BOX"
                },
                new ParcelDimension
                { 
                    pieces = 1,
                    length = 1,
                    height = 2,
                    breadth = 2.2,
                    weight = 1.00,
                    description = "PARCEL"
                }
            };          
            request.Add("parcel_dimensions", _dimensions);

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelDelivery>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }

        }
        [Route("getdeliverypod")]
        public async Task<JsonResult> GetDeliveryPod()
        {   
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            //List<AcceptQuotex> _accept_quotes = new List<AcceptQuotex>();
            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_delivery_pod");
            request.Add("delivery_no", "CLG15");

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelDeliveryPod>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }
        } 
        [Route("getdeliverypodimage")]
        public async Task<JsonResult> GetDeliveryPodImage()
        {   
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            //List<AcceptQuotex> _accept_quotes = new List<AcceptQuotex>();
            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_delivery_pod_image");
            request.Add("delivery_no", "CLG15");

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelDeliveryPodImage>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }
        } 
        [Route("getdeliverydoc")]
        public async Task<JsonResult> GetDeliveryDoc()
        {   
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            //List<AcceptQuotex> _accept_quotes = new List<AcceptQuotex>();
            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_delivery_doc");
            request.Add("delivery_no", "CLG15");

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelDeliveryDoc>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }
        } 
        [Route("checkdeliveryno")]
        public async Task<JsonResult> CheckDeliveryNo()
        {   
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            //List<AcceptQuotex> _accept_quotes = new List<AcceptQuotex>();
            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "check_delivery_no");
            request.Add("delivery_no", "CLG15");

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelDeliveryNo>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }
        } 

#endregion

#region Tracking
        [Route("gettrackingevents")]
        public async Task<JsonResult> GetTrackingEvents()
        {   
            CourierConfig _configuration = CourierService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            //List<AcceptQuotex> _accept_quotes = new List<AcceptQuotex>();
            HttpClient http = new HttpClient();
            Dictionary<string, object> request = new Dictionary<string, object>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_tracking_events");
            request.Add("delivery_no", "CLG15");

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(end_point, content);
            response.EnsureSuccessStatusCode();

            if (response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModelTracking>(responseContent);
                return new JsonResult(new { result });
            }
            else{
                return Json( new 
                    {
                        success = false,
                        message = "Error obtaining results"
                    }, new Newtonsoft.Json.JsonSerializerSettings());
            }
        } 
#endregion

        #endregion
    }
}
