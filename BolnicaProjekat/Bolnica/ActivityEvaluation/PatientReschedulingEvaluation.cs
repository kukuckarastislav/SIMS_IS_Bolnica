using System;
using System.Collections.Generic;
using Model;

namespace ActivityEvaluation
{
    class PatientReschedulingEvaluation : PatientActivityEvaluation
    {
        public PatientReschedulingEvaluation() : base("POMJERANJE") { }


        public int CountOccurencesForRequestedPeriod(int patiendId, TimeSpan period)
        {
            return CountOccurrences(patiendId, period);
        }


        protected override int CountOccurrences(int patientId, TimeSpan period)
        {
            int count = 0;
            foreach (Aktivnost a in GetOccurencesForRequestedPeriod(patientId, period))
            {
                if (a.Vrsta.Equals("POMJERANJE"))
                    count++;
            }
            return count;

        }

        private List<Aktivnost> GetOccurencesForRequestedPeriod(int patiendId, TimeSpan period)
        {
            List<Aktivnost> relevantActivities = new List<Aktivnost>();

            foreach (Aktivnost a in base._repository.GetPatientActivityById(patiendId))
            {
                if (DateTime.Compare(a.Datum, DateTime.Now - period) > 0)
                {
                    relevantActivities.Add(a);
                }
            }
            return relevantActivities;

        }
    }
}
