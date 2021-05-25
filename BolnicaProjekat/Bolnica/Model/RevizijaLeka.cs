using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RevizijaLeka
    {
        public RevizijaLeka(int idLekara, int statusRevizije, string poruka)
        {
            IdLekara = idLekara;
            StatusRevizije = statusRevizije;
            Poruka = poruka;
        }

        public int IdLekara { get; set; }
        public int StatusRevizije { get; set; }         // 0 na cekanju; -1 zabrana; 1 odobrio
        public string Poruka { get; set; }
    }
}
