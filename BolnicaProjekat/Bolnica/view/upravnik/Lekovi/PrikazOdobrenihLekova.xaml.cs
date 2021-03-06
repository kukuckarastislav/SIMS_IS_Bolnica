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
using DTO;
using Kontroler;
using Model;

namespace Bolnica.view.upravnik.Lekovi
{
    /// <summary>
    /// Interaction logic for PrikazOdobrenihLekova.xaml
    /// </summary>
    /// 
    public partial class PrikazOdobrenihLekova : Page
    {
        public ObservableCollection<LekDTO> KolekcijaLekovi { get; set; }
        public LekDTO OdabraniLek { get; set; }

        public LekoviKontroler lekoviKontrolerObjekat;
        public PrikazOdobrenihLekova()
        {
            InitializeComponent();
            lekoviKontrolerObjekat = new LekoviKontroler();
            List<LekDTO> lekoviLista = lekoviKontrolerObjekat.GetOdobreniLekovi();
            KolekcijaLekovi = new ObservableCollection<LekDTO>();
            foreach (LekDTO lek in lekoviLista)
            {
                KolekcijaLekovi.Add(lek);
            }
            this.DataGridPrikazOdobrenihLekova.ItemsSource = KolekcijaLekovi;
        }

        public void AzurirajPrikaz()
        {
            KolekcijaLekovi = new ObservableCollection<LekDTO>();
            List<LekDTO> lekoviLista = lekoviKontrolerObjekat.GetOdobreniLekovi();
            foreach (LekDTO lek in lekoviLista)
            {
                KolekcijaLekovi.Add(lek);
            }
            this.DataGridPrikazOdobrenihLekova.ItemsSource = KolekcijaLekovi;
        }

        public LekDTO GetSelectedLek()
        {
            return (DataGridPrikazOdobrenihLekova.SelectedItem as LekDTO);
        }

        private void DataGridPrikazOdobrenihLekova_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OdabraniLek = DataGridPrikazOdobrenihLekova.SelectedItem as LekDTO;
        }

    }
}
