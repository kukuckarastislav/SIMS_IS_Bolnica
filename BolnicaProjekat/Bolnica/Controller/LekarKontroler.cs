/***********************************************************************
 * Module:  LekarKontroler.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class Kontroler.LekarKontroler
 ***********************************************************************/

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
      
      public List<Lekar> GetAll()
      {
         // TODO: implement
         return null;
      }

        public ObservableCollection<Model.Lekar> GetAllObs()
        {
            return lekarServis.GetAllObs();
        }
        public ObservableCollection<LekarDTO> getAllDto()
        {
            return lekarServis.GetAllDto();
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

        public Lekar PrijavaLekara(String korisnickoIme, String lozinka)
        {
            return lekarServis.PrijaviLekara(korisnickoIme, lozinka);
        }




        public ObservableCollection<LekarRevizijaLekaDTO> GetLekariDTOzaComboBox()
        {
            return lekarServis.GetLekariDTOzaComboBox();
        }


    }
}