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
            //Termin termin = new Termin();
            //ZdravstvenaUsluga test = new ZdravstvenaUsluga(termin, 1, 1,1, TipUsluge.Pregled, 1, false, "nebitan", "nebitan");
            //ZdravstvenaUslugaRepozitorijum.GetInstance.DodajUslugu(test);
            //Model.RadnoVreme radnoVreme = new Model.RadnoVreme(8, 14);
            //Lekar l = new Lekar(radnoVreme, RadniStatus.Aktivan, 1, false, "", "LasloUri", "laci", "Laslo",
            //"Uri", Pol.Musko, "laci@gmail.com", "0621010909",new DateTime(1999,10,10),
            //"1234123412341", "madjarsko", "blizu hotela park");
            //LekarRepozitorijum.GetInstance.DodajLekara(l);

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
            var lekar_home = new Bolnica.view.lekar.LekarHome();
            lekar_home.Show();
        }

        private void Pacijent_Home_Click(object sender, RoutedEventArgs e)
        {
            var pacijent_home = new Bolnica.view.pacijent.PacijentHome(Model.Bolnica.GetInstance.GetPacijent("jmbg"));
            pacijent_home.Show();
        }
    }
}
