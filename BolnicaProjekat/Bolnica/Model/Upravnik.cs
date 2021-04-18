/***********************************************************************
 * Module:  Upravnik.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Upravnik.Upravnik
 ***********************************************************************/

using System;

namespace Model
{
   public class Upravnik : Osoblje
   {
      public int Id { get; set; }

        public Upravnik(RadnoVreme radnoVreme, RadniStatus radniStatus, int id) : base(radnoVreme, radniStatus)
        {
            Id = id;
        }

    }
}