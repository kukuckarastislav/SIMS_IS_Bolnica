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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.view.lekar.pacijenti
{
    /// <summary>
    /// Interaction logic for PrikazMedicinskiKarton.xaml
    /// </summary>
    public partial class PrikazMedicinskiKarton : Page
    {
        public ObservableCollection<Pregled> preglediKolekcija { get; set; }
        public System.Collections.ArrayList preglediLista { get; set; }
        public Pacijent IzabraniPacijent { get; set; }
        public PrikazMedicinskiKarton(Model.Pacijent izabranPacijent)
        {
            InitializeComponent();

            this.IzabraniPacijent = izabranPacijent;
            preglediLista = IzabraniPacijent.MedicinskiKarton.GetPregled();
            preglediKolekcija = new ObservableCollection<Pregled>();

            foreach (Pregled p in preglediLista) { preglediKolekcija.Add(p); }
            this.listaPregledaPacijenta.ItemsSource = preglediKolekcija;

            


        }

        public Pacijent GetIzabraniPacijenta { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void listaPregledaPacijenta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Kreiranje_Pregleda(object sender, RoutedEventArgs e)
        {
            var kreiranje_pregleda_forma = new Bolnica.view.lekar.pacijenti.KreiranjePregledaForma(IzabraniPacijent);
            kreiranje_pregleda_forma.Show();
            //  Model.Pregled kreiraniPregled = new Model.Pregled(; 
        }

        private void BrisanjePregleda(object sender, RoutedEventArgs e)
        {
            
            this.IzabraniPacijent.MedicinskiKarton.GetPregled().Remove(listaPregledaPacijenta.SelectedItem as Pregled);
                
        }
    }
}
