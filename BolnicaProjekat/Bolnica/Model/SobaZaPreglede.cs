/***********************************************************************
 * Module:  Ordinacija.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Upravnik.Ordinacija
 ***********************************************************************/

using System;

namespace Model
{
    public class SobaZaPreglede : Prostorija
    {
        public SobaZaPreglede()
        {
        }

        public SobaZaPreglede(int id, int sprat, double povrsina, int idInventara) : base(id, sprat, povrsina, idInventara)
        {
        }
    }
}