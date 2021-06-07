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

        public int BrojOdobrenihLekova()
        {
            return lekoviServisObjekat.BrojOdobrenihLekova();
        }

        public int BrojNeOdobrenihLekova()
        {

            return lekoviServisObjekat.BrojNeOdobrenihLekova();
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


        public ObservableCollection<Lek> GetLekoviZaRevizijuByIdLekara(int idLekara)
        {
            return lekoviServisObjekat.GetLekoviZaRevizijuByIdLekara(idLekara);
        }


        public bool IzmenaLekaByLekar(int IdLeka,
                                    string naziv,
                                    string sifra,
                                    double cena,
                                    string opis,
                                    RevizijaLeka revizija,
                                    List<string> alergeni
                                    )
        {

            return lekoviServisObjekat.IzmenaLekaByLekar(IdLeka, naziv, sifra, cena, opis, revizija, alergeni);
        }


        public bool LekarOdobravaLek(int idLeka, RevizijaLeka revizija)
        {
            return lekoviServisObjekat.LekarOdobravaLek(idLeka, revizija);
        }


    }
}
