using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KieAdapterConsol
{
    [Serializable]
    public class Context
    {
        public Medicament medicament;
        public Organe organe;

        public Context()
        {
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

        public Context(Medicament medicament, Organe organe)
        {
            this.medicament = medicament;
            this.organe = organe;
        }
    }
}
