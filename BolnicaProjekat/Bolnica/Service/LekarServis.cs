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
using Bolnica.DTO;
using System.Windows;

namespace Servis
{
   public class LekarServis
   {
        public LekarServis()
        {

        }
      public Lekar DodajLekara(Model.Lekar lekar)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Lekar AzurirajLekara(Model.Lekar lekar)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Lekar ObrisiLekara(Model.Lekar lekar)
      {
         // TODO: implement
         return null;
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
                lekariDto.Add(noviDto);
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