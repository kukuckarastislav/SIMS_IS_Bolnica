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
using System.Windows.Shapes;
using Model;
using DTO;
using System.Collections.ObjectModel;
using Controller;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for IstorijaBolesti.xaml
    /// </summary>
    public partial class IstorijaBolesti : Window
    {
        private ObservableCollection<ZdravstvenaUslugaDTO> Lista { get; set; } //koji k
        private ZdravstvenaUslugaKontroler Kontroler { get; set; }
        private Pacijent Pacijent {get; set;}
        public IstorijaBolesti(Pacijent Pacijent)
        {
            Kontroler = new ZdravstvenaUslugaKontroler();
            this.Pacijent = Pacijent;
            InitializeComponent();
            Lista = Kontroler.GetProsliTerminiPacijenta(Pacijent.Id);
            this.listaZavrseniTermini.ItemsSource = Lista;
        }

        private void listaZavrseniTermini_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ZdravstvenaUslugaDTO OdabraniTermin = listaZavrseniTermini.SelectedItem as ZdravstvenaUslugaDTO;
            anamneza.Text = OdabraniTermin.RezultatUsluge;
        }

        private void dodaj_podsjetnik(object sender, RoutedEventArgs e)
        {
            var varr = new NoviPodsjetnik(Pacijent,sadrzaj.Text);
            varr.Show();
        }
    }
}
