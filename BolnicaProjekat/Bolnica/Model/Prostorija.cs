/***********************************************************************
 * Module:  Prostorija.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Upravnik.Prostorija
 ***********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Model
{
    public class Prostorija
    {

        public Prostorija(List<int> idZdravstveneUsluge, int id, TipProstorije tipProstorije, string broj, int sprat, double povrsina, int brojKreveta, int brojSlobodnihKreveta, int idInventar)
        {
            Id = id;
            TipProstorije = tipProstorije;
            Broj = broj;
            Sprat = sprat;
            Povrsina = povrsina;
            BrojKreveta = brojKreveta;
            BrojSlobodnihKreveta = brojSlobodnihKreveta;
            IdZdravstveneUsluge = idZdravstveneUsluge;
            IdInventar = idInventar;

        }

        public List<int> IdZdravstveneUsluge { get; set; }

       // public System.Collections.ArrayList TerminiZauzetosti { get; set; }
        /*
        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetTerminiZauzetosti()
        {
            if (TerminiZauzetosti == null)
                TerminiZauzetosti = new System.Collections.ArrayList();
            return TerminiZauzetosti;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetTerminiZauzetosti(System.Collections.ArrayList newTerminiZauzetosti)
        {
            RemoveAllTerminiZauzetosti();
            foreach (Termin oTermin in newTerminiZauzetosti)
                AddTerminiZauzetosti(oTermin);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddTerminiZauzetosti(Termin newTermin)
        {
            if (newTermin == null)
                return;
            if (this.terminiZauzetosti == null)
                this.terminiZauzetosti = new System.Collections.ArrayList();
            if (!this.terminiZauzetosti.Contains(newTermin))
                this.terminiZauzetosti.Add(newTermin);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveTerminiZauzetosti(Termin oldTermin)
        {
            if (oldTermin == null)
                return;
            if (this.terminiZauzetosti != null)
                if (this.terminiZauzetosti.Contains(oldTermin))
                    this.terminiZauzetosti.Remove(oldTermin);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllTerminiZauzetosti()
        {
            if (terminiZauzetosti != null)
                terminiZauzetosti.Clear();
        }
        */
        public int Id { get; set; }
        public TipProstorije TipProstorije { get; set; }
        public string Broj { get; set; }
        public int Sprat { get; set; }
        public double Povrsina { get; set; }
        public int BrojKreveta { get; set; }
        public int BrojSlobodnihKreveta { get; set; }

        private string brojSprat;
        public string BrojSprat
        {
            get
            {
                return Broj + "/" + Sprat;
            }
            set {
                brojSprat = value;
            }
        }

        public int IdInventar { get; set; }

    }
}