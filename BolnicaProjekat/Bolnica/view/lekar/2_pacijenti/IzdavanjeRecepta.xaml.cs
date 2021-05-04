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
        public Pacijent IzabraniPacijent { get; set; }
        public ObservableCollection<Recept> Recepti { get; set; }
        public ObservableCollection<Lek> KolekcijaLekovi { get; set; }
        public Lek OdabraniLek { get; set; }
        public Lekar Lekar;
        private view.lekar.pacijenti.PrikazMedicinskiKarton refPrikazMedicinskiKarton;

        public IzdavanjeRecepta(Lekar Lekar,Pacijent IzabraniPacijent)
        {
            this.Lekar = Lekar;
            this.IzabraniPacijent = IzabraniPacijent;
            InitializeComponent();

            Servis.LekoviServis servis = new Servis.LekoviServis();
            KolekcijaLekovi = servis.GetOdobreniLekovi();

            ComboBoxLek.ItemsSource = KolekcijaLekovi;


            headerIme.Text = IzabraniPacijent.Ime;
            headerPrezime.Text = IzabraniPacijent.Prezime;
            headerJMBG.Text = IzabraniPacijent.Jmbg;

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

            OdabraniLek = ComboBoxLek.SelectedItem as Lek;
            string nacin_koriscenja = NacinKorsicenja.Text;
            int idRec = Repozitorijum.ReceptRepozitorijum.GetInstance.GetAll().Count+1;
            int idLekar = Lekar.Id;
            int idPac = IzabraniPacijent.Id;
            int idLeka = OdabraniLek.Id;

            Recept r = new Recept(idRec, idLekar, idPac, idLeka, DatumPropisivanja, DatumPropisivanja, false, nacin_koriscenja);


           // Recept r = new Recept(2,2,1,2, DatumPropisivanja, DatumPropisivanja,false,"po zelji");
            Servis.NotifikacijeServis.ReceptNotifikacija(r,vrijemeUzimanja);
            Servis.ReceptServis.DodajRecept(r);
            //Recepti = new ObservableCollection<Recept>();

        }

        private void PrikazMedicinskiKartonButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(Lekar,IzabraniPacijent);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }

    }
}
