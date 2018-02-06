using KieServerAdapter;
using System.Threading.Tasks;
using KieForms.Model;
using KieForms.Configurations;

namespace KieForms
{
    public class ExecuteRules
    {
        public async Task<ExecutionResponse<Context>> ExecuteAsyncjson(Context insertObject, string namecontainer)
        {
            Configuration configuration = Configuration.GetConfiguration();
            string packageName;
            var executer = new KieExecuter
            {
                HostUrl = configuration.HostUrl,
                AuthUserName = configuration.AuthUserName,
                AuthPassword = configuration.AuthPassword,
                LookUp = configuration.LookUp /*StatelessKieSession,defaultKieSession*/
            };
            if (namecontainer == configuration.ContainerName1)
                packageName = "medic.Context";
            else
                packageName = "org.pharmacie.Context";

            //Insert object to KieServer session
            executer.Insert(insertObject, packageName);

            //objects est l'out-identifier ("get-objects":"out-identifier" : "objects")
            //executer.GetObjects("obj");

            executer.FireAllRules();
                        
            //executer.ExecuteAsync(nom container)
            var response = await executer.ExecuteAsync<Context>(namecontainer);

            //executer.Insert(insertObject, "org.pharmacie.Context");
            //executer.FireAllRules();
            //var response_second = await executer.ExecuteAsync<Context>(configuration.ContainerName2);
            var bodyResponse = response.ResponseBody;
            
            return response;
        }
    }
}
