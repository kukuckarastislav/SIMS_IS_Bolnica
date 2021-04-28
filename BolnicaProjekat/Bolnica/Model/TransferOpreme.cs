using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TransferOpreme
    {
        public int IdInventar1 { get; set; }            // iz ovog inventara premestamo
        public int IdInventar2 { get; set; }            // u ovaj inventar
        public string SifraOpreme { get; set; }
        public int KolicinaOpreme { get; set; }

        public TransferOpreme(int idInventar1, int idInventar2, string sifraOpreme, int kolicinaOpreme)
        {
            IdInventar1 = idInventar1;
            IdInventar2 = idInventar2;
            SifraOpreme = sifraOpreme;
            KolicinaOpreme = kolicinaOpreme;
        }
    }
}
