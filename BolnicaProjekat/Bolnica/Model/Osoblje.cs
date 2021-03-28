/***********************************************************************
 * Module:  Osoblje.cs
 * Author:  Milica
 * Purpose: Definition of the Class Osoblje
 ***********************************************************************/

using System;

namespace Model
{
   public abstract class Osoblje : Korisnik
   {
      public RadnoVreme radnoVreme;
   
      private RadniStatus RadniStatus;
   
   }
}