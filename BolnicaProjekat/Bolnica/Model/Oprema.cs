/***********************************************************************
 * Module:  StatickaOprema.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class StatickaOprema
 ***********************************************************************/

using System;

namespace Model
{
    public class Oprema
    {
        public Oprema(int id, string sifra, string naziv, TipOpreme tip, string opis, int kolicina, double cena, int idInventar)
        {
            Id = id;
            Sifra = sifra;
            Naziv = naziv;
            Tip = tip;
            Opis = opis;
            Kolicina = kolicina;
            Cena = cena;
            IdInventar = idInventar;
        }

        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public TipOpreme Tip { get; set; }
        public string Opis { get; set; }
        public int Kolicina { get; set; }
        public double Cena { get; set; }
        public int IdInventar { get; set; }

    }
}