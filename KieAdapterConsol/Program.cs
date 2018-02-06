using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KieAdapterConsol
{
    class Program
    {
        static void Main(string[] args)
        {
            //KieExecuteXML k = new KieExecuteXML();
            ExecuteMedi k = new ExecuteMedi();

            k.ExecuteAsyncjson().GetAwaiter().GetResult();
        }
    }
}
