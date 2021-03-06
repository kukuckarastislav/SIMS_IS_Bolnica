using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Model;
using Kontroler;
using System.Collections.ObjectModel;

namespace Bolnica.view.upravnik.Inventari
{
    /// <summary>
    /// Interaction logic for PreraspodelaStatickeInventara.xaml
    /// </summary>
    public partial class PreraspodelaStatickeInventara : Window
    {

        private int smerTransfera = 0;  // 0 - magacin u invetar; 1 - inventar u magacin
        private Inventar inventar1;
        private Inventar inventar2;
        private Prostorija prostorija1;
        private Prostorija prostorija2;
        private Magacin.PrikazStaticke refPrikazStaticke = null;
        private Magacin.PrikazStaticke prikazStatickeInventar1 = null;
        private Magacin.PrikazStaticke prikazStatickeInventar2 = null;
        private TerminProstorije terminProstorije;

        public ObservableCollection<TransferOpreme> lTransferOpreme { get; set; }


        private InventariKontroler inventariKontroler;
        private ProstorijeKontroler prostorijeKontroler;
        private TerminProstorijeKontroler terminProstorijeKontrolerObjekat;

        public PreraspodelaStatickeInventara(TerminProstorije terminProstorije,
                                        Magacin.PrikazStaticke refPrikazStaticke,
                                        Prostorija prostorija1,
                                        Prostorija prostorija2)
        {
            InitializeComponent();
            this.terminProstorije = terminProstorije;
            this.inventariKontroler = new InventariKontroler();
            this.prostorijeKontroler = new ProstorijeKontroler();
            this.terminProstorijeKontrolerObjekat = new TerminProstorijeKontroler();
            this.refPrikazStaticke = refPrikazStaticke;
            this.prostorija1 = prostorija1;
            this.prostorija2 = prostorija2;
            this.lTransferOpreme = terminProstorijeKontrolerObjekat.GetTransferOpremeObservebleByTerminProstorije(terminProstorije);
            DataGridPrikazTransfera.ItemsSource = lTransferOpreme;
            this.inventar1 = inventariKontroler.GetInventarById(prostorija1.IdInventar);
            prikazStatickeInventar1 = new Magacin.PrikazStaticke(prostorija1.IdInventar, txt_naziv_opreme, false);
            lblProstorija1.Text = "Prostorija " + prostorija1.BrojSprat;
            if (prostorija2 != null)
            {
                // prostorija
                this.inventar2 = inventariKontroler.GetInventarById(prostorija2.IdInventar);
                prikazStatickeInventar2 = new Magacin.PrikazStaticke(prostorija2.IdInventar, txt_naziv_opreme, false);
                lblProstorija2.Text = "Prostorija " + prostorija2.BrojSprat;
            }
            else
            {
                // magacin
                this.inventar2 = inventariKontroler.GetInventarById(0);
                prikazStatickeInventar2 = new Magacin.PrikazStaticke(0, txt_naziv_opreme, false);
                lblProstorija2.Text = "Magacin";
            }

            PovrsinaPrikazInvetar1.Content = prikazStatickeInventar1;
            PovrsinaPrikazInvetar2.Content = prikazStatickeInventar2;

        }

        private void btn_smer_transfera_Click(object sender, RoutedEventArgs e)
        {
            smerTransfera = (smerTransfera != 0) ? 0 : 1;
            if (smerTransfera == 0)
            {
                btn_smer_transfera.Content = "-->";
            }
            else
            {
                btn_smer_transfera.Content = "<--";
            }
            txt_naziv_opreme.Text = "Oprema";
        }

        private void btn_prebaci_Click(object sender, RoutedEventArgs e)
        {

            Oprema oprema = null;
            if (smerTransfera == 0)
            {
                // 1 -> 2
                oprema = prikazStatickeInventar1.GetSelectedOprema();
            }
            else if (smerTransfera == 1)
            {
                // 2 -> 1
                oprema = prikazStatickeInventar2.GetSelectedOprema();
            }


            if (oprema == null) return; // neka greska

            int kolicina = Convert.ToInt32(txtBox_kolicina.Text);
            if (kolicina > oprema.Kolicina)
            {
                MessageBox.Show("Uneta kolicina " + kolicina + " nadmasuje aktualnu kolicinu " + oprema.Kolicina);
                txtBox_kolicina.Text = Convert.ToString(oprema.Kolicina);
                return;
            }

            if (smerTransfera == 0)
            {
                // 1 -> 2
                //inventariKontroler.preraspodelaOpreme(inventar1.Id, inventar2.Id, oprema, kolicina);
                if(prostorija2 == null)
                {
                    terminProstorijeKontrolerObjekat.DodajTrensferZaTerminProstorije(terminProstorije, 
                        new TransferOpreme(prostorija1.BrojSprat, "Magacin", prostorija1.IdInventar, 0, oprema.Sifra, kolicina));
                }
                else
                {
                    terminProstorijeKontrolerObjekat.DodajTrensferZaTerminProstorije(terminProstorije, 
                        new TransferOpreme(prostorija1.BrojSprat, prostorija2.BrojSprat, prostorija1.IdInventar, prostorija2.IdInventar, oprema.Sifra, kolicina));
                }
                
            }
            else if (smerTransfera == 1)
            {
                // 2 -> 1
                //inventariKontroler.preraspodelaOpreme(inventar2.Id, inventar1.Id, oprema, kolicina);
                if (prostorija2 == null)
                {
                    terminProstorijeKontrolerObjekat.DodajTrensferZaTerminProstorije(terminProstorije, 
                        new TransferOpreme("Magacin", prostorija1.BrojSprat, 0, prostorija1.IdInventar, oprema.Sifra, kolicina));
                }
                else
                {
                    terminProstorijeKontrolerObjekat.DodajTrensferZaTerminProstorije(terminProstorije, 
                        new TransferOpreme(prostorija2.BrojSprat, prostorija1.BrojSprat, prostorija2.IdInventar, prostorija1.IdInventar, oprema.Sifra, kolicina));
                }
            }

            terminProstorijeKontrolerObjekat.AzurirajTransferOpreme(terminProstorije);
            azurirajListuTransfera();
            prikazStatickeInventar1.azurirajPrikaz();
            prikazStatickeInventar2.azurirajPrikaz();
            

        }

        public void azurirajListuTransfera()
        {
            this.lTransferOpreme = terminProstorijeKontrolerObjekat.GetTransferOpremeObservebleByTerminProstorije(terminProstorije);
            DataGridPrikazTransfera.ItemsSource = lTransferOpreme;
        }

        private void Button_Click_zavrsi(object sender, RoutedEventArgs e)
        {
            if (refPrikazStaticke != null) refPrikazStaticke.azurirajPrikaz();
            this.Close();
        }
    }
}
