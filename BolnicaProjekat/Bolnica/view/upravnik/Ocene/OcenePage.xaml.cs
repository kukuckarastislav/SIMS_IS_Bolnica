using DTO;
using Kontroler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Bolnica.view.upravnik.Ocene
{
    /// <summary>
    /// Interaction logic for OcenePage.xaml
    /// </summary>
    public partial class OcenePage : Page
    {

        public ObservableCollection<LekarRevizijaLekaDTO> KolekcijaLekaraCombo;
        public LekarKontroler lekarKontrolerObjekat;
        private Controller.AnketaKontroler AnketaKontrolerObjekat;

        public ObservableCollection<OcenaDTO> KolekcijaOcena { get; set; }
        public OcenePage()
        {
            InitializeComponent();

            lekarKontrolerObjekat = new LekarKontroler();
            KolekcijaLekaraCombo = lekarKontrolerObjekat.GetLekariDTOzaComboBox();
            ComboLekar.ItemsSource = KolekcijaLekaraCombo;

            AnketaKontrolerObjekat = new Controller.AnketaKontroler();
            KolekcijaOcena = AnketaKontrolerObjekat.GetSveOceneLekara();
            DataGridOcene.ItemsSource = KolekcijaOcena;
        }

        private void comboLekar_DropDownClosed(object sender, EventArgs e)
        {
            // setuj ocene za ovog lekara
            LekarRevizijaLekaDTO lekar = (LekarRevizijaLekaDTO)ComboLekar.SelectedItem;
            if(lekar != null)
            {
                KolekcijaOcena = AnketaKontrolerObjekat.GetOceneOdabranogLekara(lekar.IdLekara);
                DataGridOcene.ItemsSource = KolekcijaOcena;

                double prosecnaOcena = 0.0;
                if (KolekcijaOcena.Count > 0)
                {
                    foreach (OcenaDTO ocena in KolekcijaOcena)
                    {
                        prosecnaOcena += ocena.Vrednost;
                    }
                    prosecnaOcena = prosecnaOcena / KolekcijaOcena.Count;
                }
                txtProsecnaOcena.Text = Convert.ToString(prosecnaOcena);
            }
        }
    }
}
