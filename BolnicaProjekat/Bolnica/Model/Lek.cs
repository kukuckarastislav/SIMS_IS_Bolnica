/***********************************************************************
 * Module:  Lek.cs
 * Author:  Milica
 * Purpose: Definition of the Class Lek
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;

namespace Model
{
    public class Lek
    {
        public Lek(int id, string sifra, string naziv, bool odobren, string opis, int kolicina, double cena, List<string> alergeni, List<RevizijaLeka> revizije)
        {
            Id = id;
            Sifra = sifra;
            Naziv = naziv;
            Odobren = odobren;
            Opis = opis;
            Kolicina = kolicina;
            Cena = cena;
            Alergeni = alergeni;
            Revizije = revizije;
        }

        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public bool Odobren { get; set; }
        public string Opis { get; set; }
        public int Kolicina { get; set; }
        public double Cena { get; set; }
        public List<string> Alergeni { get; set; }
        public List<RevizijaLeka> Revizije { get; set; }

        public bool PostojiLekarURevizijiByID(int idLekara)
        {
            foreach(RevizijaLeka revizija in Revizije)
            {
                if(revizija.IdLekara == idLekara)
                {
                    return true;
                }
            }
            return false;
        }

    }
}