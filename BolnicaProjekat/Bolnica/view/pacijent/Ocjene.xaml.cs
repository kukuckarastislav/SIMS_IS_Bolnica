using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using DTO;


namespace Bolnica.view.pacijent
{

    public partial class Ocjene : Window
    {
        private PacijentDTO Pacijent;
        private ObservableCollection<OcenaDTO> KolekcijaOcjene;
        private Controller.AnketaKontroler Kontroler;
        private ObservableCollection<LekarDTO> listaLekari;

        public Ocjene(PacijentDTO Pacijent)
        {
            Kontroler = new Controller.AnketaKontroler();
            this.Pacijent = Pacijent;
            InitializeComponent();

            KolekcijaOcjene = KonvertujUKolekciju(Kontroler.GetSveOceneLekara());
            this.listaOcjena.ItemsSource = KolekcijaOcjene;

            Kontroler.LekarKontroler k = new Kontroler.LekarKontroler();
            listaLekari = k.getAllNeobrisaniLekari();
            this.ComboBoxLekari.ItemsSource = listaLekari;
        }

        private ObservableCollection<OcenaDTO> KonvertujUKolekciju(List<OcenaDTO> lista)
        {
            ObservableCollection<OcenaDTO> ret = new ObservableCollection<OcenaDTO>();
            foreach (OcenaDTO o in lista) ret.Add(o);
            return ret;
        }

        private void prikazi_ocene_lekara(object sender, RoutedEventArgs e)
        {
            LekarDTO OdabraniLekar = ComboBoxLekari.SelectedItem as LekarDTO;

            if (OdabraniLekar != null)
            {
                KolekcijaOcjene = KonvertujUKolekciju(Kontroler.GetOceneOdabranogLekara(OdabraniLekar.Id));
                this.listaOcjena.ItemsSource = KolekcijaOcjene;
            }
            else
            {
                MessageBox.Show("Niste odabrali lekara");
            }
        }

        private void MenuItem_Click_ocene_lekara(object sender, RoutedEventArgs e)
        {
            KolekcijaOcjene = KonvertujUKolekciju(Kontroler.GetSveOceneLekara());
            this.listaOcjena.ItemsSource = KolekcijaOcjene;
        }

        private void MenuItem_Click_ocene_bolnice(object sender, RoutedEventArgs e)
        {
            KolekcijaOcjene = KonvertujUKolekciju(Kontroler.GetSveOceneBolnice());
            this.listaOcjena.ItemsSource = KolekcijaOcjene;
        }

        private void MenuItem_Click_moje_ocene(object sender, RoutedEventArgs e)
        {
            KolekcijaOcjene = KonvertujUKolekciju(Kontroler.GetSveOcenePacijenta(Pacijent.Id));
            this.listaOcjena.ItemsSource = KolekcijaOcjene;
        }
    }
}
