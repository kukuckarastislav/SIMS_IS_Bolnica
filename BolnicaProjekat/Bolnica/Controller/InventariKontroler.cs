using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Servis;

namespace Kontroler
{
    class InventariKontroler
    {

        public InventariSerivs InventariSerivsObjekat { get; set; }

        public InventariKontroler()
        {
            InventariSerivsObjekat = new InventariSerivs();
        }

        public Oprema DodajOpremuUInventarById(int idInventara,
                                              TipOpreme tipOpreme, 
                                              string naziv,
                                              string sifra,
                                              int kolicina,
                                              double cena,
                                              string opis)
        {


            return InventariSerivsObjekat.DodajOpremuUInventarById(idInventara ,tipOpreme, naziv, sifra, kolicina, cena, opis);
        }

        public Oprema ObrisiOpremuInvetara(int idInventara, Oprema oprema, bool skroz)
        {
            return InventariSerivsObjekat.ObrisiOpremuInvetara(idInventara, oprema, skroz);
        }

        public ObservableCollection<Oprema> GetTipOpremeByIdInventaraObservable(int id, TipOpreme tipOpreme)
        {
            return InventariSerivsObjekat.GetTipOpremeByIdInventaraObservable(id, tipOpreme);
        }

    }
}
