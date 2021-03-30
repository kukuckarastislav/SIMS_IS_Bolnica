/***********************************************************************
 * Module:  Prostorija.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Upravnik.Prostorija
 ***********************************************************************/

using System;
using System.Collections;
using System.ComponentModel;

namespace Model
{
   public class Prostorija
    {

        
        public int Id { get; set; }

        public int Sprat { get; set; }
        public double Povrsina { get; set; }
        public Inventar Inventar;

        public Prostorija(int id, int sprat, double povrsina, int idInventara)
        {
            Id = id;
            Sprat = sprat;
            Povrsina = povrsina;
            this.Inventar = new Inventar(idInventara);
        }

        public System.Collections.ArrayList terminiZauzetosti;
      
        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetTerminiZauzetosti()
        {
            if (terminiZauzetosti == null)
            terminiZauzetosti = new System.Collections.ArrayList();
            return terminiZauzetosti;
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
   

   
   }
}