using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace DTO
{


    class OpremaDTO
    {
        public Oprema Oprema { get; set; }
        public string BrojSpratProstorije { get; set; }
        public string TipOpreme { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public TipOpreme Tip { get; set; }
        public string Opis { get; set; }
        public int Kolicina { get; set; }
        public double Cena { get; set; }

        public OpremaDTO(Oprema oprema, string brojSpratProstorije)
        {
            Oprema = oprema;
            BrojSpratProstorije = brojSpratProstorije;
            
            Sifra = Oprema.Sifra;
            Naziv = Oprema.Naziv;
            Tip = Oprema.Tip;
            Opis = Oprema.Opis;
            Kolicina = Oprema.Kolicina;
            Cena = Oprema.Cena;
            TipOpreme = ((Oprema.Tip == Model.TipOpreme.Staticka)?"Staticka":"Dinamicka");
            
        }
    }
}
