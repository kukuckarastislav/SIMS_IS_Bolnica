/***********************************************************************
 * Module:  Lek.cs
 * Author:  Milica
 * Purpose: Definition of the Class Lek
 ***********************************************************************/

using System;

namespace Model
{
    public class Lek
    {
        public Lek(int id, string sifra, string naziv, bool odobren, string opis, int kolicina, double cena, int idInventar)
        {
            Id = id;
            Sifra = sifra;
            Naziv = naziv;
            Odobren = odobren;
            Opis = opis;
            Kolicina = kolicina;
            Cena = cena;
            IdInventar = idInventar;    // id inventara nam ne treba
        }

        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public bool Odobren { get; set; }
        public string Opis { get; set; }
        public int Kolicina { get; set; }
        public double Cena { get; set; }
        public int IdInventar { get; set; }

    }
}