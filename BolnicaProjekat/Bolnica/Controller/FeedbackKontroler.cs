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
        public void DodajFeedbackLekara(int idLekara, String text)
        {
            servis.DodajFeedbackLekara(idLekara, text);
        }
        public void DodajFeedbackSekretara(int idSekretara, String text)
        {
            servis.DodajFeedbackSekretara(idSekretara, text);
        }

        public bool JelSekretarDaoFeedback(int idSekretara)
        {
            return servis.JelSekretarDaoFeedback(idSekretara);
        }

        public void DodajFeedbackUpravnika(int idUpravnika, String text)
        {
            servis.DodajFeedbackUpravnika(idUpravnika, text);
        }


    }
}
