using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model;

namespace Servis
{
    class InventariSerivs
    {

        public Repozitorijum.InventariRepozitorijum InventarRepozitorijumRef { get; set; }

        public InventariSerivs()
        {
            InventarRepozitorijumRef = Repozitorijum.InventariRepozitorijum.GetInstance;
        }

        public List<Inventar> GetAllInventar()
        {
            return InventarRepozitorijumRef.GetAll();
        }

        public Inventar GetInventarById(int id)
        {
            List<Inventar> li = GetAllInventar();
            foreach(Inventar inv in li)
            {
                if(inv.Id == id)
                {
                    return inv;
                }
            }
            return null;
        }

        public ObservableCollection<Oprema> GetTipOpremeByIdInventaraObservable(int id, TipOpreme tipOpreme)
        {
            Inventar inv = GetInventarById(id);         // ako ne nadje inventar baca null pa tu puca program
            if(inv == null)
            {
                MessageBox.Show("Nije pronadjen trazeni invetnar/magacin");
                return new ObservableCollection<Oprema>();
            }
            List<Oprema> oprema = inv.GetOpremaByTip(tipOpreme);

            ObservableCollection<Oprema> obsOP = new ObservableCollection<Oprema>();
            foreach (Oprema op in oprema)
            {
                obsOP.Add(op);
            }

            return obsOP;
        }


        public Oprema DodajOpremuUInventarById(int idInventara,
                                            TipOpreme tipOpreme,
                                            string naziv,
                                            string sifra,
                                            int kolicina,
                                            double cena,
                                            string opis)
        {
            Inventar inv = GetInventarById(idInventara);
            if(inv == null)
            {
                MessageBox.Show("Ne postoji inventar sa tim ID");
                return null;
            }
            Oprema oprema = new Oprema(-1, sifra, naziv, tipOpreme, opis, kolicina, cena, inv.Id);
            inv.LOprema.Add(oprema);
            InventarRepozitorijumRef.AzurirajInventar(inv);
            return oprema;
        }

        /*
         * parametar skroz nam sluzi ako zelimo obrisati neku opremu na nivou celog sistema
         * */
        public Oprema ObrisiOpremuInvetara(int idInventara, Oprema oprema, bool skroz)
        {
            Inventar inv = GetInventarById(idInventara);
            if(inv == null)
            {
                MessageBox.Show("Ne postoji inventar sa tim ID");
                return null;
            }

            if (!skroz)
            {
                inv.ObrisiOpremuBySifra(oprema.Sifra);
                InventarRepozitorijumRef.AzurirajInventar(inv);
            }
            else
            {
                // brisanje na nivou celog sistema
                foreach(Inventar inventar in GetAllInventar())
                {
                    inventar.ObrisiOpremuBySifra(oprema.Sifra);
                }
                InventarRepozitorijumRef.AzurirajInventar();
            }


            
            return oprema;
        }



    }
}
