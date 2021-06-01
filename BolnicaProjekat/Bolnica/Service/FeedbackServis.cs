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
        private string vrsteKorisnika;

        public FeedbackServis()
        {
            repozitorijum = new FeedbackRepozitorijum();
        }

        internal void DodajFeedbackPacijenta(int idPacijenta, string text)
        {
            vrsteKorisnika = "PACIJENT";
            int id = repozitorijum.getNewId();
            Feedback NoviFeedback = new Feedback(id,text,idPacijenta,vrsteKorisnika);
            repozitorijum.DodajFeedback(NoviFeedback);
        }

        internal void DodajFeedbackLekara(int idLekara, string text)
        {
            vrsteKorisnika = "LEKAR";
            int id = repozitorijum.getNewId();
            Feedback NoviFeedback = new Feedback(id, text, idLekara, vrsteKorisnika);
            repozitorijum.DodajFeedback(NoviFeedback);
        }

        internal void DodajFeedbackSekretara(int idSekretar, string text)
        {
            vrsteKorisnika = "SEKRETAR";
            int id = repozitorijum.getNewId();
            Feedback NoviFeedback = new Feedback(id, text, idSekretar, vrsteKorisnika);
            repozitorijum.DodajFeedback(NoviFeedback);
        }

        internal void DodajFeedbackUpravnika(int idUpravik, string text)
        {
            vrsteKorisnika = "UPRAVNIK";
            int id = repozitorijum.getNewId();
            Feedback NoviFeedback = new Feedback(id, text, idUpravik, vrsteKorisnika);
            repozitorijum.DodajFeedback(NoviFeedback);
        }

    }

}
