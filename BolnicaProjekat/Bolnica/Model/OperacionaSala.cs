/***********************************************************************
 * Module:  OperacionaSala.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Upravnik.OperacionaSala
 ***********************************************************************/

using System;

namespace Model
{
    public class OperacionaSala : Prostorija
    {
        public OperacionaSala(int id, int sprat, double povrsina, int idInventara) : base(id, sprat, povrsina, idInventara)
        {

        }

        public OperacionaSala()
        {

        }
    }
}