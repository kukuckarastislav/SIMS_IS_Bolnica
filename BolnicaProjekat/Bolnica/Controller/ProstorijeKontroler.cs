/***********************************************************************
 * Module:  ProstorijeKontroler.cs
 * Author:  lacik
 * Purpose: Definition of the Class Kontroler.ProstorijeKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;

namespace Kontroler
{
   public class ProstorijeKontroler
   {
      public Model.Prostorija DodajProstoriju()
      {
         // TODO: implement
         return null;
      }
      
      public Model.OperacionaSala DodajOperacionuSalu()
      {
         // TODO: implement
         return null;
      }
      
      public Model.SobaZaPreglede DodajSobuZaPreglede()
      {
         // TODO: implement
         return null;
      }
      
      public Model.BolesnickaSoba DodajBolesnickuSobu()
      {
         // TODO: implement
         return null;
      }
      
      public Prostorija ObrisiProstoriju()
      {
         // TODO: implement
         return null;
      }
      
      public OperacionaSala ObrisiOperacionuSalu()
      {
         // TODO: implement
         return null;
      }
      
      public SobaZaPreglede ObrisiSobuZaPreglede()
      {
         // TODO: implement
         return null;
      }
      
      public BolesnickaSoba ObrisiBolesnickuSobu()
      {
         // TODO: implement
         return null;
      }
      
      public Prostorija AzurirajProstoriju()
      {
         // TODO: implement
         return null;
      }
      
      public OperacionaSala AzurirajOperacionuSalu()
      {
         // TODO: implement
         return null;
      }
      
      public SobaZaPreglede AzurirajSobuZaPreglede()
      {
         // TODO: implement
         return null;
      }
      
      public BolesnickaSoba AzurirajBolesnickuSobu()
      {
         // TODO: implement
         return null;
      }
      
      public Prostorija GetProstorijaById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public OperacionaSala GetOperacionaSalaById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public SobaZaPreglede GetSobaZaPregledeById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public BolesnickaSoba GetBolesnickaSobaById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public List<Prostorija> GetProstorijeAll()
      {
         // TODO: implement
         return null;
      }
      
      public List<OperacionaSala> GetOperacioneSaleAll()
      {
         // TODO: implement
         return null;
      }
      
      public List<SobaZaPreglede> GetSobeZaPregledeAll()
      {
         // TODO: implement
         return null;
      }
      
      public List<BolesnickaSoba> GetBolesnickeSobeAll()
      {
         // TODO: implement
         return null;
      }
   
      public System.Collections.ArrayList prostorijeServis;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetProstorijeServis()
      {
         if (prostorijeServis == null)
            prostorijeServis = new System.Collections.ArrayList();
         return prostorijeServis;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetProstorijeServis(System.Collections.ArrayList newProstorijeServis)
      {
         RemoveAllProstorijeServis();
         foreach (Servis.ProstorijeServis oProstorijeServis in newProstorijeServis)
            AddProstorijeServis(oProstorijeServis);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddProstorijeServis(Servis.ProstorijeServis newProstorijeServis)
      {
         if (newProstorijeServis == null)
            return;
         if (this.prostorijeServis == null)
            this.prostorijeServis = new System.Collections.ArrayList();
         if (!this.prostorijeServis.Contains(newProstorijeServis))
            this.prostorijeServis.Add(newProstorijeServis);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveProstorijeServis(Servis.ProstorijeServis oldProstorijeServis)
      {
         if (oldProstorijeServis == null)
            return;
         if (this.prostorijeServis != null)
            if (this.prostorijeServis.Contains(oldProstorijeServis))
               this.prostorijeServis.Remove(oldProstorijeServis);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllProstorijeServis()
      {
         if (prostorijeServis != null)
            prostorijeServis.Clear();
      }
   
   }
}