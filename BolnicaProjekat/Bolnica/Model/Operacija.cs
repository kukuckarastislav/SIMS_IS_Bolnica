/***********************************************************************
 * Module:  Operacija.cs
 * Author:  Milica
 * Purpose: Definition of the Class Operacija
 ***********************************************************************/

using System;

namespace Model
{
   public class Operacija : ZdravstvenaUsluga
   {
      public Termin termin;
      public Racun racun;
   
      private string TipOperacije;
      private string RezultatOperacije;
      private OperacionaSala OperacionaSala;
   
   }
}