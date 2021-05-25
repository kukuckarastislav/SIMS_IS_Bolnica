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
        public LekarServis()
        {

        }
        public LekarDTO DodajLekara(LekarDTO lekarDto)
        {
            Lekar lekar = konvertujDto(lekarDto);
            lekar.LogickiObrisan = false;
            LekarRepozitorijum.GetInstance.DodajLekara(lekar);

            return lekarDto;
        }

        public Lekar konvertujDto(LekarDTO dto)
        {
            int id = LekarRepozitorijum.GetInstance.GetNewId();
            Lekar lekar = new Lekar(id, dto.Specijalista, dto.Specijalizacija, null, RadniStatus.Aktivan, dto.KorisnickoIme,
                dto.Sifra, dto.Ime, dto.Prezime, dto.Pol, dto.Email, dto.Telefon, dto.DatumRodjenja, dto.Jmbg, dto.Drzavljanstvo, dto.AdresaStanovanja);
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
   
      public Repozitorijum.LekarRepozitorijum lekarRepozitorijum;
   
   }
}