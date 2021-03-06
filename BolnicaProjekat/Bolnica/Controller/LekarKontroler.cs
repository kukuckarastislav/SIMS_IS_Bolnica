using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;
using Servis;
using DTO;

namespace Kontroler
{
    public class LekarKontroler
    {
        public Servis.LekarServis lekarServis;

        public LekarKontroler()
        {
            lekarServis = new LekarServis();
        }
        public void DodajLekara(RegistracijaLekaraDTO podaciLekara)
        {
            lekarServis.DodajLekara(podaciLekara);
        }

        public LekarDTO AzurirajLekara(LekarDTO lekar)
        {
            return lekarServis.AzurirajLekara(lekar);
        }

        public LekarDTO ObrisiLekara(LekarDTO lekar)
        {
            return lekarServis.ObrisiLekara(lekar);
        }

        public ObservableCollection<Lekar> GetAllObs()
        {
            return lekarServis.GetAllObs();
        }
        public List<LekarDTO> GetAllDTO()
        {
            return lekarServis.GetAllDTO();
        }

        public ObservableCollection<LekarDTO> getAllNeobrisaniLekari()
        {
            return lekarServis.GetAllNeobrisaniLekari();
        }

        public Model.Lekar GetById(long id)
        {
            // TODO: implement
            return null;
        }

        public LekarDTO PrijavaLekara(String korisnickoIme, String lozinka)
        {
            LekarDTO ret = null;
            if ((korisnickoIme != null) && (lozinka != null))
            {
                Lekar l = lekarServis.PrijaviLekara(korisnickoIme, lozinka);
                if (l != null)
                {
                    ret = new LekarDTO(l.Id, l.Specijalista, l.Specijalizacija, l.Ime, l.Prezime, l.KorisnickoIme, l.Email, l.Telefon, l.Pol, l.DatumRodjenja, l.Jmbg, l.Drzavljanstvo, l.AdresaStanovanja, l.Sifra, l.radnoVreme);
                }
            }
            return ret;
        }

        public ObservableCollection<LekarRevizijaLekaDTO> GetLekariDTOzaComboBox()
        {
            return lekarServis.GetLekariDTOzaComboBox();
        }

        public List<LekDTO> GetLekoviZaRevizijuByIdLekara(int idLekara)
        {
            return lekarServis.GetLekoviZaRevizijuByIdLekara(idLekara);
        }

    }
}