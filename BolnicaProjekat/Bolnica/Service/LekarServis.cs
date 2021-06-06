/***********************************************************************
 * Module:  LekarServis.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class Servis.LekarServis
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;
using Repozitorijum;
using DTO;
using System.Windows;

namespace Servis
{
    public class LekarServis
    {

        public Repozitorijum.LekarRepozitorijum lekarRepozitorijumRef;

        public LekarServis()
        {
            lekarRepozitorijumRef = LekarRepozitorijum.GetInstance;
        }
        public void DodajLekara(RegistracijaLekaraDTO podaciLekara)
        {
            Lekar lekar = konvertujDtoUModel(podaciLekara);
            lekar.LogickiObrisan = false;
            LekarRepozitorijum.GetInstance.DodajLekara(lekar);
        }

        public Lekar konvertujDtoUModel(RegistracijaLekaraDTO podaciLekara)
        {
            int id = LekarRepozitorijum.GetInstance.GetNewId();
            Pol pol = Pol.Zensko;
            if(podaciLekara.Musko) pol = Pol.Musko;
            Lekar lekar = new Lekar(id, podaciLekara.Specijalista, podaciLekara.Specijalizacija, new RadnoVreme(8,16), RadniStatus.Aktivan, podaciLekara.KorisnickoIme,
                podaciLekara.Sifra, podaciLekara.Ime, podaciLekara.Prezime, pol, podaciLekara.Email, podaciLekara.Telefon, podaciLekara.DatumRodjenja,
                podaciLekara.Jmbg, podaciLekara.Drzavljanstvo, podaciLekara.AdresaStanovanja);
            return lekar;
        }
      
        public LekarDTO AzurirajLekara(LekarDTO lekar)
        {
            LekarRepozitorijum.GetInstance.AzurirajLekara(lekar);
            return lekar;
        }
      
        public LekarDTO ObrisiLekara(LekarDTO dto)
         {
            LekarRepozitorijum.GetInstance.ObrisiLekara(dto);
            return dto;
        }
      
      public List<Lekar> GetAll()
      {
         // TODO: implement
         return null;
      }

        public ObservableCollection<Model.Lekar> GetAllObs()
        {
            return LekarRepozitorijum.GetInstance.GetAllObs();
        }
        public ObservableCollection<LekarDTO> GetAllDto()
        {
            ObservableCollection<LekarDTO> lekariDto = new ObservableCollection<LekarDTO>();
            ObservableCollection<Lekar> sviLekari = LekarRepozitorijum.GetInstance.GetAllObs();
            foreach(Lekar lekar in sviLekari)
            {
                LekarDTO noviDto = new LekarDTO();
                noviDto.Id = lekar.Id;
                noviDto.Ime = lekar.Ime;
                noviDto.Prezime = lekar.Prezime;
                noviDto.KorisnickoIme = lekar.KorisnickoIme;
                noviDto.Specijalista = lekar.Specijalista;
                noviDto.Specijalizacija = lekar.Specijalizacija;
                noviDto.Telefon = lekar.Telefon;
                noviDto.Email = lekar.Email;
                noviDto.DatumRodjenja = lekar.DatumRodjenja;
                lekariDto.Add(noviDto);
            }

            return lekariDto;
        }

        public ObservableCollection<LekarDTO> GetAllNeobrisaniLekari()
        {
            ObservableCollection<LekarDTO> lekariDto = new ObservableCollection<LekarDTO>();
            ObservableCollection<Lekar> sviLekari = LekarRepozitorijum.GetInstance.GetAllObs();
            foreach (Lekar lekar in sviLekari)
            {
                if (!lekar.LogickiObrisan)
                {
                    LekarDTO noviDto = new LekarDTO();
                    noviDto.Id = lekar.Id;
                    noviDto.Ime = lekar.Ime;
                    noviDto.Drzavljanstvo = lekar.Drzavljanstvo;
                    noviDto.AdresaStanovanja = lekar.AdresaStanovanja;
                    noviDto.Jmbg = lekar.Jmbg;
                    noviDto.Prezime = lekar.Prezime;
                    noviDto.KorisnickoIme = lekar.KorisnickoIme;
                    noviDto.Specijalista = lekar.Specijalista;
                    noviDto.Specijalizacija = lekar.Specijalizacija;
                    noviDto.Telefon = lekar.Telefon;
                    noviDto.Email = lekar.Email;
                    noviDto.DatumRodjenja = lekar.DatumRodjenja;
                    noviDto.Pol = lekar.Pol;
                    noviDto.radnoVreme = lekar.radnoVreme;
                    lekariDto.Add(noviDto);
                }
            }

            return lekariDto;
        }

        public bool ProveriPostojanjeLekara(string korisnickoIme)
        {
            return LekarRepozitorijum.GetInstance.ProveriPostojanjeLekara(korisnickoIme);
        }

        public Lekar PrijaviLekara(string korisnickoIme, string lozinka)
        {
            if (ProveriPostojanjeLekara(korisnickoIme))
            {
                return LekarRepozitorijum.GetInstance.GetByImeLozinka(korisnickoIme, lozinka);
            }

            return null;
        }

        public Model.Lekar GetById(long id)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<LekarRevizijaLekaDTO> GetLekariDTOzaComboBox()
        {
            ObservableCollection<LekarRevizijaLekaDTO> obsLekarRevizijaLekaDTO = new ObservableCollection<LekarRevizijaLekaDTO>();
            List<Lekar> Lekari = lekarRepozitorijumRef.GetAll();

            foreach(Lekar lekar in Lekari)
            {
                obsLekarRevizijaLekaDTO.Add(new LekarRevizijaLekaDTO(lekar.Id, lekar.Ime + " " + lekar.Prezime, lekar.Specijalizacija, "bez prava"));
            }

            return obsLekarRevizijaLekaDTO;
        }

    }
}