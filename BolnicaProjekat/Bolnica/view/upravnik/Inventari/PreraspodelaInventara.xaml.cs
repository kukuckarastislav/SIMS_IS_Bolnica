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

namespace Bolnica.view.upravnik.Inventari
{
    /// <summary>
    /// Interaction logic for PreraspodelaInventara.xaml
    /// </summary>
    public partial class PreraspodelaInventara : Window
    {

        private int smerTransfera = 0;  // 0 - magacin u invetar; 1 - inventar u magacin
        private TipOpreme tipOpreme;
        private Inventar inventar1;
        private Inventar inventar2;
        private int idInventar1;
        private int idInventar2;
        private Prostorija prostorija1;
        private Prostorija prostorija2;
        private Magacin.PrikazStaticke refPrikazStaticke = null;
        private Magacin.PrikazStaticke prikazStatickeInventar1 = null;
        private Magacin.PrikazStaticke prikazStatickeInventar2 = null;

        private Magacin.PrikazDinamicke refPrikazDinamicke = null;
        private Magacin.PrikazDinamicke prikazDinamickeInventar1 = null;
        private Magacin.PrikazDinamicke prikazDinamickeInventar2 = null;





        private InventariKontroler inventariKontroler;
        private ProstorijeKontroler prostorijeKontroler;

        public PreraspodelaInventara(Magacin.PrikazStaticke refPrikazStaticke,
                                      Magacin.PrikazDinamicke refPrikazDinamicke,
                                      TipOpreme tipOpreme,
                                      int idInventar1,
                                      int idInventar2)
        {
            this.idInventar1 = idInventar1;
            this.idInventar2 = idInventar2;
            this.inventariKontroler = new InventariKontroler();
            this.prostorijeKontroler = new ProstorijeKontroler();
            this.refPrikazStaticke = refPrikazStaticke;
            this.refPrikazDinamicke = refPrikazDinamicke;
            this.tipOpreme = tipOpreme;
            this.inventar1 = inventariKontroler.GetInventarById(idInventar1);
            this.inventar2 = inventariKontroler.GetInventarById(idInventar2);

            if(inventar1 == null || inventar2 == null)
            {
                MessageBox.Show("Greska inventari su == NULL");
            }
            InitializeComponent();
            prostorija1 = prostorijeKontroler.GetProstorijaById(inventar1.IdProstorije);
            prostorija2 = prostorijeKontroler.GetProstorijaById(inventar2.IdProstorije);
            if (prostorija2 == null)
            {
                MessageBox.Show("Greska prostorije su == NULL");
            }
            if (tipOpreme == TipOpreme.Staticka)
            {
                prikazStatickeInventar1 = new Magacin.PrikazStaticke(idInventar1, txt_naziv_opreme, false);
                prikazStatickeInventar2 = new Magacin.PrikazStaticke(idInventar2, txt_naziv_opreme, false);
                PovrsinaPrikazInvetar1.Content = prikazStatickeInventar1;
                PovrsinaPrikazInvetar2.Content = prikazStatickeInventar2;
            }
            else
            {
                prikazDinamickeInventar1 = new Magacin.PrikazDinamicke(idInventar1, txt_naziv_opreme, false);
                prikazDinamickeInventar2 = new Magacin.PrikazDinamicke(idInventar2, txt_naziv_opreme, false);
                PovrsinaPrikazInvetar1.Content = prikazDinamickeInventar1;
                PovrsinaPrikazInvetar2.Content = prikazDinamickeInventar2;
            }

            
            if (idInventar1 == 0) lblProstorija1.Text = "Magacin";
            else lblProstorija1.Text = "Prostorija " + prostorija1.BrojSprat;
            if (idInventar2 == 0) lblProstorija2.Text = "Magacin";
            else lblProstorija2.Text = "Prostorija " +  prostorija2.BrojSprat;
            

        }

        private void btn_smer_transfera_Click(object sender, RoutedEventArgs e)
        {
            smerTransfera = (smerTransfera != 0) ? 0:1;
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
            if(smerTransfera == 0)
            {
                // magacin -> inventar

            }else if(smerTransfera == 1)
            {
                // inventar -> magacin

            }
        }

        private void Button_Click_zavrsi(object sender, RoutedEventArgs e)
        {
            if (refPrikazStaticke != null) refPrikazStaticke.azurirajPrikaz();
            if (refPrikazDinamicke != null) refPrikazDinamicke.azurirajPrikaz();

            this.Close();
        }
    }
}
