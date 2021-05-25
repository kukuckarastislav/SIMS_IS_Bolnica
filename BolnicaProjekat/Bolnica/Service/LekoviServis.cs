using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repozitorijum;

namespace Servis
{
    class LekoviServis
    {
        public LekoviRepozitorijum lekoviRepozitorijumRef;
        public LekoviServis()
        {
            lekoviRepozitorijumRef = LekoviRepozitorijum.GetInstance;
        }

        public void PosaljiLekoveNaReviziju(ObservableCollection<Lekar> odabraniLekari, Lek lek)
        {
            throw new NotImplementedException();

            //ovdje prolazi kroz sve lekare itd..
        }

        public ObservableCollection<Lek> GetOdobreniLekovi()
        {
            ObservableCollection<Lek> ret = new ObservableCollection<Lek>();
            List<Lek> lekovi = Repozitorijum.LekoviRepozitorijum.GetInstance.GetAll();
            foreach (Lek l in lekovi)
            {
                if (l.Odobren == true)
                    ret.Add(l);
            }
            return ret;
        }

        public ObservableCollection<Lek> GetNeodobreniLekovi()
        {
            ObservableCollection<Lek> ret = new ObservableCollection<Lek>();
            List<Lek> lekovi = Repozitorijum.LekoviRepozitorijum.GetInstance.GetAll();
            foreach (Lek l in lekovi)
            {
                if (l.Odobren == false)
                    ret.Add(l);
            }
            return ret;
        }

        public Lek ObrisiLek(Lek lek)
        {
            return lekoviRepozitorijumRef.ObrisiLek(lek);
        }


        public bool DodajLek(string naziv,
                              string sifra,
                              int kolicina,
                              double cena,
                              string opis,
                              List<RevizijaLeka> revizijeLekara,
                              List<string> alergeni)
        {
            int idLeka = lekoviRepozitorijumRef.GetFirstFitID();
            Lek noviLek = new Lek(idLeka, sifra, naziv, false, opis, kolicina, cena, alergeni, revizijeLekara);
            lekoviRepozitorijumRef.DodajLek(noviLek);
            return true;
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

            Lek lek = lekoviRepozitorijumRef.GetLekById(idLeka);
            lek.Naziv = naziv;
            lek.Sifra = sifra;
            lek.Kolicina = kolicina;
            lek.Cena = cena;
            lek.Opis = opis;
            lek.Revizije = revizijeLekara;
            lek.Alergeni = alergeni;

            lekoviRepozitorijumRef.AzurirajLek(lek);

            return true;
        }


    }
}
