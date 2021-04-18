/***********************************************************************
 * Module:  Sekretar.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Sekretar.Sekretar
 ***********************************************************************/

using System;

namespace Model
{
   public class Sekretar : Osoblje
   {
      public int Id { get; set; }

        public Sekretar(RadnoVreme radnoVreme, RadniStatus radniStatus,int id):base(radnoVreme,radniStatus)
        {
            Id = id;
        }
    }
}