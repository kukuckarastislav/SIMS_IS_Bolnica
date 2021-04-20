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

        public Oprema ObrisiOpremuBySifra(string sifra)
        {
            foreach(Oprema op in LOprema)
            {
                if (op.Sifra.Equals(sifra))
                {
                    LOprema.Remove(op);
                    return op;
                }
            }
            return null;
        }


        /*
         * 
         * private System.Collections.ArrayList lekovi;
        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetLekovi()
        {
            if (lekovi == null)
                lekovi = new System.Collections.ArrayList();
            return lekovi;
        }

        
        /// <pdGenerated>default setter</pdGenerated>
        public void SetLekovi(System.Collections.ArrayList newLekovi)
        {
            RemoveAllLekovi();
            foreach (Lek oLek in newLekovi)
                AddLekovi(oLek);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddLekovi(Lek newLek)
        {
            if (newLek == null)
                return;
            if (this.lekovi == null)
                this.lekovi = new System.Collections.ArrayList();
            if (!this.lekovi.Contains(newLek))
            {
                this.lekovi.Add(newLek);
                newLek.SetInventar(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveLekovi(Lek oldLek)
        {
            if (oldLek == null)
                return;
            if (this.lekovi != null)
                if (this.lekovi.Contains(oldLek))
                {
                    this.lekovi.Remove(oldLek);
                    oldLek.SetInventar((Inventar)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllLekovi()
        {
            if (lekovi != null)
            {
                System.Collections.ArrayList tmpLekovi = new System.Collections.ArrayList();
                foreach (Lek oldLek in lekovi)
                    tmpLekovi.Add(oldLek);
                lekovi.Clear();
                foreach (Lek oldLek in tmpLekovi)
                    oldLek.SetInventar((Inventar)null);
                tmpLekovi.Clear();
            }
        }
        */



        /*
        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetStatickaOprema()
        {
            if (statickaOprema == null)
                statickaOprema = new System.Collections.ArrayList();
            return statickaOprema;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetStatickaOprema(System.Collections.ArrayList newStatickaOprema)
        {
            RemoveAllStatickaOprema();
            foreach (Oprema oStatickaOprema in newStatickaOprema)
                AddStatickaOprema(oStatickaOprema);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddStatickaOprema(Oprema newStatickaOprema)
        {
            if (newStatickaOprema == null)
                return;
            if (this.statickaOprema == null)
                this.statickaOprema = new System.Collections.ArrayList();
            if (!this.statickaOprema.Contains(newStatickaOprema))
            {
                this.statickaOprema.Add(newStatickaOprema);
                newStatickaOprema.SetInventar(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveStatickaOprema(Oprema oldStatickaOprema)
        {
            if (oldStatickaOprema == null)
                return;
            if (this.statickaOprema != null)
                if (this.statickaOprema.Contains(oldStatickaOprema))
                {
                    this.statickaOprema.Remove(oldStatickaOprema);
                    oldStatickaOprema.SetInventar((Inventar)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllStatickaOprema()
        {
            if (statickaOprema != null)
            {
                System.Collections.ArrayList tmpStatickaOprema = new System.Collections.ArrayList();
                foreach (Oprema oldStatickaOprema in statickaOprema)
                    tmpStatickaOprema.Add(oldStatickaOprema);
                statickaOprema.Clear();
                foreach (Oprema oldStatickaOprema in tmpStatickaOprema)
                    oldStatickaOprema.SetInventar((Inventar)null);
                tmpStatickaOprema.Clear();
            }
        }

        */

    }
}