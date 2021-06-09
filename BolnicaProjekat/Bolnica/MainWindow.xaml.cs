using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;
using System.Text.Json;
using LiveCharts;
using LiveCharts.Wpf;
using Model;
using DTO;
using Repozitorijum;
using Kontroler;
using Bolnica.Repository;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PacijentDTO PrijavljeniPacijent;

        public MainWindow()
        {
            App.glavniProzor = this;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Sekretar s = new Sekretar(new RadnoVreme(7, 15), RadniStatus.Aktivan, 1);
            //SekretarRepozitorijum.GetInstance.Sekretari.Add(s);
            //SekretarRepozitorijum.GetInstance.SaveData();
            //Upravnik u = new Upravnik(new RadnoVreme(9, 17), RadniStatus.Aktivan, 1);
            //UpravnikRepozitorijum.GetInstance.Upravnici.Add(u);
            //UpravnikRepozitorijum.GetInstance.SaveData();
            
        }

        private void Sekretar_Home_Click(object sender, RoutedEventArgs e)
        {
            var sekretar_home = new Bolnica.view.sekretar.SekretarHome();
            sekretar_home.Show();

        }

        private void Upravnik_Home_Click(object sender, RoutedEventArgs e)
        {
            var upravnik_home = new Bolnica.view.upravnik.UpravnikHome();
            upravnik_home.Show();
        }

        private void Lekar_Home_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pacijent_Home_Click(object sender, RoutedEventArgs e)
        {
            var pacijent_home = new Bolnica.view.pacijent.PacijentHome(PrijavljeniPacijent);
            pacijent_home.Show();
        }

        private void Prijava_Click(object sender, RoutedEventArgs e)
        {
            SekretarKontroler skontroler = new SekretarKontroler();
            Sekretar s = skontroler.PrijavaSekretara(txbIme.Text, txbLozinka.Password);
            if (s != null)
            {
                App.IdUlogovanogKorisnika = s.Id;
                App.ulogovaniKorisnik = s;
                var sekretar_home = new Bolnica.view.sekretar.SekretarHome();
                App.stranicaSekretara = sekretar_home;
                sekretar_home.Show();
            }
            UpravnikKontroler ukontroler = new UpravnikKontroler();
            Upravnik u = ukontroler.PrijavaUpravnika(txbIme.Text, txbLozinka.Password);
            if (u != null)
            {
                App.IdUlogovanogKorisnika = u.Id;
                App.ulogovaniKorisnik = u;
                var upravnik_home = new Bolnica.view.upravnik.UpravnikHome();
                upravnik_home.Show();
            }
            LekarKontroler lkontroler = new LekarKontroler();
            LekarDTO lekar = lkontroler.PrijavaLekara(txbIme.Text, txbLozinka.Password);
            if (lekar != null)
            {
                App.IdUlogovanogKorisnika = lekar.Id;
                //App.ulogovaniKorisnik = lekar;
                var lekar_home = new Bolnica.view.lekar.LekarHome(lekar);
                lekar_home.Show();
            }
            PacijentKontroler pkontroler = new PacijentKontroler();
            PrijavljeniPacijent = pkontroler.PrijavaPacijenta(txbIme.Text, txbLozinka.Password);
            if (PrijavljeniPacijent != null)
            {
                //App.ulogovaniKorisnik = lekar;
                App.IdUlogovanogKorisnika = PrijavljeniPacijent.Id;
                var pacijent_home = new Bolnica.view.pacijent.PacijentHome(PrijavljeniPacijent);
                pacijent_home.Show();
            }

        }

        public void resetLogin()
        {
            txbIme.Text = "";
            txbLozinka.Password = "";
        }

    }
}
