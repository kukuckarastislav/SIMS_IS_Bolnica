using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repozitorijum;

namespace ActivityEvaluation
{
    public class PatientActivityEvaluation
    {
        public AktivnostPacijentaRepozitorijum _repository { get; set; }
        private String ActivityType;

        public PatientActivityEvaluation(string activityType)
        {
            _repository = AktivnostPacijentaRepozitorijum.GetInstance;
            ActivityType = activityType;
        }

        protected virtual int CountOccurrences(int patiendId, TimeSpan period)
        {
            return 0;
        }

    }
}
