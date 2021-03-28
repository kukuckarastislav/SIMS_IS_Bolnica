/***********************************************************************
 * Module:  ZdravstvenaUsluga.cs
 * Author:  lacik
 * Purpose: Definition of the Class ZdravstvenaUsluga
 ***********************************************************************/

using System;

namespace Model
{
   public abstract class ZdravstvenaUsluga
   {
      private string NazivZdrastveneUstanove;
      private string LokacijaZdravsteveUstanove;
      private int IdLekara;
      private Korisnik ZakazivacUsluge;
      private bool Obavljena;
      private DateTime DatumUsluge;
      private string Komentar;
   
   }
}