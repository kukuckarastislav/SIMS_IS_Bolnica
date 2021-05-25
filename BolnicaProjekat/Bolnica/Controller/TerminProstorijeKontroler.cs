using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servis;
using Model;
using System.Collections.ObjectModel;
using DTO;

namespace Kontroler
{
    public class TerminProstorijeKontroler
    {

        private TerminProstorijeServis terminProstorijeServisObjekat;
        public TerminProstorijeKontroler()
        {
            terminProstorijeServisObjekat = new TerminProstorijeServis();
        }

        public ObservableCollection<Termin> GetTerminiByProstorijaIdObs(int idProstorije1)
        {
            return terminProstorijeServisObjekat.GetTerminiByProstorijaIdObs(idProstorije1);
        }

        public ObservableCollection<Termin> GetUnijaTerminaByProstorijaIdObs(int idProstorije1, int idProstorije2)
        {
            return terminProstorijeServisObjekat.GetUnijaTerminaByProstorijaIdObs(idProstorije1, idProstorije2);
        }


        public bool ZakaziTerminPremestanjaProstorije(int idProstorije1, int idProstorije2, TipTerminaProstorije tipTerminaProstorije, DateTime pocetak, DateTime kraj)
        {
            return terminProstorijeServisObjekat.ZakaziTerminPremestanjaProstorije(idProstorije1, idProstorije2, tipTerminaProstorije, pocetak, kraj);
        }

        public ObservableCollection<TerminProstorije> GetTerminiZauzetostiByProstorijaIdObs(int idProstorije1, int idProstorije2 = -1)
        {
            return terminProstorijeServisObjekat.GetTerminiZauzetostiByProstorijaIdObs(idProstorije1, idProstorije2);
        }

        public ObservableCollection<TerminProstorije> GetTerminiPreraspodeleByProstorijaIdObs(int idProstorije1, int idProstorije2 = -1)
        {
            return terminProstorijeServisObjekat.GetTerminiPreraspodeleByProstorijaIdObs(idProstorije1, idProstorije2);
        }

        public TerminProstorije OtkaziTerminProstorije(TerminProstorije terminProstorije)
        {
            return terminProstorijeServisObjekat.OtkaziTerminProstorije(terminProstorije);
        }

        public TerminProstorije AzurirajTransferOpreme(TerminProstorije terminProstorije)
        {
            return terminProstorijeServisObjekat.AzurirajTransferOpreme(terminProstorije);
        }

        public ObservableCollection<TransferOpreme> GetTransferOpremeObservebleByTerminProstorije(TerminProstorije terminProstorije)
        {
            return terminProstorijeServisObjekat.GetTransferOpremeObservebleByTerminProstorije(terminProstorije);
        }

        public TransferOpreme DodajTrensferZaTerminProstorije(TerminProstorije terminProstorije, TransferOpreme transferOpreme)
        {
            return terminProstorijeServisObjekat.DodajTrensferZaTerminProstorije(terminProstorije, transferOpreme);
        }

        public ObservableCollection<TerminProstorijeDTO> GetTerminiProstorijeDTOobsByProstorija(Prostorija prostorija)
        {
            return terminProstorijeServisObjekat.GetTerminiProstorijeDTOobsByProstorija(prostorija);
        }

        public bool ZakaziTerminRenoviranjaProstorije(int idProstorije, DateTime pocetak, DateTime kraj)
        {
            return terminProstorijeServisObjekat.ZakaziTerminRenoviranjaProstorije(idProstorije, pocetak, kraj);
        }


        public bool ZakaziTerminRazdvajanjaProstorije(int idProstorije, DateTime pocetak, DateTime kraj, TransformacijaProstorijeParametri transformacijaProstorije)
        {
            return terminProstorijeServisObjekat.ZakaziTerminRazdvajanjaProstorije(idProstorije, pocetak, kraj, transformacijaProstorije);
        }

    }

}
