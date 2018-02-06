using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KieServerAdapter
{
    public class KieExecuter
    {
        protected const string ApplicationType = "application/json";
        protected const string AutenticationType = "Basic";
        protected const string DefaultInstancesPath = "/services/rest/server/containers/instances/";

        [JsonIgnore]
        public string HostUrl { get; set; }

        [JsonIgnore]
        public string InstancesPath { get; set; } = "kie-server";

        [JsonIgnore]
        public string AuthUserName { get; set; }

        [JsonIgnore]
        public string AuthPassword { get; set; }

        [JsonProperty("lookup")]
        public string LookUp { get; set; } = "defaultKieSession";

        [JsonProperty("commands")]
        public List<ICommandContainer> Commands { get; private set; } = new List<ICommandContainer>();

        public void StartProcess(string processId)
        {
            Commands.Add(new StartProcess(processId));
        }

        public void GetObjects(string outIdentifier)
        {
            Commands.Add(new GetObjects(outIdentifier));
        }

        public void Insert(object commandObject, string objectNameSpace)
        {
            Commands.Add(new Insert(commandObject, objectNameSpace));
        }

        public void SetGlobal(string identifier, object commandObject, string objectNameSpace)
        {
            Commands.Add(new SetGlobal(identifier, commandObject, objectNameSpace));
        }

        public void GetGlobal(string identifier)
        {
            Commands.Add(new GetGlobal(identifier));
        }

        public void FireAllRules()
        {
            FireAllRules(-1);
        }

        public void FireAllRules(int max)
        {
            Commands.Add(new FireAllRules(max));
        }

        public async Task<ExecutionResponse<object>> ExecuteAsync(string containerName)
        {
            return await ExecuteAsync<object>(containerName);
        }

        public async Task<ExecutionResponse<T>> ExecuteAsync<T>(string containerName)
        {
            return await ExecuteAsync<T>(containerName, KieCommandTypeEnum.Insert);
        }

        public async Task<ExecutionResponse<T>> ExecuteGlobalAsync<T>(string containerName)
        {
            return await ExecuteAsync<T>(containerName, KieCommandTypeEnum.SetGlobal);
        }

        public async Task<ExecutionResponse<T>> ExecuteObjectsAsync<T>(string containerName)
        {
            return await ExecuteAsync<T>(containerName, KieCommandTypeEnum.GetObjects);
        }

        private async Task<ExecutionResponse<T>> ExecuteAsync<T>(string containerName, KieCommandTypeEnum commandType)
        {
            var startDate = DateTime.Now;

            ExecutionResponse<T> result = await ExecuteCall<T>(containerName);

            ProcessResult(result, commandType);

            var span = DateTime.Now - startDate;

            result.ElapsedTime = (int)span.TotalMilliseconds;

            return result;
        }

        private async Task<ExecutionResponse<T>> ExecuteCall<T>(string containerName)
        {
            Commands = Commands.OrderByDescending(c => c.Command.CommandType).ToList();
            var json = JsonConvert.SerializeObject(this);
            var result = new ExecutionResponse<T>();

            using (var client = new HttpClient { BaseAddress = new Uri(HostUrl) })
            {

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationType));

                if (!string.IsNullOrEmpty(AuthUserName))
                {
                    var byteArray = Encoding.ASCII.GetBytes($"{AuthUserName}:{AuthPassword}");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AutenticationType, Convert.ToBase64String(byteArray));
                }

                try
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Post, string.Concat(InstancesPath, DefaultInstancesPath, containerName)))
                    {
                        request.Content = new StringContent(json);
                        request.Content.Headers.ContentType = new MediaTypeHeaderValue(ApplicationType);

                        //using (var response = await client.SendAsync(request).ConfigureAwait(continueOnCapturedContext: false))
                        using (var response = await client.SendAsync(request))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                result = await response.Content.ReadAsAsync<ExecutionResponse<T>>();
                                result.ResponseBody = await response.Content.ReadAsStringAsync();
                            }
                        }                        
                    }
                }
                catch (Exception ex)
                {
                    string errorType = ex.GetType().ToString();
                    string errorMessage = errorType + ": " + ex.Message;
                    throw new Exception(errorMessage, ex.InnerException);
                }
            }

            result.RequestBody = json;

            return result;
        }

        private void ProcessResult<T>(ExecutionResponse<T> result, KieCommandTypeEnum commandType)
        {
            if (typeof(T) != typeof(object))
            {
                try
                {
                    var command = Commands.FirstOrDefault(c => c.Command.CommandType == commandType);
                    var identifier = command?.Command as ICommandOutIdentifier;
                    //var outObject = result.Result?.ExecutionResults.Results.Last(e => e.Key == identifier?.OutIdentifier);
                   var outObject = result.Result?.ExecutionResults.Results.SingleOrDefault(e => e.Key == identifier?.OutIdentifier);
                    
                    if (outObject != null)
                    {
                        //var items = (JArray)outObject.Value.Value;

                        //foreach (var i in items.Children())
                        //{
                        //.......
                        //}

                        var item = (JObject)outObject.Value.Value;
                        var first = item.First;
                        //23:  var first = item.First;

                        if (first is JProperty)
                        {
                            var prop = first as JProperty;
                            var commandObject = command?.Command as ICommandObject;
                            var v = prop.Name.Equals(commandObject?.CommandObject.ObjectNameSpace);
                            //23: var v = prop.Name.Equals(commandObject?.CommandObject);
                            if (true)
                            {
                                result.SmartSingleResponse = JsonConvert.DeserializeObject<T>(prop.Value.ToString(), new UnixTimestampConverter());
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        //protected List<Object> findFacts(StatefulKnowledgeSession session, Object factClass)
        //{
        //    ObjectFilter filter = new ObjectFilter()
        //    {
        //        public override Boolean accept(Object obj)
        //        {
        //            return obj.Equals(factClass);
        //        }
        //    };  

        //    List<Object> results = session.getObjects(filter);
        //    return results;
        //}



        
    }
}
