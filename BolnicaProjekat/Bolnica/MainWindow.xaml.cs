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
using Model;
using Repozitorijum;
using Kontroler;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
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
            var lekar_home = new Bolnica.view.lekar.LekarHome(Repozitorijum.LekarRepozitorijum.GetInstance.GetById(1));
            lekar_home.Show();
        }

        private void Pacijent_Home_Click(object sender, RoutedEventArgs e)
        {
            var pacijent_home = new Bolnica.view.pacijent.PacijentHome(Repozitorijum.PacijentRepozitorijum.GetInstance.GetById(1));
            pacijent_home.Show();
        }

        private void Prijava_Click(object sender, RoutedEventArgs e)
        {
            SekretarKontroler skontroler = new SekretarKontroler();
            Korisnik k = skontroler.PrijavaSekretara(txbIme.Text, txbLozinka.Text);
            if(k!=null)
            {
                var sekretar_home = new Bolnica.view.sekretar.SekretarHome();
                sekretar_home.Show();
            }
            UpravnikKontroler ukontroler = new UpravnikKontroler();
            k = ukontroler.PrijavaUpravnika(txbIme.Text, txbLozinka.Text);
            if (k != null)
            {
                var upravnik_home = new Bolnica.view.upravnik.UpravnikHome();
                upravnik_home.Show();
            }
            LekarKontroler lkontroler = new LekarKontroler();
            k = lkontroler.PrijavaLekara(txbIme.Text, txbLozinka.Text);
            if (k != null)
            {
                var lekar_home = new Bolnica.view.lekar.LekarHome(Repozitorijum.LekarRepozitorijum.GetInstance.GetById(1));
                lekar_home.Show();
            }
            PacijentKontroler pkontroler = new PacijentKontroler();
            k = pkontroler.PrijavaPacijenta(txbIme.Text, txbLozinka.Text);
            if (k != null)
            {
                var pacijent_home = new Bolnica.view.pacijent.PacijentHome(Repozitorijum.PacijentRepozitorijum.GetInstance.GetById(1));
                pacijent_home.Show();
            }

        }
    }
}
