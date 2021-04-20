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
using Kontroler;
using Model;

namespace Bolnica.view.upravnik.Magacin
{
    /// <summary>
    /// Interaction logic for DodajOpremuUMagForma.xaml
    /// </summary>
    public partial class DodajOpremuUMagForma : Window
    {

        private InventariKontroler InventarKontrolerObjekat { get; set; }
        private PrikazStaticke prikazStaticke = null;
        private PrikazDinamicke prikazDinamicke = null;
        private TipOpreme tipOpreme;
        private Oprema editOprema;

        public DodajOpremuUMagForma(PrikazStaticke prikazStaticke,
                                    PrikazDinamicke prikazDinamicke,
                                    TipOpreme tipOpreme)
        {
            InventarKontrolerObjekat = new InventariKontroler();
            this.prikazStaticke = prikazStaticke;
            this.prikazDinamicke = prikazDinamicke;
            this.tipOpreme = tipOpreme;
            editOprema = null;
            InitializeComponent();

            inputTip.Text = (tipOpreme == TipOpreme.Staticka) ? "Staticka" : "Dinamicka";


        }
        public DodajOpremuUMagForma(PrikazStaticke prikazStaticke,
                            PrikazDinamicke prikazDinamicke,
                            Oprema editOprema)
        {
            InventarKontrolerObjekat = new InventariKontroler();
            this.prikazStaticke = prikazStaticke;
            this.prikazDinamicke = prikazDinamicke;
            this.editOprema = editOprema;
            InitializeComponent();

            if (editOprema == null)
            {
                MessageBox.Show("editOprema je null!");
            }

            inputTip.Text = (tipOpreme == TipOpreme.Staticka) ? "Staticka" : "Dinamicka";
            inputCena.Text = Convert.ToString(editOprema.Cena);
            inputNaziv.Text = Convert.ToString(editOprema.Naziv);
            inputSifra.Text = Convert.ToString(editOprema.Sifra);
            inputKolicina.Text = Convert.ToString(editOprema.Kolicina);
            inputOpis.Text = Convert.ToString(editOprema.Opis);

        }

        private void close_win(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void Potvrdi_btn(object sender, RoutedEventArgs e)
        {
            if (editOprema == null)
            {
                // dodajemo novi
                InventarKontrolerObjekat.DodajOpremuUInventarById(0,  // magacin 
                                                                 tipOpreme,
                                                                 Convert.ToString(inputNaziv.Text),
                                                                 Convert.ToString(inputSifra.Text),
                                                                 Convert.ToInt32(inputKolicina.Text),
                                                                 Convert.ToDouble(inputCena.Text),
                                                                 Convert.ToString(inputOpis.Text));


            }
            else
            {
                // menjamo postojeci
                InventarKontrolerObjekat.IzmeniOpremuUInventarById(0,  // magacin 
                                                                 editOprema,
                                                                 Convert.ToString(inputNaziv.Text),
                                                                 Convert.ToString(inputSifra.Text),
                                                                 Convert.ToInt32(inputKolicina.Text),
                                                                 Convert.ToDouble(inputCena.Text),
                                                                 Convert.ToString(inputOpis.Text));

            }

            // azuriranje prikaza onog sto su nam poslali
            if (prikazStaticke != null) prikazStaticke.azurirajPrikaz();
            if (prikazDinamicke != null) prikazDinamicke.azurirajPrikaz();

            this.Close();
        }
    }
}
