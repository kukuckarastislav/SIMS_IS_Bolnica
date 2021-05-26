/***********************************************************************
 * Module:  Inventar.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Upravnik.Inventar
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model
{
    public class Inventar
    {
        public Inventar(int id, int idProstorije, List<Oprema> lOprema, List<Lek> lLekovi)
        {
            Id = id;
            IdProstorije = idProstorije;
            LOprema = lOprema;
            LLekovi = lLekovi;
        }

        public int Id { get; set; }
        public int IdProstorije { get; set; }
        public List<Oprema> LOprema { get; set; }
        public List<Lek> LLekovi { get; set; }

        public List<Oprema> GetOpremaByTip(TipOpreme tipOpreme)
        {
            List<Oprema> retVal = new List<Oprema>();
            foreach(Oprema op in LOprema)
            {
                if(op.Tip == tipOpreme)
                {
                    retVal.Add(op);
                }
            }
            return retVal;
        }


        public Oprema GetOpremaBySifra(string sifra)
        {
            foreach (Oprema opream in LOprema)
            {
                if (opream.Sifra.Equals(sifra))
                {
                    return opream;
                }
            }
            return null;
        }

        public Oprema ObrisiOpremuBySifra(string sifra)
        {
            Oprema oprema = GetOpremaBySifra(sifra);
            LOprema.Remove(oprema);
            return oprema;
        }

        public bool dodajOpremu(Oprema oprema, int kolicina)
        {

            foreach(Oprema op in LOprema)
            {
                if(op.Sifra == oprema.Sifra)
                {
                    op.Kolicina = op.Kolicina + kolicina;
                    return true;
                }
            }

            Oprema opNova = new Oprema(oprema.Id, oprema.Sifra, oprema.Naziv, oprema.Tip, oprema.Opis, kolicina, oprema.Cena, oprema.IdInventar);
            LOprema.Add(opNova);
            return true;
        }

        public bool oduzmiOpremu(Oprema oprema, int kolicina)
        {
            if (kolicina > oprema.Kolicina) return false;
            
            oprema.Kolicina = oprema.Kolicina - kolicina;
            if(oprema.Kolicina == 0 && Id != 0)
            {
                Oprema opremaIzInventara = GetOpremaBySifra(oprema.Sifra);
                return LOprema.Remove(opremaIzInventara);
            }
            return true;
        }


        public int RazlikaUKoliciniOpreme(TransferOpreme transferOpreme)
        {
            // ako vrati 0 onda je taman isti broj kolicin opreme koju zelimo da premestimo i kolicina opreme
            // ako vrati pozitivan broj to znaci da te opreme u inventaru ima vise od onog sto zelimo da prebacimo i to je ok
            // ako vrati negativan broj to znaci da zelimo vise kolicine prebacimo nego sto imamo u ovom inventaru
            Oprema opremaIzInventara = GetOpremaBySifra(transferOpreme.SifraOpreme);
            if(opremaIzInventara != null)
            {
                return opremaIzInventara.Kolicina - transferOpreme.KolicinaOpreme;
            }

            return -transferOpreme.KolicinaOpreme;
        }


        public Oprema oduzmiOpremu(string SifraOpreme, int kolicina)
        {
            Oprema oprema = GetOpremaBySifra(SifraOpreme);
            if(oprema == null)
            {
                // ovu opremu ne mozemo premestiti vise je nema ...
                return null;  
            }

            oprema.Kolicina = oprema.Kolicina - kolicina;
            if (oprema.Kolicina == 0 && Id != 0)
            {
                LOprema.Remove(oprema);
            }

            return oprema;
        }


       

    }
}