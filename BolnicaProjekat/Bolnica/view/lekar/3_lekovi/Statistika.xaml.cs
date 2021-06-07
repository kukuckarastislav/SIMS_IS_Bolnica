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
using LiveCharts;
using LiveCharts.Wpf;
using Kontroler;
using Model;

namespace Bolnica.view.lekar.lekovi
{

    public partial class Statistika : Page
    {
        private LekoviKontroler RefLekoviKontroler;
        private Lekar Lekar;
        public Statistika(Lekar Lekar)
        {
            InitializeComponent();
            this.Lekar = Lekar;
            RefLekoviKontroler = new LekoviKontroler();
            ChartValues<int> values = new ChartValues<int>();
            double brojOdobrenihLekova = RefLekoviKontroler.BrojOdobrenihLekova();
            double brojNeodobrenihLekova = RefLekoviKontroler.BrojNeOdobrenihLekova();
            double brojLekova = brojOdobrenihLekova + brojNeodobrenihLekova;

            rectNedobrenih.Height *= (brojNeodobrenihLekova / brojLekova);
            rectOdobrenih.Height *= (brojOdobrenihLekova / brojLekova);
            brojOdobrenihLekovatxt.Text = ""+brojOdobrenihLekova;
            brojNeodobrenihLekovatxt.Text = ""+brojNeodobrenihLekova;


            //   values.Add(brojOdobrenihLekova);
            //  values.Add(brojNeodobrenihLekova);
            SeriesCollection ChartData = new SeriesCollection()
            {
            new LineSeries() {  Values = values }
             };
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var refLekovi = new view.lekar.lekovi.Lekovi(Lekar);
            NavigationService.Navigate(refLekovi);
        }
    }
}
