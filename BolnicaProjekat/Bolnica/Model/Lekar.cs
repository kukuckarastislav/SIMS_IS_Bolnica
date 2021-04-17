/***********************************************************************
 * Module:  OpstiLekar.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Lekar.OpstiLekar
 ***********************************************************************/

using System;

namespace Model
{
   public class Lekar : Osoblje
   {
      public int Id { get; set; }
        public Boolean Specijalista { get; set; }
        public string Specijalizacija { get; set; }

    }
}