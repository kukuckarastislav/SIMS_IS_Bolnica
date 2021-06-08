/***********************************************************************
 * Module:  PacijentServis.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class Servis.PacijentServis
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;
using Repozitorijum;
using DTO;
using Bolnica.view.sekretar;
using Interface;
using Threads;

using System.Collections;

namespace Servis
{
   class PacijentServis : IObserver
   {
        public Repozitorijum.PacijentRepozitorijum pacijentRepozitorijum;
        public void DodajPacijenta(RegistracijaPacijentaDTO podaciPacijenta)
        {
            podaciPacijenta.Id = PacijentRepozitorijum.GetInstance.GetNewId();
            Pacijent pacijent = konvertujDtoUModel(podaciPacijenta);
            if (podaciPacijenta.PacijentGost)
            {
                pacijent.KorisnickoIme = podaciPacijenta.Jmbg;
                pacijent.Sifra = podaciPacijenta.Jmbg;
            }
            PacijentRepozitorijum.GetInstance.DodajPacijenta(pacijent);
        }

        public Pacijent konvertujDtoUModel(RegistracijaPacijentaDTO podaciPacijenta)
        {
            Pol pol = Pol.Zensko;
            if (podaciPacijenta.Musko) pol = Pol.Musko;
            Pacijent pacijent = new Pacijent(new MedicinskiKarton(podaciPacijenta.Id,false, null,new Terapija(), new List<string>()), new ArrayList(),podaciPacijenta.Id,podaciPacijenta.pacijentGost,false,false,false,
                podaciPacijenta.KorisnickoIme,podaciPacijenta.Sifra,podaciPacijenta.Ime,podaciPacijenta.Prezime,pol,
                podaciPacijenta.Email,podaciPacijenta.Telefon,podaciPacijenta.DatumRodjenja,podaciPacijenta.Jmbg,podaciPacijenta.Drzavljanstvo,podaciPacijenta.AdresaStanovanja);
            return pacijent;
        }

        public Model.Pacijent AzurirajPacijenta(Model.Pacijent pacijent)
        {
            PacijentRepozitorijum.GetInstance.AzurirajPacijenta(pacijent);
            return pacijent;
        }

        public void AzurirajPacijenta(PacijentDTO noviPodaci)
        {
            PacijentRepozitorijum.GetInstance.AzurirajPacijenta(noviPodaci);
        }

        public void ObrisiPacijenta(PacijentDTO pacijent)
        {
            PacijentRepozitorijum.GetInstance.ObrisiPacijenta(pacijent);
        }

        public bool ProveriPostojanjePacijenta(string korisnickoIme)
        {
            return PacijentRepozitorijum.GetInstance.ProveriPostojanjePacijenta(korisnickoIme);
        }

        public PacijentDTO PrijaviPacijenta(string korisnickoIme, string lozinka)
        {
            if (ProveriPostojanjePacijenta(korisnickoIme))
            {
                return KonvertujPacijentaUPacijentDTO(PacijentRepozitorijum.GetInstance.GetByImeLozinka(korisnickoIme, lozinka));
            }

            return null;
        }

        public ObservableCollection<Model.Pacijent> GetAll()
        {
            return PacijentRepozitorijum.GetInstance.GetAll();
        }

        public ObservableCollection<PacijentDTO> GetPacijentiDto()
        {
            ObservableCollection<Pacijent> sviPacijenti = PacijentRepozitorijum.GetInstance.GetNeobrisaniPacijenti();
            ObservableCollection<PacijentDTO> dtoPacijenti = new ObservableCollection<PacijentDTO>();

            foreach(Pacijent pacijent in sviPacijenti)
            {
                dtoPacijenti.Add(KonvertujPacijentaUPacijentDTO(pacijent));
            }

            return dtoPacijenti;
        }

        public PacijentDTO KonvertujPacijentaUPacijentDTO(Pacijent pacijent)
        {
            return new PacijentDTO(pacijent.Id, pacijent.Ime, pacijent.Prezime, pacijent.Email, pacijent.Telefon, pacijent.Jmbg,pacijent.AdresaStanovanja,
                pacijent.Drzavljanstvo,pacijent.Pol,pacijent.DatumRodjenja,pacijent.KorisnickoIme);
        }

        public List<string> GetAlergeniPacijenta(int id)
        {
            return PacijentRepozitorijum.GetInstance.GetAlergeniPacijenta(id);
        }

        public void DodajAlergen(int idPacijenta, string alergen)
        {
            PacijentRepozitorijum.GetInstance.DodajAlergen(idPacijenta, alergen);
        }

        public void ObrisiAlergen(int idPacijenta, string alergen)
        {
            PacijentRepozitorijum.GetInstance.ObrisiAlergen(idPacijenta, alergen);
        }
        public bool JelPostojiKorisnickoIme(string korisnickoIme)
        {
            bool postojanjePacijenta = PacijentRepozitorijum.GetInstance.JelPostojiKorisnickoIme(korisnickoIme);
            bool postojanjeSekretara = SekretarRepozitorijum.GetInstance.JelPostojiKorisnickoIme(korisnickoIme);
            bool postojanjeUpravnika = UpravnikRepozitorijum.GetInstance.JelPostojiKorisnickoIme(korisnickoIme);
            bool postojanjeLekara = LekarRepozitorijum.GetInstance.JelPostojiKorisnickoIme(korisnickoIme);

            bool pom = postojanjePacijenta || postojanjeSekretara || postojanjeUpravnika || postojanjeLekara;
            return pom;
        }

        public void SaveData()
        {
            PacijentRepozitorijum.GetInstance.SaveData();
        }

        public void Update(ISubject subject)
        {
            if(subject is UserSuspension userSuspension)
            {
                Pacijent p = PacijentRepozitorijum.GetInstance.GetById(userSuspension.Patientid);
                p.SpamUser = false;
                AzurirajPacijenta(p);
            }
        }
    }
}