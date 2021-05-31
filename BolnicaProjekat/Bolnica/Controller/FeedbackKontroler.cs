using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servis;

namespace Kontroler
{
    class FeedbackKontroler
    {
        private FeedbackServis servis;

        public FeedbackKontroler()
        {
            servis = new FeedbackServis();
        }

        public void DodajFeedbackPacijenta(int idPacijenta,String text)
        {
            servis.DodajFeedbackPacijenta(idPacijenta,text);
        }
        public void DodajFeedbackLekara()
        {

        }
        public void DodajFeedbackUpravnika()
        {

        }
        public void DodajFeedbackSekretara()
        {

        }

    }
}
