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
            foreach (Inventar inv in li)
            {
                if (inv.Id == id)
                {
                    return inv;
                }
            }
            return null;
        }

        public ObservableCollection<Oprema> GetTipOpremeByIdInventaraObservable(int id, TipOpreme tipOpreme)
        {
            Inventar inv = GetInventarById(id);         // ako ne nadje inventar baca null pa tu puca program
            if (inv == null)
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
            if (inv == null)
            {
                MessageBox.Show("Ne postoji inventar sa tim ID");
                return null;
            }
            Oprema oprema = new Oprema(-1, sifra, naziv, tipOpreme, opis, kolicina, cena, inv.Id);
            inv.LOprema.Add(oprema);
            InventarRepozitorijumRef.AzurirajInventar(inv);
            return oprema;
        }



        public Oprema IzmeniOpremuUInventarById(int idInventara,
                                                Oprema editOprema,
                                                string naziv,
                                                string sifra,
                                                int kolicina,
                                                double cena,
                                                string opis)
        {
            Inventar inv = GetInventarById(idInventara);
            if (inv == null)
            {
                MessageBox.Show("Ne postoji inventar sa tim ID");
                return null;
            }
            editOprema.Naziv = naziv;
            editOprema.Sifra = sifra;
            editOprema.Cena = cena;
            editOprema.Kolicina = kolicina;
            editOprema.Opis = opis;

            InventarRepozitorijumRef.AzurirajInventar(inv);
            return editOprema;
        }

        /*
         * parametar skroz nam sluzi ako zelimo obrisati neku opremu na nivou celog sistema
         * */
        public Oprema ObrisiOpremuInvetara(int idInventara, Oprema oprema, bool skroz)
        {
            Inventar inv = GetInventarById(idInventara);
            if (inv == null)
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
                foreach (Inventar inventar in GetAllInventar())
                {
                    inventar.ObrisiOpremuBySifra(oprema.Sifra);
                }
                InventarRepozitorijumRef.AzurirajInventar();
            }



            return oprema;
        }


        public Oprema preraspodelaOpreme(int idInventar1, int idInventar2, Oprema oprema, int kolicina)
        {
            Inventar inv1 = GetInventarById(idInventar1);
            Inventar inv2 = GetInventarById(idInventar2);

            if(inv1 == null || inv2 == null)
            {
                MessageBox.Show("Inventari su null u servisu metodi preraspodleaOpreme()");
                return null;
            }

            inv1.oduzmiOpremu(oprema, kolicina);
            inv2.dodajOpremu(oprema, kolicina);
            InventarRepozitorijumRef.AzurirajInventar();
            return oprema;
        }

        public bool preraspodelaOpreme(int idInventar1, int idInventar2, string sifraOprema, int kolicina)
        {
            Inventar inv1 = GetInventarById(idInventar1);
            Inventar inv2 = GetInventarById(idInventar2);

            if (inv1 == null || inv2 == null)
            {
                MessageBox.Show("Inventari su null u servisu metodi preraspodleaOpreme()");
                return false;
            }

            Oprema oprema = inv1.oduzmiOpremu(sifraOprema, kolicina);
            if (oprema == null) return false;
            inv2.dodajOpremu(oprema, kolicina);
            InventarRepozitorijumRef.AzurirajInventar();
            return true;
        }

        public bool preraspodelaOpreme(TransferOpreme transferOpreme)
        {
            return preraspodelaOpreme(transferOpreme.IdInventar1, transferOpreme.IdInventar2, transferOpreme.SifraOpreme, transferOpreme.KolicinaOpreme);
        }


    }
}
