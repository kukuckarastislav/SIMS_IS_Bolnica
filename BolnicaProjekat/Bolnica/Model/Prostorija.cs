/***********************************************************************
 * Module:  Prostorija.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Upravnik.Prostorija
 ***********************************************************************/

using System;
using System.Collections;

namespace Model
{
    public class Prostorija
    {
        /*
         *     "terminiZauzetosti": null,
    "Id": 1,
    "TipProstorije": 0,
    "Broj": "2",
    "Sprat": 3,
    "Povrsina": 100,
    "BrojKreveta": 0,
    "BrojSlobodnihKreveta": 0,
    "BrojSprat": "2/3",
    "inventar": null
         * */
        public Prostorija(ArrayList terminiZauzetosti, int id, TipProstorije tipProstorije, string broj, int sprat, double povrsina, int brojKreveta, int brojSlobodnihKreveta, Inventar inventar)
        {
            Id = id;
            TipProstorije = tipProstorije;
            Broj = broj;
            Sprat = sprat;
            Povrsina = povrsina;
            BrojKreveta = brojKreveta;
            BrojSlobodnihKreveta = brojSlobodnihKreveta;
            TerminiZauzetosti = terminiZauzetosti;
            Inventar = inventar;

        }



        public System.Collections.ArrayList TerminiZauzetosti { get; set; }
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

        public Inventar Inventar { get; set; }

    }
}