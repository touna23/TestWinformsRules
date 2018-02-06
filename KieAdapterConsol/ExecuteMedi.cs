using KieServerAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace KieAdapterConsol
{
    public class ExecuteMedi
    {
        public async Task ExecuteAsyncjson()
        {
            Organe organe = new Organe { nomOrgane = "Tête", typeMaux = "MauxContinue" , localisation="frontale"};
            Medicament medicament = new Medicament();
            Context insertObject = new Context(medicament, organe);

            var executer = new KieExecuter
            {
                HostUrl = "http://127.0.0.1:8090",
                AuthUserName = "kie-server",
                AuthPassword = "1234",
                LookUp = "defaultKieSession" /*StatelessKieSession,defaultKieSession*/
            };

            //Insert object to KieServer session
            executer.Insert(insertObject, "medic.Context");

            //objects est l'out-identifier ("get-objects":"out-identifier" : "objects")
            executer.GetObjects("obj");

            executer.FireAllRules();
            
            //executer.ExecuteAsync(nom container)
            var response = await executer.ExecuteAsync<Context>("medi2");
            var bodyResponse = response.ResponseBody;
           
            
            var res = response.ResponseType.Equals(TypeEnum.Success);
        }
    }
}
