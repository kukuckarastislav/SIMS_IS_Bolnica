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

        public List<int> IdZdravstveneUsluge { get; set; }      // ovo tu je neka greska treba obrisati ovu listu 

      
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


        public override string ToString()
        {
            return BrojSprat;
        }
    }
}