using System;
using Repozitorijum;
using Model;
using Interface;
using Threads;
using ActivityEvaluation;

namespace Servis
{
    class KorisnickaAktivnostServis : IObserver
    {
        private AktivnostPacijentaRepozitorijum _AktivnostPacijentaRepozitorijum;
        private NotifikacijaRepozitorijum _NotifikacijeRepozitorijum;
        private PacijentRepozitorijum _PacijentRepozitorijum;

        public KorisnickaAktivnostServis()
        {
            _AktivnostPacijentaRepozitorijum = AktivnostPacijentaRepozitorijum.GetInstance;
            _NotifikacijeRepozitorijum = NotifikacijaRepozitorijum.GetInstance;
            _PacijentRepozitorijum = PacijentRepozitorijum.GetInstance;
        }

        public bool JeSpamUser(int IdPacijenta)
        {
            if (PacijentRepozitorijum.GetInstance.GetById(IdPacijenta).SpamUser)
                return true;
            else
                return AnalizaAktivnostiPacijenta(IdPacijenta);
        }


        public bool AnalizaAktivnostiPacijenta(int IdPacijenta)
        {

            TimeSpan posmatrajZakazivanje = new TimeSpan(30, 0, 0, 0, 0);
            TimeSpan posmatrajPomjeranje = new TimeSpan(30, 0, 0, 0, 0);

            PatientSchedulingEvaluation schedulingEvaluation = new PatientSchedulingEvaluation();
            PatientReschedulingEvaluation reschedulingEvaluation = new PatientReschedulingEvaluation();

            int shedulingCount = schedulingEvaluation.CountOccurencesForRequestedPeriod(IdPacijenta, posmatrajZakazivanje);
            int reshedulingCount = reschedulingEvaluation.CountOccurencesForRequestedPeriod(IdPacijenta, posmatrajPomjeranje);

            if (shedulingCount > 3 || reshedulingCount > 3)
                return false;

            return true;
        }

        public void PosaljiUpozorenje(int idPacijenta)
        {
            int id = NotifikacijaRepozitorijum.GetInstance.GetAll().Count;
            NotifikacijaRepozitorijum.GetInstance.DodajNotifikaciju(new Notifikacija(id + 1, -1, idPacijenta, -1, false, false,
                                                                     " Upozoravamo vas da cete biti bannovani ako uradite jos jedno pomjeranje ili zakazivanje termina!"));
        }

        public Aktivnost DodajKorisnickuAktivnost(Aktivnost aktivnost)
        {
            return AktivnostPacijentaRepozitorijum.GetInstance.DodajAktivnost(aktivnost);
        }

        public void Update(ISubject subject)
        {
            if (subject is UserSuspension userSuspension)
            {
                AktivnostPacijentaRepozitorijum.GetInstance.AzurirajStareSuspenzije(userSuspension.Patientid);
            }
        }
    }
}
