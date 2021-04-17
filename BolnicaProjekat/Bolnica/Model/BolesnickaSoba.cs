/***********************************************************************
 * Module:  BolesnickaSoba.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Upravnik.BolesnickaSoba
 ***********************************************************************/

using System;
using System.Collections.Generic;


namespace Model
{
   public class BolesnickaSoba : Prostorija
   {
      public int BrojKreveta { get; set; }
      public int BrojSlobodnihKreveta { get; set; }

    }
}