using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KieForms
{
    [Serializable]
    public class Person
    {
        public int Age { get; set; }
        public bool Approved { get; set; }
        public int LengthOfService { get; set; }
        public double? MoneyInves { get; set; }
        public string Name { get; set; }
        //public string Rating { get; set; }
        public int Vacation { get; set; }
    }
}
