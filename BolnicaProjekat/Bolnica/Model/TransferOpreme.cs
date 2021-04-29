using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TransferOpreme
    {
        public string BrojSpratProstorije1 { get; set; }
        public string BrojSpratProstorije2 { get; set; }    // ovde ce pisati Magacin ako je 
        public int IdInventar1 { get; set; }            // iz ovog inventara premestamo
        public int IdInventar2 { get; set; }            // u ovaj inventar
        public string SifraOpreme { get; set; }
        public int KolicinaOpreme { get; set; }

        public TransferOpreme(string brojSpratProstorije1, string brojSpratProstorije2, int idInventar1, int idInventar2, string sifraOpreme, int kolicinaOpreme)
        {
            BrojSpratProstorije1 = brojSpratProstorije1;
            BrojSpratProstorije2 = brojSpratProstorije2;
            IdInventar1 = idInventar1;
            IdInventar2 = idInventar2;
            SifraOpreme = sifraOpreme;
            KolicinaOpreme = kolicinaOpreme;
        }
    }
}
