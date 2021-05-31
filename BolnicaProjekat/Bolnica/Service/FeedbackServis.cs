using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repozitorijum;
using Model;

namespace Servis
{
    class FeedbackServis
    {
        private FeedbackRepozitorijum repozitorijum;

        public FeedbackServis()
        {
            repozitorijum = new FeedbackRepozitorijum();
        }

        internal void DodajFeedbackPacijenta(int idPacijenta, string text)
        {
            int id = repozitorijum.getNewId();
            Feedback NoviFeedback = new Feedback(id,text,idPacijenta,"PACIJENT");
            repozitorijum.DodajFeedback(NoviFeedback);
        }
    }
}
