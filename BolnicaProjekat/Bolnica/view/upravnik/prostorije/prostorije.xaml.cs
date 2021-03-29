using System;
using System.Collections;
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

namespace Bolnica.view.upravnik.prostorije
{
    /// <summary>
    /// Interaction logic for prostorije.xaml
    /// </summary>
    public partial class Prostorije : Page
    {

        //public List<Model.Prostorija> Prostorijee { get; set; }
        //public ArrayList Prostorijee { get; set; }
        public ObservableCollection<Model.Prostorija> KolekcijaProstorija { get; set; }

        public Prostorije()
        {
            /*
            Prostorijee = new List<Model.Prostorija>(Model.Bolnica.GetInstance().GetBrojProstorija());
            foreach(Model.Prostorija p in Model.Bolnica.GetInstance().GetProstorije())
            {
                Prostorijee.Add(p);
            }
            */
            //KolekcijaProstorija = dajMiListu();
            KolekcijaProstorija = Model.Bolnica.GetInstance.GetProstorije();
            //Prostorijee = Model.Bolnica.GetInstance().GetProstorije();
            InitializeComponent();
            //this.DataGridPrikazProstorija.ItemsSource = KolekcijaProstorija;
            this.DataGridPrikazProstorija.ItemsSource = KolekcijaProstorija;
        }

        private ObservableCollection<Model.Prostorija> dajMiListu()
        {
            ObservableCollection<Model.Prostorija> retVal = new ObservableCollection<Model.Prostorija>();
            foreach (Model.Prostorija p in Model.Bolnica.GetInstance.GetProstorije())
            {
                retVal.Add(p);
            }
            return retVal;
        }

        private void Izmeni_Prostoriju(object sender, RoutedEventArgs e)
        {
            Model.Prostorija pro = DataGridPrikazProstorija.SelectedItem as Model.Prostorija;
            if (pro == null) return;

            var dodajProstorijuForma = new Bolnica.view.upravnik.prostorije.DodajProstorijuForma(pro);
            dodajProstorijuForma.Show();

            DataGridPrikazProstorija.Items.Refresh();
        }

        private void Dodaj_Prostoriju(object sender, RoutedEventArgs e)
        {
            Model.Prostorija novaProstorija = new Model.Prostorija(-1, -1, -1, -1);
            var dodajProstorijuForma = new Bolnica.view.upravnik.prostorije.DodajProstorijuForma();
            dodajProstorijuForma.Show();
        }


        private void Obrisi_Prostoriju(object sender, RoutedEventArgs e)
        {
            
            Model.Prostorija pro = DataGridPrikazProstorija.SelectedItem as Model.Prostorija;
            if(pro != null)
            {
                //Model.Bolnica.GetInstance.RemoveProstorijeByID(pro.Id);
                Model.Bolnica.GetInstance.RemoveProstorije(pro);
            }
            
            /* 
            var selektovanaProstorija = DataGridPrikazProstorija.SelectedItem;
            if (selektovanaProstorija != null)
            {
                KolekcijaProstorija.Remove((Model.Prostorija)selektovanaProstorija);
            }
            */
           


            
        }
    }
}
