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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using Kontroler;

namespace Bolnica.view.lekar.lekovi
{
    /// <summary>
    /// Interaction logic for OdobravanjeLeka.xaml
    /// </summary>
    public partial class OdobravanjeLeka : Page
    {

        public LekoviKontroler lekoviKontrolerObjekat;
        private Lek lek;
        private Lekar lekar;
        private RevizijaLeka revizija;
        public OdobravanjeLeka(Lek lek, Lekar lekar)
        {
            InitializeComponent();
            lekoviKontrolerObjekat = new LekoviKontroler();
            this.lek = lek;
            this.lekar = lekar;
            RevizijaLeka tempRevizija = lek.GetRevizijaLekaByIdLekara(lekar.Id);
            revizija = new RevizijaLeka(tempRevizija.IdLekara, tempRevizija.StatusRevizije, tempRevizija.Poruka);

        }

        private void Potvrdi_click(object sender, RoutedEventArgs e)
        {
            // revizija.
            MessageBox.Show("odobravanje");

            revizija.StatusRevizije = 1;
            lekoviKontrolerObjekat.LekarOdobravaLek(lek.Id, revizija);

            if (this.lekar != null)
            {
                var lekoviPage = new Lekovi(lekar);
                NavigationService.Navigate(lekoviPage);
            }
        }
    }
}
