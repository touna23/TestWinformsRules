using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KieForms.Model
{
    [Serializable]
    public class Organe
    {
        public string nomOrgane { get; set; }
        public string typeMaux { get; set; }
        public string localisation { get; set; }
    }
}
