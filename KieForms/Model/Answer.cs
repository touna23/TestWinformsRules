using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KieForms.Model
{
    [Serializable]
    public class Answer
    {
        public List<string> descp { get; set; }
        public string type { get; set; }
        public string typeEnum { get; set; }
        public AnswerTypeEnum answerTypeEnum { get; }
    }

    public enum AnswerTypeEnum
    {
        nomOrgane,
        typeMaux ,
        localisation ,
        medicament 
    }
}
