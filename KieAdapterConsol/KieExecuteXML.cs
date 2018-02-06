using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Xml.Serialization;
using System.Xml;
using System;
using System.Net.Http.Headers;
using KieServerAdapter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KieAdapterConsol
{
    public class KieExecuteXML
    {
        public async Task ExecuteAsyncjson()
        {
            Person insertObject = new Person { Name = "E", Age = 41, Vacation = 100, Approved = true, MoneyInves = 6000 };

            var executer = new KieExecuter
            {
                HostUrl = "http://127.0.0.1:8090",
                AuthUserName = "kie-server",
                AuthPassword = "1234"
                ,
                LookUp = "defaultKieSession"
            };

            //Insert object to KieServer session
            executer.Insert(insertObject, "demotest.Person");
            
            executer.GetObjects("objects");
            executer.FireAllRules();

            //executer.ExecuteAsync(nom container)
            // var response = await executer.ExecuteAsync("instances");

            var response = await executer.ExecuteAsync<Person>("instances");
            var rep = response.Result.ExecutionResults.Results.Find(e => e.Key == "objects1");



            var resp = response.Result.ExecutionResults.Results.LastOrDefault(e => e.Key == "object");
            //var rep = response.Result.ExecutionResults.Results.Find(e => e.Key == "objects1");
            //var items = (JArray)rep.Value;
            //var last = items.Last;           

            //foreach (var item in items.Children())
            //{
            //    var itemProperties = item.Children<JProperty>();
            //    //you could do a foreach or a linq here depending on what you need to do exactly with the value
            //    var myElement = itemProperties.FirstOrDefault(x => x.Name == "nomMedic");
            //    var myElementValue = myElement.Value; ////This is a JValue type
            //}


            var bodyResponse = response.ResponseBody;
            var res = response.ResponseType.Equals(TypeEnum.Success);           
        }
        
        //public void ExecutePOSTWebAPI(string resourceName, object classObj)
        //public async Task ExecuteCallXML<T>()
        //{
        //    var result = new ExecutionResponse<T>();
            
        //    using (var client = new HttpClient { BaseAddress = new Uri("http://127.0.0.1:8090") })
        //    {
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));

        //        var byteArray = Encoding.ASCII.GetBytes($"{"kie-server"}:{"1234"}");
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", Convert.ToBase64String(byteArray));
                
        //        using (var request = new HttpRequestMessage(HttpMethod.Post, string.Concat("kie-server", "/services/rest/server/containers/instances/", "instances")))
        //        {
        //            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
        //            //var returnedXml = client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
        //            using (var response = await client.SendAsync(request))
        //            {
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    result = await response.Content.ReadAsAsync<ExecutionResponse<T>>();
        //                    result.ResponseBody = await response.Content.ReadAsStringAsync();
        //                }
        //            }
        //        }
        //    }
            
        //    //return result;
        //}
    }
}
