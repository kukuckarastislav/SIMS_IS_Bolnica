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
using System.Windows.Shapes;

namespace Bolnica.view.lekar.pacijenti
{
    /// <summary>
    /// Interaction logic for KreiranjePregledaForma.xaml
    /// </summary>
    public partial class KreiranjePregledaForma : Window
    {
        public ObservableCollection<Model.SobaZaPreglede> KolekcijaSobeZaPregled { get; set; }
        public ObservableCollection<String> KolekcijaIDSobeZaPregled{ get; set; }

        //public Model.Pregled KreiranPregled { get; set; }

        private Model.Pacijent izabraniPacijent;

        public KreiranjePregledaForma(Model.Pacijent izabraniPacijent)
        {
            this.izabraniPacijent = izabraniPacijent;
           // KolekcijaSobeZaPregled = Model.Bolnica.GetInstance.GetSobeZaPreglede();
            KolekcijaIDSobeZaPregled = new ObservableCollection<String>();
            foreach(Model.SobaZaPreglede s in KolekcijaSobeZaPregled)
            {
                KolekcijaIDSobeZaPregled.Add(s.Id.ToString());
            }

            InitializeComponent();
            this.ComboBoxSobeZaPregled.ItemsSource = KolekcijaIDSobeZaPregled;

        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;
            if (calendar.SelectedDate.HasValue)
            {
                DateTime date = calendar.SelectedDate.Value;
                this.Title = date.ToShortDateString();
                MessageBox.Show(date.ToString());
            }
        }

        private void PotvrdiButton(object sender, RoutedEventArgs e)
        {
            DateTime pocetak = PocetakTermina.SelectedDate.Value;
            DateTime kraj = pocetak.Add(new TimeSpan(0,30,0,0));
            /*
                        Termin termin, string tipPregleda, string rezultatPregleda, string nazivZdrastveneUstanove, 
                            string lokacijaZdravsteveUstanove, string idLekara, string zakazivacUsluge, bool obavljena,
                            string id,string komentar, SobaZaPreglede sobaZaPregled) : base(nazivZdrastveneUstanove,
                                lokacijaZdravsteveUstanove, idLekara, zakazivacUsluge, obavljena, id, komentar)


            */

            // ComboBoxSobeZaPregled.SelectedItem as Model.SobaZaPreglede
            //Model.SobaZaPreglede soba = new Model.SobaZaPreglede(200, 2, 1130, 1997);
            int id = Convert.ToInt32(ComboBoxSobeZaPregled.SelectedItem.ToString());

            //KreiranPregled = new Model.Pregled(new Model.Termin(pocetak, kraj), inputTipPregleda.Text, "", 
              //                          "Zdravo Bolnica", "Novi Sad",Model.Bolnica.GetInstance.getLekarByI(1),"",false,inputIDPregleda.Text,"",Model.Bolnica.GetInstance.GetSobaZaPregledeByID(id));

            //izabraniPacijent.MedicinskiKarton.AddPregled(KreiranPregled);
            this.Close();

        }

        private void CloseWin(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
