using System;
using Model;
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

namespace Bolnica.view.lekar
{
    /// <summary>
    /// Interaction logic for Notifikacije.xaml
    /// </summary>
    public partial class Notifikacije : Page
    {
        // BACK - PAGES
        // NEXT - PAGES
        // KORISNICI
        public Lekar Lekar;
        // KOLEKCIJE
        public ObservableCollection<Notifikacija> KolekcijaNotifikacija;

        public Notifikacije(Lekar Lekar)
        {
            this.Lekar = Lekar;
            InitializeComponent();
            KolekcijaNotifikacija = new ObservableCollection<Notifikacija>();
      //     KolekcijaNotifikacija = Repository.NotifikacijaRepozitorijum.GetInstance.GetByIdLekara(1);
            this.listaNotifikacija.ItemsSource = KolekcijaNotifikacija;
        }
    }
}
