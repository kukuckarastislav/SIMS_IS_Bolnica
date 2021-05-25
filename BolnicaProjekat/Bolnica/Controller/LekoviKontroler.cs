using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Servis;

namespace Kontroler
{
    public class LekoviKontroler
    {
        private LekoviServis lekoviServisObjekat;

        public LekoviKontroler()
        {
            lekoviServisObjekat = new LekoviServis();
        }

        public void PosaljiLekoveNaReviziju(ObservableCollection<Lekar> odabraniLekari, Lek lek)
        {
            lekoviServisObjekat.PosaljiLekoveNaReviziju(odabraniLekari, lek);
        }

        public ObservableCollection<Lek> GetOdobreniLekovi()
        {
            return lekoviServisObjekat.GetOdobreniLekovi();
        }

        public ObservableCollection<Lek> GetNeOdobreniLekovi()
        {
            return lekoviServisObjekat.GetNeodobreniLekovi();
        }

        public void ObrisiLek(Lek lek)
        {
            lekoviServisObjekat.ObrisiLek(lek);
        }

        public bool DodajLek(string naziv,
                            string sifra,
                            int kolicina,
                            double cena,
                            string opis,
                            List<RevizijaLeka> revizijeLekara,
                            List<string> alergeni
                            )
        {
            return lekoviServisObjekat.DodajLek(naziv,
                                               sifra,
                                               kolicina,
                                               cena,
                                               opis,
                                               revizijeLekara,
                                               alergeni
                                               );

        }

        public bool IzmeniLek(int idLeka,
                            string naziv,
                            string sifra,
                            int kolicina,
                            double cena,
                            string opis,
                            List<RevizijaLeka> revizijeLekara,
                            List<string> alergeni
                            )
        {
            return lekoviServisObjekat.IzmeniLek(idLeka,
                                                   naziv,
                                                   sifra,
                                                   kolicina,
                                                   cena,
                                                   opis,
                                                   revizijeLekara,
                                                   alergeni);

        }

        
    }
}
