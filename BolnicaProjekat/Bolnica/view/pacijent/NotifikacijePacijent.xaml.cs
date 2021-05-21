using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Model;

namespace Bolnica.view.pacijent
{
    public partial class NotifikacijePacijent : Window
    {
        private ObservableCollection<Notifikacija> Notifikacije;
        private Notifikacija KliknutaNotifijacija;
        private Controller.NotifikacijaKontroler Kontroler;

        public NotifikacijePacijent()
        {

            Kontroler = new Controller.NotifikacijaKontroler();
            Notifikacije = Kontroler.GetNotifikacijePacijenta(1);

            InitializeComponent();
            this.listaNotifikacija.ItemsSource = Notifikacije;
        }

        private void kliknuta_notifikacija(object sender, MouseButtonEventArgs e)
        {
            KliknutaNotifijacija = listaNotifikacija.SelectedItem as Notifikacija;
            if (KliknutaNotifijacija.Id == 0) //sve notifikacije o anketi bolnice ce imati id 0
            {
                var varr = new view.pacijent.AnketaBolnica(1);
                varr.Show();
            }

        }

        private void obrisi_notifikaciju(object sender, RoutedEventArgs e)
        {
            KliknutaNotifijacija = listaNotifikacija.SelectedItem as Notifikacija;
            Kontroler.ObrisiNotifikaciju(1, KliknutaNotifijacija.Id);
        }
    }
}
