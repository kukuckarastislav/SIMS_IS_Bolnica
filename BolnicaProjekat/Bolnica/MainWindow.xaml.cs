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

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Model.Bolnica bolnica = new Model.Bolnica("Zdravo bolnica","4", Model.Mesto.NoviSad);
            InitializeComponent();
            System.Collections.ArrayList a = Model.Bolnica.GetInstance.GetLekari();

            XmlSerializer serializer = new XmlSerializer(typeof(Model.Bolnica));
            StreamReader reader = new StreamReader("Serialization.xml");
            Model.Bolnica bolnica = (Model.Bolnica)serializer.Deserialize(reader);
            Model.Bolnica.GetInstance = bolnica;
            //Model.Bolnica.GetInstance.SetPacijenti(bolnica.GetPacijenti());
            reader.Close();

          //  Model.RadnoVreme radnoVreme = new Model.RadnoVreme(8.00, 14.00);
           // Model.Lekar l = new Model.Lekar(1, true,Model.Odeljenje.OpstaHirurgija,radnoVreme, Model.RadniStatus.Aktivan,
             // "laslouri99", "sifra123", "Laslo", "Uri", Model.Pol.Musko, "laslou@gmail.com", "066-666-666",
            //  new DateTime(1999, 7, 16), "1111111", "Srpsko", "Novi Sad");
          //  Model.Bolnica.GetInstance.AddLekari(l);
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Model.Bolnica b = Model.Bolnica.GetInstance;
            XmlSerializer xs = new XmlSerializer(typeof(Model.Bolnica));

            TextWriter txtWriter = new StreamWriter("Serialization.xml");

            xs.Serialize(txtWriter, b);

            txtWriter.Close();
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
