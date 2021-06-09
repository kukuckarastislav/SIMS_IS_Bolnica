using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Service;
using DTO;
using Model;
using Servis;

namespace Kontroler
{
    public class LekoviKontroler
    {
        private LekoviCRUDServis lekoviCRUDServis;
        private LekarServis lekarServis;
        public LekoviKontroler()
        {
            lekoviCRUDServis = new LekoviCRUDServis();
            lekarServis = new LekarServis();
        }

        public int BrojOdobrenihLekova()
        {
            return lekoviCRUDServis.GetOdobreniLekovi().Count();
        }

        public int BrojNeOdobrenihLekova()
        {

            return lekoviCRUDServis.GetNeodobreniLekovi().Count();
        }

        public void PosaljiLekoveNaReviziju(ObservableCollection<Lekar> odabraniLekari, Lek lek)
        {
            //lekoviServisObjekat.PosaljiLekoveNaReviziju(odabraniLekari, lek);
        }

        public List<LekDTO> GetOdobreniLekovi()
        {
            return lekoviCRUDServis.GetOdobreniLekovi();
        }



        public List<LekDTO> GetNeOdobreniLekovi()
        {
            return lekoviCRUDServis.GetNeodobreniLekovi();
        }

        public void ObrisiLek(LekDTO lek)
        {
            lekoviCRUDServis.ObrisiLek(lek);
        }

        public void DodajLek(LekDTO lek)
        {
            lekoviCRUDServis.DodajLek(lek);
        }

        public void IzmeniLek(LekDTO lek)
        {
            lekoviCRUDServis.AzurirajLek(lek);
        }


        public List<LekDTO> GetLekoviZaRevizijuByIdLekara(int idLekara)
        {
            return lekarServis.GetLekoviZaRevizijuByIdLekara(idLekara);
        }


        public bool IzmenaLekaByLekar(LekDTO dto, RevizijaLeka revizija)
        {

            return lekarServis.IzmenaLekaByLekar(dto, revizija);
        }


        public bool LekarOdobravaLek(int idLeka, RevizijaLeka revizija)
        {
            return lekarServis.LekarOdobravaLek(idLeka, revizija);
        }


    }
}
