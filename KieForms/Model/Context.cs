using System;

namespace KieForms.Model
{
    [Serializable]
    public class Context
    {
        public Medicament medicament;
        public Organe organe;
        public Answer answer;
        public Question question;

        public Context()
        {
        }

        public Context(Medicament medicament, Organe organe, Answer answer, Question question)
        {
            this.medicament = medicament;
            this.organe = organe;
            this.question = question;
            this.answer = answer;
        }

        public Context(Organe organe)
        {
            this.organe = organe;
        }

        public Medicament getMedicament()
        {
            return this.medicament;
        }

        public void setMedicament(Medicament medicament)
        {
            this.medicament = medicament;
        }

        public Organe getOrgane()
        {
            return this.organe;
        }

        public void setOrgane(Organe organe)
        {
            this.organe = organe;
        }

        public Answer getAnswer()
        {
            return this.answer;
        }

        public void setAnswer(Answer answer)
        {
            this.answer = answer;
        }

        public Question getQuestion()
        {
            return this.question;
        }

        public void setQuestion(Question question)
        {
            this.question = question;
        }        
    }
}
