using Model;
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

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for pregledi.xaml
    /// </summary>
    public partial class RaspoloziviPregledi : Window
    {

        public ObservableCollection<Model.Pregled> Pregledi { get; set; }
        public Pregled odabraniPregled;
        public List<Lekar> listaLekari { get; set; }

        public RaspoloziviPregledi()
        {
            InitializeComponent();
            Pregledi = Model.Bolnica.GetInstance.Pregledi;
            this.listaPregleda.
                ItemsSource = Pregledi;



            listaLekari = new List<Lekar>();
            listaLekari.Add(Model.Bolnica.GetInstance.getLekarByI(1));  //ovo naravno treba biti lista svih lekara
            this.ComboBoxLekari.ItemsSource = listaLekari;
        }

        private void zakazi_pregled(object sender, MouseButtonEventArgs e)
        {
            odabraniPregled = listaPregleda.SelectedItem as Pregled;
        }

        private void pregled_odabran(object sender, RoutedEventArgs e)
        {
            Model.Bolnica.GetInstance.GetPacijent("jmbg").ZakazivanjePregleda(odabraniPregled);
            Pregledi.Remove(odabraniPregled);
            Model.Bolnica.GetInstance.Pregledi.Remove(odabraniPregled);
        }

        private void datum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = datum.SelectedDate.Value;
            /*
            int pocetakSati = Convert.ToInt32(vrijeme_pocetak_sati.SelectedItem.ToString());
            int pocetakMinute = Convert.ToInt32(vrijeme_pocetak_minute.SelectedItem.ToString());
            string pocetakAP = vrijeme_pocetak_ap.SelectedItem.ToString();

            int krajSati = Convert.ToInt32(vrijeme_kraj_sati.SelectedItem.ToString());
            int krajkMinute = Convert.ToInt32(vrijeme_kraj_minute.SelectedItem.ToString());
            string krajkAP = vrijeme_kraj_ap.SelectedItem.ToString();

            if (pocetakAP.Equals("PM"))
            {
                pocetakSati += 12;
            }
            */

           // DateTime poc = new DateTime(date.Year, date.Month, date.Day, pocetakSati, pocetakMinute,00);
            DateTime poc = new DateTime(date.Year, date.Month, date.Day);

            MessageBox.Show(poc.ToString());


            //DateTime dtpocetak = DateTime.Parse();

        }
    }
}
