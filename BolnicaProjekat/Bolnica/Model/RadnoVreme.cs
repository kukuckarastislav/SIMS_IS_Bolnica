/***********************************************************************
 * Module:  RadnoVreme.cs
 * Author:  lacik
 * Purpose: Definition of the Class RadnoVreme
 ***********************************************************************/

using System;

namespace Model
{
   public class RadnoVreme
   {
        /*
        private DateTime PocetakRadnogVremena;
        private DateTime KrajRadnogVremena;

        public RadnoVreme(DateTime pocetakRadnogVremena, DateTime krajRadnogVremena)
        {
            PocetakRadnogVremena = pocetakRadnogVremena;
            KrajRadnogVremena = krajRadnogVremena;
        }
        */

        private double PocetakRadnogVremena;
        private double KrajRadnogVremena;



        public RadnoVreme(double pocetakRadnogVremena, double krajRadnogVremena)
        {
            PocetakRadnogVremena = pocetakRadnogVremena;
            KrajRadnogVremena = krajRadnogVremena;
        }

        public RadnoVreme()
        {
        }
    }
}