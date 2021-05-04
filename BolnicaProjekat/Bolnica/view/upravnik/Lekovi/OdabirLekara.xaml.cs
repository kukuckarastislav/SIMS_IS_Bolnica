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

namespace Bolnica.view.upravnik.Lekovi
{
    /// <summary>
    /// Interaction logic for OdabirLekara.xaml
    /// </summary>
    public partial class OdabirLekara : Window
    {
        public Model.Lek Lek { get; set; }
        public ObservableCollection<Model.Lekar> Lekari { get; set; }
        public ObservableCollection<Model.Lekar> OdabraniLekari { get; set; }


        public OdabirLekara(Model.Lek OdabraniLek)
        {
            InitializeComponent();
            Lekari = Repozitorijum.LekarRepozitorijum.GetInstance.GetAllObs();
            this.listaLekara.ItemsSource = Lekari;
            this.Lek = OdabraniLek;
        }

        private void Odustani_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Posalji_Button_Click(object sender, RoutedEventArgs e)
        {
            OdabraniLekari = new ObservableCollection<Model.Lekar>();
            foreach (Model.Lekar l in listaLekara.SelectedItems)
            {
                OdabraniLekari.Add(l);
            }
            Kontroler.LekoviKontroler kontroler = new Kontroler.LekoviKontroler();
            kontroler.PosaljiLekoveNaReviziju(OdabraniLekari, Lek);

            this.Close();
        }
    }
}
