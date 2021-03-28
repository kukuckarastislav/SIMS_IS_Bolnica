/***********************************************************************
 * Module:  BolesnickaSoba.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Upravnik.BolesnickaSoba
 ***********************************************************************/

using System;

namespace Model
{
   public class BolesnickaSoba : Prostorija
   {
        private int BrojKreveta;
        private int BrojSlobodnihKreveta;

        public BolesnickaSoba(int brojKreveta, int brojSlobodnihKreveta, int id, int sprat, double povrsina, int idInventara) : base(id, sprat, povrsina, idInventara)
        {
            BrojKreveta = brojKreveta;
            BrojSlobodnihKreveta = brojSlobodnihKreveta;
        }
    }
}