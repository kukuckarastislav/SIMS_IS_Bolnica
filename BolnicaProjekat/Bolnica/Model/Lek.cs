/***********************************************************************
 * Module:  Lek.cs
 * Author:  Milica
 * Purpose: Definition of the Class Lek
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Windows;
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

        public bool JeOdobren()
        {
            int broj_odobrenja = 0;
            foreach(RevizijaLeka revizija in Revizije)
            {
                if(revizija.StatusRevizije == 1)
                {
                    broj_odobrenja++;
                    MessageBox.Show("opet");
                }
            }
            Odobren = broj_odobrenja >= 2;
            MessageBox.Show(Convert.ToString(broj_odobrenja));
            return Odobren;
        }

        public RevizijaLeka GetRevizijaLekaByIdLekara(int idLekara)
        {
            foreach(RevizijaLeka revizija in Revizije)
            {
                if(revizija.IdLekara == idLekara)
                {
                    return revizija;
                }
            }
            return null;
        }

        public bool IzmeniRevizijuLekar(RevizijaLeka revizijaLekara)
        {
            foreach(RevizijaLeka revizija in Revizije)
            {
                if(revizija.IdLekara == revizijaLekara.IdLekara)
                {
                    revizija.StatusRevizije = revizijaLekara.StatusRevizije;
                    revizija.Poruka = revizijaLekara.Poruka;
                    JeOdobren();
                    return true;
                }
            }

            return false;
        }

    }
}