using Model;
using Repozitorijum;
using Servis;
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

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for WindowZakazivanjeTermina.xaml
    /// </summary>
    public partial class WindowZakazivanjeTermina : Window
    {

        private List<Model.ZdravstvenaUsluga> PreglediList { get; set; }
        private ObservableCollection<ZdravstvenaUsluga> Pregledi { get; set; }
        private ZdravstvenaUsluga odabraniPregled;
        private DateTime date;
        private Lekar OdabraniLekar;

        private ObservableCollection<Model.Lekar> listaLekari;
        private Pacijent pacijent;
        public WindowZakazivanjeTermina(Pacijent pacijent)
        {
            InitializeComponent();
            Pregledi = new ObservableCollection<ZdravstvenaUsluga>();
            DateTime pocetak = new DateTime(2021, 4, 19, 8, 0, 00);
            DateTime kraj = new DateTime(2021, 4, 19, 16, 0, 00);
            PreglediList = ZdravstvenaUslugaServis.getAppointments(LekarRepozitorijum.GetInstance.GetById(1),pocetak,kraj);
            foreach(var usluga in PreglediList)
            {
                Pregledi.Add(usluga);
            }
            this.listaPregleda.ItemsSource = Pregledi;

            listaLekari = Repozitorijum.LekarRepozitorijum.GetInstance.GetAllObs();
            this.ComboBoxLekari.ItemsSource = listaLekari;
            this.pacijent = pacijent;
        }
    }
}
