using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;

namespace Factory
{
    public class BazaFactory
    {
        public static IBaza GetBaza(string nazivBaze)
        {
            IBaza baza = null;

            if(nazivBaze == "JSON")
            {
                baza = new JSONBaza();
            }else if(nazivBaze == "SQL")
            {
                // Sql baza
            }
            else
            {
                baza = new JSONBaza();
            }

            return baza;
        }
    }
}
