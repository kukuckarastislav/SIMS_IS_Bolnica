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
    /// Interaction logic for IzdavanjeRecepta.xaml
    /// </summary>
    public partial class IzdavanjeRecepta : Page
    {
        private Pacijent IzabraniPacijent;
        public ObservableCollection<Recept> Recepti;
        public Lek OdabraniLek;
        public IzdavanjeRecepta(Model.Pacijent IzabraniPacijent)
        {
            this.IzabraniPacijent = IzabraniPacijent;
            InitializeComponent();

        }

        private void IzdavanjeReceptaButton(object sender, RoutedEventArgs e)
        {
            int VremeSati = Convert.ToInt32(Vreme_Sati.Text);
            int VremeMinute = Convert.ToInt32(Vreme_Minute.Text);
            string Vreme_AP = Vreme_AM_PM.Text;

            if (Vreme_AP.Equals("PM"))
                VremeSati += 12;



            DateTime vrijemeUzimanja= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, VremeSati, VremeMinute, 00);
            MessageBox.Show(vrijemeUzimanja.ToString());



            DateTime DatumPropisivanja = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            //DateTime DatumIsteka = datum_isteka.SelectedDate.Value; //iz nekog razl ne radi

            // OdabraniLek = ComboBoxLek.SelectedItem as Lek;

            Recept r = new Recept(2,2,1,2, DatumPropisivanja, DatumPropisivanja,false,"po zelji");
            Servis.NotifikacijeServis.ReceptNotifikacija(r,vrijemeUzimanja);

            //Recepti = new ObservableCollection<Recept>();

        }
    }
}
