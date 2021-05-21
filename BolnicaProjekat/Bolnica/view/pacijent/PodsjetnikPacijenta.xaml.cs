using System.Collections.ObjectModel;
using System.Windows;
using Model;
using Kontroler;

namespace Bolnica.view.pacijent
{

    public partial class PodsjetnikPacijenta : Window
    {
        public Pacijent Pacijent;
        public ObservableCollection<Podsjetnik> Lista { get; set; }
        private PodsjetnikKontroler Kontroler;
        public PodsjetnikPacijenta(Pacijent Pacijent)
        {
            Kontroler = new PodsjetnikKontroler();
            this.Pacijent = Pacijent;
            InitializeComponent();
            Kontroler.AzurirajStanjePosleCitanja(Pacijent.Id);
            Lista = Kontroler.GetPodsjetnikPacijenta(Pacijent.Id);
            this.listaPodsjetnik.ItemsSource = Lista;
        }

        private void dodaj_podsjetnik(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.NoviPodsjetnik(Pacijent,"");
            varr.Show();
        }
    }
}
