using System;
using Repozitorijum;
using Model;

namespace Servis
{
    class FeedbackServis
    {
        private FeedbackRepozitorijum repozitorijum;
        private string vrsteKorisnika;

        public FeedbackServis()
        {
            repozitorijum = FeedbackRepozitorijum.GetInstance;
        }

        internal void DodajFeedbackPacijenta(int idPacijenta, string text)
        {
            vrsteKorisnika = "PACIJENT";
            int id = repozitorijum.getNewId();
            Feedback NoviFeedback = new Feedback(id,text,idPacijenta,vrsteKorisnika,DateTime.Now);
            repozitorijum.DodajFeedback(NoviFeedback);
        }

        internal void DodajFeedbackLekara(int idLekara, string text)
        {
            vrsteKorisnika = "LEKAR";
            int id = repozitorijum.getNewId();
            Feedback NoviFeedback = new Feedback(id, text, idLekara, vrsteKorisnika, DateTime.Now);
            repozitorijum.DodajFeedback(NoviFeedback);
        }

        internal void DodajFeedbackSekretara(int idSekretar, string text)
        {
            vrsteKorisnika = "SEKRETAR";
            int id = repozitorijum.getNewId();
            Feedback NoviFeedback = new Feedback(id, text, idSekretar, vrsteKorisnika, DateTime.Now);
            repozitorijum.DodajFeedback(NoviFeedback);
        }

        internal void DodajFeedbackUpravnika(int idUpravik, string text)
        {
            vrsteKorisnika = "UPRAVNIK";
            int id = repozitorijum.getNewId();
            Feedback NoviFeedback = new Feedback(id, text, idUpravik, vrsteKorisnika, DateTime.Now);
            repozitorijum.DodajFeedback(NoviFeedback);
        }

        public bool JelSekretarDaoFeedback(int idSekretara)
        {
            Feedback fb = FeedbackRepozitorijum.GetInstance.GetFeedBackBySekretarId(idSekretara);
            if (fb != null) return true;

            return false;
        }

    }

}
