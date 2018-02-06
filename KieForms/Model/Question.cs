using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KieForms.Model
{
    [Serializable]
    public class Question
    {
        public string description { get; set; }
        public bool lastQuestion { get; set; }
    }
}
