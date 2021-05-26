using System.Windows;
using System.Windows.Controls;
using DTO;
using System.Collections.ObjectModel;
using Controller;

namespace Bolnica.view.pacijent
{
    public partial class IstorijaBolesti : Window
    {
        private ObservableCollection<ZdravstvenaUslugaDTO> Lista;
        private ZdravstvenaUslugaKontroler Kontroler;
        private ZdravstvenaUslugaDTO OdabranaUsluga;
        private PacijentDTO Pacijent;

        public IstorijaBolesti(PacijentDTO Pacijent)
        {
            Kontroler = new ZdravstvenaUslugaKontroler();
            this.Pacijent = Pacijent;
            InitializeComponent();
            Lista = Kontroler.GetProsliTerminiPacijenta(Pacijent.Id);
            this.listaZavrseniTermini.ItemsSource = Lista;
        }

        private void listaZavrseniTermini_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OdabranaUsluga = listaZavrseniTermini.SelectedItem as ZdravstvenaUslugaDTO;
            anamneza.Text = OdabranaUsluga.RezultatUsluge;
            sadrzaj.Text = OdabranaUsluga.Komentar;
        }

        private void dodaj_podsjetnik(object sender, RoutedEventArgs e)
        {
            Kontroler.DodajKomentarNaUslugu(OdabranaUsluga.Id, sadrzaj.Text);
            var varr = new NoviPodsjetnik(Pacijent,sadrzaj.Text);
            varr.Show();
        }
    }
}
