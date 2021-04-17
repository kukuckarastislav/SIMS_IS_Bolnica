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

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Collections.ArrayList a = Model.Bolnica.GetInstance.GetLekari();
            try
            {
                System.Collections.ObjectModel.ObservableCollection < Model.Pacijent >p = JsonSerializer.Deserialize<System.Collections.ObjectModel.ObservableCollection<Model.Pacijent>>(File.ReadAllText("../../Data/sve.txt"));
                Model.Bolnica.GetInstance.SetPacijenti(p);
            }catch(Exception e)
            {
                MessageBox.Show("greska");
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Model.Bolnica b = Model.Bolnica.GetInstance;
  
            var formatiranje = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(b.GetPacijenti(), formatiranje);
            File.WriteAllText("../../Data/sve.txt", jsonString);
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
