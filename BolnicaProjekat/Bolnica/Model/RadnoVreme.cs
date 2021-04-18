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
      public int PocetakRadnogVremena { get; set; }
        public int KrajRadnogVremena { get; set; }


        public RadnoVreme(int pocetak, int kraj)
        {
            PocetakRadnogVremena = pocetak;
            KrajRadnogVremena = kraj;
        }
    }
}