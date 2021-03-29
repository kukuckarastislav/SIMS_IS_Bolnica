/***********************************************************************
 * Module:  Termin.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Util.Termin
 ***********************************************************************/

using System;

namespace Model
{
    public class Termin
    {
        public DateTime Pocetak { get; set; }
        private double Trajanje { get; set; }
        private DateTime Kraj{ get; set; }

        public Termin(DateTime pocetak, double trajanje, DateTime kraj)
        {
            Pocetak = pocetak;
            Trajanje = trajanje;
            Kraj = kraj;
        }

        public Termin(DateTime pocetak, DateTime kraj)
        {
            Pocetak = pocetak;
            Trajanje = 10.00 ;
            Kraj = kraj;
        }
    }
}